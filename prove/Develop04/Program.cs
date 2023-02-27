using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Welcome to the activity app!");
        while(true) {
        Console.Clear();
        Console.WriteLine("Menu Options: ");
        Console.WriteLine("1. Start breathing activity ");
        Console.WriteLine("2. Start reflecting activity ");
        Console.WriteLine("3. Start listing activity ");
        Console.WriteLine("4. Quit ");
        Console.Write("Select a choice from the menu: ");

        int choice = int.Parse(Console.ReadLine());

        switch (choice)
            {
            case 1:
            var breathingActivity = new BreathingActivity();
            breathingActivity.StartBreathingActivity();
                break;
            case 2:
            var reflectionActivity = new ReflectionActivity();
            reflectionActivity.StartReflectionActivity();
                break;
            case 3:
            var listingActivity = new ListingActivity();
            listingActivity.StartListingActivity();
                break;
            case 4:
            Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid choice.");
                return;
            }
        }
    }
}



public abstract class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;
    protected List<string> _animation;

    public Activity()
    {
        Animation();
    }

    public void ShowIntro()
    {
        Console.WriteLine($"Welcome to the {_name} Activity.");
        Console.WriteLine();
        Console.WriteLine($"{_description}");
        Console.WriteLine();
        SetDurationFromUser();
        Console.Clear();
        Console.WriteLine("Get Ready...");
        runAnimation();
        Console.WriteLine();
    }

    public void ShowEnding()
    {
        Console.WriteLine("Well done!!");
        runAnimation();
        Console.WriteLine();
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name} Activity.");
        runAnimation();
    }

    protected void Pause(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write(".");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    protected void SetDurationFromUser()
    {
        Console.WriteLine($"How long, in seconds, would you like for your {_name} session? (10 seconds minimum)");
        string input = Console.ReadLine();
        while (!int.TryParse(input, out _duration))
        {
            Console.WriteLine("Invalid input, please enter a valid integer:");
            input = Console.ReadLine();
        }
    }

    protected void Animation() {
        _animation = new List<string>();
        _animation.Add("-"); // -\|/-
        _animation.Add("\\");
        _animation.Add("|");
        _animation.Add("/");
        _animation.Add("-");
        _animation.Add("\\");
        _animation.Add("|");
        // _animation.Add("|");
        // _animation.Add("\\");
        // _animation.Add("-");
        // _animation.Add("/");
        // _animation.Add("|");
        // _animation.Add("\\");
        // _animation.Add("-");

    }

    public List<string> getAnimation() {
        return _animation;
    }

    public void runAnimation() {
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(5);
        int i = 0;
        while (DateTime.Now <= endTime) {
            string s = _animation[i];
            Console.Write(s);
            Thread.Sleep(500);
            Console.Write("\b \b");

            i++;

            if (i >= _animation.Count){
                i = 0;
            }
        }
    }
    public void runAnimationLong() {
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(15);
        int i = 0;
        while (DateTime.Now <= endTime) {
            string s = _animation[i];
            Console.Write(s);
            Thread.Sleep(500);
            Console.Write("\b \b");

            i++;

            if (i >= _animation.Count){
                i = 0;
            }
        }
    }

    public void runAnimationNumbers() {
        for (int j = 5; j > 0; j--) {
            Console.Write(j);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
    // public void runAnimation() {
    //     foreach (string s in _animation) {
    //         Console.Write(s);
    //         Thread.Sleep(500);
    //         Console.Write("\b \b");
    //     }
    // }


    // public void runAnimation() {
    //     Console.Clear();
    //     Console.WriteLine("Get Ready...");
    //     for (int i = 0; i <_animation.Count; i++) {
    //         Console.Write(_animation[i]);
    //         Thread.Sleep(500);
    //         Console.Write("\b \b");
    //     }
    // }

    protected abstract void SetDuration();
}


public class BreathingActivity : Activity
{
    public BreathingActivity() : base()
    {
        _name = "Breathing";
        _description = "This Activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    protected override void SetDuration()
    {
        throw new NotImplementedException();
    }

    public void StartBreathingActivity()
    {
        Console.Clear();
        base.ShowIntro();

        int secondsPerBreath = 12;
        int breathCount = 0;
        int elpasedSeconds = 0;

        while (elpasedSeconds < _duration)
        {
            Console.Write("Breathe in...");
            for (int j = 4; j > 0; j--){
                Console.Write(j);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
            Console.WriteLine();
            Console.Write("Breathe out...");
            for (int j = 4; j > 0; j--){
                Console.Write(j);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
            Console.WriteLine();
            Console.WriteLine();
            
            // Console.WriteLine("Breathe in...");
            // Pause(3);
            // Console.WriteLine("3...");
            // Pause(1);
            // Console.WriteLine("2...");
            // Pause(1);
            // Console.WriteLine("1...");
            // Pause(1);

            // Console.WriteLine("Breathe out...");
            // Pause(3);
            // Console.WriteLine("3...");
            // Pause(1);
            // Console.WriteLine("2...");
            // Pause(1);
            // Console.WriteLine("1...");
            // Pause(1);

            breathCount++;
            elpasedSeconds += secondsPerBreath;
        }
        base.ShowEnding();
    }
}

public class ReflectionActivity : Activity
{
    private Random _random;
    private List<string> _reflectingQuestions;
    private List<string> _reflectingMessage;

    public ReflectionActivity() : base()
    {
        _name = "Reflection";
        _description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
        _random = new Random();

        _reflectingMessage = new List<string>() {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        _reflectingQuestions = new List<string>() {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };
    }

    public string GetReflectingQuestion()
    {
        int index = _random.Next(_reflectingQuestions.Count);
        return _reflectingQuestions[index];
    }

    public string GetReflectingMessage()
    {
        int index = _random.Next(_reflectingMessage.Count);
        return _reflectingMessage[index];
    }

    public void StartReflectionActivity()
    {
        Console.Clear();
        base.ShowIntro();

        Console.WriteLine("Consider the following prompt:");
        string prompt = GetReflectingMessage();
        Console.WriteLine();
        Console.WriteLine($"--- {prompt} ---");
        Console.WriteLine();

        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();

        Console.WriteLine("Now ponder on each of the following questions as they related to this experience.");
        Console.Write("You may begin in: ");
        for (int j = 4; j > 0; j--) {
            Console.Write(j);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
        Console.Clear();

        string question1 = GetReflectingQuestion();
        Console.Write($"> {question1} ");
        base.runAnimationLong();
        Console.WriteLine();
        string question2 = GetReflectingQuestion();
        Console.Write($"> {question2} ");
        base.runAnimationLong();
        Console.WriteLine();
        Console.WriteLine();

        base.ShowEnding();
        Console.WriteLine();
    }

    protected override void SetDuration()
    {
        throw new NotImplementedException();
    }
}




public class ListingActivity : Activity
{
    private string[] prompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base()
    {
        _name = "Listing";
        _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
    }

    protected override void SetDuration()
    {
        throw new NotImplementedException();
    }

    protected new void SetDurationFromUser()
    {
        base.SetDurationFromUser();
    }

    public void StartListingActivity()
    {
        Console.Clear();
        base.ShowIntro();
        Random random = new Random();
        int promptIndex = random.Next(prompts.Length);
        string prompt = prompts[promptIndex];

        Console.WriteLine("List as many responses you an to the following prompt:");
        Console.WriteLine($"--- {prompt} ---");
        Console.Write("You may begin in...");
        base.runAnimationNumbers();
        Console.WriteLine();


        int itemNumber = 0;
        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string item = Console.ReadLine();
            itemNumber++;
        }

        Console.WriteLine($"You listed {itemNumber} items!");
        Console.WriteLine();
        base.ShowEnding();
    }
}