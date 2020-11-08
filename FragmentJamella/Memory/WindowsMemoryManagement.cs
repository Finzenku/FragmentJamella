using System;
using System.Diagnostics;
using System.Text;
using Binarysharp.MemoryManagement;

namespace FragmentJamella.Memory
{
    public class WindowsMemoryManagement : IMemoryManagement
    {
        private MemorySharp m;

        public WindowsMemoryManagement(Process process)
        {
            m = new MemorySharp(process);
        }

        public string ReadString(IntPtr address, Encoding encoding, bool isRelative = true, int maxLength = 512)
        {
            return m.ReadString(address, encoding, isRelative, maxLength);
        }

        public T Read<T>(IntPtr address, bool isRelative = true)
        {
            return m.Read<T>(address, isRelative);
        }

        public void WriteString(IntPtr address, string text, Encoding encoding, bool isRelative = true)
        {
            m.WriteString(address,text,encoding,isRelative);
        }

        public void Write<T>(IntPtr address, T value, bool isRelative = true)
        {
            m.Write<T>(address,value,isRelative);
        }
    }
}