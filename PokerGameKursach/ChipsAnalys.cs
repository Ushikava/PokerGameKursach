using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGameKursach
{
    class ChipsAnalys
    {
        public int HardBets(int NumOfCombo, int Ante, int Pairplus, int HighCardResult)
        {
            int Variable = 0;

            if (Pairplus == 0)
            {
                switch (NumOfCombo)
                {
                    case 1:
                        if (HighCardResult == 0)
                        {
                            Variable = Ante + Ante + Ante;
                            break;
                        }
                        else 
                        {
                            Variable = Ante + Ante + Ante * 2;
                            break;
                        }
                    case 2:
                        if (HighCardResult == 0)
                        {
                            Variable = Ante + Ante + Ante;
                            break;
                        }
                        else
                        {
                            Variable = Ante + Ante + Ante * 2;
                            break;
                        }
                    case 3:
                        if (HighCardResult == 0)
                        {
                            Variable = Ante + Ante + Ante;
                            break;
                        }
                        else
                        {
                            Variable = Ante + Ante + Ante * 2;
                            break;
                        }
                    case 4:
                        if (HighCardResult == 0)
                        {
                            Variable = Ante + Ante + Ante * 2;
                            break;
                        }
                        else
                        {
                            Variable = (Ante + Ante + Ante * 2) * 2;
                            break;
                        }
                    case 5:
                        if (HighCardResult == 0)
                        {
                            Variable = Ante + Ante + Ante * 4;
                            break;
                        }
                        else
                        {
                            Variable = Ante + Ante + (Ante * 2) * 4;
                            break;
                        }
                    case 6:
                        if (HighCardResult == 0)
                        {
                            Variable = Ante + Ante + Ante * 5;
                            break;
                        }
                        else
                        {
                            Variable = Ante + Ante + (Ante * 2) * 5;
                            break;
                        }
                }
                return (Variable);
            }
            else
            {
                switch (NumOfCombo)
                {
                    case 1:
                        if (HighCardResult == 0)
                        {
                            Variable = Ante + Ante + Ante;
                            break;
                        }
                        else
                        {
                            Variable = Ante + Ante + Ante * 2;
                            break;
                        }
                    case 2:
                        if (HighCardResult == 0)
                        {
                            Variable = (Ante + Ante + Ante) + Pairplus * 2;
                            break;
                        }
                        else
                        {
                            Variable = (Ante + Ante + Ante * 2) + Pairplus * 2;
                            break;
                        }
                    case 3:
                        if (HighCardResult == 0)
                        {
                            Variable = (Ante + Ante + Ante) + Pairplus * 5;
                            break;
                        }
                        else
                        {
                            Variable = (Ante + Ante + Ante * 2) + Pairplus * 5;
                            break;
                        }
                    case 4:
                        if (HighCardResult == 0)
                        {
                            Variable = (Ante + Ante + Ante * 2) + Pairplus * 6;
                            break;
                        }
                        else
                        {
                            Variable = (Ante + Ante + (Ante * 2) * 2) + Pairplus * 6;
                            break;
                        }
                    case 5:
                        if (HighCardResult == 0)
                        {
                            Variable = (Ante + Ante + Ante * 4) + Pairplus * 21;
                            break;
                        }
                        else
                        {
                            Variable = (Ante + Ante + (Ante * 2) * 4) + Pairplus * 21;
                            break;
                        }
                    case 6:
                        if (HighCardResult == 0)
                        {
                            Variable = (Ante + Ante + Ante * 5) + Pairplus * 41;
                            break;
                        }
                        else
                        {
                            Variable = (Ante + Ante + (Ante * 2) * 5) + Pairplus * 41;
                            break;
                        }
                }

                return (Variable);
            }
        }


        public int SimpleBets(int NumOfCombo, int Ante, int Pairplus, int HighCardResult)
        {
            int Variable = 0;
        
            if (Pairplus == 0)
            {
                switch (NumOfCombo)
                {
                    case 2:
                        if (HighCardResult == 0)
                        {
                            Variable = Ante + Ante + Ante;
                            break;
                        }
                        else
                        {
                            Variable = Ante + Ante + Ante*2;
                            break;
                        }
                    case 3:
                        if (HighCardResult == 0)
                        {
                            Variable = Ante + Ante + Ante;
                            break;
                        }
                        else
                        {
                            Variable = Ante + Ante + Ante * 2;
                            break;
                        }
                    case 4:
                        if (HighCardResult == 0)
                        {
                            Variable = Ante + Ante + Ante * 2;
                            break;
                        }
                        else
                        {
                            Variable = Ante + Ante + (Ante * 2) * 2;
                            break;
                        }
                    case 5:
                        if (HighCardResult == 0)
                        {
                            Variable = Ante + Ante + Ante * 4;
                            break;
                        }
                        else
                        {
                            Variable = Ante + Ante + (Ante * 2) * 4;
                            break;
                        }
                    case 6:
                        if (HighCardResult == 0)
                        {
                            Variable = Ante + Ante + Ante * 5;
                            break;
                        }
                        else
                        {
                            Variable = Ante + Ante + (Ante * 2) * 5;
                            break;
                        }
                }
                return (Variable);
            }
            else
            {
                switch (NumOfCombo)
                {
                    case 2:
                        if (HighCardResult == 0)
                        {
                            Variable = (Ante + Ante + Ante) + Pairplus * 2;
                            break;
                        }
                        else
                        {
                            Variable = (Ante + Ante + Ante * 2) + Pairplus * 2;
                            break;
                        }
                    case 3:
                        if (HighCardResult == 0)
                        {
                            Variable = (Ante + Ante + Ante) + Pairplus * 5;
                            break;
                        }
                        else
                        {
                            Variable = (Ante + Ante + Ante * 2) + Pairplus * 5;
                            break;
                        }
                    case 4:
                        if (HighCardResult == 0)
                        {
                            Variable = (Ante + Ante + Ante * 2) + Pairplus * 6;
                            break;
                        }
                        else
                        {
                            Variable = (Ante + Ante + (Ante * 2) * 2) + Pairplus * 6;
                            break;
                        }
                    case 5:
                        if (HighCardResult == 0)
                        {
                            Variable = (Ante + Ante + Ante * 4) + Pairplus * 21;
                            break;
                        }
                        else
                        {
                            Variable = (Ante + Ante + (Ante * 2) * 4) + Pairplus * 21;
                            break;
                        }
                    case 6:
                        if (HighCardResult == 0)
                        {
                            Variable = (Ante + Ante + Ante * 5) + Pairplus * 41;
                            break;
                        }
                        else
                        {
                            Variable = (Ante + Ante + (Ante * 2) * 5) + Pairplus * 41;
                            break;
                        }
                }

                return (Variable);
            }
        }

    }
}
