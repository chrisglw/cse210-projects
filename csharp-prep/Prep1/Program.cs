using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your first name? ");
        string first_name = Console.ReadLine() ?? "";

        Console.Write("What is your last name? ");
        string last_name = Console.ReadLine() ?? "";

        Console.WriteLine("");

        Console.WriteLine($"Your name is {last_name}, {first_name} {last_name}.");

    //     Console.WriteLine(AddNumbers(2,2))
    }

    // static int AddNumbers(int num1, int num2)
    // {
    //     return num1 + num2;
    // }
}


