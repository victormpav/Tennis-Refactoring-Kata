namespace Tennis
{
    public class ReadableScoreBoard
    {
        private const string LOVE_SCORE = "Love";
        private const string FIFTEEN_SCORE = "Fifteen";
        private const string THIRTY_SCORE = "Thirty";
        private const string FORTY_SCORE = "Forty";

        protected string[] SCORE_NAMES_MAPPING = { LOVE_SCORE, FIFTEEN_SCORE, THIRTY_SCORE, FORTY_SCORE };

        protected const string ALL_SCORE = "-All";
        protected const string SOCORE_SEPARATOR = "-";

        protected const string DEUCE_SCORE = "Deuce";

        protected const string ADVANTAGE_SCORE = "Advantage ";
        protected const string WINER_MATCH = "Win for ";


        protected Match match;

        public ReadableScoreBoard(Match match)
        {
            this.match = match;
        }

        public string GetScore()
        {
            if (match.Tied())
            {
                ReadableScoreBoardTiedMatch readableScoreBoard = new ReadableScoreBoardTiedMatch(match);
                return readableScoreBoard.GetScore();
            }

            return string.Empty;
        }
    }
}