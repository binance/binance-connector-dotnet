#!/bin/sh
set -eu

cd "${1:-$(dirname "$0")/..}"
{
    echo '# Connectors'
    echo
    echo 'One NuGet package per Binance product. Each one depends on `Binance.Common`, which brings the platform library.'
    echo
    echo '| Package | Description |'
    echo '| --- | --- |'
    for project in $(find src -mindepth 2 -maxdepth 2 -name 'Binance.*.csproj' | LC_ALL=C sort); do
        name=$(basename "$project" .csproj)
        case "$name" in Binance.Common*) continue ;; esac
        description=$(sed -n 's:.*<Description>\(.*\)</Description>.*:\1:p' "$project" | head -n 1)
        echo "| [$name](../src/$name/README.md) | $description |"
    done
} > docs/connectors.md.tmp
mv docs/connectors.md.tmp docs/connectors.md
