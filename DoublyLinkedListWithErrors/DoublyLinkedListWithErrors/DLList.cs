using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoublyLinkedListWithErrors
{
    public class DLList
    {
        public DLLNode head { get; set; } // pointer to the head of the list
        public DLLNode tail { get; set; } // pointer to the tail of the list
        public DLList()
        {
            head = null;
            tail = null;
        } // constructor
        /*-------------------------------------------------------------------
        * The methods below includes several errors. Your  task is to write
        * unit test to discover these errors. During delivery the tutor may
        * add or remove errors to adjust the scale of the effort required by
        */
        public void AddToTail(DLLNode node)
        {
            if (head == null)
            {
                head = node;
                tail = node;
            }
            else
            {
                tail.next = node;
                node.previous = tail; // Corrected line
                tail = node;
            }
        }// end of addToTail

        public void AddToHead(DLLNode node)
        {
            if (head == null)
            {
                head = node;
                tail = node;
            }
            else
            {
                node.next = this.head;
                this.head.previous = node;
                head = node;
            }
        } // end of addToHead

        public void RemoveHead()
        {
            if (this.head == null) return;

            if (this.head.next != null)
            {
                this.head = this.head.next;
                this.head.previous = null;
            }
            else
            {
                this.head = null;
                this.tail = null;
            }
        } // removeHead

        public void RemoveTail()
        {
            if (this.tail == null) return;
            if (this.head == this.tail)
            {
                this.head = null;
                this.tail = null;
            }
            else
            {
                this.tail = tail.previous;
                if (this.tail != null)
                {
                    this.tail.next = null;
                }
            }
        } // remove tail
        public DLLNode Search(int num)
        {
            DLLNode p = head;
            while (p != null)
            {
                if (p.num == num)
                {
                    return p;
                }
                p = p.next;
            }
            return null;
        } // end of search (return pointer to the node);

        public void RemoveNode(DLLNode p)
        { // removing the node p.
            if (p == null)
            {
                return;
            }
            if (head == null)
            {
                return;
            }

            DLLNode current = head;
            while (current != null)
            {
                if (current == p)
                {
                    //removing head
                    head = p.next;
                    if (head != null)
                    {
                        head.previous = null;
                    }
                    else
                    {
                        //list becomes empty
                        tail = null;
                    }
                }
                else if (p == tail)
                {
                    //removing tail 
                    tail = p.previous;
                    if (tail != null)
                    {
                        tail.next = null;
                    }
                    else
                    {
                        //list becomes empty
                        head = null;
                    }
                }
                else
                {
                    // Removing a node in the middle
                    p.previous.next = p.next;
                    p.next.previous = p.previous;
                }
                // Clear references from the removed node
                p.next = null;
                p.previous = null;

                return; // Node removed, exit the method
            }
            current = current.next;
        } // end of remove a node

        public int Total()
        {
            DLLNode p = head;
            int tot = 0;
            while (p != null)
            {
                tot += p.num;
                p = p.next;
            }
            return (tot);
        } // end of total
    } // end of DLList class
}
