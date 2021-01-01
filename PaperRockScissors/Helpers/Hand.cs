using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaperRockScissors.Helpers
{
    public class Hand
    {
        public OptionRPS Selection { get; set; }
        public OptionRPS WinsAgainst { get; set; }
        public OptionRPS LosesAgainst { get; set; }
        public string Image { get; set; }

        public GameStatus PlayAgainst(Hand oponentHand)
        {

            if (Selection == oponentHand.Selection)
            {
                return GameStatus.Draw;
            }
            if (LosesAgainst == oponentHand.Selection)
            {
                return GameStatus.Loss;
            }
                return GameStatus.Victory;
        }



    }
}
