using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using Binarysharp.MemoryManagement.Internals;

namespace FragmentJamella.Memory
{
    public class LinuxMemoryManagement : IMemoryManagement
    {
        private Process p;
        
       // [DllImport("libSimpleLinuxMemoryAccess.so")]
        public static extern IntPtr ReadMemory(int pid, IntPtr address, int maxLenght);
        
       // [DllImport("libSimpleLinuxMemoryAccess.so")]
        public static extern void WriteMemory(int pid, IntPtr address, byte[] value, int valueSize);
        
       // [DllImport("libSimpleLinuxMemoryAccess.so")]
        public static extern IntPtr freeingMemory(IntPtr address);
        
        [DllImport ("libc")]
        public static extern uint getuid ();
        
        public LinuxMemoryManagement(Process  process)
        {
            p = process;
            AppDomain.CurrentDomain.AssemblyResolve+= new ResolveEventHandler(CurrentDomain_AssemblyResolve);
        }

        public string ReadString(IntPtr address, Encoding encoding, bool isRelative = true, int maxLength = 512)
        {
            
            IntPtr value = ReadMemory(p.Id, address,maxLength);
            byte[] byteValue = new byte[maxLength];
            Marshal.Copy(value, byteValue, 0, maxLength);
            string encoded = encoding.GetString(byteValue);

            freeingMemory(value);

            return encoded;
            
        }

        public T Read<T>(IntPtr address, bool isRelative = true)
        {
            IntPtr value = ReadMemory(p.Id, address,MarshalType<T>.Size);
           // Console.WriteLine("Returned Data " + value);
           
            T temp = Marshal.PtrToStructure<T>(value);

            freeingMemory(value);
            return temp;
        }

        public void WriteString(IntPtr address, string text, Encoding encoding, bool isRelative = true)
        {
            byte[] value = encoding.GetBytes(text);
            WriteMemory(p.Id,address,value,value.Length);
        }

        public void Write<T>(IntPtr address, T value, bool isRelative = true)
        {
            byte[] byteValue = MarshalType<T>.ObjectToByteArray(value);
            WriteMemory(p.Id,address,byteValue,byteValue.Length);
        }


        public static uint checkPrivileges()
        {
            return getuid();
        }


        private static System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            using (var stream = System.Reflection.Assembly.GetExecutingAssembly()
                .GetManifestResourceStream(typeof(LinuxMemoryManagement).Namespace + ".libSimpleLinuxMemoryAccess.so"))
            {
                byte[] data = new byte[stream.Length];
                stream.Read(data, 0, data.Length);
                return System.Reflection.Assembly.Load(data);
            }
        }
    }
}