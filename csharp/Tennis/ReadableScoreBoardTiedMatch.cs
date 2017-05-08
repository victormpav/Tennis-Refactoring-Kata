namespace Tennis
{
    public class ReadableScoreBoardTiedMatch : ReadableScoreBoard
    {
        public ReadableScoreBoardTiedMatch(Match match) : base(match)
        {

        }

        public override string Score()
        {
            string score;

            if (match.TiedAtFourtyOrMore())
            {
                score = DEUCE_SCORE;
            }
            else
            {
                score = SCORE_NAMES_MAPPING[match.GetPlayerOneScore()] + ALL_SCORE;
            }

            return score;
        }
    }
}