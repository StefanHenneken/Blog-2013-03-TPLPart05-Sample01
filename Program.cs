using System;
using System.Threading;

namespace Sample01
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            Console.WriteLine("Start Run");
            try
            {
                Thread t = new Thread(Do);
                t.IsBackground = true;
                t.Start();
                t.Join();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Run: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("End Run");
                Console.ReadLine();
            }            
        }
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine("Unhandled Exception: " + ((Exception)e.ExceptionObject).Message);
            Console.ReadLine();
            Environment.Exit(0);
        }
        static public void Do()
        {
            Console.WriteLine("Start Do");
            Thread.Sleep(1000);
            int a = 1;
            a = a / --a;
            Console.WriteLine("End Do");
        }
    }
}
