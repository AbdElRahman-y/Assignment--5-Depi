using System;

namespace Assignment4
{
    // ===================== Enums & Structs =====================
    enum WeekDays { Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday }

    enum Season { Spring, Summer, Autumn, Winter }

    enum Colors { Red, Green, Blue }

   
    enum Permissions
    {
        None = 0,
        Read = 1,      // 0001
        Write = 2,     // 0010
        Delete = 4,    // 0100
        Execute = 8    // 1000
    }

    struct Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    struct Point
    {
        public double X { get; set; }
        public double Y { get; set; }
    }

   
    class Car
    {
        public string Model { get; set; }
    }

    internal class Program
    {
        
        static int ReadInt(string message)
        {
            int value;
            Console.Write(message);
            while (!int.TryParse(Console.ReadLine(), out value))
                Console.Write("Invalid number, try again: ");
            return value;
        }

        static double ReadDouble(string message)
        {
            double value;
            Console.Write(message);
            while (!double.TryParse(Console.ReadLine(), out value))
                Console.Write("Invalid number, try again: ");
            return value;
        }

        // ===================== Part 1: Functions =====================

        // ---- Q1: ----
   
        static void SwapByValue(int a, int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        static void SwapByRef(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        // ---- Q2:  ----
      
        static void ChangeModel(Car car)
        {
            car.Model = "Changed inside method";
        }

   
        static void NewCarByValue(Car car)
        {
            car = new Car { Model = "New car (by value)" };
        }

    
        static void NewCarByRef(ref Car car)
        {
            car = new Car { Model = "New car (by ref)" };
        }

        // ---- Q3: 4 parameters ----
        static void SumAndSubtract(int a, int b, out int sum, out int difference)
        {
            sum = a + b;
            difference = a - b;
        }

        // ---- Q4: ----
        static int SumOfDigits(int number)
        {
            number = Math.Abs(number);
            int sum = 0;
            while (number > 0)
            {
                sum += number % 10;  
                number /= 10;        
            }
            return sum;
        }

        // ---- Q5:  ----
        static bool IsPrime(int number)
        {
            if (number < 2) return false;
            for (int i = 2; i * i <= number; i++)
            {
                if (number % i == 0)
                    return false;
            }
            return true;
        }

        // ---- Q6:  ----
        static void MinMaxArray(int[] array, ref int min, ref int max)
        {
            min = array[0];
            max = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < min) min = array[i];
                if (array[i] > max) max = array[i];
            }
        }

        // ---- Q7: ) ----
        static long Factorial(int number)
        {
            long result = 1;
            for (int i = 2; i <= number; i++)
                result *= i;
            return result;
        }

        // ---- Q8: ----
       
        static string ChangeChar(string text, int position, char newChar)
        {
            if (position < 0 || position >= text.Length)
                return text;

            char[] chars = text.ToCharArray();
            chars[position] = newChar;
            return new string(chars);
        }

        // ===================== Menu =====================
        static void Main(string[] args)
        {
            int choice;
            do
            {
                Console.WriteLine();
                Console.WriteLine("===== Assignment 4 =====");
                Console.WriteLine("Functions:");
                Console.WriteLine(" 1) Value type: by value vs by ref");
                Console.WriteLine(" 2) Reference type: by value vs by ref");
                Console.WriteLine(" 3) Sum & Subtract (out)");
                Console.WriteLine(" 4) Sum of digits");
                Console.WriteLine(" 5) IsPrime");
                Console.WriteLine(" 6) MinMaxArray (ref)");
                Console.WriteLine(" 7) Factorial");
                Console.WriteLine(" 8) ChangeChar");
                Console.WriteLine("Enum & Struct:");
                Console.WriteLine(" 9) WeekDays enum");
                Console.WriteLine("10) Person struct array");
                Console.WriteLine("11) Season");
                Console.WriteLine("12) Permissions (Flags)");
                Console.WriteLine("13) Colors");
                Console.WriteLine("14) Point distance");
                Console.WriteLine("15) Oldest person");
                Console.WriteLine(" 0) Exit");
                choice = ReadInt("Choose: ");

                switch (choice)
                {
                    case 1: Q1(); break;
                    case 2: Q2(); break;
                    case 3: Q3(); break;
                    case 4: Q4(); break;
                    case 5: Q5(); break;
                    case 6: Q6(); break;
                    case 7: Q7(); break;
                    case 8: Q8(); break;
                    case 9: E1(); break;
                    case 10: E2(); break;
                    case 11: E3(); break;
                    case 12: E4(); break;
                    case 13: E5(); break;
                    case 14: E6(); break;
                    case 15: E7(); break;
                    case 0: break;
                    default: Console.WriteLine("Invalid choice"); break;
                }
            } while (choice != 0);
        }

       
        static void Q1()
        {
            int x = 1, y = 2;

            SwapByValue(x, y);
            Console.WriteLine($"After SwapByValue: x = {x}, y = {y}");   // 1 , 2 (ما اتغيرش)

            SwapByRef(ref x, ref y);
            Console.WriteLine($"After SwapByRef:   x = {x}, y = {y}");   // 2 , 1 (اتبدل)
        }

