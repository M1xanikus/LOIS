using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FALSL
{// Сделано Михаилом Чаплей и Алексеем Марченко
    public class Language_grammar
    {
        public Language_grammar(string formula, ref List<string> lexemes)
        {
            this.formula_ = formula;
            
           Check(ref lexemes);
        }
        string formula_ = "";
        private void Replacing()
        {
            if (formula_.Length < 2) { return; }
            for (int i = 1; i < formula_.Length - 1; i++)
            {
                if (formula_[i - 1] == '-' && formula_[i] == '>') // > imp
                {
                    formula_ = formula_.Remove(i - 1, 1);
                    i--;
                    continue;
                }
                if (formula_[i - 1] == '/' && formula_[i] == '\\') // \ con
                {
                    formula_ = formula_.Remove(i - 1, 1);
                    i--;
                    continue;
                }
                if (formula_[i - 1] == '\\' && formula_[i] == '/') // / dis
                {
                    formula_ = formula_.Remove(i - 1, 1);
                    i--;
                    continue;
                }
            }
        }
        public void Check(ref List<string> lexemes)
        {
            try
            {
                Replacing();
                lexemes.Add(formula_);//
                Rec_counter_formulas(formula_, ref lexemes);
                Check_grammar(lexemes);
            }
            catch (Exception e)
            {
                lexemes.Clear();
                throw new Exception(e.Message);
            }
        }
        private void Check_grammar(List<string> lexemes)
        {   
            int counter = 0;
            int open_brackets_counter = 0, close_brackets_counter = 0, ops_counter = 0;
    
                for (int i = 0; i < lexemes[0].Length; i++)
                {
                    if ((lexemes[0][i] >= 'а' && lexemes[0][i] <= 'я') || (lexemes[0][i] >= 'А' && lexemes[0][i] <= 'Я'))
                        throw new Exception("Ошибка: формула не соответствует грамматике!"); //Проверка на ввод кириллицы
                    if (lexemes[0][i] == '(')
                        open_brackets_counter++;
                    if (lexemes[0][i] == ')')
                        close_brackets_counter++;
                    if (lexemes[0][i] == '~' || lexemes[0][i] == '>' || lexemes[0][i] == '/' || lexemes[0][i] == '!' || Convert.ToChar(lexemes[0][i]) == '\\')
                        ops_counter++;
                }
                if ((ops_counter != (open_brackets_counter + close_brackets_counter) / 2) || (open_brackets_counter != close_brackets_counter))
                    throw new Exception("Ошибка: формула не соответствует грамматике!");
            // если количество пар скобок не совпадает с количеством операций, тогда есть грамматическая ошибка
                if (lexemes[0].Length > 1)
                {
                    if ((Convert.ToChar(lexemes[0][0]) >= 'A' && Convert.ToChar(lexemes[0][0]) <= 'Z') && ((Convert.ToChar(lexemes[0][1]) >= 'A' && Convert.ToChar(lexemes[0][1]) <= 'Z') || char.IsNumber(lexemes[0][1])))
                        throw new Exception("Ошибка: формула не соответствует грамматике!");
                    if(Convert.ToChar(lexemes[0][0]) == '(' && (Convert.ToChar(lexemes[0][1]) == '~' || Convert.ToChar(lexemes[0][1]) == '>' || Convert.ToChar(lexemes[0][1]) == '/' || Convert.ToChar(lexemes[0][1]) == '\\'))
                        throw new Exception("Ошибка: формула не соответствует грамматике!");
                }
                for (int i = 0; i < lexemes[0].Length; i++)
                {
                    if (lexemes[0][i] == '-' || lexemes[0][i] == '+' || lexemes[0][i] == '*' || lexemes[0][i] == '_' ||
                    lexemes[0][i] == '`' || lexemes[0][i] == '@' || lexemes[0][i] == '#' || lexemes[0][i] == '$' || lexemes[0][i] == '№' || lexemes[0][i] == ':' || lexemes[0][i] == ';' || lexemes[0][i] == '<' || lexemes[0][i] == '%' || lexemes[0][i] == '^'
                    || lexemes[0][i] == '=' || lexemes[0][i] == '.' || lexemes[0][i] == '\'' || lexemes[0][i] == '\"' || lexemes[0][i] == ',' || lexemes[0][i] == '[' || lexemes[0][i] == ']' 
                    || lexemes[0][i] == '{' || lexemes[0][i] == '}' || lexemes[0][i] == '&' || lexemes[0][i] == '?' || (Convert.ToChar(lexemes[0][i]) >= 'a' && Convert.ToChar(lexemes[0][i]) <= 'z'))
                        throw new Exception("Ошибка: формула не соответствует грамматике!");// проверка на ввод арифметических операций и др знаков
                    if (counter < 0)
                        throw new Exception("Ошибка: формула не соответствует грамматике!");
                    if (lexemes[0][i] == '(')
                    {
                        counter++;
                        continue;
                    }
                    if (lexemes[0][i] == ')')
                    {
                        counter--;
                        continue;
                    }
                }
                counter = 0;
                for (int i = lexemes.Count - 1; i > -1; i--)
                {
                    if (lexemes[i].Length == 1)
                    {
                        if (Convert.ToChar(lexemes[i]) >= 'a' && Convert.ToChar(lexemes[i]) <= 'z')
                            throw new Exception("Ошибка: формула не соответствует грамматике!");
                    }
                    if (char.IsDigit(lexemes[i][0]))
                        if (!(lexemes[i][0] == '0' || lexemes[i][0] == '1'))
                            throw new Exception("Ошибка: формула не соответствует грамматике!");
                    if (lexemes[i][0] == '(' && lexemes[i][lexemes[i].Length - 1] == ')')
                    {
                        for (int j = 1; j < lexemes[i].Length - 1; j++)
                        {
                            if (lexemes[i][j] == '(')
                            {
                                counter++;
                            }
                            if (lexemes[i][j] == ')')
                            {
                                counter--;
                            }
                            if (counter != 0 && j == lexemes[i].Length - 2)//fix
                            {
                                throw new Exception("Ошибка: формула не соответствует грамматике!");
                            }
                            if (lexemes[i][j] == '!')
                            {
                                if (Convert.ToChar(lexemes[i][j + 1]) >= 'a' && Convert.ToChar(lexemes[i][j + 1]) <= 'z')
                                    throw new Exception("Ошибка: формула не соответствует грамматике!");
                                if (lexemes[i][j + 1] == '~' || lexemes[i][j + 1] == '>' || lexemes[i][j + 1] == '/' || Convert.ToChar(lexemes[i][j + 1]) == '\\')
                                    throw new Exception("Ошибка: формула не соответствует грамматике!");
                            }
                            if ((Convert.ToChar(lexemes[i][j]) >= 'A' && Convert.ToChar(lexemes[i][j]) <= 'Z') && ((Convert.ToChar(lexemes[i][j + 1]) >= 'A' && Convert.ToChar(lexemes[i][j + 1]) <= 'Z') || char.IsDigit(lexemes[i][j + 1])))
                            {
                                throw new Exception("Ошибка: формула не соответствует грамматике!");
                            }
                            if (((Convert.ToChar(lexemes[i][j]) >= 'A' && Convert.ToChar(lexemes[i][j]) <= 'Z') || Convert.ToChar(lexemes[i][j]) == '1' || Convert.ToChar(lexemes[i][j]) == '0') && Convert.ToChar(lexemes[i][j + 1]) == ')' && Convert.ToChar(lexemes[i][j - 1]) == '(')
                            {
                                throw new Exception("Ошибка: формула не соответствует грамматике!");
                            }
                            if (Convert.ToChar(lexemes[i][j]) >= 'A' && Convert.ToChar(lexemes[i][j]) <= 'Z' || Convert.ToChar(lexemes[i][j]) == ')' && j + 1 <= lexemes[i].Length - 1)
                            {
                                if ((Convert.ToChar(lexemes[i][j + 1]) == '~' || Convert.ToChar(lexemes[i][j + 1]) == '>' || Convert.ToChar(lexemes[i][j + 1]) == '/' || Convert.ToChar(lexemes[i][j + 1]) == '\\') && (Convert.ToChar(lexemes[i][j + 2]) == '~' || Convert.ToChar(lexemes[i][j + 2]) == '>' || Convert.ToChar(lexemes[i][j + 2]) == '/' || Convert.ToChar(lexemes[i][j + 2]) == '\\'))
                                    throw new Exception("Ошибка: формула не соответствует грамматике!");
                                if ((Convert.ToChar(lexemes[i][j + 1]) == '~' || Convert.ToChar(lexemes[i][j + 1]) == '>' || Convert.ToChar(lexemes[i][j + 1]) == '/' || Convert.ToChar(lexemes[i][j + 1]) == '\\') && Convert.ToChar(lexemes[i][j + 2]) == ')')
                                    throw new Exception("Ошибка: формула не соответствует грамматике!");
                            }
                            if (char.IsDigit(lexemes[i][j]))
                                if (!(lexemes[i][j] == '0' || lexemes[i][j] == '1'))
                                    throw new Exception("Ошибка: формула не соответствует грамматике!");

                        }
                        counter = 0;
                    }
                    if (lexemes[i][0] != '(' && lexemes[i][lexemes[i].Length - 1] == ')' || lexemes[i][0] == '(' && lexemes[i][lexemes[i].Length - 1] != ')')
                        throw new Exception("Ошибка: формула не соответствует грамматике!");
                }
            
           

        }
        private void Rec_counter_formulas(string formula, ref List<string> lexemes)
        {  
            
            string buf = "";
            try { 
            if (((formula[0] >= 'A' && formula[0] <= 'Z') || formula[0] == '1' || formula[0] == '0') && formula.Length == 1)
            {
            return;
            }
            if (formula[0] == '(' && formula.Length > 1)//added
            {
                if (formula[1] == '!')
                { 
                    for (int i = 2; i < formula.Length-1; i++) 
                    {
                    buf += formula[i];
                    }
                        if (lexemes.IndexOf(buf) == -1)
                        {
                            lexemes.Add(buf);
                        }
                    //Console.WriteLine(buf);
                     Rec_counter_formulas(buf,ref lexemes);
            }
            else if(formula[0] == '(' && formula.Length == 1) //added
                    throw new Exception("Ошибка: формула не соответствует грамматике!");
             else if (formula[0] == '(' && (formula[1] >= 'A' && formula[0] <= 'Z') && formula.Length == 2) //added
                    throw new Exception("Ошибка: формула не соответствует грамматике!");
                if (formula[1] == '(')
                {
                    int i = 1, counter = 1;
                        while ((formula[i] != '~' && formula[i] != '>' && formula[i] != '/' && formula[i] != '\\') || counter != 1)
                        {
                            if (formula[i] == '(') counter++;
                            if (formula[i] == ')') counter--;
                            buf += formula[i];
                            i++;
                        if (i > formula.Length - 1)
                            throw new Exception("Ошибка: формула не соответствует грамматике!");
                        }
                    if (lexemes.IndexOf(buf) == -1)
                    {
                        lexemes.Add(buf);
                    }
                    //Console.WriteLine(buf);
                    Rec_counter_formulas(buf, ref lexemes);
                    buf = "";
                        for (int j = i+1; j < formula.Length-1; j++)
                        {
                            buf += formula[j];
                        }
                    if (lexemes.IndexOf(buf) == -1 && buf != "")
                    {
                        lexemes.Add(buf);
                    }
                    if (buf != "") // added fix
                        Rec_counter_formulas(buf, ref lexemes);
                }
                if ((formula[1] >= 'A' && formula[1] <= 'Z') || formula[0] == '1' || formula[0] == '0')
                {
                    if (lexemes.IndexOf(formula[1].ToString()) == -1)
                    {
                        lexemes.Add(formula[1].ToString());
                    }
                    //Console.WriteLine(formula[1].ToString());
                    Rec_counter_formulas(formula[1].ToString(),ref lexemes);
                    if (formula[2] == '~' || formula[2] == '>' || formula[2] == '/' || formula[2] == '\\')
                    {
                        for (int i = 3; i < formula.Length - 1; i++)
                        {
                            buf += formula[i];

                        }
                        if (lexemes.IndexOf(buf) == -1 && buf != "")
                        {
                            lexemes.Add(buf);
                        }
                        //Console.WriteLine(buf);
                        if (buf != "")
                            Rec_counter_formulas(buf, ref lexemes);
                    }
                }
           
                
            }
            }
            catch (IndexOutOfRangeException) { throw new IndexOutOfRangeException("Ошибка: Выход за пределы массива при вычислении!"); }
        }
    }
}
