using System;
using CtciExercises.ArraysAndStrings;
using CtciExercises.ThreadsAndLocks;
using CtciExercises.TreesAndGraphs;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var node1 = new GraphNode();
            var node2 = new GraphNode();
            var node3 = new GraphNode();
            var node4 = new GraphNode();

            node1.Neighbors.Add(node2);
            node2.Neighbors.Add(node3);
            
            Console.WriteLine($"The node1 is connected to itself:{node1.IsConnectedTo(node1)}");
            Console.WriteLine($"The node1 is connected to node 3:{node1.IsConnectedTo(node3)}");
            Console.WriteLine($"The node1 is connected to node 4:{node1.IsConnectedTo(node4)}");
        }
    }
}
