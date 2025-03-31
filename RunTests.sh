#!/bin/bash
echo "running tests"


if [ -d "windows" ]; then
    rm -rf "windows"
    echo "windows has been completely removed."
else
    echo "Directory  does not exist: windows"
fi

if [ -d "shared" ]; then
    rm -rf "shared"
    echo "shared has been completely removed."
else
    echo "Directory does not exist: /shared"
fi
mkdir shared

echo "starting docker"
docker compose up -d

TIMEOUT=$((60 * 60))
SECONDS=0

echo "Waiting for docker test to finish"
until [ -f "shared/fin" ] || (( SECONDS >= TIMEOUT )); do sleep 1;  done


docker compose down


