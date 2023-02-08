using System;
using System.Collections.Generic;
using System.Linq;

namespace EncapsulatedScripture
{
    class Verse
    {
        private string reference;
        private string text;
        private bool[] hidden;

        public Verse(string reference, string text)
        {
            this.reference = reference;
            this.text = text;
            this.hidden = new bool[0];
        }


        public string Reference
        {
            get { return reference; }
        }

        public string Text
        {
            get { return text; }
        }

        public bool[] Hidden
        {
            get { return hidden; }
            set { hidden = value; }
        }
    }

    class Scripture
    {
        private List<Verse> verses;
        private Random random;

        public Scripture(List<Verse> verses)
        {
            this.verses = verses;
            this.random = new Random();
        }

        public List<Verse> Verses
        {
            get { return verses; }
        }

        public void HideWords()
        {
            foreach (Verse verse in verses)
            {
                string[] words = verse.Text.Split(' ');
                int wordCount = words.Length;
                bool[] hidden = new bool[wordCount];
                int hiddenCount = 0;

            while (hiddenCount < wordCount)
                {
                    int index = random.Next(0, wordCount);
                    if (!hidden[index])
                    {
                        hidden[index] = true;
                        hiddenCount++;
                    }
                }
                if (hiddenCount >= wordCount) break;
            }
        }


