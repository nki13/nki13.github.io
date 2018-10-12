using System;
using System.Text;
using System.Collections.Generic;

namespace BinaryPrinter
{

    class Node<T>
    {
        public T data;
        public Node<T> next;

        public Node(T data, Node<T> next)
        {
            this.data = data;
            this.next = next;
        }
    }

    interface IQueue<T>
    {
        T push(T element);

        T pop();

        bool isEmpty();


    }

    class QueueUnderflowException : Exception
    {
        public QueueUnderflowException() : base() { }

        public QueueUnderflowException(string message) : base(message) { }
    }

    class LinkedQueue<T> : IQueue<T>
    {
        private Node<T> front;
        private Node<T> rear;

        public T push(T element)
        {
            if (element == null )
            {
                throw new NullReferenceException();
            }
            
            if ( isEmpty() )
            {
                Node<T> tmp = new Node<T>(element, null);
            }
            else
            {
                Node<T> tmp = new Node<T>(element, null);
                rear.next = tmp;
                rear = tmp;
            }
            return element;
        }

        public T pop()
        {
            T tmp;
            if ( isEmpty() )
            {
                throw new QueueUnderflowException("The queue was empty when pop was invoked");
            }
            else if ( front == rear)
            {
                tmp = front.data;
                front = null;
                rear = null;
            }
            else
            {
                tmp = front.data;
                front = front.next;
            }
            return tmp;
        }

        public bool isEmpty()
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

    class Program
    {
        static LinkedList<String> generateBinaryRepresentationList(int n)
        {
            LinkedQueue<StringBuilder> q = new LinkedQueue<StringBuilder>();

            LinkedList<String> output = new LinkedList<String>();

            if (n <= 1)
            {
                output.AddFirst(n.ToString());
                return output;
            }

            q.push(new StringBuilder("1"));

            while(n-- > 0)
            {

                StringBuilder sb = q.pop();
                output.AddLast(sb.ToString());

                StringBuilder sbc = new StringBuilder(sb.ToString());

                //Left child
                sb.Append('0');
                q.push(sb);
                //Right child
                sbc.Append('1');
                q.push(sbc);
            }
            return output;
        }

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
            LinkedList<String> output = generateBinaryRepresentationList(n);

            int maxLength = output.Last.Value.Length;

            foreach (String s in output)
            {
                for (int i = 0;i < maxLength - s.Length; i++)
                {
                    Console.WriteLine(" ");
                }
                Console.WriteLine(s);
            }
        }
    }
}
