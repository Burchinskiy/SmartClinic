using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace SmartClinicServer
{
    public static class SQL
    {
        public static DataTable SelectTransaction(string sqlCommand, string pathToDataBase, int commandTimeout = 30)
        {
            using (var mySQLConnection = new SqlConnection(pathToDataBase))
            {
                using (var mySQLDataAdapter = new SqlDataAdapter(sqlCommand, mySQLConnection))
                {
                    using (var myDataSet = new DataSet())
                    {
                        mySQLDataAdapter.SelectCommand.CommandTimeout = commandTimeout;
                        var dataTable = new DataTable();

                        try
                        {
                            mySQLDataAdapter.Fill(myDataSet);
                            return myDataSet.Tables[0];
                        }
                        catch (Exception exception)
                        {
                            dataTable.Columns.Add();
                            dataTable.Rows.Add(exception.Message);
                            return dataTable;
                        }
                    }
                }
            }
        }

        public static int EditTransaction(string sqlCommand, string sqlConnection, int commandTimeout = 30)
        {
            using (var mySqlConnection = new SqlConnection(sqlConnection))
            {
                using (var mySqlCommand = new SqlCommand(sqlCommand, mySqlConnection))
                {
                    mySqlCommand.CommandTimeout = commandTimeout;
                    var commit = 0;

                    try
                    {
                        mySqlConnection.Open();
                        commit = mySqlCommand.ExecuteNonQuery();
                        return commit;
                    }
                    catch { }

                    return commit;
                }
            }
        }

        public static string TableToOneString(DataTable table)
        {
            var result = string.Empty;

            var resultList = table.Select().Select(dr => dr.ItemArray.Select(x => x.ToString()).ToArray()).ToList();

            foreach (var row in resultList)
            {
                foreach (var cell in row)
                {
                    result += cell + "\t";
                }
                result += "\n";
            }
            return result;
        }

        public static string GetFirstCell(DataTable dataTable)
        {
            return TableToOneString(dataTable).Split('\t')[0];
        }

        public static string CheckConnection()
        {
            return "SELECT 'TEST';";
        }

        public static string GetNumberOfUserDB()
        {
            return "SELECT count(*) FROM sys.databases WHERE owner_sid != CHAR(0x01)";
        }

        public static string CheckDataBase()
        {
            return "IF(DB_ID('Clinic') IS NULL) CREATE DATABASE Clinic;";
        }

        public static string GetNumberOfUserTables()
        {
            return "USE Clinic SELECT COUNT(*) FROM sys.objects WHERE type in (N'U')";
        }


        public static string CheckTables()
        {
            string createTableAssignment =
                "USE Clinic " +
                "IF OBJECT_ID('Assignment') IS NULL " +
                "CREATE TABLE[dbo].[Assignment](" +
                "[id][int] IDENTITY(1,1) NOT NULL," +
                "[id_ticket] [int] NOT NULL," +
                "[id_patient] [int] NOT NULL," +
                "[id_schedule] [int] NOT NULL)";

            string createTablePatients =
                "IF OBJECT_ID('Patients') IS NULL " +
                "CREATE TABLE[dbo].[Patients](" +
                "[id][int] IDENTITY(1,1) NOT NULL," +
                "[passport] [varchar] (10) NOT NULL," +
                "[last_name] [varchar] (50) NOT NULL," +
                "[first_name] [varchar] (50) NOT NULL," +
                "[patronymic] [varchar] (50) NOT NULL," +
                "[birthdate] [date] NOT NULL)";

            string createTableSchedule =
                "IF OBJECT_ID('Schedule') IS NULL " +
                "CREATE TABLE[dbo].[Schedule](" +
                "[id][int] IDENTITY(1,1) NOT NULL," +
                "[staff_id] [int] NOT NULL," +
                "[visit_start_time] [datetime] NOT NULL," +
                "[visit_end_time] [datetime] NOT NULL," +
                "[status] [bit] NULL)";

            string createTableStaff =
                "IF OBJECT_ID('Staff') IS NULL " +
                "CREATE TABLE [dbo].[Staff](" +
                "[id][int] IDENTITY(1, 1) NOT NULL," +
                "[last_name] [varchar] (50) NOT NULL," +
                "[first_name] [varchar] (50) NOT NULL," +
                "[patronymic] [varchar] (50) NOT NULL," +
                "[department] [varchar] (50) NOT NULL," +
                "[type] [varchar] (50) NOT NULL," +
                "[category] [varchar] (50) NULL," +
                "[degree] [varchar] (50) NULL," +
                "[post] [varchar] (100) NULL)";

            string createTableTicket =
                "IF OBJECT_ID('Ticket') IS NULL " +
                "CREATE TABLE[dbo].[Ticket](" +
                "[id][int] IDENTITY(1,1) NOT NULL," +
                "[number] [nchar] (3) NOT NULL," +
                "[datetime] [datetime] NOT NULL," +
                "[status] [bit] NULL," +
                "[window] [char](1) NULL);";

            return createTableAssignment +
                createTablePatients +
                createTableSchedule +
                createTableStaff +
                createTableTicket;
        }

        public static string SqlGetColumnsNames(string tableName)
        {
            return $"DECLARE @LIST VARCHAR(MAX), @TABLE VARCHAR(MAX) = '{tableName}';" +
                "SELECT @LIST = COALESCE(@LIST + ', ' + @TABLE + '.' + COLUMN_NAME, @TABLE + '.' + COLUMN_NAME) " +
                "FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = @TABLE; " +
                "SELECT @LIST";
        }

        public static string GetPenultTicket()
        {
            return "SELECT number FROM Ticket WHERE id = (SELECT MAX(id) FROM Ticket);";
        }

        public static string InsertNewTicket()
        {
            var lastTicket = Ticket.GetLastTicket();

            return "INSERT INTO Ticket (datetime, number) " +
                $"VALUES(GETDATE(), '{lastTicket}');" +
                "SELECT * FROM Ticket " +
                "WHERE id = SCOPE_IDENTITY();";
        }

        public static string GetQueue()
        {
            return "SELECT TOP 5 number, IsNull(window,' ') FROM Ticket " +
                "WHERE status IS NULL ORDER BY window DESC, datetime;";
        }

        public static string GetTicketList()
        {
            return "SELECT IsNull(window,''), number, CONVERT(VARCHAR, datetime, 21), id " +
                "FROM Ticket WHERE status IS NULL ORDER BY window , datetime";
        }

        public static string RemoveTicket(string ticketId)
        {
            return $"UPDATE Ticket SET status = 0 WHERE id = {ticketId}";
        }

        public static string TicketToWindow(string ticketId, string numberOfWindow)
        {
            return $"UPDATE Ticket SET window = {numberOfWindow} " +
                $"WHERE id = {ticketId}; SELECT @@ROWCOUNT;";
        }

        public static string TicketToQueue(string ticketId)
        {
            return $"UPDATE Ticket SET window = NULL " +
                $"WHERE id = {ticketId}; SELECT @@ROWCOUNT;";
        }

        public static string GetPatientList(string searchWord, string columnNames)
        {
            return "SELECT passport, convert(varchar, birthdate, 23), last_name, first_name, patronymic, id " +
                $"FROM Patients WHERE CONCAT({columnNames}) LIKE '%{searchWord}%'";
        }

        public static string AddPatient(List<string> personParam)
        {
            string passport = personParam[0];
            string lastName = personParam[1];
            string firstName = personParam[2];
            string patronymic = personParam[3];
            string birthdate = personParam[4];

            return "INSERT INTO Patients (passport, last_name, first_name, patronymic, birthdate) " +
                $"VALUES ('{passport}', '{lastName}', '{firstName}', '{patronymic}', '{birthdate}');";
        }

        public static string GetSchedule(string searchWord, string columnNames)
        {
            return "SELECT CONVERT(CHAR(16), visit_start_time, 20) AS DATETIME, type, last_name, Schedule.id " +
                "FROM Schedule JOIN Staff ON Schedule.staff_id = Staff.id " +
                $"WHERE status IS NULL AND concat({columnNames}) like '%{searchWord}%'" +
                "ORDER BY visit_start_time, last_name";
        }

        public static string AddAssignment(string ticketId, string patientId, string scheduleId)
        {
            return "INSERT INTO Assignment (id_ticket, id_patient, id_schedule) " +
                $"VALUES({ticketId}, {patientId}, {scheduleId});" +
                $"UPDATE Schedule SET status = 1 WHERE id = {scheduleId};";        
        }

        public static string GetStaffList(string searchWord)
        {
            return $"SELECT * FROM Staff WHERE last_name like '%{searchWord}%' OR " +
                $"first_name like '%{searchWord}%' OR patronymic like '%{searchWord}%' OR " +
                $"type like '%{searchWord}%' OR category like '%{searchWord}%' OR " +
                $"degree like '%{searchWord}%' OR post like '%{searchWord}%'";
        }

        public static string AddStaff(List<string> personParam)
        {
            return "INSERT INTO Staff (last_name, first_name, patronymic," +
                "department, type, category, degree, post) VALUES" +
                $"('{personParam[0]}', '{personParam[1]}', '{personParam[2]}', " +
                $"'{personParam[3]}', '{personParam[4]}', '{personParam[5]}', " +
                $"'{personParam[6]}', '{personParam[7]}');";
        }

        public static string AddSchedule(string apointments)
        {
            return "INSERT INTO Schedule (staff_id, visit_start_time, visit_end_time) " +
                $"VALUES{apointments}; SELECT * FROM Ticket WHERE id = SCOPE_IDENTITY()";
        }
    }
}