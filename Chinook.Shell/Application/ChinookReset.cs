using Chinook.Application;
using Chinook.Persistence;
using EasyLOB;
using EasyLOB.Library;
using System;

namespace Chinook.Shell
{
    partial class Program
    {
        private static void ApplicationChinookReset()
        {
            Console.WriteLine("\nApplication Chinook RESET");

            ZOperationResult operationResult = new ZOperationResult();
            IChinookUnitOfWork unitOfWork = DIHelper.GetService<IChinookUnitOfWork>();
            IChinookApplication application = DIHelper.GetService<IChinookApplication>();
            application.Reset(operationResult, unitOfWork);

            if (!operationResult.Ok)
            {
                Console.WriteLine("\n");
                Console.WriteLine(operationResult.Text);
            }
        }
    }
}