        static void Q2()
        {
            Car car = new Car { Model = "BMW" };

            ChangeModel(car);
            Console.WriteLine($"After ChangeModel (by value): {car.Model}");   

            car = new Car { Model = "BMW" };
            NewCarByValue(car);
            Console.WriteLine($"After NewCarByValue: {car.Model}");           

            NewCarByRef(ref car);
            Console.WriteLine($"After NewCarByRef:   {car.Model}");            
        }

        static void Q3()
        {
            int a = ReadInt("Enter first number: ");
            int b = ReadInt("Enter second number: ");

            SumAndSubtract(a, b, out int sum, out int difference);
            Console.WriteLine($"Sum = {sum}, Difference = {difference}");
        }

        static void Q4()
        {
            int number = ReadInt("Enter a number: ");
            Console.WriteLine($"The sum of the digits of the number {number} is: {SumOfDigits(number)}");
        }

        static void Q5()
        {
            int number = ReadInt("Enter a number: ");
            Console.WriteLine(IsPrime(number) ? $"{number} is prime" : $"{number} is not prime");
        }

        static void Q6()
        {
            int size = ReadInt("Array size: ");
            while (size <= 0)
                size = ReadInt("Size must be greater than 0: ");

            int[] array = new int[size];
            for (int i = 0; i < array.Length; i++)
                array[i] = ReadInt($"Element {i}: ");

            int min = 0, max = 0;
            MinMaxArray(array, ref min, ref max);
            Console.WriteLine($"Min = {min}, Max = {max}");
        }

        static void Q7()
        {
            int number = ReadInt("Enter a number: ");
            while (number < 0)
                number = ReadInt("Number must be 0 or more: ");

            Console.WriteLine($"{number}! = {Factorial(number)}");
        }

        static void Q8()
        {
            Console.Write("Enter text: ");
            string text = Console.ReadLine() ?? "";
            int position = ReadInt("Position (0 based): ");

            Console.Write("New letter: ");
            string input = Console.ReadLine() ?? "";
            if (input.Length == 0)
            {
                Console.WriteLine("You must enter a letter");
                return;
            }

            Console.WriteLine(ChangeChar(text, position, input[0]));
        }

        // ===================== Enum & Struct =====================
        static void E1()
        {
            foreach (WeekDays day in Enum.GetValues(typeof(WeekDays)))
                Console.WriteLine(day);
        }

        static void E2()
        {
            Person[] people = new Person[3];
            people[0] = new Person { Name = "Ahmed", Age = 25 };
            people[1] = new Person { Name = "Sara", Age = 30 };
            people[2] = new Person { Name = "Omar", Age = 22 };

            foreach (Person p in people)
                Console.WriteLine($"Name: {p.Name}, Age: {p.Age}");
        }

        static void E3()
        {
            Console.Write("Enter season name (Spring, Summer, Autumn, Winter): ");
            string input = Console.ReadLine() ?? "";

           
            if (Enum.TryParse(input, true, out Season season) && Enum.IsDefined(typeof(Season), season))
            {
                string range = season switch
                {
                    Season.Spring => "March to May",
                    Season.Summer => "June to August",
                    Season.Autumn => "September to November",
                    Season.Winter => "December to February",
                    _ => ""
                };
                Console.WriteLine($"{season}: {range}");
            }
            else
            {
                Console.WriteLine("Invalid season");
            }
        }

        static void E4()
        {
            Permissions permissions = Permissions.None;

            // Add
            permissions |= Permissions.Read;
            permissions |= Permissions.Write;
            permissions |= Permissions.Delete;
            Console.WriteLine($"After add Read, Write, Delete: {permissions}");

            // Remove
            permissions &= ~Permissions.Write;
            Console.WriteLine($"After remove Write: {permissions}");

            // Check
            Console.WriteLine($"Has Read?    {permissions.HasFlag(Permissions.Read)}");
            Console.WriteLine($"Has Write?   {permissions.HasFlag(Permissions.Write)}");
            Console.WriteLine($"Has Execute? {(permissions & Permissions.Execute) == Permissions.Execute}");
        }

        static void E5()
        {
            Console.Write("Enter color name: ");
            string input = Console.ReadLine() ?? "";

            if (Enum.TryParse(input, true, out Colors color) && Enum.IsDefined(typeof(Colors), color))
                Console.WriteLine($"{color} is a primary color");
            else
                Console.WriteLine($"{input} is not a primary color");
        }

        static void E6()
        {
            Point p1 = new Point
            {
                X = ReadDouble("Point 1 - X: "),
                Y = ReadDouble("Point 1 - Y: ")
            };
            Point p2 = new Point
            {
                X = ReadDouble("Point 2 - X: "),
                Y = ReadDouble("Point 2 - Y: ")
            };

            double distance = Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));
            Console.WriteLine($"Distance = {distance}");
        }

        static void E7()
        {
            Person[] people = new Person[3];
            for (int i = 0; i < people.Length; i++)
            {
                Console.Write($"Person {i + 1} name: ");
                string name = Console.ReadLine() ?? "";
                int age = ReadInt($"Person {i + 1} age: ");
                people[i] = new Person { Name = name, Age = age };
            }

            Person oldest = people[0];
            foreach (Person p in people)
            {
                if (p.Age > oldest.Age)
                    oldest = p;
            }
            Console.WriteLine($"Oldest: {oldest.Name}, Age: {oldest.Age}");
        }
    }
}
