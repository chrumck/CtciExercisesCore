
using System;
using System.Threading;

namespace CtciExercises.ThreadsAndLocks
{
   /// <summary>
   ///   A class for the exercise 15.5
   /// </summary>
   public static class CallInOrder
   {
      /// <summary>
      ///    Starts three threads in an order as given by the three method parameters.
      /// </summary>
      /// <param name="first">The first thread to run.</param>
      /// <param name="second">The second thread to run.</param>
      /// <param name="third">The third thread to run</param>
      public static void RunInOrder(int first, int second, int third)
      {
         var semaphoreForSecond = new SemaphoreSlim(0, 1);
         var semaphoreForThird = new SemaphoreSlim(0, 1);

         var runners = new Thread[3];

         runners[0] = new Thread(() => { 
            Foo.First();
            semaphoreForSecond.Release();
            Thread.Sleep(100);
            Console.WriteLine("Finished call from the first thread.");
         });

         runners[1] = new Thread(() => { 
            semaphoreForSecond.Wait();
            Foo.Second();
            semaphoreForThird.Release();
            Console.WriteLine("Finished call from the second thread.");
         });

         runners[2] = new Thread(() => { 
            semaphoreForThird.Wait();
            Foo.Third();
            Console.WriteLine("Finished call from the third thread.");
         });

         runners[first - 1].Start();
         runners[second - 1].Start();
         runners[third - 1].Start();
      }
   }

   /// <summary>
   ///   A sample class for for the exercise.
   /// </summary>
   public class Foo
   {
      public static void First() { Console.WriteLine("First method called."); }
      public static void Second() { Console.WriteLine("Second method called."); }
      public static void Third() { Console.WriteLine("Third method called."); }
   }
}

