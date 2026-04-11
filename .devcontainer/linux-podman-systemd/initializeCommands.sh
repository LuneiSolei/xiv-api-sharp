#!/bin/bash

mkdir -p "${1}/tmp"
gpg --export > "${1}/tmp/pubkeys.gpg"

if [ -z "${XDG_RUNTIME_DIR}" ]; then
    echo "Error: Environment variable, 'XDG_RUNTIME_DIR', is not set. GPG agent forwarding will not work."
    exit 1
fi

if [ ! -S "${XDG_RUNTIME_DIR}/gnupg/S.gpg-agent.extra" ]; then
    echo "Error: GPG extra socket not found at ${XDG_RUNTIME_DIR}/gnupg/S.gpg-agent.extra"
    exit 1
fi