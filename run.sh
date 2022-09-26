#!/usr/bin/env bash
set -Ceu
#---------------------------------------------------------------------------
# にdotnet6でHelloWorldする。
# CreatedAt: 2022-09-26
#---------------------------------------------------------------------------
Run() {
	THIS="$(realpath "${BASH_SOURCE:-0}")"; HERE="$(dirname "$THIS")"; PARENT="$(dirname "$HERE")"; THIS_NAME="$(basename "$THIS")"; APP_ROOT="$PARENT";
	cd "$HERE"

	NAME=MyApp
	dotnet new console -o $NAME -f net6.0
	cd $NAME
	dotnet run
}
Run "$@"
