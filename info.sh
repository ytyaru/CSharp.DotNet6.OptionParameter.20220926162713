#!/usr/bin/env bash
set -Ceu
#---------------------------------------------------------------------------
# dotnet6の情報を表示する。
# CreatedAt: 2022-09-26
#---------------------------------------------------------------------------
Run() {
	THIS="$(realpath "${BASH_SOURCE:-0}")"; HERE="$(dirname "$THIS")"; PARENT="$(dirname "$HERE")"; THIS_NAME="$(basename "$THIS")"; APP_ROOT="$PARENT";
	cd "$HERE"
	dotnet --version
	dotnet --help
	dotnet new --list
}
Run "$@"
