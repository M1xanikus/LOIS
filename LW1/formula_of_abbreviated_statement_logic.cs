using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InputExc;
namespace FALSL
{// Сделано Михаилом Чаплей и Алексеем Марченко
    public class Formula_of_abbreviated_statement_logic
    {
        public Formula_of_abbreviated_statement_logic(string formula) 
        {
            try
            {
                InputExceptions e = new(ref formula);
                Language_grammar check = new Language_grammar(formula, ref _lexemes);
                _count_of_subformulas = _lexemes.Count;
            }
            catch (Exception e)
            {   
                _error_text = e.Message;
                Console.WriteLine(e.Message);
            }
        }
        private List<string> _lexemes = new List<string>();
        private string _error_text = "";
        private int _count_of_subformulas;
        private void Recover_lexs()
        {
            for (int i = 0; i < _lexemes.Count; i++)
            {
                for (int j = 0; j < _lexemes[i].Length; j++)
                {
                    if (_lexemes[i][j] == '>')
                    {
                        _lexemes[i] = _lexemes[i].Insert(j, "-");
                        j++;
                    }
                    if (_lexemes[i][j] == '\\')
                    {
                        _lexemes[i] = _lexemes[i].Insert(j, "/");
                        j++;
                    }
                    if (_lexemes[i][j] == '/')
                    {
                        _lexemes[i] = _lexemes[i].Insert(j, "\\");
                        j++;
                    }

                }
            }
        }
        public void Print_subformulas()
        {
            Recover_lexs();
            for (int i = 0; i < _lexemes.Count; i++)
            {
                Console.WriteLine(_lexemes[i]);
            }
            
        }
        public void Print_count_of_subformulas()
        {
            try
            {
                    Console.Write(Count_of_subformulas);
            }
            catch(Exception e) { Console.WriteLine(e.Message); }
        }
        public int Count_of_subformulas
        {
            get
            {
                try
                {
                    if (this._error_text != "")
                        throw new Exception($"Ошибка: нельзя получить число подформул, если {this._error_text}");
                    else return _count_of_subformulas;
                }
                catch (Exception e) 
                {
                    throw new Exception(e.Message);
                }
            }
        }

    }
}
