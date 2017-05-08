using System;

namespace Tennis
{
    public class ReadableScoreBoardNonTiedMatch : ReadableScoreBoard
    {
        public ReadableScoreBoardNonTiedMatch(Match match) : base(match)
        {

        }

        public override string Score()
        {
            string score;

            if (match.AtLeastOnePlayerHasMoreThanForty())
            {
                score = GetScoreWithPlayerThatHaveMoreThanForty();
            }
            else
            {
                score = GetScoreWithScoresUnderForty();
            }

            return score;
        }


        private string GetScoreWithScoresUnderForty()
        {
            return SCORE_NAMES_MAPPING[match.GetPlayerOneScore()] + SOCORE_SEPARATOR + SCORE_NAMES_MAPPING[match.GetPlayerTwoScore()];
        }

        private string GetScoreWithPlayerThatHaveMoreThanForty()
        {
            string score;
            Player playerWithHighScore = match.PlayerWithHighScore();
            String highestScorePlayerName = playerWithHighScore.name;
            if (match.AbsoluteDiffrenceBetweenPlayers() == 1)
            {
                score = ADVANTAGE_SCORE + highestScorePlayerName;
            }
            else
            {
                score = WINER_MATCH + highestScorePlayerName;
            }
            return score;
        }
    }
}