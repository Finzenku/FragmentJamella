#bin/bash

curl -o nuget.exe https://dist.nuget.org/win-x86-commandline/latest/nuget.exe

mono nuget.exe restore FragmentJamella.sln


if [ -d "SimpleLinuxMemoryAccess" ]; then rm -Rf SimpleLinuxMemoryAccess; fi
if [ -d "builds" ]; then rm -Rf builds; fi

git clone https://github.com/Zackmon/SimpleLinuxMemoryAccess.git
mkdir builds

cd SimpleLinuxMemoryAccess

cmake .
make
cp libMemoryManagement.so ../FragmentJamella/LinuxLibraries/

cd ..



msbuild -property:Configuration=Release

cd FragmentJamella/bin/Release/

#Ubuntu 32
monoRuntimeName=mono-6.8.0-ubuntu-16.04-x86
mkbundle --fetch-target $monoRuntimeName
mkbundle -o ../../../builds/FragmentJamella-$monoRuntimeName --cross $monoRuntimeName FragmentJamella.exe --library libSimpleLinuxMemoryAccess,../../../SimpleLinuxMemoryAccess/libSimpleLinuxMemoryAccess.so --machine-config /etc/mono/4.5/machine.config --no-config


#Ubuntu 64
monoRuntimeName=mono-6.8.0-ubuntu-16.04-x64
mkbundle --fetch-target $monoRuntimeName
mkbundle -o ../../../builds/FragmentJamella-$monoRuntimeName --cross $monoRuntimeName FragmentJamella.exe --library libSimpleLinuxMemoryAccess,../../../SimpleLinuxMemoryAccess/libSimpleLinuxMemoryAccess.so --machine-config /etc/mono/4.5/machine.config --no-config



#debian 32
monoRuntimeName=mono-6.8.0-debian-10-x86
mkbundle --fetch-target $monoRuntimeName
mkbundle -o ../../../builds/FragmentJamella-$monoRuntimeName --cross $monoRuntimeName FragmentJamella.exe --library libSimpleLinuxMemoryAccess,../../../SimpleLinuxMemoryAccess/libSimpleLinuxMemoryAccess.so --machine-config /etc/mono/4.5/machine.config --no-config

#debian 64
monoRuntimeName=mono-6.8.0-debian-10-x64
mkbundle --fetch-target $monoRuntimeName
mkbundle -o ../../../builds/FragmentJamella-$monoRuntimeName --cross $monoRuntimeName FragmentJamella.exe --library libSimpleLinuxMemoryAccess,../../../SimpleLinuxMemoryAccess/libSimpleLinuxMemoryAccess.so --machine-config /etc/mono/4.5/machine.config --no-config

if [ -f "FragmentJamella.Windows.zip" ]; then rm - FragmentJamella.Windows.zip; fi

zip -r FragmentJamella.Windows.zip .

cp FragmentJamella.Windows.zip ../../../builds/

cd ../../../