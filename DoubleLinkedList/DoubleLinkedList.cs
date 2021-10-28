using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleLinkedList
{
    public class DoubleLinkedList
    {
        public Node Head { get; set; }
        public Node Tail { get; set; }
        public int FemaleCount { get; set; }
        public int MaleCount { get; set; }
        public int TotalCount { get { return FemaleCount + MaleCount; } }
        public Node MostPopularFemale { get; set; }
        public Node MostPopularMale { get; set; }
        public LetterIndex[] LetterIndicies { get; set; } = new LetterIndex[26];


        public DoubleLinkedList()
        {
            var alphabet = "abcdefghijklmnopqrstuvwxyz";
            for (int i = 0; i < LetterIndicies.Length; i++)
            {
                LetterIndicies[i] = new LetterIndex(alphabet[i]);
            }
        }

        public void AddNode(Node newNode)
        {
            var currentIndex = LetterIndicies[FindLetterIndex(newNode.Data.Name[0])];
            var currentNode = currentIndex.Start;

            if (currentNode == null) //index has not data. Add new node
            {
                currentIndex.Start = newNode;
                currentIndex.End = newNode;
                IncrementCounters(newNode.Data.Gender);
            }
            else
            {
                var flag = true;
                while (currentNode != null && Char.ToLower(currentNode.Data.Name[0]) == currentIndex.Letter && flag)
                {
                    var insertionCheck = CompareStrings(currentNode.Data.Name, newNode.Data.Name);

                    if (insertionCheck == 1 && currentNode == currentIndex.End)//newNode inserted at end of list.
                    {
                        newNode.Previous = currentNode;
                        currentNode.Next = newNode;
                        currentIndex.End = newNode;
                        IncrementCounters(newNode.Data.Gender);
                        break;
                    }

                    switch (insertionCheck)
                    {
                        case 0://do nothing for now. This is when there are duplicates

                            if (newNode.Data.Gender == currentNode.Data.Gender) // Duplicate entry attempt
                            {
                                Console.WriteLine($"Duplicate Entry Found {currentNode.Data.Name}: Press Y to add to list with \"_1\" suffix. Any key to skip entry");
                                var input = Console.ReadKey().Key;
                                if (input == ConsoleKey.Y)
                                {
                                    Console.WriteLine();
                                    newNode.Next = currentNode.Next;
                                    newNode.Previous = currentNode;
                                    if (currentNode.Next != null)
                                    {
                                        currentNode.Next.Previous = newNode;
                                    }

                                    currentNode.Next = newNode;

                                    newNode.Data.Name += "_1";
                                    flag = false;
                                    IncrementCounters(newNode.Data.Gender);
                                    UpdateMostPopular(newNode);
                                }
                            }
                            //user decided not to add duplicate entry to list.
                            flag = false;
                            break;

                        case 1:
                            currentNode = currentNode.Next;
                            break;

                        case 2:
                            if (currentIndex.Start == currentNode) //newNode inserted at head
                            {
                                newNode.Next = currentNode;
                                currentNode.Previous = newNode;
                                currentIndex.Start = newNode;
                            }
                            else//newNode inserted in middle
                            {
                                currentNode.Previous.Next = newNode;
                                newNode.Previous = currentNode.Previous;
                                currentNode.Previous = newNode;
                                newNode.Next = currentNode;
                            }
                            IncrementCounters(newNode.Data.Gender);
                            UpdateMostPopular(newNode);
                            flag = false;
                            break;
                    }
                }
            }

            rebuildList();


        }


        public bool SearchList(string name)
        {
            var currentNode = LetterIndicies[FindLetterIndex(name[0])].Start;
            var endNode = LetterIndicies[FindLetterIndex(name[0])].End;

            while(currentNode != endNode)
            {
                if (currentNode.Data.Name.ToLower() == name.ToLower())
                {
                    return true;
                }
                currentNode = currentNode.Next;
            }
            return false;

        }

        private void IncrementCounters(bool gender)
        {
            if (gender)
            {
                MaleCount++;
            }
            else
            {
                FemaleCount++;
            }
        }

        private void UpdateMostPopular(Node newNode)
        {
            switch (newNode.Data.Gender)
            {
                case false:
                    if (MostPopularFemale == null)
                    {
                        MostPopularFemale = newNode;
                    }
                    else
                    {
                        if (MostPopularFemale.Data.Rank < newNode.Data.Rank)
                        {
                            MostPopularFemale = newNode;
                        }
                    }
                    break;
                case true:
                    if (MostPopularMale == null)
                    {
                        MostPopularMale = newNode;
                    }
                    else
                    {
                        if (MostPopularMale.Data.Rank < newNode.Data.Rank)
                        {
                            MostPopularMale = newNode;
                        }
                    }
                    break;
            }
        }

        private int FindLetterIndex(char nodeStartingLetter)
        {
            for (int i = 0; i < LetterIndicies.Length; i++)
            {
                if (LetterIndicies[i].Letter == Char.ToLower(nodeStartingLetter))
                {
                    return i;
                }
            }
            return -1;
        }

        private void rebuildList()
        {
            Node currentTail = null;
            foreach (var index in LetterIndicies)
            {
                if (currentTail == null && index.End != null) // Find our first index with data in it.
                {
                    currentTail = index.End;
                    Head = index.Start;
                }
                else if (currentTail!= null && index.Start != null) // Connect last tail to next found head.
                {
                    currentTail.Next = index.Start;
                    index.Start.Previous = currentTail;
                    currentTail = index.End;
                }
            }

            Tail = currentTail; // Last found tail in index Arr is end of LL
        }

        private int CompareStrings(string existingNode, string newNode)
        {
            if (String.Compare(existingNode, newNode) == 0)
                return 0; // names are equal
            else if (String.Compare(existingNode, newNode) < 0)
                return 1; // existing name should come before new name
            else if (String.Compare(existingNode, newNode) > 0)
                return 2; // existing name should come after new name
            else
            {
                return -1;
            }
        }


    }
}
