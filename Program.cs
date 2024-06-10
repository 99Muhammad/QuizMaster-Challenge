using Lab2_QuizMaster;

namespace ConsoleApp4
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool isRepeate = true;

            while (isRepeate) 
            {
                try
                {
                    Console.Clear();
                    clsQuiz.StartQuiz();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

                finally
                {
                    Console.WriteLine("Your quiz is completed");
                    Console.WriteLine("If you want to repeate quiz press on keys(y /n )");
                    
                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    
                    if (keyInfo.Key == ConsoleKey.Y)
                    {
                        isRepeate = true;
                    }
                    else
                    {
                        Console.WriteLine("\nYou pressed a key other than 'n' or 'y'.");
                        isRepeate = false;
                    }

                    Console.WriteLine();

                }

            } 

           
        }
    }
}
