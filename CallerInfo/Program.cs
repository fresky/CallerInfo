using System;
using System.Runtime.CompilerServices;

namespace CallerInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            Caller caller = new Caller();
            caller.DoSomthing();
            caller.UseReflaction();
        }
    }

    class Caller
    {
        public void DoSomthing()
        {
            Callee.Trace();
        }

        public void UseReflaction()
        {
            Callee.TraceByReflection(System.Reflection.MethodBase.GetCurrentMethod().Name);
        }
 
    }

    class Callee
    {
        public static void Trace([CallerMemberName] string callerName = "", [CallerLineNumber] int lineNumber = -1, [CallerFilePathAttribute] string filePath = "")
        {
            Console.WriteLine("Trace by CallerInfo:");
            Console.WriteLine(string.Format("Caller Method Name: {0}", callerName));
            Console.WriteLine(string.Format("Caller Line Number: {0}", lineNumber));
            Console.WriteLine(string.Format("Caller File Path: {0}", filePath));
        }
        public static void TraceByReflection(string method)
        {
            Console.WriteLine("Trace by Reflection:");
            Console.WriteLine(string.Format("Caller method: {0}", method));
        }
    }
}
