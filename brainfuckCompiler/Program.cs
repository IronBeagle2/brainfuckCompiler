using System;
using System.Diagnostics;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.Title = "brain == fucked | (c) DEJVOSS Productions 2024";
        string input = ">+++++++++[<++++++++>-]<.>+++++++[<++++>-]<+.+++++++..+++.[-]>++++++++[<++++>-] <.>+++++++++++[<++++++++>-]<-.--------.+++.------.--------.[-]>++++++++[<++++>- ]<+.[-]++++++++++.";

        int[] mem = new int[30000];
        int pointer = 0;

        for (int j = 0; j < input.Length; j++)
        {
            if (input[j] == '+')
            {
                mem[pointer]++;
                Debug.WriteLine($"[{pointer}] + to {mem[pointer]}");
            }
            else if (input[j] == '-')
            {
                mem[pointer]--;
                Debug.WriteLine($"[{pointer}] - to {mem[pointer]}");
            }
            else if (input[j] == '>')
            {
                Debug.Write($"[{pointer}] > to ");
                pointer++;
                Debug.WriteLine($"[{pointer}]");
            }
            else if (input[j] == '<')
            {
                Debug.Write($"[{pointer}] < to ");
                pointer--;
                Debug.WriteLine($"[{pointer}]");
            }
            else if (input[j] == '[')
            {
                if (mem[pointer] != 0)
                {
                    continue;
                }
                int skip2 = 0;
                int skipPointer2 = j + 1;
                while (input[skipPointer2] != ']' || skip2 > 0)
                {
                    if (input[skipPointer2] == '[')
                    {
                        skip2++;
                    }
                    else if (input[skipPointer2] == ']')
                    {
                        skip2--;
                    }
                    skipPointer2++;
                    j = skipPointer2;
                }
            }
            else if (input[j] == ']')
            {
                if (mem[pointer] == 0)
                {
                    continue;
                }
                int skip = 0;
                int skipPointer = j - 1;
                while (input[skipPointer] != '[' || skip > 0)
                {
                    if (input[skipPointer] == ']')
                    {
                        skip++;
                    }
                    else if (input[skipPointer] == '[')
                    {
                        skip--;
                    }
                    skipPointer--;
                    j = skipPointer;
                }
            }
            else if (input[j] == '.')
            {
                Console.Write((char)mem[pointer]);
                Debug.WriteLine($"print {mem[pointer]} (\'{(char)mem[pointer]}\') at [{pointer}]");
            }
            else if (input[j] != ',')
            {
            }
        }
        Console.WriteLine();
        for (int i = 0; i < mem.Length; i++)
        {
            if (mem[i] != 0)
            {
                Console.WriteLine(i + "  " + mem[i]);
            }
        }
        Console.ReadLine();
        Console.Clear();
        Main(args);
    }
}