FROM mcr.microsoft.com/devcontainers/dotnet AS build
RUN sudo apt-get update && sudo apt-get install gnupg2 -y
RUN install -d -m 700 -o vscode -g vscode /home/vscode/.gnupg
