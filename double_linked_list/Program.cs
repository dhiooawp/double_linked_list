using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace double_linked_list
{
    class Node
    {
        /* Node class represents the node of doubly linked list.
         * it consists of the information part and links to 
         * its succeeding and preceeding
         * in terms of the next and previous*/
        public int noMhas;
        public string name;
        //Point to succeding node
        public Node next;
        //Point to preceeding node
        public Node prev;
    }

    class DoubleLinkedList
    {
        Node START;
        public DoubleLinkedList()
        {
            START = null;
        }
        public void addNode()
        {
            int nim;
            string nm;
            Console.Write("\nEnter the roll number of the student: ");
            nim = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nEnter the name of the student: ");
            nm = Console.ReadLine();
            Node newNode = new Node();
            newNode.noMhas = nim;
            newNode.name = nm;

            if (START == null || nim <= START.noMhas)
            {
                if ((START != null) && (nim == START.noMhas))
                {
                    Console.WriteLine("\nDuplicate number not allowed");
                    return;
                }
                newNode.next = START;
                if (START != null)
                    START.prev = null;
                START = newNode;
                return;
            }
            Node previous, current;
            for (current = previous = START; current != null && nim >= current.noMhas; previous= current, current = current.next)
            {
                if (nim == current.noMhas)
                {
                    Console.WriteLine("\nDuplicate roll numbers not allowed");
                    return;
                }
            }
            newNode.next = current;
            newNode.prev = previous;

            if (current == null)
            {
                newNode.next = null;
                newNode.next = newNode;
                return;
            }
        }
        public bool Search(int rollNo, ref Node previous, ref Node current)
        {
            for (previous = current = START; current != null && rollNo != current.noMhas; previous = current, current = current.next) { }
            return (current != null);
        }
        public bool dellNode(int rollNo)
        {
            Node previous, current;
            previous = current = null;
            if (Search(rollNo, ref previous, ref current) == false)
                return false;
            if (current.next == null)
            {
                previous.next = null;
                return true;
            }
            if (current == START)
            {
                START = START.next;
                if (START != null)
                    START.prev = null;
                return true;
            }
            previous.next = current.next;
            current.next.prev = previous;
            return true;
        }
        public bool listEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
        }
        public void ascending()
        {
            if(listEmpty())
                Console.WriteLine("\nList is Empty");
            else
            {
                Console.WriteLine("\nReceord in the ascending order of" + "roll number are:\n");
                Node currentNode;
                for (currentNode = START; currentNode != null; currentNode = currentNode.next)
                    Console.Write(currentNode.noMhas + "" + currentNode.name + "\n");
            }
        }
        public void descending()
        {
            if(listEmpty())
                Console.WriteLine("\nList is empty");
            else
            {
                Console.WriteLine("\nRecord in the Descending order of" + "roll number are:\n");
                Node currentNode;
                for(currentNode = START; currentNode != null; currentNode = currentNode.next)
                { }

                while(currentNode != null)
                {
                    Console.Write(currentNode.noMhas + "" + currentNode.name + "\n");
                    currentNode = currentNode.prev;
                }
            }
        }
    }
}