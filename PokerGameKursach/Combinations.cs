using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGameKursach
{
    public class Combinations
    {

        public int Combo(int First, int Ssecond, int Third)
        {
            int Result = 0;

            if (((First % 100) + 1) == Ssecond % 100 && ((Ssecond % 100) + 1) == Third % 100)                             // Стрит
            {
                Result = 4;

                if (First / 100 == Ssecond / 100 && Ssecond / 100 == Third / 100)                                         // Стрит - флеш
                {
                    Result = 6;
                }
            }
            else if (First % 100 == Ssecond % 100 && Ssecond % 100 == Third % 100)                                         // Тройка
            {
                Result = 5;
            }
            else if (First / 100 == Ssecond / 100 && Ssecond / 100 == Third / 100)                                         // флеш
            {
                Result = 3;
            }
            else if (First % 100 == Ssecond % 100 || First % 100 == Third % 100 || Ssecond % 100 == Third % 100)           // пара
            {
                Result = 2;
            }
            else                                                                                                            // Нет комбинации / старшая карта
            {
                Result = 1;
            }

            return (Result);
        }
    }
}
