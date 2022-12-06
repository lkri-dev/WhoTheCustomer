using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

public class Program
{
    public static void Main(string[] args)
    {
        CustomerQueue queue = new CustomerQueue();
        var gamerTags = new List<string>()
                    {
                        "ExoticWhale", 
                        "TrainedPony", 
                        "FlashyRogue", 
                        "Herobot"
                    };
        queue.MakeQueue(gamerTags);

        Finder finder = new Finder();

        Console.WriteLine("FindFromRight: {0,30}", finder.FindFromRight(queue.firstCustomer, 3));
        Console.WriteLine("FindFromLeftNewReversedList: {0,16}", finder.FindFromLeftNewReversedList(queue.firstCustomer, 3));
        Console.WriteLine("FindFromLeftReverseList: {0,20}", finder.FindFromLeftReverseList(queue.firstCustomer, 3));
    }
}