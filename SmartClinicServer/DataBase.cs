using System;
using System.IO;

namespace SmartClinicServer
{
    public static class DataBase
    {
        public static string GetServerIP()
        {
            return File.ReadAllText("ServerIP.txt");
        }

        public static string ReadConfigFileDB()
        {
            return File.ReadAllText("SQLDB.txt");
        }

        public static string ReadConfigFileForCreationDB()
        {
            return File.ReadAllText("SQLDBCreate.txt");
        }

        public static string CheckConnection(int commandTimeout = 30)
        {
            return SQL.TableToOneString
                (SQL.SelectTransaction
                (SQL.CheckConnection(),
                ReadConfigFileForCreationDB(),
                commandTimeout)).Split('\t')[0];
        }

        public static int GetNumberOfUserDB(int commandTimeout = 30)
        {
            return Convert.ToInt32
                (SQL.TableToOneString
                (SQL.SelectTransaction
                (SQL.GetNumberOfUserDB(),
                ReadConfigFileForCreationDB(),
                commandTimeout)).Split('\t')[0]);
        }

        public static int CheckDataBase(int commandTimeout = 30)
        {
            return SQL.EditTransaction
                (SQL.CheckDataBase(),
                ReadConfigFileForCreationDB(),
                commandTimeout);
        }

        public static int GetNumberOfUserTables(int commandTimeout = 30)
        {
            return Convert.ToInt32
                    (SQL.TableToOneString
                    (SQL.SelectTransaction
                    (SQL.GetNumberOfUserTables(),
                    ReadConfigFileForCreationDB(),
                    commandTimeout)).Split('\t')[0]);
        }

        public static int CheckTables(int commandTimeout = 30)
        {
            return SQL.EditTransaction
                (SQL.CheckTables(),
                ReadConfigFileForCreationDB(),
                commandTimeout);
        }

        public static string Check()
        {
            int smallTimeOut = 1;

            string resultOfCheckDB =
                CheckConnection(smallTimeOut) + "\n";

            if (string.Equals(resultOfCheckDB, "TEST\n"))
            {
                resultOfCheckDB =
                    "Соединение с сервером успешно установлено\n";

                int NumberOfUserDBBeforeCreate =
                    GetNumberOfUserDB(smallTimeOut);

                CheckDataBase(smallTimeOut);

                int NumberOfСreatedUserDB =
                    GetNumberOfUserDB(smallTimeOut) -
                    NumberOfUserDBBeforeCreate;

                resultOfCheckDB +=
                    $"Колличество созданных БД (при необходимости): {NumberOfСreatedUserDB}\n";

                int NumberOfUserTablesBeforeCreate =
                    GetNumberOfUserTables(smallTimeOut);

                CheckTables(smallTimeOut);

                int NumberOfСreatedUserTables =
                    GetNumberOfUserTables(smallTimeOut) -
                    NumberOfUserTablesBeforeCreate;

                resultOfCheckDB +=
                    $"Колличество созданных Талбиц (при необходимости): {NumberOfСreatedUserTables}\n";

                return resultOfCheckDB;
            }

            return resultOfCheckDB;
        }
    }
}