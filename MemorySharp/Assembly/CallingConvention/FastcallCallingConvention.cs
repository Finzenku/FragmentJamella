﻿/*
 * MemorySharp Library
 * http://www.binarysharp.com/
 *
 * Copyright (C) 2012-2016 Jämes Ménétrey (a.k.a. ZenLulz).
 * This library is released under the MIT License.
 * See the file LICENSE for more information.
*/
using System;
using System.Collections.Generic;
using System.Text;

namespace Binarysharp.MemoryManagement.Assembly.CallingConvention
{
    /// <summary>
    /// Define the Fast Calling Convention (aka __msfastcall).
    /// </summary>
    public class FastcallCallingConvention : ICallingConvention
    {
        /// <summary>
        /// The name of the calling convention.
        /// </summary>
        public string Name
        {
            get { return "Fastcall"; }
        }
        /// <summary>
        /// Defines which function performs the clean-up task.
        /// </summary>
        public CleanupTypes Cleanup
        {
            get { return CleanupTypes.Callee; }
        }
        /// <summary>
        /// Formats the given parameters to call a function.
        /// </summary>
        /// <param name="parameters">An array of parameters.</param>
        /// <returns>The mnemonics to pass the parameters.</returns>
        public string FormatParameters(IntPtr[] parameters)
        {
            // Declare a var to store the mnemonics
            var ret = new StringBuilder();
            var paramList = new List<IntPtr>(parameters);
            // Store the first parameter in the ECX register
            if (paramList.Count > 0)
            {
                ret.AppendLine("mov ecx, " + paramList[0]);
                paramList.RemoveAt(0);
            }
            // Store the second parameter in the EDX register
            if (paramList.Count > 0)
            {
                ret.AppendLine("mov edx, " + paramList[0]);
                paramList.RemoveAt(0);
            }
            // For each parameters (in reverse order)
            paramList.Reverse();
            foreach (var parameter in paramList)
            {
                ret.AppendLine("push " + parameter);
            }
            // Return the mnemonics
            return ret.ToString();
        }
        /// <summary>
        /// Formats the call of a given function.
        /// </summary>
        /// <param name="function">The function to call.</param>
        /// <returns>The mnemonics to call the function.</returns>
        public string FormatCalling(IntPtr function)
        {
            return "call " + function;
        }
        /// <summary>
        /// Formats the cleaning of a given number of parameters.
        /// </summary>
        /// <param name="nbParameters">The number of parameters to clean.</param>
        /// <returns>The mnemonics to clean a given number of parameters.</returns>
        public string FormatCleaning(int nbParameters)
        {
            return String.Empty;
        }
    }
}
