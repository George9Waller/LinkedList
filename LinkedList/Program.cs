using System;
using System.Collections.Generic;

namespace LinkedList
{
    class Player
    {
    public string Name { get; }
    public int Pointer { get; set; }

    public Player(string newName, int newPointer)
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

        static void GetAllPlayersInOrder(ref List<Player> list, int index)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"{i}\t{list[index].Name}");
                index = list[index].Pointer;
                if (index == -1) {return;}
            }
        }

        static void AddPlayer(ref List<Player> list, Player playerAfter, Player newPlayer)
        {
            newPlayer.Pointer = playerAfter.Pointer;
            playerAfter.Pointer = list.IndexOf(newPlayer);
        }

        static void Main(string[] args)
        {
            Player p1 = new Player("Rob", 3);
            Player p2 = new Player("Matt", 0);
            Player p3 = new Player("Ethan", 4);
            Player p4 = new Player("Max", -1);
            Player p5 = new Player("George", 1);

            linkedList.AddRange(new Player[]{p1, p2, p3, p4, p5});

            Player p6 = new Player("Mr Tattam", 3);
            linkedList.Add(p6);
            AddPlayer(ref linkedList, p1, p6);
            
            GetAllPlayersInOrder(ref linkedList, 2);
            //PrintAllPlayers(linkedList);
        }
    }
}