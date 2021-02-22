using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Timers;

namespace CsharpPractice
{
    class Program
    {
        // a private field is a private property that can be accessed to all the members of the class
        private static string k = "";
        static void Main(string[] args)
        {
            // Reversing a string
            string phrase = "Well, sir, there's nothing on earth Like a genuine, bona fide Electrified, six - car monorail " +
                " What'd I say? Monorail What's it called? Monorail That's right! Monorail";
            // Convert the string into an array of single characters
            char[] charArray = phrase.ToCharArray();
            // Reverse the array
            Array.Reverse(charArray);

            //Console.WriteLine(charArray);
            /* Convert a string into currency values */
            // string myString = string.Format("{0:C}", 250.45); // :C will convert to your region currency
            //string myString = string.Format("{0:N}", 444677634332); // format number
            //string myString = string.Format("{0:P}", .1); // Percentage, .01 == 1% and 1 == 100%
            //string myString = string.Format("Phone number: {0: ####-####}", 12345678); // "draw" the format using #
            ////
            // StringBuilder represents a mutable str
            // requires System.Text
            StringBuilder myString = new StringBuilder();

            for (int i = 0; i < 100; i++)
            {
                // This simply adds whatever at the end instead of having to work with the entire string
                myString.Append(" - " + i);
            }

            //  Console.WriteLine(myString);

            DateTime myBirthday = new DateTime(1999, 7, 23);
            // get how old I am
            TimeSpan myAge = DateTime.Now.Subtract(myBirthday);
            // convert that data into days
            //Console.WriteLine(myAge.TotalDays);
            Car myCar = new Car();
            // Create reference from the same object
            Car myOtherCar = myCar;
            myOtherCar.Model = "98";
            // Clear that reference from the scope setting its value to null
            myOtherCar = null;
            //
            for (int i = 0; i < 10; i++)
            {
                k = i.ToString();
            }
            // Ctrl + . if there's no reference to the library I need, and select
            //WebClient client = new WebClient();
            //string reply = client.DownloadString("http://google.com");
            ////
            //File.WriteAllText(@"C:\Users\Usuario\Downloads\Nico\SuperAwesomeTestText.txt", reply);


            // Collections are arrays in steroids, there are different types
            /*
            Car car1 = new Car("A1","Oldsmobile", "Cutlas Supreme", 1987, "Red");
            
            Car car2 = new Car("B2", "Geo", "Prizm", 1967, "Black");

            Book b1 = new Book
            {
                Author = "Myself",
                Title = "Test Title",
                ISBN = "0-000000000-0"
            };

            // ArrayLists are dynamically sized, supports sorting, remove items, etc.

            ArrayList myArrayList = new ArrayList();
            myArrayList.Add(car1);
            // But they're not strongly type, you can mess up and put something that you don't want inside
            myArrayList.Add(b1); // I unintentionally added a book instead of another car

            // So is better to use a collection named List, a generic list (List<T>)
            // You can choose what type of data can be inside a collection
            List<Car> myList = new List<Car>(); //Inside <...> I put what kind of data type I want inside
            myList.Add(car1);
            myList.Add(car2);
            // myList.Add(b1); // Gives an error, b1 doesn't have data type Car
            //foreach (Car car in myList)
            //{
            //    Console.WriteLine(car.Make);
            //}
            // Dictionaries have a key and a value (Like a real dictionary)
            // Tend to be declared like this: Dictionary<TKey, TValue>

            Dictionary<string, Car> myDictionary = new Dictionary<string, Car>();

            myDictionary.Add(car1.VIN, car1); // VIN as key and the entire car1 object as value
            myDictionary.Add(car2.VIN, car2);

            // Console.WriteLine(myDictionary["B2"].Make);

            */
            // Object initializer, doesn't need a constructor
            Car car1 = new Car() {Make = "BMW", Model = "750li", VIN = "C3", Year = 1965, Color = "White"};
            Car car2 = new Car() {Make = "Toyota", Model = "4Runner", VIN = "D4", Year = 1977, Color = "Gray"};
            
            // Collection initializer

            List<Car> myList = new List<Car>() {
                new Car {Make = "Oldsmobile", Color = "Green", Year = 1946, VIN = "E5", Model = "Cutlas Supreme"},
                new Car {Make = "Nissan", Color = "Yellow", Year = 1725, VIN = "F6", Model = "Altima"}
            };

            // Working with LINQ (Language Integrated Query)
            // A way to filter, sort, and perform other aggregate operations on data stored inside collections

            List<Car> myCars = new List<Car>() {
                new Car {VIN = "A1", Make = "BMW", Model = "550i", StickerPrice = 55000, Year = 1963},
                new Car {VIN = "B2", Make = "Toyota", Model = "4Runner", StickerPrice = 35000, Year = 1984},
                new Car {VIN = "C3", Make = "BMW", Model = "745li", StickerPrice = 75000, Year = 1978},
                new Car {VIN = "D4", Make = "Ford", Model = "Escape", StickerPrice = 25000, Year = 1999},
                new Car {VIN = "E5", Make = "BMW", Model = "55i", StickerPrice = 57000, Year = 2010}
            };

            // the var keyword lets the compiler figure out what kind o datatype is the variable

            // LINQ Query Syntax

            /*
            var bmws = from car in myCars
                       where car.Make == "BMW"
                       && car.Year == 2010
                       select car;
            */

            /*
            var orderedCars = from car in myCars
                              orderby car.Year descending
                              select car;
            */

            //LINQ Method Syntax

            /*
            var bmws = myCars.Where(p => p.Make == "BMW" && p.Year == 2010);
            */

            /*
            var orderedCars = myCars.OrderByDescending(p => p.Year);
            */

            // var firstBMW = myCars.OrderByDescending(p => p.Year).First(p => p.Make == "BMW");


            // Console.WriteLine(myCars.TrueForAll(p => p.Year >= 2012));

            //myCars.ForEach(p => p.StickerPrice -= 3000);

            // Generate an anonymous type of cars selecting only determined attribbutes

            var newCars = from car in myCars
                       where car.Make == "BMW"
                       && car.Year == 2010
                       select new { car.Make, car.Model };

            // Enumerations and Switch Statements

            List<Todo> todos = new List<Todo>()
            {
                new Todo { Description = "Task 1", EstimatedHours = 6, Status = Status.Completed },
                new Todo { Description = "Task 2", EstimatedHours = 2, Status = Status.InProgress },
                new Todo { Description = "Task 3", EstimatedHours = 8, Status = Status.NotStarted },
                new Todo { Description = "Task 4", EstimatedHours = 12, Status = Status.Deleted },
                new Todo { Description = "Task 5", EstimatedHours = 6, Status = Status.InProgress },
                new Todo { Description = "Task 6", EstimatedHours = 2, Status = Status.NotStarted },
                new Todo { Description = "Task 7", EstimatedHours = 14, Status = Status.NotStarted },
                new Todo { Description = "Task 8", EstimatedHours = 8, Status = Status.Completed },
                new Todo { Description = "Task 9", EstimatedHours = 8, Status = Status.InProgress },
                new Todo { Description = "Task 10", EstimatedHours = 8, Status = Status.Completed },
                new Todo { Description = "Task 11", EstimatedHours = 4, Status = Status.NotStarted },
                new Todo { Description = "Task 12", EstimatedHours = 10, Status = Status.Completed },
                new Todo { Description = "Task 13", EstimatedHours = 12, Status = Status.Deleted },
                new Todo { Description = "Task 14", EstimatedHours = 6, Status = Status.Completed },
            };

            // PrintAssessment(todos);

            ///////
            // How to handle runtime exceptions
            /*
            try
            {
                string content = File.ReadAllText(@"C:\Users\Usuario\Downloads\Nico\Example.txt");
                Console.WriteLine(content);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("There was a problem in the application");
                Console.WriteLine(ex.Message);
                Console.WriteLine("Make sure the file has the correct name: Example.txt");
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine("There was a problem in the application");
                Console.WriteLine(ex.Message);
                Console.WriteLine("Make sure the name of the directory exist");
            }
            catch (Exception ex)
            {
                Console.WriteLine("There was a problem in the application");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                // Code that will always run
                Console.WriteLine("End of the try and catch example");
            }
            */

            // Event Driven Programming
            /////////// /////////////////

            Timer myTimer = new Timer(2000);

            myTimer.Elapsed += MyTimer_Elapsed;
            myTimer.Elapsed += MyTimer_Elapsed1;

            myTimer.Start();

            Console.WriteLine("Press enter to remove the green event");
            Console.ReadLine();


            myTimer.Elapsed -= MyTimer_Elapsed1;
            

            Console.ReadLine();
        }

