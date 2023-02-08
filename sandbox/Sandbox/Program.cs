using System;

class Program
{    static void Main(string[] args) {
        
        // var divider =  new IntegerDivision();
        // divider.lhs = 10;
        // divider.rhs = 1;
        // divider.DisplayResult();

        // divider.lhs = 0;
        // divider.rhs = 100;
        // divider.DisplayResult();

        // divider.lhs = 5;
        // divider.rhs = 0;
        // divider.DisplayResult();

        // divider.lhs = 25;
        // divider.rhs = 5;
        // divider.DisplayResult();
    }
}

class IntegerDivision {
    private int _lhs;
    private int _rhs;

    public int GetLHS(int newLHS) {
        return _lhs;
    }
    public void setLHS() {
        
    }

    public int Result() {
        return _lhs / _rhs;
    }

    public void DisplayResult() {
        var result = Result();
        Console.WriteLine($"{_lhs} divided by {_rhs} is {result}");
    }
}


//     static void Main(string[] args)
//     {
//         var account = new Account(); 
        
//     }
// }

// class Account {
//     public int balance = 0;

//     public void Deposit(int amount) {
//         balance += amount;
//     }
// }
