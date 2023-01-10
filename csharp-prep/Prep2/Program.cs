using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string grade = Console.ReadLine();
        int percentage = int.Parse(grade);
        string letter = "";

        if (percentage >= 90)
        {
            letter = "A";
        }
        else if (percentage >= 80)
        {
            letter = "B";
        }
        else if (percentage >= 70)
        {
            letter = "C";
        }
        else if (percentage >= 60)
        {
            letter = "D";
        }
        else if (percentage <60)
        {
            letter = "F";
        }

        Console.WriteLine($"Your letter grade is {letter}");
        
        if (percentage >= 70)
        {
            Console.Write("CONGRATULATIONS! You passed the class!! :)");
        }
        else if (percentage <60)
        {
            Console.Write("The minimum grade to pass the class is a 'C'. You can pass it next time!!");
        }
    }
}