using PaperRockScissors.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace PaperRockScissors.Pages
{
    public partial class Index : IDisposable
    {
        List<Hand> hands = new List<Hand>()
        {
            new Hand{Selection = OptionRPS.Rock, LosesAgainst = OptionRPS.Paper, WinsAgainst = OptionRPS.Scissors, Image="images/rock.jpg"},
            new Hand{Selection = OptionRPS.Paper, WinsAgainst = OptionRPS.Rock, LosesAgainst= OptionRPS.Scissors, Image="images/paper.jpg"},
            new Hand{Selection = OptionRPS.Scissors, LosesAgainst = OptionRPS.Rock, WinsAgainst= OptionRPS.Paper, Image="images/scissors.jpg"}
        };


        public Timer Timer { get; set; }
        Hand oponentHand;
        string resultMessage = string.Empty;
        string resultMessageColor = string.Empty;
        public void Dispose()
        {
            if (Timer != null)
            {
                Timer.Dispose();
            }
        }

        protected override void OnInitialized()
        {
            oponentHand = hands[0];
            Timer = new Timer();
            Timer.Interval = 100;
            Timer.Elapsed += TimerOnElapsed;
            Timer.Start();
        }
        int indexOponentHand = 0;
        private void TimerOnElapsed(object sender, ElapsedEventArgs e)
        {
            indexOponentHand = (indexOponentHand + 1) % hands.Count;
            oponentHand = hands[indexOponentHand];
            StateHasChanged();
        }
        private void SelectHand(Hand hand)
        {
            Timer.Stop();
            var result = hand.PlayAgainst(oponentHand);

            if (result == GameStatus.Victory)
            {
                resultMessageColor = "green";
                resultMessage = "You WIN!";
            }
            else if (result == GameStatus.Loss)
            {
                resultMessageColor = "red";
                resultMessage = "You Loose!";
            }
            else
            {
                resultMessageColor = "bue";
                resultMessage = "It's a DRAW. Try Again?";
            }

        }

        private void PlayAgain()
        {

            Timer.Start();
            resultMessage = string.Empty;
        }
    }

}
