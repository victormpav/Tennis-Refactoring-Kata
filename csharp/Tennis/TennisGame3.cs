namespace Tennis
{
    public class TennisGame3 : ITennisGame
    {
        private const string LOVE_SCORE = "Love";
        private const string FIFTEEN_SCORE = "Fifteen";
        private const string THIRTY_SCORE = "Thirty";
        private const string FORTY_SCORE = "Forty";
        private const string ALL_SCORE = "-All";
        private const string SOCORE_SEPARATOR = "-";
        private const string DEUCE_SCORE = "Deuce";
        private const string ADVANTAGE_SCORE = "Advantage ";
        private const string WINER_MATCH = "Win for ";
        private const string PLAYER_ONE_NAME = "player1";
        private int playerTwoScore;
        private int playerOneScore;
        private string playerOneName;
        private string p2N;

        public TennisGame3(string player1Name, string player2Name)
        {
            this.playerOneName = player1Name;
            this.p2N = player2Name;
        }

        public string GetScore()
        {
            string score;
            if ((playerOneScore < 4 && playerTwoScore < 4) && (playerOneScore + playerTwoScore < 6))
            {
                string[] scoresNames = { LOVE_SCORE, FIFTEEN_SCORE, THIRTY_SCORE, FORTY_SCORE };
                score = scoresNames[playerOneScore];
                return (playerOneScore == playerTwoScore) ? score + ALL_SCORE : score + SOCORE_SEPARATOR + scoresNames[playerTwoScore];
            }
            else
            {
                if (playerOneScore == playerTwoScore)
                    return DEUCE_SCORE;
                score = playerOneScore > playerTwoScore ? playerOneName : p2N;
                return ((playerOneScore - playerTwoScore) * (playerOneScore - playerTwoScore) == 1) ? ADVANTAGE_SCORE + score : WINER_MATCH + score;
            }
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

