using System;
using System.IO;

namespace TicketingSystem
{
    internal class Program
    {
        static string tickets = "tickets.cvs";
        private static string _pickedChoice;
        
        
        // Allows selection for the user to choose from
        public static void Main(string[] args)
        {
            bool choice = true;
            
            do
            {
                MainMenu();
                switch (_pickedChoice)
                {
                    case "1":
                        Read();
                        break;
                    case "2":
                        Write();
                        break;
                    default:
                        choice = false;
                        break;
                }
            } while (choice);
        }
        
        
        
        // Allows you to enter an option for Main to run
        private static void MainMenu()
        {
            Console.WriteLine("1) Read the data from the file.");
            Console.WriteLine("2) Create file from users data.");
            Console.WriteLine("Enter anything else to exit.");
            _pickedChoice = Console.ReadLine();
        }

        // Reads from the tickets.csv document
        private static void Read()
        {
            if (File.Exists(tickets))
            { 
                StreamReader sr = new StreamReader(tickets);
                string firstLine = sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    string output = sr.ReadLine();
                    var column = output.Split(',');
                    Console.WriteLine("{0},{1},{2},{3},{4},{5},{6}", column[0], column[1], column[2], column[3], column[4], column[5], column[6]);
                } 
               sr.Close();
            }
        }

        // Prompts the user for entry data and then writes it to the tickets.csv document
        private static void Write()
        {
            Console.WriteLine("Ticket Number:");
            int ticketNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Summary of Ticket:");
            string summary = Console.ReadLine() + ",";
            Console.WriteLine("Status of Ticket:");
            string status = Console.ReadLine() + ",";
            Console.WriteLine("Priority:");
            string priority = Console.ReadLine() + ",";
            Console.WriteLine("Submitter:");
            string submitter = Console.ReadLine() + ",";
            Console.WriteLine("Assigned:");
            string assigned = Console.ReadLine() + ",";

            string watching;
            bool prompt = true;
            
            Console.WriteLine("Watching:");
            watching = Console.ReadLine();

            do
            {
                Console.WriteLine("Add another watcher? Y/N");
                string question = Console.ReadLine();
                
                if (question == "Y" || question == "y")
                { 
                   Console.WriteLine("Watching:");
                   string newWatcher = Console.ReadLine();
                   watching = watching + "|" + newWatcher;
                }
                else
                {
                    prompt = false;
                }

            } while (prompt);

            string finalWatcher = watching;

            StreamWriter sw = new StreamWriter(tickets,true);
            var ticketEntry = ticketNumber + "," + summary + status + priority + submitter + assigned + finalWatcher;
            sw.WriteLine(ticketEntry);
            sw.Close();
        }



    }
}

