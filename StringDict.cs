using System;
using System.Collections.Generic;

class Program
{
// Declaring dictionary named "StrDict"
    static Dictionary<string, string> StrDict = new Dictionary<string, string>();
// Initialize random number generator
    static Random random = new Random();

// Main method of the program, contains a do-while loop to display a menu for our switch statement
    static void Main()
    {
        bool exit = false;

        do
        {
// Display options for user
            Console.WriteLine("\n What would you like to do?");
            Console.WriteLine("a) Fill the Dictionary");
            Console.WriteLine("b) Look at the Dictionary");
            Console.WriteLine("c) Remove an Entry");
            Console.WriteLine("d) Add an Entry");
            Console.WriteLine("e) Change an Entry");
            Console.WriteLine("f) Sort Dictionary by Key");
            Console.WriteLine("X) Exit");

// Collect Input and go to correct helper method
            string UserChoice = Console.ReadLine();

            switch (UserChoice)
            {
                case "a":
                    FillDict();
                    break;
                case "b":
                    PrintDict();
                    break;
                case "c":
                    RemoveEntry();
                    break;
                case "d":
                    UserVal();
                    break;
                case "e":
                    ChangeEntry();
                    break;
                case "f":
                    SortDict();
                    break;
                case "X":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Wrong! Try again");
                    break;
            }
        } while (!exit);
    }

// Alphanumeric string generator, not directly called bbut used by other methods to create an entry
    static string NewString(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        char[] RandStr = new char[length];
        for (int i = 0; i < length; i++)
        {
            RandStr[i] = chars[random.Next(chars.Length)];
        }
        return new string(RandStr);
    }
// Numeric 4-digit string generator for generating keys, not directly callable
static string NumString(int length)
    {
        const string chars = "0123456789";
        char[] RandStr = new char[length];
        for (int i = 0; i < length; i++)
        {
            RandStr[i] = chars[random.Next(chars.Length)];
        }
        return new string(RandStr);
    }
// Method to fill the dictionary with 20 entries
    static void FillDict()
    {
        StrDict.Clear();
        for (int i = 0; i < 20; i++)
        {
            string key = NumString(4);
            string value = NewString(12);
            StrDict[key] = value;
        }
        Console.WriteLine("Dictionary Filled!");
    }
// Method to output the dictionary contents for the user
    static void PrintDict()
    {
        foreach (var Entry in StrDict)
        {
            Console.WriteLine($"Key: {Entry.Key}, Value: {Entry.Value}");
        }
    }
// Method to remove an entry from the dictionary by calling its key
    static void RemoveEntry()
    {
        Console.WriteLine("Which entry would you like to remove (Entry Key)?");
        string key = Console.ReadLine();
        if (StrDict.ContainsKey(key))
        {
            StrDict.Remove(key);
            Console.WriteLine($"Key '{key}' removed.");
        }
        else
        {
            Console.WriteLine($"Key '{key}' doesn't exist.");
        }
    }
// Method to add a key and value to the dictionary
    static void UserVal()
    {
        Console.WriteLine("What's the key?");
        string key = Console.ReadLine();
        Console.WriteLine("What's the value?");
        string value = Console.ReadLine();
        StrDict[key] = value;
        Console.WriteLine($"Key '{key}' added with value '{value}'.");
    }
// Method to change an entry in the dictionary by calling its key
    static void ChangeEntry()
    {
        Console.WriteLine("What is the key of the value you want changed?");
        string key = Console.ReadLine();
        if (StrDict.ContainsKey(key))
        {
            Console.WriteLine("What is the new value?");
            string UserVal = Console.ReadLine();
            StrDict[key] = UserVal;
            Console.WriteLine($"The value for key '{key}' has been changed to '{UserVal}'.");
        }
        else
        {
            Console.WriteLine($"Key '{key}' doesn't exist.");
        }
    }
// Method to sort dictionary by key value
    static void SortDict()
    {
        List<string> OrderedDict = new List<string>(StrDict.Keys);
        OrderedDict.Sort();
        Console.WriteLine("Ordered Dictionary:");
        foreach (var key in OrderedDict)
        {
            Console.WriteLine($"Key: {key}, Value: {StrDict[key]}");
        }
    }
}