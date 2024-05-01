using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputExc
{
    internal class InputExceptions
    {
        public InputExceptions(ref string formula) 
        {
            try
            {
                if (formula == "") throw new ArgumentException("Ошибка ввода: введённая строка пустая!");
                if (formula.All(c => c == ' ')) throw new ArgumentException("Ошибка ввода: строка заполнена пробелами!");
                if (formula[0] == ' ')
                {
                    while (formula.IndexOf(' ', 0) != -1)
                        formula = formula.Remove(0, 1);
                }
                if (formula[formula.Length-1] == ' ')
                {
                    while (formula.LastIndexOf(' ', formula.Length-1) != -1)
                        formula = formula.Remove(formula.Length-1, 1);
                }
            }
            catch(ArgumentException e) { throw new ArgumentException(e.Message); }
        }
    }
}
