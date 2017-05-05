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
        private int p2;
        private int p1;
        private string p1N;
        private string p2N;

        public TennisGame3(string player1Name, string player2Name)
        {
            this.p1N = player1Name;
            this.p2N = player2Name;
        }

        public string GetScore()
        {
            string s;
            if ((p1 < 4 && p2 < 4) && (p1 + p2 < 6))
            {
                string[] p = { LOVE_SCORE, FIFTEEN_SCORE, THIRTY_SCORE, FORTY_SCORE };
                s = p[p1];
                return (p1 == p2) ? s + ALL_SCORE : s + SOCORE_SEPARATOR + p[p2];
            }
            else
            {
                if (p1 == p2)
                    return DEUCE_SCORE;
                s = p1 > p2 ? p1N : p2N;
                return ((p1 - p2) * (p1 - p2) == 1) ? ADVANTAGE_SCORE + s : WINER_MATCH + s;
            }
        }

        public void WonPoint(string playerName)
        {
            if (playerName == PLAYER_ONE_NAME)
                this.p1 += 1;
            else
                this.p2 += 1;
        }

    }
}

