﻿using System;
using System.Collections.Generic;
using System.IO;
using HavokScriptToolsCommon;

namespace HavokScriptDisassembler
{
    class Program
    {
        const string usage = "usage: hksdisasm <filename>";
        static bool ParseArgs(string[] args, out string infilename, out string outfilename)
        {
            infilename = null;
            outfilename = "hksdisasm.out";
            if (args.Length != 1 && args.Length != 2)
            {
                Console.Error.WriteLine(usage);
                return false;
            }

            infilename = args[0];
            if (args.Length == 2)
            {
                outfilename = args[1];
            }
            return true;
        }
        static int Main(string[] args)
        {
            if (!ParseArgs(args, out string infilename, out string outfilename))
            {
                return 1;
            }
            byte[] data = File.ReadAllBytes(infilename);
            var disassembler = new HksDisassembler(data);
            disassembler.Disassemble(outfilename);
            return 0;
        }
    }
}
