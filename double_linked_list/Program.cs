using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }
    }
}