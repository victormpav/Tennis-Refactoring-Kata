using System;

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

        private readonly Player playerOne;
        private readonly Player playerTwo;
        private readonly Match match;

        public TennisGame3(string playerOneName, string playerTwoName)
        {
            playerOne = new Player(playerOneName);
            playerTwo = new Player(playerTwoName);

            match = new Match(playerOne, playerTwo);
        }

        public string GetScore()
        {
            string score;

            if (match.Tied())
            {
                ReadableScoreBoard readableScoreBoard = new ReadableScoreBoard(match);
                score = readableScoreBoard.GetScore();
            }
            else
            {
                if (match.AtLeastOnePlayerHasMoreThanForty())
                {
                    score = GetScoreWithPlayerThatHaveMoreThanForty();
                }
                else
                {
                    score = GetScoreWithScoresUnderForty();
                }
            }

            return score;
        }

        private string GetScoreWithScoresUnderForty()
        {
            string score;
            score = SCORE_NAMES_MAPPING[playerOne.score] + SOCORE_SEPARATOR + SCORE_NAMES_MAPPING[playerTwo.score];
            return score;
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

        private string GetTiedScore()
        {
            string score;
            if (match.TiedAtFourtyOrMore())
            {
                score = DEUCE_SCORE;
            }
            else
            {
                score = SCORE_NAMES_MAPPING[playerOne.score] + ALL_SCORE;
            }
            return score;
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

