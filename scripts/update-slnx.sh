#!/bin/sh
# Writes Binance.slnx with every project of src/, examples/ and tests/, in a solution folder of the same name.
# The file is rewritten from the projects on disk, so running it twice changes nothing, a removed project drops out, and
# the result does not depend on how a .NET SDK version merges solution folders (`dotnet sln add` can duplicate them).
# Usage: scripts/update-slnx.sh [repository directory; default: the parent of scripts/]
set -eu

cd "${1:-$(dirname "$0")/..}"
{
    echo '<Solution>'
    for folder in src examples tests; do
        projects=$(find "$folder" -mindepth 2 -maxdepth 2 -name '*.csproj' 2>/dev/null | LC_ALL=C sort)
        [ -n "$projects" ] || continue
        echo "  <Folder Name=\"/$folder/\">"
        for project in $projects; do
            echo "    <Project Path=\"$project\" />"
        done
        echo '  </Folder>'
    done
    echo '</Solution>'
} > Binance.slnx.tmp
mv Binance.slnx.tmp Binance.slnx
