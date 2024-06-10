using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_QuizMaster
{
    public class clsQuiz
    {
      

        public static List<string> lstRandomQuastions = new List<string>();
        public static List<string> AnswerQuastions = new List<string>();

        public static Random random = new Random();

        public static void GetRandomNumber(ref int FirstNumber,ref int SecondNumber)
        {
            FirstNumber = random.Next(1,100);
            SecondNumber = random.Next(1,100);
        }
        public static bool CheckTheResult( char RandomeOperation,int UserAnswer,int FirstNumber,int SecondNumber,
            ref int IndexAnswerQues)
        {
            int Result;

            if (RandomeOperation == '+')
            {
                Result = FirstNumber + SecondNumber;
                ++IndexAnswerQues;
                AnswerQuastions.Add(Convert.ToString(Result));
                return UserAnswer == Convert.ToInt32(AnswerQuastions[IndexAnswerQues - 1]);

            }
            if (RandomeOperation == '-')
            {
                Result = FirstNumber - SecondNumber;
                ++IndexAnswerQues;
                AnswerQuastions.Add(Convert.ToString(Result));
                return UserAnswer == Convert.ToInt32(AnswerQuastions[IndexAnswerQues - 1]);

            }
            if (RandomeOperation == '*')
            {
                Result = FirstNumber * SecondNumber;
                ++IndexAnswerQues;
                AnswerQuastions.Add(Convert.ToString(Result));
                return UserAnswer == Convert.ToInt32(AnswerQuastions[IndexAnswerQues - 1]);
            }
            if (RandomeOperation == '/')
            {
                Result = FirstNumber / SecondNumber;
                ++IndexAnswerQues;
                AnswerQuastions.Add(Convert.ToString(Result));
                return UserAnswer == Convert.ToInt32(AnswerQuastions[IndexAnswerQues - 1]);
            }
            return false;
        }
        public static bool IsRepeate(ref bool isRepeateQuestion,ref int IndexRandomQues)
        {

            bool continueLoop = true;

            while (continueLoop)
            {

                ConsoleKeyInfo keyInfo = Console.ReadKey();

                if (keyInfo.Key == ConsoleKey.N)
                {
                    Console.WriteLine("\nQuastion is skiped :-(");
                    isRepeateQuestion = false;
                    ++IndexRandomQues;
                    continueLoop = false;
                }

                else if (keyInfo.Key == ConsoleKey.Y)
                {
                    isRepeateQuestion = true;
                    continueLoop = false;
                }
                else
                {
                    Console.WriteLine("\nYou pressed a key other than 'n' or 'y'.");
                }

                Console.WriteLine();
            }
            return isRepeateQuestion;

        }
        public static void AddQuastionsToList(ref char RandomeOperation,ref int FirstNumber,ref int SecondNumber)
        {
            char[] arrOperationType = new char[] { '+', '-', '/', '*' };
            GetRandomNumber(ref FirstNumber,ref SecondNumber);
           int GetRandomNum = random.Next(0, 3);
           RandomeOperation = arrOperationType[GetRandomNum];
      
          string Equation = "";
          Equation = $"{FirstNumber} {RandomeOperation} {SecondNumber} = ";
          lstRandomQuastions.Add(Equation);
        }

        public static void ShowQuestions(ref int UserAnswer,bool isRepeateQuestion, ref int IndexRandomQues,
            int NumberOfQuestions)
        {

            try
            {
                for (; IndexRandomQues < lstRandomQuastions.Count; IndexRandomQues++)
                {
                    Console.WriteLine(lstRandomQuastions[IndexRandomQues]);
                    UserAnswer = Convert.ToInt32(Console.ReadLine());
                }
            }
            catch (Exception FX)
            {
                Console.WriteLine(FX.Message);

                Console.WriteLine("Press the 'N/n' key to continue to another question" +
                    ", the 'Y/y' key to repeate the question");

                
                if(IsRepeate(ref isRepeateQuestion,ref IndexRandomQues))
                {
                    Console.WriteLine($"Question {NumberOfQuestions} :");
                    ShowQuestions(ref UserAnswer,isRepeateQuestion,ref IndexRandomQues,NumberOfQuestions);
                }

            }
        }

        public static void StartQuiz()
        {
           int NumberOfQuestions = 0;
            int UserScore = 5;
            char RandomeOperation = '+';
            int UserAnswer = 0;
            bool IsRepeateQuestion = false;
            int FirstNumber = 0;
            int SecondNumber = 0;
            int IndexRandomQues = 0;
            int IndexAnswerQues = 0;

            Console.WriteLine("\nIMPORTANT NOTE --> ** Your quiz consistes of five (5) questions " +
                "\n** Your answer should be a valid number " +
                ", Otherwise you will lose " +
                "one point in your score for each quastion if you skip it\n ' Be Carefull ' ! . \nGOOD LUCK :-) \n" +
                "** If you are ready to start the quiz ,press any key :-)");

            Console.ReadKey();

            while (NumberOfQuestions++ < 5)
            {
                Console.WriteLine($"Question {NumberOfQuestions} :");

                AddQuastionsToList(ref RandomeOperation,ref FirstNumber,ref SecondNumber);

                ShowQuestions(ref UserAnswer,IsRepeateQuestion, ref IndexRandomQues, NumberOfQuestions);

               
                if (CheckTheResult(RandomeOperation, UserAnswer,FirstNumber,SecondNumber,ref IndexAnswerQues))
                    Console.WriteLine("Your answer is coorect :-)");

                else
                {
                    --UserScore;
                    Console.WriteLine("Your answer is wrong :-(");
                }
            }
            ShowFinalResult(UserScore);
        }

        public static void ShowFinalResult(int UserScore)
        {
            Console.WriteLine("\nFinal Result :");
            if (UserScore < 3)
            {
                UserScore = (UserScore < 0) ? 0 : UserScore;

                Console.WriteLine($"Your are Failed,Your Score is  :{UserScore} / 5");
            }
            else
            {
                Console.WriteLine($"Congratulations,Your Score is :{UserScore} / 5");
            }

        }
    }
}
