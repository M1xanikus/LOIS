﻿using FALSL;
using System;
namespace Menu
{
    class Menu
    {
        static void Main(string[] args)
        {
            Formula_of_abbreviated_statement_logic a = new("(A->B) ");
            a.Print_subformulas();
            a.Print_count_of_subformulas();
            Random rand = new Random();
            List<string> formulas = new List<string>() {"(A->1)","(!A)","A","((!(A~B))/\\C)","1", "((!(((A->(!B))~(C\\/D))/\\((!E)~(F->(!G)))))->(N/\\(K\\/L)))" };
            while (true) 
            {
                Console.WriteLine("\n1. Ввести формулу сокращенного языка логики высказываний для подсчета подформул\n2. Запустить тестирование пользователя");
                string choose;
                choose = Console.ReadLine();
                switch (choose)
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
                        int index = rand.Next(0,formulas.Count());
                        Console.WriteLine("Введите количество подформул для данной формулы сокращенного языка логики высказываний:");
                        Console.WriteLine(formulas[index]);
                        Formula_of_abbreviated_statement_logic formula_2 = new(formulas[index]);
                        string answer = Console.ReadLine();
                        if (answer == formula_2.Count_of_subformulas.ToString())
                            Console.WriteLine($"Ответ верный! ({formula_2.Count_of_subformulas})");
                        else Console.WriteLine($"Ответ неверный! ({formula_2.Count_of_subformulas})");
                        break;
                   
        
                    default:
                        break;
  
                }
            }
        }

    }
}