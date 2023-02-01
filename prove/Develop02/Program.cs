using System;
using System.IO;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        int userChoice = 0;
        Menu menu = new Menu();
        Prompt prompt = new Prompt();
        Journal journal = new Journal();

        while (userChoice != 5) {
            menu.DisplayMenu();
            string MenuChoice = Console.ReadLine() ?? "5";
            userChoice = int.Parse(MenuChoice);
            if (userChoice == 1) {
                var newPrompt = prompt.RandomPrompt();
                Console.WriteLine(newPrompt);
                string userInput = Console.ReadLine() ?? "";
                journal.NewEntry(newPrompt, userInput);
            }
            else if (userChoice == 2) {
                journal.DisplayEntries();
            }
            else if (userChoice == 3) {
            Console.Write("Enter the filename: ");
            string fileName = Console.ReadLine();
            journal.LoadFile(fileName);
            }
            else if (userChoice == 4) {
                Console.Write("Enter the filename: ");
                string fileName = Console.ReadLine();
                journal.SaveEntries(fileName);
            }
        } 
    }
}

public class Menu{
    public void DisplayMenu() {
        Console.WriteLine("Welcome to the Journal Program!");
        Console.WriteLine("Please select one of the following choices:");
        Console.WriteLine("1. Write");
        Console.WriteLine("2. Display");
        Console.WriteLine("3. Load");
        Console.WriteLine("4. Save");
        Console.WriteLine("5. Quit");
        Console.Write("What would you like to do? ");
    }
}

public class Prompt {
    List<string> prompts = new List<string>();
    public Prompt(){
        prompts.Add("How are you feeling? ");
        prompts.Add("Were you nice today? ");
        prompts.Add("What was the best thing that happened to you today? ");
        prompts.Add("What could you have done better today? ");
        prompts.Add("What did you do different today? ");
        prompts.Add("Who was the most interesting person I interacted with today? ");
        prompts.Add("What was the best part of my day? ");
        prompts.Add("How did I see the hand of the Lord in my life today? ");
        prompts.Add("What was the strongest emotion I felt today? ");
        prompts.Add("If I had one thing I could do over today, what would it be? ");
        prompts.Add("What was the reason why I did not do something I wanted to do? ");
    }
    public string RandomPrompt() {
        var rdm = new Random();
        var randomIndex = rdm.Next(prompts.Count());
        var randomPrompt = prompts[randomIndex];
        return randomPrompt;
    }
}
public class Journal {
    List<Entry> entries = new List<Entry>();
    public void NewEntry(string prompt, string input) {
        Entry newEntry = new Entry();
        newEntry.prompt = prompt;
        newEntry.input = input;
        entries.Add(newEntry);
    }
    public void DisplayEntries() {
        foreach(var entry in entries){
            entry.Display();
            Console.WriteLine("");
        }
    }

    public void SaveEntries(string fileName) {
        // Console.Write("What is the filename? ");
        // string fileName = Console.ReadLine() ?? "";
        using (StreamWriter outputFile = new StreamWriter(fileName)) {
            foreach (Entry entry in entries)
            {
                outputFile.WriteLine(entry.date);
                outputFile.WriteLine(entry.prompt);
                outputFile.WriteLine(entry.input);
            }
        }
    }
    public void LoadFile(string fileName) {
    using (StreamReader inputFile = new StreamReader(fileName)) {
    while (!inputFile.EndOfStream){
            Entry entry = new Entry();
            entry.date = inputFile.ReadLine();
            entry.prompt = inputFile.ReadLine();
            entry.input = inputFile.ReadLine();
            entries.Add(entry);
            }
        }
    }
public class Entry {
    public String date;
    public String prompt;
    public String input;

    public Entry()
    {
        // string date = theCurrentTime.ToShortDateString();
    }
    public void Display() {
        Console.Write($"Date: {date} — Prompt: ");
        Console.WriteLine(prompt);
        Console.WriteLine(input);
    }
    }
}



