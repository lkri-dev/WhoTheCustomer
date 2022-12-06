using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

public class Finder
{
    /// <summary>
    /// Method that n'th customer from the Last in line by reversing the linked list.
    /// </summary>
    /// <param name="customer">The customer object of the first in line</param>
    /// <param name="numberFromRight">The number of the customer to find</param>
    /// <returns>The GamerTag of the customer</returns>
    public string FindFromLeftReverseList(Customer customer, int numberFromLeft)
    {
        Customer previous = null, current = customer, next = null;

        while (current != null)
        {
            next = current.Next;
            current.Next = previous;
            previous = current;
            current = next;
        }
        current = previous;

        return FindFromRight(current, numberFromLeft);
    }
    /// <summary>
    /// Method that n'th customer from the first in line.
    /// </summary>
    /// <param name="customer">The customer object of the first in line</param>
    /// <param name="numberFromRight">The number of the customer to find</param>
    /// <returns>The GamerTag of the customer</returns>
    public string FindFromRight(Customer customer, int numberFromRight)
    {
        Customer searchedForCustomer = null;
        // Runs through the linked list to find the n'th costumer in the linked list.
        for (int i = 1; i <= numberFromRight; i++)
        {
            searchedForCustomer = customer.Next;
        }
        return searchedForCustomer.Gamertag;
    }
    /// <summary>
    /// Method that n'th customer from the Last in line by making a new reversed queue.
    /// </summary>
    /// <param name="customer">The customer object of the first in line</param>
    /// <param name="numberFromRight">The number of the customer to find</param>
    /// <returns>The GamerTag of the customer</returns>
    public string FindFromLeftNewReversedList(Customer customer, int numberFromLeft)
    {
        CustomerQueue queue = new CustomerQueue();
        List<string> gamerTags = new List<string>();
        while (customer != null)
        {
            gamerTags.Add(customer.Gamertag);
            customer = customer.Next;
        }
        queue.MakeQueue(gamerTags);
        return FindFromRight(queue.firstCustomer, numberFromLeft);
    }
}

/*
 * This is an implementation of a Singly linked list.
 * Note: I think there is some confusion about right and left here.
 *       In the example it looks like the last customer in line is the right most customer and has no referances.
 *       So the example finds the n'th customer from the left not the right is was confusing.
 */
public class CustomerQueue
{
    public Customer firstCustomer;

    public void MakeQueue(IEnumerable<string> gamerTags)
    {
        Customer currentCustomer = null;
        foreach (string gamerTag in gamerTags) {
            currentCustomer = new Customer(currentCustomer, gamerTag);
        }
        firstCustomer = currentCustomer;
    }
}

public class Customer
{
    public Customer Next { get; set; }
    public string Gamertag { get; }

    public Customer(Customer next, string gamertag)
    {
        Next = next;
        Gamertag = gamertag;
    }
}