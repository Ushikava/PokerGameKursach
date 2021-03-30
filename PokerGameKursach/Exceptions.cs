using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGameKursach
{
    class Exceptions
    {

        public int UException(int NumOfCombo, int PFirst, int PSecond, int PThird, int DFirst, int DSecond, int DThird)
        {
            int Result = 0;                                                                           //1 - Игрок победил || 2 - пк победил || 3 - ничья || 0 - У крупье нет игры

            if ((DFirst % 100) >= 12 || (DSecond % 100) >= 12 || (DThird % 100) >= 12)
            {
                if (NumOfCombo == 1)                                                                  // Старшая карта у обоих
                {
                    if (PThird % 100 > DThird % 100)
                    {
                        Result = 1;
                        return (Result);
                    }
                    else if (PThird % 100 < DThird % 100)
                    {
                        Result = 2;
                        return (Result);
                    }
                    else
                    {
                        if (PSecond % 100 > DSecond % 100)
                        {
                            Result = 1;
                            return (Result);
                        }
                        else if (PSecond % 100 < DSecond % 100)
                        {
                            Result = 2;
                            return (Result);
                        }
                        else
                        {
                            if (PFirst % 100 > DFirst % 100)
                            {
                                Result = 1;
                                return (Result);
                            }
                            else if (PFirst % 100 < DFirst % 100)
                            {
                                Result = 2;
                                return (Result);
                            }
                            else
                            {
                                Result = 3;
                                return (Result);
                            }
                        }
                    }
                }
                else if (NumOfCombo == 2)                                                             // пара у обоих
                {
                    if (PSecond % 100 > DSecond % 100)
                    {
                        Result = 1;
                        return (Result);
                    }
                    else if (PSecond % 100 < DSecond % 100)
                    {
                        Result = 2;
                        return (Result);
                    }
                    else
                    {
                        if ((PFirst % 100) + (PSecond % 100) + (PThird % 100) > (DFirst % 100) + (DSecond % 100) + (DThird % 100))
                        {
                            Result = 1;
                            return (Result);
                        }
                        else if ((PFirst % 100) + (PSecond % 100) + (PThird % 100) < (DFirst % 100) + (DSecond % 100) + (DThird % 100))
                        {
                            Result = 2;
                            return (Result);
                        }
                        else
                        {
                            Result = 3;
                            return (Result);
                        }
                    }
                }
                else if (NumOfCombo == 3)                                                             // флеш у обоих
                {
                    if (PThird % 100 > DThird % 100)
                    {
                        Result = 1;
                        return (Result);
                    }
                    else if (PThird % 100 < DThird % 100)
                    {
                        Result = 2;
                        return (Result);
                    }
                    else
                    {
                        if (PSecond % 100 > DSecond % 100)
                        {
                            Result = 1;
                            return (Result);
                        }
                        else if (PSecond % 100 < DSecond % 100)
                        {
                            Result = 2;
                            return (Result);
                        }
                        else
                        {
                            if (PFirst % 100 > DFirst % 100)
                            {
                                Result = 1;
                                return (Result);
                            }
                            else if (PFirst % 100 < DFirst % 100)
                            {
                                Result = 2;
                                return (Result);
                            }
                            else
                            {
                                Result = 3;
                                return (Result);
                            }
                        }
                    }
                }
                else if (NumOfCombo == 4)                                                             // стрит у обоих
                {
                    if (PThird % 100 > DThird % 100)
                    {
                        Result = 1;
                        return (Result);
                    }
                    else if (PThird % 100 < DThird % 100)
                    {
                        Result = 2;
                        return (Result);
                    }
                    else
                    {
                        Result = 3;
                        return (Result);
                    }
                }
                else if (NumOfCombo == 5)                                                             // Тройка у обоих (НЕ МОЖЕТ БЫТЬ!)
                {
                    if (PThird % 100 > DThird % 100)
                    {
                        Result = 1;
                        return (Result);
                    }
                    else if (PThird % 100 < DThird % 100)
                    {
                        Result = 2;
                        return (Result);
                    }
                    else
                    {
                        Result = 3;
                        return (Result);
                    }
                }
                else                                                                                    // Стрит - флеш у обоих
                {
                    if (PThird % 100 > DThird % 100)
                    {
                        Result = 1;
                        return (Result);
                    }
                    else if (PThird % 100 < DThird % 100)
                    {
                        Result = 2;
                        return (Result);
                    }
                    else
                    {
                        Result = 3;
                        return (Result);
                    }
                }
            }
            else
            {
                Result = 0;
                return (Result);
            }

        }

    }
}
