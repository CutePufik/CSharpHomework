using System;
using Homework8;


class MyClass
{
    static void Main(string[] args)
    {
        
        // task1
        // AgileLinkedList<int> list = new(new[] { 1, 2, 2, 13 });
        // Console.WriteLine(list);
        
        // task2
        // AgileLinkedList<int> list1 = new(new[] { 1 });
        // list1.addFirst(666);
        // Console.WriteLine(list1);
        //
        // list1.addLast(666);
        // Console.WriteLine(list1);
        // Console.WriteLine(list1.isSymmetric());
        //
        // list1.addLast(666);
        // Console.WriteLine(list1);
        // Console.WriteLine(list1.isSymmetric());
        
        
        //task 3
        // AgileLinkedList<int> list3 = new(new[] { 1,1,2 });
        // list3.insertAfterPosition(3,666);
        // Console.WriteLine(list3);
        
        
        // AgileLinkedList<int> list4 = new(new[] { 1,1,1000 });
        // Console.WriteLine(list4);
        // list4.removeAtPosition(3);
        // Console.WriteLine(list4);
        
        
        // task4
        // AgileLinkedList<int> list5 = new(new[] { 1,2,3,4 });
        // list5.shiftLeft(10);
        // Console.WriteLine(list5);
        
        //task5
        // AgileLinkedList<int> list6 = new(new[] { 1,2,3,4 });
        // list6.reverse();
        // Console.WriteLine(list6);
        
        //task 7
        AgileLinkedList<int> list7 = new(new[] { 1,2,3,4 });
        var a = list7.getRandomElem();
        Console.WriteLine(a.ToString());

    }
}