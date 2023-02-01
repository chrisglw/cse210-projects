using System;

class Program
{
    static void Main(string[] args)
    {
        var account = new Account(); 
        
    }
}

class Account {
    public int balance = 0;

    public void Deposit(int amount) {
        balance += amount;
    }
}