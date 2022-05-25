using System;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        // Fråga 1:
        // Stacken är ett system för minnesalokering med LiFo-struktur. Stacken ansvarar själv för hur kod lagras (i omvänd ordning).
        // När ett stycke kod ska köras anropas den senaste (översta) delen, varefter den tas bort från stacken så nästa stycke kan köras. 
        // Heapen är ett annat system för minnesalokering, som har träd-struktur. Varja segment är direkt accessbar så de kan köras i
        // vilken ordning som helst. När en bit kod har körts ligger den kvar i heapen så den kan köras igen och igen. Om ingen extern
        // kod tar bort segmentet finns den kvar tills "Garbige Collector" tar bort den eller programmet avslutas.

        // Fråga 2:
        // Value types är typer från System.ValueType. Dessa lagras direkt i variabler. De kan hamna både på stacken eller heapen.
        // Reference types är typer som ärver från System.Object. Dessa kan vara vilka objekt som helst och de lagras alltid i
        // heapen och variabler refererar till dem.

        // Fråga 3:
        // Den första arbetar med integers dvs value types. y kopierar x, medan x förblir det den är.
        // Den andra arbetar med objekt dvs reference types. När y sätts till x kopieras endast referensen. Både y och x refererar
        // till samma objekt. När y ändrar värdet till 4 sktivs det ursprungliga värdet över.




        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParanthesis"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */

            //List<string> theList = new List<string>();
            //string input = Console.ReadLine();
            //char nav = input[0];
            //string value = input.substring(1);
            //switch(nav){...}


            Console.WriteLine("Add somthing to the list by typing a + or - followed by the text to add or remove");

            List<string> theList = new List<string>();
            //int capacity = theList.Capacity;
            // Capacity är 0 från början
            

            bool loop = true;
            do
            {
                ConsoleKeyInfo keyObj = Console.ReadKey(false);
                char nav = keyObj.KeyChar;

                switch (nav)
                {
                    case '+':
                        {
                            string input = Console.ReadLine()!;
                            theList.Add(input);
                            //capacity = theList.Capacity;
                            // Capacity ökar från 0 till 4 när första objektet läggs till
                            // Ökar sedan från 4 till 8 när femte objectet läggs till osv

                            break;
                        }
                    case '-':
                        {
                            string input = Console.ReadLine()!;
                            bool success = theList.Remove(input);
                            //capacity = theList.Capacity;
                            // Capacity minskar inte alls när objekt tas bort.
                            // Man bör använda en egen array om man från början vet hur stor den behöver vara
                            
                            if (!success) Console.WriteLine($"{input} was not found in the list");

                            break;
                        }
                    case '0':
                        {
                            Console.WriteLine();
                            loop = false;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Only use + or - to add or remove, or 0 to go back");
                            break;
                        }
                }


            } while (loop);


        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */

            Console.WriteLine("Add a name to the list by typing a + followed by the name or e to expedite");

            Queue<string> theQueue = new Queue<string>();

            bool loop = true;
            do
            {
                ConsoleKeyInfo keyObj = Console.ReadKey(true);
                char nav = keyObj.KeyChar;

                switch (nav)
                {
                    case '+':
                        {
                            Console.Write("+");
                            string input = Console.ReadLine()!;
                            theQueue.Enqueue(input);
                            break;
                        }
                    case 'e':
                        {
                            if (theQueue.Count > 0) Console.WriteLine($"{theQueue.Dequeue()} was expedited");
                            else Console.WriteLine("The cue is empty");
                            break;
                        }
                    case '0':
                        {
                            Console.WriteLine();
                            loop = false;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Only use + to add to the que, e for expedition or 0 to go back");
                            break;
                        }
                
                }

            } while (loop);

        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */
        }

        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

        }

    }
}

