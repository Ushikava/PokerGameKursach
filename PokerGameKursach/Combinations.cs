using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGameKursach
{
    public class Combinations
    {

        public int combo(int first, int second, int third)
        {
            int result = 0;

            if (((first % 100) + 1) == second % 100 && ((second % 100) + 1) == third % 100)                             // Стрит
            {
                result = 4;

                if (first / 100 == second / 100 && second / 100 == third / 100)                                         // Стрит - флеш
                {
                    result = 6;
                }
            }
            else if (first % 100 == second % 100 && second % 100 == third % 100)                                         // Тройка
            {
                result = 5;
            }
            else if (first / 100 == second / 100 && second / 100 == third / 100)                                         // флеш
            {
                result = 3;
            }
            else if (first % 100 == second % 100 || first % 100 == third % 100 || second % 100 == third % 100)           // пара
            {
                result = 2;
            }
            else                                                                                                         // Нет комбинации / старшая карта
            {
                result = 1;
            }

            return (result);
        }
    }
}
