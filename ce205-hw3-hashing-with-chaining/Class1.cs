using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ce205_hw3_hashing_with_chaining
{
    public class Class1
    {
        public class HashSc
        {
            public class HashNode
            {
                int key;
                string data;
                HashNode next;
                public HashNode(int key, string data)
                {
                    this.key = key;
                    this.data = data;
                    next = null;
                }
                public int GetKey()
                {
                    return key;
                }
                public string GetData()
                {
                    return data;
                }
                public void GetNextNode(HashNode obj)
                {
                    next = obj;
                }
                public HashNode GetNextNode()
                {
                    return this.next;
                }
            }

            HashNode[] table;
            const int size = 100;

            public void OpenTable()
            {
                table = new HashNode[size];
                for (int i = 0; i < size; i++)
                {
                    table[i] = null;
                }
            }
            public void Insert(int key, string data)
            {
                HashNode nObj = new HashNode(key, data);
                int hash = key % size;
                while (table[hash] != null && table[hash].GetKey() % size != key % size)
                {
                    hash = (hash + 1) % size;
                }
                if (table[hash] != null && hash == table[hash].GetKey() % size)
                {
                    nObj.GetNextNode(table[hash].GetNextNode());
                    table[hash].GetNextNode(nObj);
                    return;
                }
                else
                {
                    table[hash] = nObj;
                    return;
                }
            }
            public string Retrieve(int key)
            {
                int hash = key % size;
                while (table[hash] != null && table[hash].GetKey() % size != key % size)
                {
                    hash = (hash + 1) % size;
                }
                HashNode current = table[hash];
                while (current.GetKey() != key && current.GetNextNode() != null)
                {
                    current = current.GetNextNode();
                }
                if (current.GetKey() == key)
                {
                    return current.GetData();
                }
                else
                {
                    return "nothing found!";
                }
            }
            public void Remove(int key)
            {
                int hash = key % size;
                while (table[hash] != null && table[hash].GetKey() % size != key % size)
                {
                    hash = (hash + 1) % size;
                }
                //a current node pointer used for traversal, currently points to the head
                HashNode current = table[hash];
                bool isRemoved = false;
                while (current != null)
                {
                    if (current.GetKey() == key)
                    {
                        table[hash] = current.GetNextNode();
                        Console.WriteLine("entry removed successfully!");
                        isRemoved = true;
                        break;
                    }

                    if (current.GetNextNode() != null)
                    {
                        if (current.GetNextNode().GetKey() == key)
                        {
                            HashNode newNext = current.GetNextNode().GetNextNode();
                            current.GetNextNode(newNext);
                            Console.WriteLine("entry removed successfully!");
                            isRemoved = true;
                            break;
                        }
                        else
                        {
                            current = current.GetNextNode();
                        }
                    }

                }

                if (!isRemoved)
                {
                    Console.WriteLine("nothing found to delete!");
                    return;
                }
            }
        }
    }
}