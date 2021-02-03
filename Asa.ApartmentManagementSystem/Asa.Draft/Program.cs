using Asa.ApartmentSystem.ApplicationService;
using System;
using System.Configuration;
using System.Threading;
using System.Threading.Tasks;

namespace Asa.Draft
{
    class Program
    {


        static AutoResetEvent autoResetEvent;
        static async Task Main(string[] args)
        {
            //autoResetEvent = new AutoResetEvent(false);
            //Console.WriteLine("Hello World!");

            ////Thread myWorker1 = new Thread(() => DoMyFirstJob());
            ////myWorker1Start();

            ////Thread myWorker2 = new Thread(() => DoMySecondJob());
            ////myWorker2.Start();

            //Console.WriteLine($"Main thread id { Thread.CurrentThread.ManagedThreadId} ");

            //var task1 = Task.Run(DoMyFirstJob);
            //var task2 = Task.Run(DoMySecondJob);
            //await Task.WhenAll(task1, task2);

            var connectionString = ConfigurationManager.ConnectionStrings["AppartmentManagementCNX"].ConnectionString;

            var baseInfoService = new BaseInfoApplicationService(connectionString);
            var units = await baseInfoService.GetAllOwnerTenantByUnitId(1);
            Console.WriteLine("Done");
            Console.ReadLine();
        }

        private static void DoMyFirstJob()
        {
            for (int i = 0; i < 100; i++)
            {
                autoResetEvent.WaitOne();
                Console.WriteLine($"{ Thread.CurrentThread.ManagedThreadId} This is item # {i}");
                autoResetEvent.Set();
            }
        }

        private static void DoMySecondJob()
        {
            autoResetEvent.Set();
            for (int i = 101; i < 200; i++)
            {
                autoResetEvent.Set();
                Console.WriteLine($"{ Thread.CurrentThread.ManagedThreadId}  =====> # {i}");
                autoResetEvent.WaitOne();
            }
        }
    }
}
