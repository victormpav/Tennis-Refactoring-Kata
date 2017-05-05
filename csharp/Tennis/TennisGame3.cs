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
        
        private int playerTwoScore;
        private int playerOneScore;
        
        private string playerOneName;
        private string playerTwoNameS;

        public TennisGame3(string player1Name, string player2Name)
        {
            this.playerOneName = player1Name;
            this.playerTwoNameS = player2Name;
        }

        public string GetScore()
        {
            string score;
            if ((playerOneScore < 4 && playerTwoScore < 4) && (playerOneScore + playerTwoScore < 6))
            {
                score = SCORE_NAMES_MAPPING[playerOneScore];
                return (AreTied()) ? score + ALL_SCORE : score + SOCORE_SEPARATOR + SCORE_NAMES_MAPPING[playerTwoScore];
            }
            else
            {
                if (playerOneScore == playerTwoScore)
                    return DEUCE_SCORE;
                score = playerOneScore > playerTwoScore ? playerOneName : playerTwoNameS;
                return ((playerOneScore - playerTwoScore) * (playerOneScore - playerTwoScore) == 1) ? ADVANTAGE_SCORE + score : WINER_MATCH + score;
            }
        }

        private bool AreTied()
        {
            return playerOneScore == playerTwoScore;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == PLAYER_ONE_NAME)
                this.playerOneScore += 1;
            else
                this.playerTwoScore += 1;
        }

    }
}

