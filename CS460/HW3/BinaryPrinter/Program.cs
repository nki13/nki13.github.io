using System;

namespace BinaryPrinter
{

    class Node
    {
        public object data;
        public Node next;

        public Node(object data, Node next)
        {
            this.data = data;
            this.next = next;
        }
    }

    interface IQueue<T>
    {
        T push(T element);

        object pop();

        bool isEmpty();


    }

    class QueueUnderflowException : System.Exception
    {
        public QueueUnderflowException() : base() { }

        public QueueUnderflowException(string message) : base(message) { }
    }

    class LinkedList<T> : IQueue<T>
    {
        private Node front;
        private Node rear;

        public T push(T element)
        {
            if (element == null )
            {
                throw new NullReferenceException();
            }
            
            if ( isEmpty() )
            {
                Node tmp = new Node(element, null);
            }
            else
            {
                Node tmp = new Node(element, null);
                rear.next = tmp;
                rear = tmp;
            }
            return element;
        }

        public object pop()
        {
            object tmp;
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
        static void Main(string[] args)
        {
        }
    }
}
