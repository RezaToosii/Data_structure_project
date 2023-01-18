using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structure_Project
{
    class Node                                              //Definition Node
    {
        public int data;
        public Node next;
    }
    class Link_list                                         //Definition Link list base of queue & stack
    {
        private Node first;                                 //Node first and use this node to find other nodes
        public Node intToNode(int x)
        {
            Node p = new Node();
            p.data = x;
            p.next = null;
            return p;
        }                     //input int x ---> output Node with x data
        public void add_End(Node x)
        {
            Node p = new Node();
            p = first;
            if (p == null)                                  //if link list empty
            {
                first = x;
                x.next = null;
                return;
            }
            while (p.next != null)
            {
                p = p.next;
            }
            p.next = x;
            x.next = null;
        }                      //add Node to last of Link list
        public void add_First(int x)
        {
            Node p = new Node();                            //add first of link list
            p.data = x;
            p.next = first;
            first = p;                                      //change first to new node
        }                     //add Node to last of Link list
        public void delete_First ()
        {
            Node p = new Node();
            if (first == null)                              //if link list empty
            {
                Console.WriteLine("your List empty!");
                return;
            }
            first = first.next;
        }                      //Delete first node in link list
        public void delete_End()
        {
            Node p = first;
            Node last = null;
            if(p == null)                                   //if link list is empty
            {
                Console.WriteLine("your list empty");
                return;
            }
            if (p.next == null)                             //if link list has only 1 node
            {
                first = null;
                return;
            }
            while (p.next != null)
            {
                last = p;
                p = p.next;
            }
            last.next = null;
        }                         //Delete last node in link list
        public void delete(int x)
        {
            Node p = first;
            Node q = null;
            while (p != null)
            {
                if (p.data == x)
                {
                    if (q != null)                          
                    {
                        q.next = p.next;
                        p = p.next;
                    }
                    else
                    {                                       //if first has x data
                        first = p.next;
                        p = p.next;
                    }
                }
                else
                {
                    q = p;
                    p = p.next;
                }
            }
        }                        //Dellete specific node with X data
        public void print()
        {
            Node p = first;
            Console.Write("< ");
            while (p != null)
            {
                if (p == first)
                {
                    Console.Write(p.data);
                }
                else Console.Write(" , " + p.data);              
                p = p.next;
            }
            Console.Write(" >");
        }                              //print all node in link list
        public void Print_reverse()
        {
            Console.Write("< ");
            print_Reverse(first);                           
            Console.Write(" >");

        }                      //send first Node to "print_Reverse()"
        private void print_Reverse(Node p)
        {
            if (p == null) return;
            print_Reverse(p.next);                          //print with recursive function
            if (p == first)
            {
                Console.Write(p.data);
            }
            else Console.Write( p.data+" , " );
        }               //print all node in link list but reverse
        public bool IsEmpty()
        {
            if (first == null) return true;
            else return false;
        }                            //check link list to empty or full (1 = empty / 0 = full)
        public void Swap(int i , int j)
        {
            Node p = first;
            Node p1 = new Node();Node p2 = new Node(); Node p3 = new Node(); Node p4 = new Node(); Node p5 = new Node();
            if (i > j)
            {
                int x = i;
                i = j;
                j = x;
            }                                   //i must < j
            if (j == i) return;                             //if i = j we dont need to swap 
            if (j-i == 1)
            {
                for (int n = 1; n <= j; n++)
                {
                    if (n == i - 1)
                    {
                        p1 = p;
                        p = p.next;
                        p2 = p;
                        p = p.next;
                        p3 = p;
                        p = p.next;
                        p4 = p;
                        break;
                    }
                    p = p.next;
                }
                p1.next = p3;
                p3.next = p2;
                p2.next = p4;
                return;
            }                               //if dont have node between i & j
            if(j-i == 2)
            {
                for (int n = 1; n <= j; n++)
                {
                    if (n == i - 1)
                    {
                        p1 = p;
                        p = p.next;
                        p2 = p;
                        p = p.next;
                        p3 = p;
                        p = p.next;
                        p4 = p;
                        p = p.next;
                        break;
                    }
                    p = p.next;
                }
                p1.next = p4;
                p4.next = p3;
                p3.next = p2;
                p2.next = p;
                return;
            }                                //if only 1 node between i & j 
            for (int n = 1; n <= j; n++)
            {
                if (n == i - 1)
                {
                    p1 = p;
                    p = p.next;
                    p2 = p;
                    p = p.next;
                    p3 = p;
                    n += 2;
                }
                if( n == j-1)
                {
                    p4 = p;
                    p = p.next;
                    p5 = p;
                    p = p.next;
                    break;
                }
                p = p.next;
            }                
            p1.next = p5;
            p5.next = p3;
            p4.next = p2;
            p2.next = p;
            return;
        }                  //swap to node with index of i+1 & j+1 
        public int Size()
        {
            int x = 0;
            Node p = first;
            while (p != null)
            {
                x++;
                p = p.next;
            }
            return x;
        }                                //return size of link list
        public void addCycle(int index)
        {
            Node q = first;
            Node p = first;
            for (int i = 1; p.next != null;i++)             //find last node
            {
                if (i == index) q = p;                      //q = user node
                p = p.next;
            }
            p.next = q;                                     //last node next is q(user node)
        }                  //add cycle in link list next of last node is index
        public bool checkCycle() 
        {
            Node[] Finder = new Node[20];                   //change 20 to your max size of link list
            Node p = first;
            for (int i = 0; p != null; i++)                 //import unique node to array 
            {
                if (Array.IndexOf(Finder, p) == -1) Finder[i] = p;          //import unique node to array 
                else return true;                                           //if this node already exist in array this list has cycle
                p = p.next;
            }
            return false;
        }                        //check link list to find list has cycle or not
        public Node Remove()
        {
            Node last = null;
            if (first == null)                              //if list empty
            {
                Console.WriteLine("your stack empty");
                return null;
            }
            Node p = first;
            if (p.next == null)                             //if list has only 1 node
            {
                last = first;
                first = null;
                return last;
            }
            while (p.next != null)
            {
                last = p;
                p = p.next;
            }
            last.next = null;
            return p;
        }                             //remove last node in stack and only use in stack
        public Node returnFirst()
        {
            return first;
        }                        //no input just return first
        
    }
    class queue                                             //Definition queue
    {
        public queue(int maxSize)
        {
            this.maxSize = maxSize;
            Queue = new Link_list();
        }                        
        private Link_list Queue;                            //Definition
        private int maxSize = 10;
        public void add(int x)
        {
            if (Queue.Size() < maxSize)                     //check queue full or not
            { 
                Queue.add_End(Queue.intToNode(x));
            }
            else Console.WriteLine("your Queue is full!");
        }                          //add node to last of link list with x data
        public void delete()
        {
            if (Queue.Size() > 0)                           //check queue empty or not
            {
                Queue.delete_First();
            }
        }                            //delete first node in queue 
        public void print()
        {
            Queue.print();
        }                             //print queue
    }
    class stack                                             //Definition Stack
    {
        public stack(int maxSize)
        {
            this.maxSize = maxSize;
            Stack = new Link_list();
        }
        private Link_list Stack;                            //Definition
        private int maxSize = 10;
        public void add (int x)
        {
            if (Stack.Size() < maxSize)                     //check Stack full or not
            {
                Stack.add_End(Stack.intToNode(x));
            }
            else Console.WriteLine("your Stack is full!");
        }                          //add node with x data end of link list
        public Node remove()
        {
            if (Stack.Size() > 0)                           //check Stack empty or not
            {
                return Stack.Remove();
            }
            else Console.WriteLine("your stack is empty!");
            return null;
        }                             //remove last node in link list
        public bool isEmpty()
        {
            if (Stack.Size() == 0) return true;
            else return false;
        }                            //check stack to empty or full(1 = empty / 0 = full)
        public Node ReturnFirst()
        {
            return Stack.returnFirst();
        }                        //just return first
        public void printS(Node p)
        {
            if (p == null) return;
            printS(p.next);
            Console.WriteLine("       "+p.data + "\n     -----");
        }                       //print all node in stack

    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("wellcome to this program.\n");
            Link_list LS = new Link_list();
            Console.Write("Please enter your queue maxsize :");                 //get max size from user and create stack & queue
            queue Q = new queue(Convert.ToInt32(Console.ReadLine()));
            Console.Write("Please enter your Stack maxsize :");
            stack S = new stack(Convert.ToInt32(Console.ReadLine()));
            try                                    
            {                                                                   //list of service and user choose one of them
                Console.WriteLine("  1:Add end of list                  2:Add First of list ");
                Console.WriteLine("  3:Delete last node in list         4:Delete first node in list");
                Console.WriteLine("  5:Delete specific data             6:Print list");
                Console.WriteLine("  7:Print list reverse               8:List is empty?");
                Console.WriteLine("  9:Swap 2 node in list             10:Add a cycle in list");
                Console.WriteLine(" 11:Check list has cycle or not     12:Add to queue     \n 13:Delete from queue               14:Print queue");
                Console.WriteLine(" 15:Add to stack                    16:Remove from stack\n 17:Print stack                     18:Check the brackets");
                Console.WriteLine(" 19:Quit");
                Console.Write("\nWhich service you want use : ");
                int i = Convert.ToInt32(Console.ReadLine());
                for (; i != 19;)                                               //check user number to not out of range                   
                {
                    if (i > 19 || i < 1)                                        
                    {
                        Console.Write("service number must between 1 and 19.\nPlease enter again : ");
                        i = Convert.ToInt32(Console.ReadLine());                                        
                    }
                    else break;
                }
                int N;
                for (; i != 19;)                                                //a loop to user can choose multi time 
                {
                    switch (i)                                                  //LS = link list - Q = queue - S = Stack
                    {
                        case 1:                                                 //Add end of list
                            Console.Write("Please enter your node data :");
                            N = Convert.ToInt32(Console.ReadLine());
                            LS.add_End(LS.intToNode(N));
                            Console.Write("Done.");
                            Console.ReadLine();
                            break;
                        case 2:                                                 //Add First of list
                            Console.Write("Please enter your node data :");
                            N = Convert.ToInt32(Console.ReadLine());
                            LS.add_First(N);
                            Console.Write("Done.");
                            Console.ReadLine();
                            break;
                        case 3:                                                 //Delete last node in list
                            LS.delete_End();
                            Console.Write("Done.");
                            Console.ReadLine();
                            break;
                        case 4:                                                 //Delete first node in list
                            LS.delete_First();
                            Console.Write("Done.");
                            Console.ReadLine();
                            break;
                        case 5:                                                 //Delete specific data
                            Console.Write("Please enter your node data :");
                            N = Convert.ToInt32(Console.ReadLine());
                            LS.delete(N);
                            Console.Write("Done.");
                            Console.ReadLine();
                            break;
                        case 6:                                                 //Print list
                            LS.print();
                            Console.ReadLine();
                            break;
                        case 7:                                                 //Print list reverse
                            LS.Print_reverse();
                            Console.ReadLine();
                            break;
                        case 8:                                                 //list full or empty
                            if (LS.IsEmpty()) Console.WriteLine("Yes your list is empty.");
                            else Console.WriteLine("No your list has some member.");
                            Console.ReadLine();
                            break;
                        case 9:                                                 //swap two node
                            Console.Write("Please enter first index of nodes you want to swap : ");
                            int N1 = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Please enter second index of nodes you want to swap : ");
                            int N2 = Convert.ToInt32(Console.ReadLine());
                            LS.add_First(0);                                    //for fix bug
                            LS.add_End(LS.intToNode(0));
                            LS.Swap(N1+1, N2+1);
                            LS.delete_End();                                    //for return to normal
                            LS.delete_First();
                            Console.Write("Done.");
                            Console.ReadLine();
                            break;
                        case 10:                                                //add a cycle in list
                            Console.Write("Please enter index of node to make cycle to it : ");
                            LS.addCycle(Convert.ToInt32(Console.ReadLine()));
                            Console.Write("Done.");
                            Console.ReadLine();
                            break;
                        case 11:                                                //check list has cycle or not
                            if (LS.checkCycle()) Console.WriteLine("List have cycle.");
                            else Console.WriteLine("List dont have cycle.");
                            Console.ReadLine();
                            break;  
                        case 12:                                                //add to queue
                            Console.Write("Please enter your node data :");
                            N = Convert.ToInt32(Console.ReadLine());
                            Q.add(N);
                            Console.Write("Done.");
                            Console.ReadLine();
                            break;
                        case 13:                                                //delete from queue
                            Q.delete();
                            Console.Write("Done.");
                            Console.ReadLine();
                            break;
                        case 14:                                                //print queue
                            Q.print();
                            Console.ReadLine();
                            break;
                        case 15:                                                //add to stack
                            Console.Write("Please enter your node data :");
                            N = Convert.ToInt32(Console.ReadLine());
                            S.add(N);
                            Console.Write("Done.");
                            Console.ReadLine();
                            break;
                        case 16:                                                //Remove from stack
                            S.remove();
                            Console.Write("Done.");
                            Console.ReadLine();
                            break;
                        case 17:                                                //Print stack
                            S.printS(S.ReturnFirst());
                            Console.ReadLine();
                            break;
                        case 18:                                                //Check the brackets
                            char a = 'T';
                            Console.Write("Please enter bracket (= to end) :"); //get bracket from user
                            a = Convert.ToChar(Console.ReadLine());
                            for (; a != '=';)                                   //for user can enter multi bracket
                            {
                                if (a == ')' || a == ']' || a == '}')           //if user enter this params
                                {
                                    int t = S.remove().data;
                                    if (t == '(' && a == ')' || t == '[' && a == ']' || t == '{' && a == '}') ; //last node Should this params
                                    else
                                    {
                                        Console.WriteLine("brackets not balance.");
                                        Console.ReadLine();
                                        break;
                                    }
                                }
                                else S.add(a);
                                Console.Write("Please enter bracket (= to end) :");
                                a = Convert.ToChar(Console.ReadLine());
                            }
                            if (a != '=') break;
                            if (S.isEmpty() == true) Console.WriteLine("brackets balance.");
                            else Console.WriteLine("brackets not balance.");
                            Console.ReadLine();
                            break;
                    }
                    Console.Clear();
                    Console.WriteLine("  1:Add end of list                  2:Add First of list ");
                    Console.WriteLine("  3:Delete last node in list         4:Delete first node in list");
                    Console.WriteLine("  5:Delete specific data             6:Print list");
                    Console.WriteLine("  7:Print list reverse               8:List is empty?");
                    Console.WriteLine("  9:Swap 2 node in list             10:Add a cycle in list");
                    Console.WriteLine(" 11:Check list has cycle or not     12:Add to queue     \n 13:Delete from queue               14:Print queue");
                    Console.WriteLine(" 15:Add to stack                    16:Remove from stack\n 17:Print stack                     18:Check the brackets");
                    Console.WriteLine(" 19:Quit");
                    Console.Write("\nWhich service you want use : ");
                    i = Convert.ToInt32(Console.ReadLine());
                    for (; i != 19; )
                    {
                        if (i > 19 || i < 1)
                        {
                            Console.Write("service number must between 1 and 19.\nPlease enter again : ");
                            i = Convert.ToInt32(Console.ReadLine()); 
                        }
                        else break;
                    }
                }
                Console.WriteLine("Thanks for using my term project program.");
                Console.ReadLine();
            }
            catch (Exception e) 
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }
    }
}