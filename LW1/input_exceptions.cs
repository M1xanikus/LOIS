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
                for (int i = 0; i < formula.Length; i++)
                {
                    if (formula[i] == ' ')
                    {
                        formula = formula.Replace(" ", "");
                        break;
                    }
                }
                for (int i = 0; i < formula.Length; i++)
                {
                    if (formula[i] == '\t')
                    {
                        formula = formula.Replace("\t", "");
                        break;
                    }
                }
            }
            catch(ArgumentException e) { throw new ArgumentException(e.Message); }
        }
    }
}
