using System;
using System.Text;
using Binarysharp.MemoryManagement.Internals;

namespace FragmentJamella.Memory
{
    public interface IMemoryManagement
    {
        
        public string ReadString(IntPtr address, Encoding encoding, bool isRelative = true, int maxLength = 512);
        public T Read<T>(IntPtr address, bool isRelative = true);
        public void WriteString(IntPtr address, string text, Encoding encoding, bool isRelative = true);
        public void Write<T>(IntPtr address, T value, bool isRelative = true);
    }
}