        private static void MyTimer_Elapsed1(object sender, ElapsedEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Elapsed time1: {0:HH:mm:ss.fff}", e.SignalTime);
        }

        private static void MyTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Elapsed time: {0:HH:mm:ss.fff}", e.SignalTime);
        }

        private static void PrintAssessment(List<Todo> todos)
        {
            foreach ( var todo in todos)
            {
                // hitting enter twice after entering the switch autocompletes it
                switch (todo.Status)
                {
                    case Status.NotStarted:
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    case Status.InProgress:
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    case Status.OnHold:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    case Status.Completed:
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        break;
                    case Status.Deleted:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        break;
                    default:
                        break;
                }
                Console.WriteLine(todo.Description);
            }
        }

        class Todo
        {
            public string Description { get; set; }
            public int EstimatedHours { get; set; }
            public Status Status { get; set; }
        }
        // Enumerations store the statuses with numbers, but allow you to use words to describe better what are they doing
        enum Status
        {
            NotStarted,
            InProgress,
            OnHold,
            Completed,
            Deleted

        }
        class Car
        {
            public string VIN { get; set; }
            public string Make { get; set; }
            public string Model { get; set; }
            public int Year { get; set; }
            public string Color { get; set; }

            public double StickerPrice { get; set; }
            // Constructor
            public Car()
            {
                // The this. is optional
                this.Make = "Nissan";
            }
            // Overloading constructor
            public Car(string vin, string make, string model, int year, string color)
            {
                VIN = vin;
                Make = make;
                Model = model;
                Year = year;
                Color = color;

            }
        }

        class Book
        {
            public string Title { get; set; }
            public string Author { get; set; }
            public string ISBN { get; set; }
        }
    }
}
