///<summary>
/// This C# console application returns the list of binary numbers
/// from 1 through n, with n being the user input
/// - Nikki Ki
///</summary>
using System;
using System.Text;
using System.Collections.Generic;

namespace BinaryPrinter
{
    /// <summary>
    /// Singly linked node class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class Node<T>
    {
        // data of node
        public T data;
        // node after current node
        public Node<T> next;

        public Node(T data, Node<T> next)
        {
            this.data = data;
            this.next = next;
        }
    }

    /// <summary>
    /// A FIFO Queue interface. This ADT is suitable for a
    /// singly linked queue.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    interface IQueue<T>
    {
        /// <summary>
        /// Add an element to the rear of the queue
        /// </summary>
        /// <param name="element"></param>
        /// <returns>
        /// the element that was enqueued
        /// </returns>
        T Push(T element);

        /// <summary>
        /// Remove and return the front element
        /// </summary>
        /// <throws>
        /// QueueUnderflowException if the queue is empty
        /// </throws>
        T Pop();

        /// <summary>
        /// Test if the queue is empty
        /// </summary>
        /// <returns>
        /// true if the queue is empty, false if not.
        /// </returns>
        bool IsEmpty();
    }

    /// <summary>
    /// A custom uncheck exception to represent situations where
    /// and illegal operation was performed on an empty queue.
    /// </summary>
    class QueueUnderflowException : Exception
    {
        public QueueUnderflowException() : base() { }

        public QueueUnderflowException(string message) : base(message) { }
    }

    /// <summary>
    /// A singly linked FIFO Queue.
    /// From Dale, Joyce and Weems "Object-Oriented Data Structures Using Java"
    /// Modified for CS 460 HW3
    /// See QueueInterface.java for documentation
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class LinkedQueue<T> : IQueue<T>
    {
        private Node<T> front;
        private Node<T> rear;

        public LinkedQueue()
        {
            front = null;
            rear = null;
        }

        /// <summary>
        /// Pushes node onto queue
        /// </summary>
        /// <param name="element"></param>
        /// <returns>enqueued element</returns>
        public T Push(T element)
        {
            if (element == null )
            {
                throw new NullReferenceException();
            }

            if ( IsEmpty() )
            {
                Node<T> tmp = new Node<T>(element, null);
                rear = front = tmp;
            }
            else
            {
                //General case
                Node<T> tmp = new Node<T>(element, null);
                rear.next = tmp;
                rear = tmp;
            }
            return element;
        }

        /// <summary>
        /// Removes and returns front element
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            T tmp;
            if ( IsEmpty() )
            {
                throw new QueueUnderflowException("The queue was empty when pop was invoked");
            }
            else if ( front == rear)
            {
                // one item in queue
                tmp = front.data;
                front = null;
                rear = null;
            }
            else
            {
                // General case
                tmp = front.data;
                front = front.next;
            }
            return tmp;
        }

        /// <summary>
        /// checks if queue is empty
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            if (front == null && rear == null )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    /// <summary>
    /// Main class, named Program
    /// 
    /// Original by Sumit Ghosh "An Interesting Method to Generate Binary Numbers from 1 to n"
    /// at https://www.geeksforgeeks.org/interesting-method-generate-binary-numbers-1-n/
    /// 
    /// Adapted for CS 460 HW3.  This simple example demonstrates the rather powerful
    /// application of Breadth-First Search to enumeration of states problems.
    /// 
    /// There are easier ways to generate a list of binary values, but this technique
    /// is very general and a good one to remember for other uses.
    /// </summary>
    class Program
    {
        /// <summary>
        /// * Print the binary representation of all numbers from 1 up to n.
        /// This is accomplished by using a FIFO queue to perform a level
        /// order(i.e.BFS) traversal of a virtual binary tree that
        /// looks like this:
        ///                 1
        ///             /       \
        ///            10       11
        ///           /  \     /  \
        ///         100  101 110  111
        ///         etc.
        /// and then storing each "value" in a list as it is "visited".
        /// </summary>
        /// <param name="n"></param>
        /// <returns>LinkedList of Binary values 1 through n</returns>
        static LinkedList<String> generateBinaryRepresentationList(int n)
        {
            // Create and empty queue of strings with which to perform the traversal
            LinkedQueue<StringBuilder> q = new LinkedQueue<StringBuilder>();
            // A list for returning the binary values
            LinkedList<String> output = new LinkedList<String>();

            if (n <= 1)
            {
                // if value is 0 or 1, then return it
                output.AddFirst(n.ToString());
                return output;
            }

            //Enqueue the first binary number. Use a dynamic string to avoid string concat
            q.Push(new StringBuilder("1"));

            // BFS
            while(n-- > 0)
            {
                // print the front of queue
                StringBuilder sb = q.Pop();
                output.AddLast(sb.ToString());

                //Make a copy
                StringBuilder sbc = new StringBuilder(sb.ToString());

                //Left child
                sb.Append('0');
                q.Push(sb);

                //Right child
                sbc.Append('1');
                q.Push(sbc);
            }
            return output;
        }

        /// <summary>
        /// Driver program to test above function
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int n = 10;
            if(args.Length < 1)
            {
                Console.WriteLine("Please invoke with the max value to print binary up to, like this:");
                Console.WriteLine("\t Program 12");
                return;
            }
            try
            {
                n = int.Parse(args[0]);
            }
            catch (FormatException)
            {
                Console.WriteLine("I'm sorry, I can't understand the number: " + args[0]);
                return;
            }

            LinkedList<string> output = new LinkedList<string>();
            try
            {
                 output = generateBinaryRepresentationList(n);
            }
            catch (QueueUnderflowException e)
            {
                Console.WriteLine(e.GetBaseException().Message);
                return;
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e);
                return;
            }

            // Print it right justified. Longest string is the last one.
            // Print enough spaces to move it over the correct distance.
            int maxLength = output.Last.Value.Length;
            foreach (String s in output)
            {
                for (int i = 0;i < maxLength - s.Length; i++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine(s);
            }
        }
    }
}
