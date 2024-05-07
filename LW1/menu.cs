using FALSL;
using InputExc;
using System;
namespace Menu
{
    class Menu
    {
        static void Main(string[] args)
        {
            //Formula_of_abbreviated_statement_logic a = new("((!(((A->(!B))~(C\\/D))/\\((!E)~(F->(!G)))))->(N/\\(K\\/L)))");
            //a.Print_subformulas();
            //a.Print_count_of_subformulas();
            Console.WriteLine("Сделано студентами группы 221702: Алексей Марченко и Чапля Михаил");
            Random rand = new Random();
            string choose_1 = "";
            List<string> formulas = new List<string>() {"(A->1)","(!A)","A","((!(A~B))/\\C)","1", "((!(((A->(!B))~(C\\/D))/\\((!E)~(F->(!G)))))->(N/\\(K\\/L)))","((!(A~B))->(C\\/D))","(R->((I\\/D)/\\(O~R)))","(A/\\A)", "(((((((((((((((((((((((((A~B)~C)~D)~E)~F)~G)~H)~I)~J)~K)~L)~M)~N)~O)~P)~Q)~R)~S)~T)~U)~V)~W)~X)~Y)~Z)" };
            while (choose_1 != "3") 
            {
                Console.WriteLine("\n1 Ввести формулу сокращенного языка логики высказываний для подсчета подформул\n2 Запустить тестирование пользователя\n3 Выход");
                try
                {
                    choose_1 = Console.ReadLine();
                    InputExceptions e1 = new(ref choose_1);
                    switch (choose_1)
                    {
                        case "1":
                            Console.WriteLine("Введите формулу:");
                            string temp = Convert.ToString(Console.ReadLine()); // A->B
                            Console.WriteLine();
                            Formula_of_abbreviated_statement_logic formula = new(temp);
                            formula.Print_subformulas();
                            Console.WriteLine($"Количество подформул:");
                            formula.Print_count_of_subformulas();
                            break;
                        case "2":
                            int index = rand.Next(0, formulas.Count());
                            Console.WriteLine("Введите количество подформул для данной формулы сокращенного языка логики высказываний:");
                            Console.WriteLine(formulas[index]);
                            Formula_of_abbreviated_statement_logic formula_2 = new(formulas[index]);
                            string answer = Console.ReadLine();
                            InputExceptions e2 = new(ref answer);
                            if (answer == formula_2.Count_of_subformulas.ToString())
                                Console.WriteLine($"Ответ верный! ({formula_2.Count_of_subformulas})");
                            else Console.WriteLine($"Ответ неверный! ({formula_2.Count_of_subformulas})");
                            break;

                        default:
                            break;

                    }
                }
                catch (Exception e) { Console.WriteLine(e.Message); }
            }
        }

    }
}