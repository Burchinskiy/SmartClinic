using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartClinicServer
{
    class Message
    {
        public delegate void MethodContainer();
        public static event MethodContainer UpdateScoreboard;        

        public static string Decode(string incomingMessage)
        {
            var tempList = incomingMessage.Split('\n').ToList();
            var keyWord = tempList.First();
            tempList.RemoveAt(0);
            var messageWithoutKeyWord = string.Join("\n", tempList);
            var messageToSend = string.Empty;
            
            if (decoders.TryGetValue(keyWord, out var decoder))
            {
                messageToSend = decoder(messageWithoutKeyWord);
            }

            return messageToSend;
        }
        
        private static string AddTicket(string incomingMessage)
        {
            var messageToSend =
                SQL.TableToOneString
                (SQL.SelectTransaction
                (SQL.InsertNewTicket(),
                DataBase.ReadConfigFileDB()));
            UpdateScoreboard();
            return messageToSend;
        }

        private static string GetTicketList(string incomingMessage)
        {
            var messageToSend =
                SQL.TableToOneString
                (SQL.SelectTransaction
                (SQL.GetTicketList(),
                DataBase.ReadConfigFileDB()));
            return messageToSend;
        }

        private static string TicketToQueue(string incomingMessage)
        {
            var ticketId = incomingMessage;
            var messageToSend = SQL.EditTransaction
                (SQL.TicketToQueue(ticketId),
                DataBase.ReadConfigFileDB()).ToString();
            UpdateScoreboard();
            return messageToSend;
        }

        private static string RemoveTicket(string incomingMessage)
        {
            var ticketId = incomingMessage;
            var messageToSend =
                SQL.EditTransaction
                (SQL.RemoveTicket(ticketId),
                DataBase.ReadConfigFileDB()).ToString();
            UpdateScoreboard();
            return messageToSend;
        }

        private static string TicketToWindow(string incomingMessage)
        {
            var tempList = incomingMessage.Split('\n').ToList();
            var ticketId = tempList[1];
            var numberOfWindow = tempList[0];
            var messageToSend =
                SQL.EditTransaction
                (SQL.TicketToWindow
                (ticketId, numberOfWindow),
                DataBase.ReadConfigFileDB()).ToString();
            UpdateScoreboard();
            return messageToSend;
        }

        private static string GetPatientList(string incomingMessage)
        {
            var searchWord = incomingMessage;
            var ColumnNamesOfPatients =
                SQL.TableToOneString
                (SQL.SelectTransaction
                (SQL.SqlGetColumnsNames("Patients"),
                DataBase.ReadConfigFileDB())).Split('\t')[0];
            var messageToSend = SQL.TableToOneString
                (SQL.SelectTransaction
                (SQL.GetPatientList
                (searchWord, ColumnNamesOfPatients),
                DataBase.ReadConfigFileDB()));
            return messageToSend;
        }

        private static string AddPatient(string incomingMessage)
        {
            var patientInfo = incomingMessage.Split('\n').ToList();
            var messageToSend = SQL.EditTransaction
                (SQL.AddPatient(patientInfo),
                DataBase.ReadConfigFileDB()).ToString();
            return messageToSend;
        }

        private static string GetSchedule(string incomingMessage)
        {
            var searchWord = incomingMessage;
            var ColumnNamesOfSchedule = SQL.TableToOneString
                (SQL.SelectTransaction
                (SQL.SqlGetColumnsNames("Schedule"),
                DataBase.ReadConfigFileDB())).Split('\t')[0];
            var ColumnNamesOfStaff = SQL.TableToOneString
                (SQL.SelectTransaction
                (SQL.SqlGetColumnsNames("Staff"),
                DataBase.ReadConfigFileDB())).Split('\t')[0];
            var messageToSend = SQL.TableToOneString
                (SQL.SelectTransaction
                (SQL.GetSchedule(searchWord,
                $"{ColumnNamesOfSchedule}, " +
                $"{ColumnNamesOfStaff}"),
                DataBase.ReadConfigFileDB()));
            return messageToSend;
        }

        private static string AddAssignment(string incomingMessage)
        {
            var tempList = incomingMessage.Split('\n').ToList();
            var ticketId = tempList[0];
            var patientId = tempList[1];
            var scheduleId = tempList[2];
            var messageToSend = SQL.EditTransaction
                (SQL.AddAssignment(ticketId, patientId, scheduleId),
                DataBase.ReadConfigFileDB()).ToString();
            return messageToSend;
        }

        private static string GetStaffList(string incomingMessage)
        {
            var searchWord = incomingMessage;
            var messageToSend =
                SQL.TableToOneString
                (SQL.SelectTransaction
                (SQL.GetStaffList(searchWord),
                DataBase.ReadConfigFileDB()));
            return messageToSend;
        }

        private static string AddStaff(string incomingMessage)
        {
            var staffInfo = incomingMessage.Split('\n').ToList();
            var messageToSend = SQL.EditTransaction
                (SQL.AddStaff(staffInfo),
                DataBase.ReadConfigFileDB()).ToString();
            return messageToSend;
        }

        private static string AddSchedule(string incomingMessage)
        {
            var tempList = incomingMessage.Split('\n').ToList();
            var staffId = tempList[0];
            tempList.RemoveAt(0);
            var appointmentList = tempList;
            var messageToSend = string.Empty;
            foreach (var appointment in appointmentList)
            {
                messageToSend += $"({staffId}, {appointment}),";
            }
            messageToSend = messageToSend.Remove
                (messageToSend.Length - 1, 1);
            messageToSend = SQL.EditTransaction
                (SQL.AddSchedule(messageToSend),
                DataBase.ReadConfigFileDB()).ToString();
            return messageToSend;
        }

        private delegate string Decoder(string incomingMessage);
        private static Dictionary<string, Decoder> decoders = new Dictionary<string, Decoder>
        {
            ["AddTicket"] = AddTicket,
            ["GetTicketList"] = GetTicketList,
            ["TicketToQueue"] = TicketToQueue,
            ["RemoveTicket"] = RemoveTicket,
            ["TicketToWindow"] = TicketToWindow,
            ["GetPatientList"] = GetPatientList,
            ["AddPatient"] = AddPatient,
            ["GetSchedule"] = GetSchedule,
            ["AddAssignment"] = AddAssignment,
            ["GetStaffList"] = GetStaffList,
            ["AddStaff"] = AddStaff,
            ["AddSchedule"] = AddSchedule
        };
    }
}