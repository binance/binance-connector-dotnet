#!/bin/sh
set -eu

cd "$(dirname "$0")/.."
version_of() { sed -n "s:.*== '$1'\">\([^<]*\)</Version>.*:\1:p" Versions.props; }

common=$(version_of Binance.Common)
target=${1:-$common}
if [ -z "$common" ] || [ "$target" != "$common" ]; then
    echo "Binance.Common is ${common:-missing} in Versions.props, not $target: bump it there (and in its changelog) first." >&2
    exit 1
fi

today=$(date -u +%Y-%m-%d)
for id in $(sed -n "s:.*== '\([^']*\)'\">.*:\1:p" Versions.props); do
    [ "$id" = Binance.Common ] && continue
    current=$(version_of "$id")
    changelog="src/$id/CHANGELOG.md"
    
    if awk '/^## /{n++} n == 1' "$changelog" | grep -q "Depends on \`Binance.Common\` \`$target\`"; then
        echo "$id $current already depends on Binance.Common $target"
        continue
    fi
    
    new=$(echo "$current" | awk -F. '{ printf "%d.%d.%d", $1, $2, $3 + 1 }')
    sed -i.bak -E "s#(== '$id'\">)[^<]*(</Version>)#\\1$new\\2#" Versions.props && rm -f Versions.props.bak
    awk -v entry="## $new - $today" -v line="- Depends on \`Binance.Common\` \`$target\`." \
        'NR == 1 { print; print ""; print entry; print ""; print "### Changed (1)"; print ""; print line; next } { print }' \
        "$changelog" > "$changelog.tmp" && mv "$changelog.tmp" "$changelog"
    
    echo "$id $current -> $new"
done
