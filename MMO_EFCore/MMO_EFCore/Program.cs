
using Microsoft.EntityFrameworkCore;
using System;

namespace MMO_EFCore
{
    class Program
    {
        [DbFunction()]
        public static double? GetAverageReviewScore(int ItemId)
        {
            throw new NotImplementedException("Don't Use!");
        }
        static void Main(string[] args)
        {
            DbCommands.InitializeDB(forceReset: true);

            Console.WriteLine("Input Your Message");
            Console.WriteLine("[0] Force Reset");
            Console.WriteLine("[1] ReadAll");
            Console.WriteLine("[2] UpdateDate");
            Console.WriteLine("[3] DeleteItem");
            Console.WriteLine("[4] ShowItems");
            Console.WriteLine("[5] Eager Loading");
            Console.WriteLine("[6] Explicit Loading");
            Console.WriteLine("[7] Select Loading");
            Console.WriteLine("[8] Update Test");
            Console.WriteLine("[9] Update (Reload)");
            Console.WriteLine("[10] Update (Full)");
            Console.WriteLine("[11] Test");
            Console.WriteLine("[12] Update 1v1");
            Console.WriteLine("[13] Update 1vN");
            Console.WriteLine("[14] Test Delete");
            Console.WriteLine("[15] Test Owned type");
            Console.WriteLine("[16] Test TPH");
            Console.WriteLine("[17] Test Table Split");
            Console.WriteLine("[18] Test Backing Field");
            Console.WriteLine("[19] CalcAberage");
            Console.WriteLine("[20] Test Update Attach");
            Console.WriteLine("[21] State Control");
            Console.WriteLine("[22] Call SQL");

            while (true)
            {
                Console.Write("> ");
                string command = Console.ReadLine();
                switch (command)
                {
                    case "0":
                        DbCommands.InitializeDB(forceReset: true);
                        break;
                    case "1":
                        DbCommands.ReadAll();
                        break;
                    case "2":
                        //DbCommands.UpdateDate();
                        break;
                    case "3":
                        DbCommands.DeleteItem();
                        break;
                    case "4":
                        DbCommands.ShowItems();
                        break;
                    case "5":
                        //DbCommands.EagerLoading();
                        break;
                    case "6":
                        //DbCommands.ExplicitLoading();
                        break;
                    case "7":
                        DbCommands.SelectLoading();
                        break;
                    case "8":
                        DbCommands.UpdateTest();
                        break;
                    case "9":
                        DbCommands.UpdateByReload();
                        break;
                    case "10":
                        DbCommands.UpdateByFull();
                        break;
                    case "11":
                        //DbCommands.Test();
                        break;
                    case "12":
                        //DbCommands.Update_1v1();
                        break;
                    case "13":
                        DbCommands.Update_1vN();
                        break;
                    case "14":
                        DbCommands.TestDelete();
                        break;
                    case "15":
                        DbCommands.ShowItem();
                        break;
                    case "16":
                        DbCommands.ShowItem();
                        break;
                    case "17":
                        DbCommands.ShowItem();
                        break;
                    case "18":
                        DbCommands.ShowItem();
                        break;
                    case "19":
                        DbCommands.CalcAverage();
                        break;
                    case "20":
                        DbCommands.TestUpdateAttach();
                        break;
                    case "21":
                        DbCommands.StateControl();
                        break;
                    case "22":
                        DbCommands.CallSQL();
                        break;
                }
            }
            
        }
    }
}
