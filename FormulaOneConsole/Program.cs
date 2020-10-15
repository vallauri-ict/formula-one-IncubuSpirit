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
                c = Char.ToUpper(Console.ReadKey().KeyChar);
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

        public static void ExecuteSqlScript(string sqlScriptName)
        {
            string fileContent = File.ReadAllText(WORKINGPATH + sqlScriptName);
            fileContent = fileContent.Replace(",", "\n");
            var sqlqueries = fileContent.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries);

            SqlConnection con = new SqlConnection(CONNECTION_STRING);
            SqlCommand cmd = new SqlCommand("query", con);
            con.Open();

            int i = 0, nr = 0;
            foreach (var query in sqlqueries)
            {
                cmd.CommandText = query;
                i++;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException err)
                {
                    Console.WriteLine("Errore in esecuzione della query numero: " + i);
                    Console.WriteLine("\tErrore SQL: " + err.Number + " - " + err.Message);
                    nr++;
                }
            }

            Console.Clear();
            Console.WriteLine($"Processo di creazione della tabella \"{sqlScriptName.Substring(0, sqlScriptName.IndexOf('.'))}\" terminato con {i} error{(i == 1 ? "e" : "i")}.");
            System.Threading.Thread.Sleep(3000);
            con.Close();
        }
        public static void ResetDb()
        {
            string[] tables = new string[] { "Countries.sql", "Teams.sql", "drivers.sql"};
            for (int i = 0; i < tables.Length; i++)
            {
                SqlConnection con = new SqlConnection(CONNECTION_STRING);
                SqlCommand cmd = new SqlCommand("query", con);
                con.Open();
                string query = "DROP TABLE IF EXIST"+tables[i];
                cmd.CommandText = query;
                con.Close();
                ExecuteSqlScript(tables[i]);
            }
        }
    }
}
