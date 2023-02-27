// using System;
// class Program 
// {
//     static void Main(string[] args)
//     {
//         var p = new Person();
//         var s = new Student();

//         Console.WriteLine(p.GetName());
//         Console.WriteLine(s.GetName());
//     }
// }

// // Parent class, supper class, base class
// class Person {
//     protected string _name;
//     public Person (string n) {
//         _name = n;
//     }
//     public string GetName() {
//         return _name;
//     }
// }

// // child class
// // sub class
// class Student: Person {
//     private int _number;
//     public Student(string name, int number): base(name) {
//         _number = number;
//     }
// }