        public void DisplayScripture()
        {
            Console.Clear();
            foreach (Verse verse in verses)
            {
                Console.WriteLine(verse.Reference);
                string[] words = verse.Text.Split(' ');
                for (int i = 0; i < words.Length; i++)
                {
                    if (verse.Hidden[i])
                    {
                        Console.Write("_____ ");
                    }
                    else
                    {
                        Console.Write(words[i] + " ");
                    }
                }
                Console.WriteLine();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Scripture scripture = new Scripture(new List<Verse>()
            {
                new Verse("John 3:16", "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life."),
                new Verse("Proverbs 3:5-6", "Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight.")
            });

            while (true)
            {
                scripture.DisplayScripture();
                Console.WriteLine("\nPress the enter key or type quit: ");
                string input = Console.ReadLine();
                if (input.ToLower() == "quit")
                {
                    break;
                }
                scripture.HideWords();
            }
        }
    }
}



// using System;
// using System.Collections.Generic;
// using System.Linq;

// namespace EncapsulatedScripture
// {
//     class Verse
//     {
//         private string reference;
//         private string text;

//         public Verse(string reference, string text)
//         {
//             this.reference = reference;
//             this.text = text;
//         }

//         public string Reference
//         {
//             get { return reference; }
//         }

//         public string Text
//         {
//             get { return text; }
//         }
//     }

//     class Scripture
//     {
//         private List<Verse> verses;
//         private Random random;

//         public Scripture(List<Verse> verses)
//         {
//             this.verses = verses;
//             this.random = new Random();
//         }

//         public List<Verse> Verses
//         {
//             get { return verses; }
//         }

//         public void HideWords()
//         {
//             foreach (Verse verse in verses)
//             {
//                 string[] words = verse.Text.Split(' ');
//                 int wordCount = words.Length;
//                 bool[] hidden = new bool[wordCount];
//                 int hiddenCount = 0;

//                 while (hiddenCount < wordCount)
//                 {
//                     int index = random.Next(0, wordCount);
//                     if (!hidden[index])
//                     {
//                         hidden[index] = true;
//                         hiddenCount++;
//                     }
//                 }
//                 verse.Hidden = hidden;
//             }
//         }

//         public void DisplayScripture()
//         {
//             Console.Clear();
//             foreach (Verse verse in verses)
//             {
//                 Console.WriteLine(verse.Reference);
//                 string[] words = verse.Text.Split(' ');
//                 for (int i = 0; i < words.Length; i++)
//                 {
//                     if (verse.Hidden[i])
//                     {
//                         Console.Write("_____ ");
//                     }
//                     else
//                     {
//                         Console.Write(words[i] + " ");
//                     }
//                 }
//                 Console.WriteLine();
//             }
//         }
//     }

//     class Program
//     {
//         static void Main(string[] args)
//         {
//             Scripture scripture = new Scripture(new List<Verse>()
//             {
//                 new Verse("John 3:16", "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life."),
//                 new Verse("Proverbs 3:5-6", "Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight.")
//             });

//             while (true)
//             {
//                 scripture.DisplayScripture();
//                 Console.WriteLine("\nPress the enter key or type quit: ");
//                 string input = Console.ReadLine();
//                 if (input.ToLower() == "quit")
//                 {
//                     break;
//                 }
//                 scripture.HideWords();
//             }
//         }
//     }
// }


// using System;
// using System.Collections.Generic;
// using System.Linq;

// namespace EncapsulatedScripture
// {
//     class Verse
//     {
//         private readonly string _reference;
//         private readonly string _text;

//         public Verse(string reference, string text)
//         {
//             _reference = reference;
//             _text = text;
//         }

//         public string Reference => _reference;
//         public string Text => _text;
//     }

//     class Scripture
//     {
//         private readonly List<Verse> _verses;

//         public Scripture(List<Verse> verses)
//         {
//             _verses = verses;
//         }

//         public List<Verse> Verses => _verses;
//     }

//     class Program
//     {
//         static void Main(string[] args)
//         {
//             var scripture = new Scripture(new List<Verse>
//             {
//                 new Verse("John 3:16", "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life."),
//                 new Verse("Proverbs 3:5-6", "Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight.")
//             });

//             var random = new Random();
//             var gameRunning = true;
//             while (gameRunning)
//             {
//                 Console.Clear();

//                 foreach (var verse in scripture.Verses)
//                 {
//                     Console.WriteLine(verse.Reference);
//                     var words = verse.Text.Split(' ');
//                     var hidden = new bool[words.Length];
//                     var hiddenCount = 0;
//                     for (var i = 0; i < words.Length; i++)
//                     {
//                         if (hidden[i])
//                         {
//                             Console.Write("_____ ");
//                         }
//                         else
//                         {
//                             Console.Write(words[i] + " ");
//                         }
//                     }

//                     Console.WriteLine();
//                 }

//                 Console.WriteLine("\nEnter 'quit' to end the game or press enter to continue: ");
//                 var input = Console.ReadLine();
//                 if (input?.ToLower() == "quit")
//                 {
//                     gameRunning = false;
//                 }
//                 else
//                 {
//                     foreach (var verse in scripture.Verses)
//                     {
//                         var words = verse.Text.Split(' ');
//                         while (hiddenCount < words.Length)
//                         {
//                             var index = random.Next(0, words.Length);
//                             if (!hidden[index])
//                             {
//                                 hidden[index] = true;
//                                 hiddenCount++;
//                             }
//                         }
//                     }
//                 }
//             }
//         }
//     }
// }


// using System;
// using System.Collections.Generic;
// using System.Linq;

// namespace EncapsulatedScripture
// {
//     class Verse
//     {
//         private string reference;
//         private string text;

//         public Verse(string reference, string text)
//         {
//             this.reference = reference;
//             this.text = text;
//         }

//         public string Reference
//         {
//             get { return reference; }
//         }

//         public string Text
//         {
//             get { return text; }
//         }
//     }

//     class Scripture
//     {
//         private List<Verse> verses;

//         public Scripture(List<Verse> verses)
//         {
//             this.verses = verses;
//         }

//         public List<Verse> Verses
//         {
//             get { return verses; }
//         }
//     }

//     class Program
//     {
//         static void Main(string[] args)
//         {
//             Scripture scripture = new Scripture(new List<Verse>()
//             {
//                 new Verse("John 3:16", "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life."),
//                 new Verse("Proverbs 3:5-6", "Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight.")
//             });

//             Random random = new Random();
//             string[] words;
//             bool[] hidden;
//             int hiddenCount;
//             while (true)
//             {
//                 Console.Clear();
//                 foreach (Verse verse in scripture.Verses)
//                 {
//                     Console.WriteLine(verse.Reference);
//                     words = verse.Text.Split(' ');
//                     hidden = new bool[words.Length];
//                     hiddenCount = 0;
//                     for (int i = 0; i < words.Length; i++)
//                     {
//                         if (hidden[i])
//                         {
//                             Console.Write("_____ ");
//                         }
//                         else
//                         {
//                             Console.Write(words[i] + " ");
//                         }
//                     }
//                     Console.WriteLine();
//                 }
//                 Console.WriteLine("\nPress the enter key or type quit: ");
//                 string input = Console.ReadLine();
//                 if (input.ToLower() == "quit")
//                 {
//                     break;
//                 }
//                 foreach (Verse verse in scripture.Verses)
//                 {
//                     words = verse.Text.Split(' ');
//                     while (hiddenCount < words.Length)
//                     {
//                         int index = random.Next(0, words.Length);
//                         if (!hidden[index])
//                         {
//                             hidden[index] = true;
//                             hiddenCount++;
//                         }
//                     }
//                 }
//                 if (hiddenCount == words.Length)
//                 {
//                     break;
//                 }
//             }
//         }
//     }
// }


// using System;
// using System.Collections.Generic;
// using System.Linq;

// namespace EncapsulatedScripture
// {
//     class Verse
//     {
//         private string reference;
//         private string text;

//         public Verse(string reference, string text)
//         {
//             this.reference = reference;
//             this.text = text;
//         }

//         public string Reference
//         {
//             get { return reference; }
//         }

//         public string Text
//         {
//             get { return text; }
//         }
//     }

//     class Scripture
//     {
//         private List<Verse> verses;

//         public Scripture(List<Verse> verses)
//         {
//             this.verses = verses;
//         }

//         public List<Verse> Verses
//         {
//             get { return verses; }
//         }
//     }

//     class Program
//     {
//         static void Main(string[] args)
//         {
//             Scripture scripture = new Scripture(new List<Verse>()
//             {
//                 new Verse("John 3:16", "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life."),
//                 new Verse("Proverbs 3:5-6", "Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight.")
//             });

//             string[] words;
//             bool[] hidden;
//             while (true)
//             {
//                 Console.Clear();
//                 foreach (Verse verse in scripture.Verses)
//                 {
//                     Console.WriteLine(verse.Reference);
//                     words = verse.Text.Split(' ');
//                     hidden = new bool[words.Length];
//                     for (int i = 0; i < words.Length; i++)
//                     {
//                         if (hidden[i])
//                         {
//                             Console.Write("_____ ");
//                         }
//                         else
//                         {
//                             Console.Write(words[i] + " ");
//                         }
//                     }
//                     Console.WriteLine();
//                 }
//                 Console.WriteLine("\nPress the enter key or type quit: ");
//                 string input = Console.ReadLine();
//                 if (input.ToLower() == "quit")
//                 {
//                     break;
//                 }
//                 int hiddenCount = 0;
//                 foreach (Verse verse in scripture.Verses)
//                 {
//                     words = verse.Text.Split(' ');
//                     for (int i = 0; i < words.Length; i++)
//                     {
//                         if (!hidden[i])
//                         {
//                             hidden[i] = true;
//                             hiddenCount++;
//                             break;
//                         }
//                     }
//                     if (hiddenCount == words.Length)
//                     {
//                         break;
//                     }
//                 }
//                 if (hiddenCount == words.Length)
//                 {
//                     break;
//                 }
//             }
//         }
//     }
// }



// using System;
// using System.Collections.Generic;
// using System.Linq;

// class Program
// {
//     static void Main(string[] args)
//     {
//         Scripture scripture = new Scripture
//         {
//             Reference = "John 3:16",
//             Text = "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life."
//         };

//         string[] words = scripture.Text.Split(' ');
//         List<int> hiddenWords = new List<int>();
//         Random rand = new Random();

//         while (hiddenWords.Count < words.Length)
//         {
//             Console.Clear();

//             for (int i = 0; i < words.Length; i++)
//             {
//                 if (hiddenWords.Contains(i))
//                 {
//                     Console.Write("____ ");
//                 }
//                 else
//                 {
//                     Console.Write(words[i] + " ");
//                 }
//             }

//             Console.WriteLine("\n\n" + scripture.Reference);

//             Console.Write("\nPress enter to hide another word, or type 'quit' to exit: ");
//             string input = Console.ReadLine();

//             if (input == "quit")
//             {
//                 break;
//             }

//             hiddenWords.Add(rand.Next(words.Length));
//         }
//     }
// }

// class Scripture
// {
//     public string Reference { get; set; }
//     public string Text { get; set; }
// }

// class Verse
// {
//     public int Start { get; set; }
//     public int End { get; set; }

//     public Verse(int start, int end)
//     {
//         Start = start;
//         End = end;
//     }
// }



// using System;
// using System.Collections.Generic;
// using System.Linq;

// namespace ScriptureApp
// {
//     class Scripture
//     {
//         public string Reference { get; set; }
//         public string Text { get; set; }

//         public Scripture(string reference, string text)
//         {
//             Reference = reference;
//             Text = text;
//         }
//     }

//     class Program
//     {
//         static void Main(string[] args)
//         {
//             Scripture scripture = new Scripture("John 3:16", "For God so loved the world that he gave his only begotten Son, that whoever believes in him should not perish but have everlasting life.");
//             string[] words = scripture.Text.Split(' ');
//             List<int> hiddenWords = new List<int>();
//             bool allHidden = false;

//             while (!allHidden)
//             {
//                 Console.Clear();
//                 Console.WriteLine(scripture.Reference);

//                 string text = scripture.Text;
//                 if (hiddenWords.Count < words.Length)
//                 {
//                     int randomIndex = new Random().Next(0, words.Length);
//                     while (hiddenWords.Contains(randomIndex))
//                     {
//                         randomIndex = new Random().Next(0, words.Length);
//                     }
//                     hiddenWords.Add(randomIndex);
//                     words[randomIndex] = "____";
//                 }
//                 text = string.Join(" ", words);
//                 Console.WriteLine(text);

//                 Console.WriteLine("\nPress enter to hide another word, type quit to exit:");
//                 string input = Console.ReadLine();
//                 if (input.ToLower() == "quit")
//                 {
//                     break;
//                 }

//                 allHidden = hiddenWords.Count == words.Length;
//             }
//         }
//     }
// }// 


// using System;
// using System.Linq;

// class Scripture
// {
//     public string Reference { get; set; }
//     public string Text { get; set; }

//     public Scripture(string reference, string text)
//     {
//         Reference = reference;
//         Text = text;
//     }
// }

// class Program
// {
//     static void Main(string[] args)
//     {
//         Scripture scripture = new Scripture("John 3:16", "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.");
//         string[] words = scripture.Text.Split(' ');

//         while (words.Any(w => w != ""))
//         {
//             Console.Clear();
//             Console.WriteLine(scripture.Reference);
//             Console.WriteLine(string.Join(" ", words));

//             Console.Write("\nPress enter to hide a word or type quit to end: ");
//             string input = Console.ReadLine();

//             if (input == "quit")
//             {
//                 break;
//             }

//             int index = new Random().Next(words.Length);
//             if (words[index] != "")
//             {
//                 words[index] = "";
//             }
//         }

//         Console.Clear();
//         Console.WriteLine("All words have been hidden!");
//     }
// }