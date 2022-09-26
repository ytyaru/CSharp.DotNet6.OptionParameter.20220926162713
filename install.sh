#!/usr/bin/env bash
set -Ceu
#---------------------------------------------------------------------------
# ラズパイにdotnet6をインストールする。
# CreatedAt: 2022-09-26
#---------------------------------------------------------------------------
Run() {
	THIS="$(realpath "${BASH_SOURCE:-0}")"; HERE="$(dirname "$THIS")"; PARENT="$(dirname "$HERE")"; THIS_NAME="$(basename "$THIS")"; APP_ROOT="$PARENT";
	cd "$HERE"

	VER=6.0.401
	NAME=dotnet-sdk-$VER-linux-arm.tar.gz
	wget https://download.visualstudio.microsoft.com/download/pr/451f282f-dd26-4acd-9395-36cc3a9758e4/f5399d2ebced2ad9640db6283aa9d714/$NAME
	INS_PATH=$HERE/.NET/$VER
	mkdir -p $INS_PATH
	tar -zxvf $NAME -C $INS_PATH
	export PATH=$PATH:$INS_PATH
}
Run "$@"
