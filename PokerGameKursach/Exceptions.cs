using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGameKursach
{
    class Exceptions
    {

        public int uexception(int num_of_combo, int p_first, int p_second, int p_third, int k_first, int k_second, int k_third)
        {
            int result = 0;                                                                           //1 - Игрок победил || 2 - пк победил || 3 - ничья || 0 - У крупье нет игры

            if ((k_first % 100) >= 12 || (k_second % 100) >= 12 || (k_third % 100) >= 12)
            {
                if (num_of_combo == 1)                                                                  // Старшая карта у обоих
                {
                    if (p_third % 100 > k_third % 100)
                    {
                        result = 1;
                        return (result);
                    }
                    else if (p_third % 100 < k_third % 100)
                    {
                        result = 2;
                        return (result);
                    }
                    else
                    {
                        if (p_second % 100 > k_second % 100)
                        {
                            result = 1;
                            return (result);
                        }
                        else if (p_second % 100 < k_second % 100)
                        {
                            result = 2;
                            return (result);
                        }
                        else
                        {
                            if (p_first % 100 > k_first % 100)
                            {
                                result = 1;
                                return (result);
                            }
                            else if (p_first % 100 < k_first % 100)
                            {
                                result = 2;
                                return (result);
                            }
                            else
                            {
                                result = 3;
                                return (result);
                            }
                        }
                    }
                }
                else if (num_of_combo == 2)                                                             // пара у обоих
                {
                    if (p_second % 100 > k_second % 100)
                    {
                        result = 1;
                        return (result);
                    }
                    else if (p_second % 100 < k_second % 100)
                    {
                        result = 2;
                        return (result);
                    }
                    else
                    {
                        if ((p_first % 100) + (p_second % 100) + (p_third % 100) > (k_first % 100) + (k_second % 100) + (k_third % 100))
                        {
                            result = 1;
                            return (result);
                        }
                        else if ((p_first % 100) + (p_second % 100) + (p_third % 100) < (k_first % 100) + (k_second % 100) + (k_third % 100))
                        {
                            result = 2;
                            return (result);
                        }
                        else
                        {
                            result = 3;
                            return (result);
                        }
                    }
                }
                else if (num_of_combo == 3)                                                             // флеш у обоих
                {
                    if (p_third % 100 > k_third % 100)
                    {
                        result = 1;
                        return (result);
                    }
                    else if (p_third % 100 < k_third % 100)
                    {
                        result = 2;
                        return (result);
                    }
                    else
                    {
                        if (p_second % 100 > k_second % 100)
                        {
                            result = 1;
                            return (result);
                        }
                        else if (p_second % 100 < k_second % 100)
                        {
                            result = 2;
                            return (result);
                        }
                        else
                        {
                            if (p_first % 100 > k_first % 100)
                            {
                                result = 1;
                                return (result);
                            }
                            else if (p_first % 100 < k_first % 100)
                            {
                                result = 2;
                                return (result);
                            }
                            else
                            {
                                result = 3;
                                return (result);
                            }
                        }
                    }
                }
                else if (num_of_combo == 4)                                                             // стрит у обоих
                {
                    if (p_third % 100 > k_third % 100)
                    {
                        result = 1;
                        return (result);
                    }
                    else if (p_third % 100 < k_third % 100)
                    {
                        result = 2;
                        return (result);
                    }
                    else
                    {
                        result = 3;
                        return (result);
                    }
                }
                else if (num_of_combo == 5)                                                             // Тройка у обоих (НЕ МОЖЕТ БЫТЬ!)
                {
                    if (p_third % 100 > k_third % 100)
                    {
                        result = 1;
                        return (result);
                    }
                    else if (p_third % 100 < k_third % 100)
                    {
                        result = 2;
                        return (result);
                    }
                    else
                    {
                        result = 3;
                        return (result);
                    }
                }
                else                                                                                    // Стрит - флеш у обоих
                {
                    if (p_third % 100 > k_third % 100)
                    {
                        result = 1;
                        return (result);
                    }
                    else if (p_third % 100 < k_third % 100)
                    {
                        result = 2;
                        return (result);
                    }
                    else
                    {
                        result = 3;
                        return (result);
                    }
                }
            }
            else
            {
                result = 0;
                return (result);
            }

        }

    }
}
