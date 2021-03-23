using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGameKursach
{
    public class Cards
    {

        /*public enum Suit //Масти множащиеся на 100
        { 
            heart = 1,
            diamond = 2,
            club = 3,
            spade = 4
        }*/

        public int cards(int suit_index, int rank_index)
        {
            return (suit_index*100 + rank_index);
        }
    }
}
