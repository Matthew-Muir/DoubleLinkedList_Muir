using System;

namespace DoubleLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            DeployCSVFile.VerifyPathForInstall(); // Deploys csv file to C:

            var linkedList = new DoubleLinkedList();

            //Reads each line of csv file and add data to linkedList.
            foreach (string line in System.IO.File.ReadLines(@"c:\tmp\yob2019.txt"))
            {
                var lineDataArray = line.Split(','); //split line into array
                lineDataArray[1] = lineDataArray[1].ToLower() == "f" ? "false" : "true"; //convert f or m to boolean value.

                MetaData data = new MetaData(Boolean.Parse(lineDataArray[1]), lineDataArray[0], Int32.Parse(lineDataArray[2]));
                Node node = new Node(data);

                linkedList.AddNode(node); // Adds new nodes in order



            }

            Console.WriteLine("\nBuilding list complete!");
            Console.WriteLine(DisplayOptions.UserOptions);

            var userSelection = Console.ReadKey().Key;

            while (userSelection != ConsoleKey.Escape)
            {
                

                switch (userSelection)
                {
                    case ConsoleKey.D1:
                        Console.WriteLine("\nEnter the name to search for");
                        var name = Console.ReadLine();
                        Console.WriteLine($"Is name in list? {linkedList.SearchList(name)}\n");
                        Console.WriteLine(DisplayOptions.UserOptions);
                        break;
                    case ConsoleKey.D2:
                        Console.WriteLine($"\n{linkedList.TotalCount}");
                        Console.WriteLine(DisplayOptions.UserOptions);
                        break;
                    case ConsoleKey.D3:
                        Console.WriteLine($"\n{linkedList.FemaleCount}");
                        Console.WriteLine(DisplayOptions.UserOptions);
                        break;
                    case ConsoleKey.D4:
                        Console.WriteLine($"\n{linkedList.MaleCount}");
                        Console.WriteLine(DisplayOptions.UserOptions);
                        break;
                    case ConsoleKey.D5:
                        Console.WriteLine("\nEnter data in \"Ava,F,140\" format");
                        var userInput = Console.ReadLine();
                        try
                        {
                            var lineDataArray = userInput.Split(','); //split line into array
                            lineDataArray[1] = lineDataArray[1].ToLower() == "f" ? "false" : "true"; //convert f or m to boolean value.

                            MetaData data = new MetaData(Boolean.Parse(lineDataArray[1]), lineDataArray[0], Int32.Parse(lineDataArray[2]));
                            Node node = new Node(data);

                            linkedList.AddNode(node); // Adds new nodes in order
                        }
                        catch (Exception)
                        {

                            Console.WriteLine("Data wasn't formatted properly");
                        }
                        Console.WriteLine($"{userInput}  Added");
                        Console.WriteLine(DisplayOptions.UserOptions);
                        break;
                    case ConsoleKey.D6:
                        Console.WriteLine($"\nName: {linkedList.MostPopularFemale.Data.Name} - Gender: Female - Rank: {linkedList.MostPopularFemale.Data.Rank}");
                        Console.WriteLine($"\nName: {linkedList.MostPopularMale.Data.Name} - Gender: Male - Rank: {linkedList.MostPopularMale.Data.Rank}");
                        Console.WriteLine(DisplayOptions.UserOptions);
                        break;
                    default:
                        Console.WriteLine(DisplayOptions.UserOptions);
                        break;
                }

                userSelection = Console.ReadKey().Key;

            }



        }
    }
}
