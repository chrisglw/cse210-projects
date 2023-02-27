using System;
using System.Collections.Generic;
using System.IO;


class Program
{
    static void Main(string[] args)
    {
        //Create an instance of the ScriptureManager class
        ScriptureManager scriptureManager = new ScriptureManager();
        
        //Load the scriptures
        scriptureManager.LoadScriptures();
        
        //Check if there are any scriptures
        while (scriptureManager.HasScriptures())
        {
            Console.Clear();

            //Get a random scripture
            Scripture scripture = scriptureManager.GetRandomScripture();

            //Keep hiding the text until it's fully hidden
            while (!scripture.IsFullyHidden())
            {
                Console.WriteLine(scripture.ToString());
                Console.WriteLine("Press enter to hide more words or type quit to end:");
                string input = Console.ReadLine();

                if (input.ToLower() == "quit")
                {
                    //Exit the program
                    Environment.Exit(0);
                }

                scripture.HideNextWords();
            }

            Console.WriteLine("You have completed the scripture. Would you like to try the same scripture again, try a new scripture, or quit? (same/new/quit)");
            string answer = Console.ReadLine().ToLower();

            if (answer == "same")
            {
                scripture.Reset();
            }
            else if (answer == "new")
            {
                scriptureManager.RemoveScripture(scripture);
            }
            else if (answer == "quit")
            {
                Environment.Exit(0);
            }
        }

        Console.WriteLine("No more scriptures to display. The program will now exit.");
    }
}

//ScriptureManager class manages the scriptures
class ScriptureManager
{
    //List of scriptures
    private List<Scripture> scriptures;

    public ScriptureManager()
    {
        //Create a new list of scriptures
        scriptures = new List<Scripture>();
    }

    //Check if there are any scriptures
    public bool HasScriptures()
    {
        return scriptures.Count > 0;
    }

    //Load the scriptures from a file
    public void LoadScriptures()
    {
        try
        {
            //Open the file and read the scriptures
            using (StreamReader reader = new StreamReader("D:\\chris\\Documents\\Classes\\5 Winter 2023\\Programming with classes\\cse210-projects\\prove\\Develop03\\scriptures.txt"))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    
                    //Create a new ScriptureReference from the line
                    ScriptureReference scriptureReference = new ScriptureReference(line);
                    
                    //Add a new scripture to the list
                    scriptures.Add(new Scripture(scriptureReference, line));
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("The file scriptures.txt could not be found. Please make sure it exists in the same directory as the program.");
            Environment.Exit(0);
        }
    }

    //Remove a scripture from the list
    public void RemoveScripture(Scripture scripture) {
        scriptures.Remove(scripture);
    }
    //Get a random scripture from the list
    public Scripture GetRandomScripture()
    {
        Random random = new Random();
        int index = random.Next(0, scriptures.Count);
        return scriptures[index];
    }
}

//ScriptureReference class contains information about the scripture reference
class ScriptureReference {
    private string _book;
    private int _chapter; 
    private int _startVerse;
    private int _endVerse;
    public ScriptureReference(string reference)
{
    //Split the reference by spaces
    string[] parts = reference.Split(' ');

    //The first part is the book
    _book = parts[0];

    //The second part is the chapter and verse(s)
    string[] chapterAndVerse = parts[1].Split(':');

    //Parse the chapter
    _chapter = int.Parse(chapterAndVerse[0]);

    //Check if there is a range of verses
    if (chapterAndVerse[1].Contains("-"))
    {
        //Split the verses by the hyphen
        string[] verses = chapterAndVerse[1].Split('-');

        //Parse the start and end verses
        _startVerse = int.Parse(verses[0]);
        _endVerse = int.Parse(verses[1]);
    }
    else
    {
        //There is only one verse
        _startVerse = int.Parse(chapterAndVerse[1]);
        _endVerse = _startVerse;
    }
}

public string Book
{
    get { return _book; }
}

public int Chapter
{
    get { return _chapter; }
}

public int StartVerse
{
    get { return _startVerse; }
}

public int EndVerse
{
    get { return _endVerse; }
}
}

//Scripture class contains information about the scripture text
class Scripture
{
    private ScriptureReference reference;
    private string text;
    private HashSet<int> hiddenWords; // keep track of hidden words indices
    private const int NumWordsToHide = 3; // number of words to hide at a time
    
    public Scripture(ScriptureReference reference, string text)
    {
        this.reference = reference;
        this.text = text;
        hiddenWords = new HashSet<int>();
    }

    //Check if all words are hidden
    public bool IsFullyHidden()
    {
        return hiddenWords.Count == text.Split(' ').Length;
    }

    //Hide the next few words in the text
    public void HideNextWords()
    {
        if (hiddenWords.Count == text.Split(' ').Length) // if all words are already hidden
        {
            return;
        }
        
        // Get the list of all the word indices
        var wordIndices = new List<int>();
        for (int i = 0; i < text.Length; i++)
        {
            if (char.IsWhiteSpace(text[i]))
            {
                wordIndices.Add(i);
            }
        }
        wordIndices.Add(text.Length); // Add the end index of the last word
        
        // Select a few random words that are not hidden yet
        var random = new Random();
        var indicesToHide = new List<int>();
        for (int i = 0; i < NumWordsToHide; i++)
        {
            int randomIndex;
            do
            {
                randomIndex = random.Next(0, wordIndices.Count - 1);
            } while (hiddenWords.Contains(randomIndex)); // make sure the index is not already hidden
            indicesToHide.Add(randomIndex);
        }

        // Hide the selected words
        foreach (var index in indicesToHide)
        {
            int wordStartIndex = index == 0 ? 0 : wordIndices[index - 1] + 1;
            int wordEndIndex = wordIndices[index];
            for (int i = wordStartIndex; i < wordEndIndex; i++)
            {
                text = text.Remove(i, 1).Insert(i, "*"); // Replace the word with asterisks
            }
            hiddenWords.Add(index);
        }
    }

    //Reset the hidden words
    public void Reset()
    {
        hiddenWords.Clear();
    }

    //Convert the scripture to a string
    public override string ToString()
    {
        return text;
    }
}
