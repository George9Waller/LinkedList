using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace LinkedList
{
    class Player
    {
    public string Name { get; }
    public int Pointer { get; set; }

    public Player(string newName, int newPointer = -1)
    {
        this.Name = newName;
        this.Pointer = newPointer;
    }
    }
    
    internal static class Program
    {
        static List<Player> linkedList = new List<Player>();

        static void PrintAllPlayers(List<Player> list)
        {
            foreach (var p in list)
            {
                Console.WriteLine(p.Name + "\t" + p.Pointer);
            }
        }

        static List<Player> GetAllPlayersInOrder(ref List<Player> list, int index = 2, bool console = true, int limit = -1)
        {
            List<Player> result = new List<Player>();
            int count = list.Count;
            if (!console)
            {
                if (limit != -1)
                {
                    count = limit;
                }
            }

            for (int i = 0; i < count; i++)
            {
                if (console) {Console.WriteLine($"{i}\t{list[index].Name}");}
                else {result.Add(list[index]);}
                
                index = list[index].Pointer;
                if (index == -1)
                {
                    if (console)
                    {
                        Console.WriteLine("\n");
                        return null;
                    }
                    else {return result;}
                }
            }
            return null;
        }

        static void AddPlayer(ref List<Player> list, int position, Player newPlayer)
        {
            List<Player> orderedList = GetAllPlayersInOrder(ref list, console: false);

            newPlayer.Pointer = list[list.IndexOf(orderedList[position - 1])].Pointer;
            list[list.IndexOf(orderedList[position - 1])].Pointer = list.IndexOf(newPlayer);
        }

        static void Main(string[] args)
        {
            Player p1 = new Player("Rob", 3);
            Player p2 = new Player("Matt", 0);
            Player p3 = new Player("Ethan", 4);
            Player p4 = new Player("Max", -1);
            Player p5 = new Player("George", 1);

            linkedList.AddRange(new Player[]{p1, p2, p3, p4, p5});
            GetAllPlayersInOrder(ref linkedList);

            Player p6 = new Player("Mr Tattam");
            linkedList.Add(p6);
            AddPlayer(ref linkedList, 4, p6);
            GetAllPlayersInOrder(ref linkedList);

            Player p7 = new Player("Ruben");
            linkedList.Add(p7);
            AddPlayer(ref linkedList, 4, p7);
            GetAllPlayersInOrder(ref linkedList);
            
            Player p8 = new Player("Tom");
            linkedList.Add(p8);
            AddPlayer(ref linkedList, 4, p8);
            
            GetAllPlayersInOrder(ref linkedList);
            //PrintAllPlayers(linkedList);
        }
    }
}