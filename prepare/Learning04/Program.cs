using System;

class Program
{
    static void Main(string[] args)
    {
        // Assignment assignment1 = new Assignment("Samauel Bennett", "Multiplication");
        // Console.WriteLine(assignment1.GetSummary());

        MathAssignment assignment2 = new MathAssignment("Roberto Rodriguez", "Fractions", "7.3", "8-19");
        Console.WriteLine(assignment2.GetSummary());
        Console.WriteLine(assignment2.GetHomeworkList());
        Console.WriteLine();

        WritingAssignment assignment3 = new WritingAssignment("Mary Waters", "European History", "The causes of World War II");
        Console.WriteLine(assignment3.GetSummary());
        Console.WriteLine(assignment3.GetWritingInformation());
    }
}

public class Assignment {
    protected string _studentName;
    private string _topic;

    public Assignment(string studentName, string topic) {
        _studentName = studentName; 
        _topic = topic;
    }
    public string GetSummary() {
        return $"{_studentName} - {_topic}";
    }
}

public class MathAssignment : Assignment {
    private string _textbookSection;
    private string _problems;

    public MathAssignment(string studentName, string topic, string textbookSection, string problems) : base(studentName, topic) {
        _textbookSection = textbookSection;
        _problems = problems;
    }
    public string GetHomeworkList() {
        return $"Section {_textbookSection} Problems {_problems}";
    }
}

public class WritingAssignment: Assignment {
    private string _title;
    public WritingAssignment(string studentName, string topic, string title) : base (studentName, topic) {
        _title = title;
    }
    public string GetWritingInformation() {
        return $"{_title} by {_studentName}";
    }
}