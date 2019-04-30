using System;
using System.IO;

namespace dataStructure
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Action Name (POST, GET, PUT, DELETE) : ");
            string action = Console.ReadLine();

            switch (action)
            {
                case "POST":
                    POST();
                    break;

                case "GET":
                    GET();
                    break;

                case "PUT":
                    PUT();
                    break;
            }
        }

        public static bool GET()
        {
            var lines = System.IO.File.ReadAllText("data.txt");
            Console.WriteLine(lines);
            Console.WriteLine("Press Enter To Exit");
            string newContent = Console.ReadLine();
            return true;
        }

        public static bool POST()
        {
            Console.WriteLine("Enter content to add :");
            string newContent = Console.ReadLine();
            File.AppendAllText("data.txt", newContent + Environment.NewLine);
            return true;
        }
        public static bool PUT()
        {
            var content = System.IO.File.ReadAllText("data.txt");
            Console.WriteLine(content);

            Console.WriteLine("Enter line number to Edit:");
            int index = Convert.ToUInt16(Console.ReadLine());
            index = index - 1;

            Console.WriteLine("Enter content to edit:");
            string newContent = Console.ReadLine();

            var lines = System.IO.File.ReadAllLines("data.txt");

            if (lines != null)
            {
                if (lines.Length > index)
                {
                    lines[index] = newContent;
                    System.IO.File.Delete("data.txt");
                    System.IO.File.AppendAllLines("data.txt", lines);
                }
                else
                {
                    Console.WriteLine("No Data found at this Index.");
                }
            }
            return true;
        }
    }
}
