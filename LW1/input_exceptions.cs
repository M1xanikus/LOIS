using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputExc
{// Сделано Михаилом Чаплей и Алексеем Марченко
    internal class InputExceptions
    {
        public InputExceptions(ref string formula) 
        {
            try
            {   
                if (formula == "") throw new ArgumentException("Ошибка ввода: введённая строка пустая!");
                try
                {
                    for (int i = 0; i < formula.Length && formula.Length > 2; i++)
                    {
                        if (formula[i] == '>' && formula[i - 1] != '-')
                            throw new ArgumentException("Ошибка: формула не соответствует грамматике!");
                        if (formula[i] == '/' && formula[i - 1] != '\\' && formula[i + 1] != '\\')
                            throw new ArgumentException("Ошибка: формула не соответствует грамматике!");
                        if (formula[i] == '\\' && formula[i - 1] != '/' && formula[i + 1] != '/')
                            throw new ArgumentException("Ошибка: формула не соответствует грамматике!");
                        if ((formula[i] == '\\'|| formula[i] == '/') && (formula[i-1] == '/' || formula[i-1] == '\\') && (formula[i+1] == '\\' || formula[i+1] == '/'))
                            throw new ArgumentException("Ошибка: формула не соответствует грамматике!");
                    }
                }
                catch(IndexOutOfRangeException e)
                {
                    throw new ArgumentOutOfRangeException("Ошибка: выход за пределы массива при выполнении!", e);
                }
            }
            catch(ArgumentException e) { throw new ArgumentException(e.Message); }
        }
    }
}
