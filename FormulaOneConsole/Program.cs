using System;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace FormulaOneConsole
{
    class Program
    {
        public const string WORKINGPATH = @"D:\FormulaOne_data\";
        private const string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + WORKINGPATH + @"FormulaOne.mdf;Integrated Security=True";
        private static string[] tableNames = { "Countries.sql", "Teams.sql", "drivers.sql" };

        private static void menu()
        {
            Console.Clear();
            Console.Title = "Formula one - Batch operations";
            Console.WriteLine("###    Formula one - Batch operations    ###");
            Console.WriteLine("1 - Create Countries table;");
            Console.WriteLine("2 - Create Teams table;");
            Console.WriteLine("3 - Create Drivers table;");
            Console.WriteLine(" - - - - - - - - - - - - -");
            Console.WriteLine("R - Reset DataBase;");
            Console.WriteLine(" - - - - - - - - - - - - -");
            Console.WriteLine("X - Exit.");
            Console.Write("\n_");
        }

        static void Main(string[] args)
        {
            char c;
            do
            {
                menu();
                c = Console.ReadKey().KeyChar;
                switch (c)
                {
                    case '1':
                        ExecuteSqlScript("Countries.sql");
                        break;
                    case '2':
                        ExecuteSqlScript("Teams.sql");
                        break;
                    case '3':
                        ExecuteSqlScript("Drivers.sql");
                        break;
                    case 'R':
                        ResetDb();
                        break;
                    default:
                        if (c != 'x' && c != 'X')
                        {
                            Console.WriteLine("Invalid selection.");
                        }
                        break;
                }
            } while (c != 'x' && c != 'X');
        }

        static bool ExecuteSqlScript(string sqlScriptName, string tab = "")
        {
            bool retVal = true;
            var fileContent = File.ReadAllText(WORKINGPATH + sqlScriptName);
            fileContent = fileContent.Replace("\r\n", "");
            fileContent = fileContent.Replace("\r", "");
            fileContent = fileContent.Replace("\n", "");
            fileContent = fileContent.Replace("\t", "");

            if (sqlScriptName == "drop.sql")
            {
                fileContent = fileContent.Replace("table_name", tab);
            }

            var sqlqueries = fileContent.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries);

            var con = new SqlConnection(CONNECTION_STRING);
            var cmd = new SqlCommand("query", con);
            con.Open();
            int i = 0;
            int nErr = 0;
            foreach (var query in sqlqueries)
            {
                cmd.CommandText = query; i++;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException err)
                {
                    Console.WriteLine("Errore in esecuzione della query numero: " + i);
                    Console.WriteLine("\tErrore SQL: " + err.Number + " - " + err.Message);
                    nErr++;
                    retVal = false;
                }
            }
            string finalMessage = nErr == 0 ? "Script " + sqlScriptName + " completed successfully without errors" : "Script completed with " + nErr + " errors";
            Console.WriteLine(finalMessage);
            return retVal;
        }


        public static void ResetDb()
        {
            Backup();
            for (int i = 0; i < tableNames.Length; i++)
            {
                SqlConnection con = new SqlConnection(CONNECTION_STRING);
                SqlCommand cmd = new SqlCommand("DROP TABLE [ IF EXISTS ] " + tableNames[i], con);
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                ExecuteSqlScript(tableNames[i]);
            }
        }

        public static void Backup()
        {
            try
            {
                SqlConnection con = new SqlConnection(CONNECTION_STRING);
                string sqlStmt = "";
                foreach(string table in tableNames)
                {
                    
                    sqlStmt += "SELECT * INTO " + table + "_bck FROM " + table + ";";
                }
                Console.WriteLine(sqlStmt);
            }
        }
    }
}
