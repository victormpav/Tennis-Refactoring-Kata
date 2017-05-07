namespace Tennis
{
    public class TennisGame3 : ITennisGame
    {
        private const string LOVE_SCORE = "Love";
        private const string FIFTEEN_SCORE = "Fifteen";
        private const string THIRTY_SCORE = "Thirty";
        private const string FORTY_SCORE = "Forty";

        string[] SCORE_NAMES_MAPPING = { LOVE_SCORE, FIFTEEN_SCORE, THIRTY_SCORE, FORTY_SCORE };

        private const string ALL_SCORE = "-All";
        private const string SOCORE_SEPARATOR = "-";

        private const string DEUCE_SCORE = "Deuce";
        
        private const string ADVANTAGE_SCORE = "Advantage ";
        private const string WINER_MATCH = "Win for ";

        private const string PLAYER_ONE_NAME = "player1";
        private const int ADVANTAGE_THRESHOLD_POINTS = 4;
        private const int FORTY_POINTS = 3;

        private readonly Player playerOne;
        private readonly Player playerTwo;

        public TennisGame3(string playerOneName, string playerTwoName)
        {
            playerOne = new Player(playerOneName);
            playerTwo = new Player(playerTwoName);
        }

        public string GetScore()
        {
            string score;
            if ((PlayerScoresAreBelowAdvantageThreshold()) && PlayersAreNotTiedAtFourty())
            {
                score = SCORE_NAMES_MAPPING[playerOne.score];
                if (playerOne.IsTiedWith(playerTwo))
                {
                    score += ALL_SCORE;
                }
                else
                {
                    score += SOCORE_SEPARATOR + SCORE_NAMES_MAPPING[playerTwo.score];
                }
            }
            else
            {
                if (playerOne.IsTiedWith(playerTwo))
                {
                    score = DEUCE_SCORE;
                }
                else
                {
                    score = playerOne.score > playerTwo.score ? playerOne.name : playerTwo.name;
                    if ((playerOne.score - playerTwo.score) * (playerOne.score - playerTwo.score) == 1)
                    {
                        score = ADVANTAGE_SCORE + score;
                    }
                    else
                    {
                        score = WINER_MATCH + score;
                    }
                }
            }

            return score;
        }

        public bool PlayersAreNotTiedAtFourty()
        {
            return !(playerOne.score == FORTY_POINTS && playerTwo.score == FORTY_POINTS);
        }

        private bool PlayerScoresAreBelowAdvantageThreshold()
        {
            return (playerOne.score < ADVANTAGE_THRESHOLD_POINTS) && (playerTwo.score < ADVANTAGE_THRESHOLD_POINTS);
        }

        public void WonPoint(string playerName)
        {
            if (playerName == PLAYER_ONE_NAME)
                playerOne.IncreaseScore();
            else
                playerTwo.IncreaseScore();
        }
    }
}

