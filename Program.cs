using System;
using System.IO;

namespace TripleDes
{
    class Program
    {
        static void Main(string[] args)
        {



            Console.WriteLine(Des.Encrypt("041350A98789ABCD"));

          

            Console.WriteLine(" Bank Code ");



            Console.WriteLine(BranchCode.GetBranchName("001"));




        }
    }
}
