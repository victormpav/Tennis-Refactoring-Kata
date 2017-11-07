using System.Collections.Generic;

namespace Tennis
{
    public class TennisGameScores
    {
        private const string LOVE = "Love";
        private const string FIFTEEN = "Fifteen";
        private const string THIRTY = "Thirty";
        private const string FORTY = "Forty";

        private List<string> scores = new List<string> {LOVE, FIFTEEN, THIRTY, FORTY};

        public string GetScore(int score)
        {
            return scores[score];
        }
    }
}