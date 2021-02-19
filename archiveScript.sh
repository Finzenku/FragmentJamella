#bin/bash

#if [ -d "SimpleLinuxMemoryAccess" ]; then rm -Rf SimpleLinuxMemoryAccess; fi
if [ -d "builds" ]; then rm -Rf builds; fi

#git clone https://github.com/Zackmon/SimpleLinuxMemoryAccess.git
mkdir builds

#cd SimpleLinuxMemoryAccess

#cmake .
#make
#cp libSimpleLinuxMemoryAccess.so ../FragmentJamella/Memory/

#cd ..



#msbuild -t:restore
#cd ../


#msbuild -property:Configuration=Release
#dotnet restore
#dotnet build -c Release
#cd FragmentJamella
#dotnet publish -r win-x64 -p:PublishSingleFile=true --self-contained true -c Release
#dotnet publish -r linux-x64 -p:PublishSingleFile=true --self-contained true -c Release

cd builds

mkdir linux-x64
mkdir win-x64

cp -a ../FragmentJamella/bin/Release/netcoreapp3.1/win-x64/publish/ win-x64/
cp -a ../FragmentJamella/bin/Release/netcoreapp3.1/linux-x64/publish/ linux-x64/

zip -r -j fragment-jamella-win-x64.zip win-x64/*
zip -r -j fragment-jamella-linux-x64.zip linux-x64/*

rm -Rf win-x64
rm -Rf linux-x64