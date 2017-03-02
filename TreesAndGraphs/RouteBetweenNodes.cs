using System;
using System.Collections.Generic;

namespace CtciExercises.TreesAndGraphs
{
   /// <summary>
   ///   Represents a graph node for a directed and possibly acyclic graph.
   /// </summary>
   public class GraphNode
   {
      /// <summary>
      ///   Creates an instance of <see cref="GraphNode"/>.
      /// </summary>
      public GraphNode()
      {
         this.Neighbors = new List<GraphNode>();
      }

      /// <summary>
      ///   Gets the node's neighbors.
      /// </summary>
      public ICollection<GraphNode> Neighbors { get; private set; }

      /// <summary>
      ///   Checks if this node is connected to the other node.
      /// </summary>
      /// <param name="other">The other node.</param>
      /// <returns>True if connected, otherwise false.</returns> <summary>
      /// <remarks>Returns true for connected to itself.</remarks>
      public bool IsConnectedTo(GraphNode other)
      {
         if (other == null) { throw new ArgumentException(nameof(other)); }
         if (this == other) { return true; }

         var queue = new Queue<GraphNode>();
         queue.Enqueue(this);

         while (queue.Count > 0)
         {
            var currentNode = queue.Dequeue();
            foreach (var neighbor in currentNode.Neighbors)
            {
               if (neighbor == other) { return true; }
               queue.Enqueue(neighbor);
            }
         }

         return false;
      }
   }
}