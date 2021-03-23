using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGameKursach
{
    class ChipsAnalys
    {
        public int hardbets(int num_of_combo, int ante, int pairplus, int high_card_result)
        {
            int variable = 0;

            if (pairplus == 0)
            {
                switch (num_of_combo)
                {
                    case 1:
                        if (high_card_result == 0)
                        {
                            variable = ante + ante + ante;
                            break;
                        }
                        else 
                        {
                            variable = ante + ante + ante * 2;
                            break;
                        }
                    case 2:
                        if (high_card_result == 0)
                        {
                            variable = ante + ante + ante;
                            break;
                        }
                        else
                        {
                            variable = ante + ante + ante * 2;
                            break;
                        }
                    case 3:
                        if (high_card_result == 0)
                        {
                            variable = ante + ante + ante;
                            break;
                        }
                        else
                        {
                            variable = ante + ante + ante * 2;
                            break;
                        }
                    case 4:
                        if (high_card_result == 0)
                        {
                            variable = ante + ante + ante * 2;
                            break;
                        }
                        else
                        {
                            variable = (ante + ante + ante * 2) * 2;
                            break;
                        }
                    case 5:
                        if (high_card_result == 0)
                        {
                            variable = ante + ante + ante * 4;
                            break;
                        }
                        else
                        {
                            variable = ante + ante + (ante * 2) * 4;
                            break;
                        }
                    case 6:
                        if (high_card_result == 0)
                        {
                            variable = ante + ante + ante * 5;
                            break;
                        }
                        else
                        {
                            variable = ante + ante + (ante * 2) * 5;
                            break;
                        }
                }
                return (variable);
            }
            else
            {
                switch (num_of_combo)
                {
                    case 1:
                        if (high_card_result == 0)
                        {
                            variable = ante + ante + ante;
                            break;
                        }
                        else
                        {
                            variable = ante + ante + ante * 2;
                            break;
                        }
                    case 2:
                        if (high_card_result == 0)
                        {
                            variable = (ante + ante + ante) + pairplus * 2;
                            break;
                        }
                        else
                        {
                            variable = (ante + ante + ante * 2) + pairplus * 2;
                            break;
                        }
                    case 3:
                        if (high_card_result == 0)
                        {
                            variable = (ante + ante + ante) + pairplus * 5;
                            break;
                        }
                        else
                        {
                            variable = (ante + ante + ante * 2) + pairplus * 5;
                            break;
                        }
                    case 4:
                        if (high_card_result == 0)
                        {
                            variable = (ante + ante + ante * 2) + pairplus * 6;
                            break;
                        }
                        else
                        {
                            variable = (ante + ante + (ante * 2) * 2) + pairplus * 6;
                            break;
                        }
                    case 5:
                        if (high_card_result == 0)
                        {
                            variable = (ante + ante + ante * 4) + pairplus * 21;
                            break;
                        }
                        else
                        {
                            variable = (ante + ante + (ante * 2) * 4) + pairplus * 21;
                            break;
                        }
                    case 6:
                        if (high_card_result == 0)
                        {
                            variable = (ante + ante + ante * 5) + pairplus * 41;
                            break;
                        }
                        else
                        {
                            variable = (ante + ante + (ante * 2) * 5) + pairplus * 41;
                            break;
                        }
                }

                return (variable);
            }
        }


        public int simplebets(int num_of_combo, int ante, int pairplus, int high_card_result)
        {
            int variable = 0;
        
            if (pairplus == 0)
            {
                switch (num_of_combo)
                {
                    case 2:
                        if (high_card_result == 0)
                        {
                            variable = ante + ante + ante;
                            break;
                        }
                        else
                        {
                            variable = ante + ante + ante*2;
                            break;
                        }
                    case 3:
                        if (high_card_result == 0)
                        {
                            variable = ante + ante + ante;
                            break;
                        }
                        else
                        {
                            variable = ante + ante + ante * 2;
                            break;
                        }
                    case 4:
                        if (high_card_result == 0)
                        {
                            variable = ante + ante + ante * 2;
                            break;
                        }
                        else
                        {
                            variable = ante + ante + (ante * 2) * 2;
                            break;
                        }
                    case 5:
                        if (high_card_result == 0)
                        {
                            variable = ante + ante + ante * 4;
                            break;
                        }
                        else
                        {
                            variable = ante + ante + (ante * 2) * 4;
                            break;
                        }
                    case 6:
                        if (high_card_result == 0)
                        {
                            variable = ante + ante + ante * 5;
                            break;
                        }
                        else
                        {
                            variable = ante + ante + (ante * 2) * 5;
                            break;
                        }
                }
                return (variable);
            }
            else
            {
                switch (num_of_combo)
                {
                    case 2:
                        if (high_card_result == 0)
                        {
                            variable = (ante + ante + ante) + pairplus * 2;
                            break;
                        }
                        else
                        {
                            variable = (ante + ante + ante * 2) + pairplus * 2;
                            break;
                        }
                    case 3:
                        if (high_card_result == 0)
                        {
                            variable = (ante + ante + ante) + pairplus * 5;
                            break;
                        }
                        else
                        {
                            variable = (ante + ante + ante * 2) + pairplus * 5;
                            break;
                        }
                    case 4:
                        if (high_card_result == 0)
                        {
                            variable = (ante + ante + ante * 2) + pairplus * 6;
                            break;
                        }
                        else
                        {
                            variable = (ante + ante + (ante * 2) * 2) + pairplus * 6;
                            break;
                        }
                    case 5:
                        if (high_card_result == 0)
                        {
                            variable = (ante + ante + ante * 4) + pairplus * 21;
                            break;
                        }
                        else
                        {
                            variable = (ante + ante + (ante * 2) * 4) + pairplus * 21;
                            break;
                        }
                    case 6:
                        if (high_card_result == 0)
                        {
                            variable = (ante + ante + ante * 5) + pairplus * 41;
                            break;
                        }
                        else
                        {
                            variable = (ante + ante + (ante * 2) * 5) + pairplus * 41;
                            break;
                        }
                }

                return (variable);
            }
        }

    }
}
