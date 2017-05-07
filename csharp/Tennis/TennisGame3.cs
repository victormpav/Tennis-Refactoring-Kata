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
        private const int ADVANTAGE_THRESHOLD_POINTS = 4;
        private const int FORTY_POINTS = 3;

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
            if ((PlayerScoresAreBelowAdvantageThreshold(playerOne, playerTwo)) && PlayersAreNotTiedAtFourty(playerOne, playerTwo))
            {
                score = SCORE_NAMES_MAPPING[playerOne.score];
                if (match.Tied())
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
                if (match.Tied())
                {
                    score = DEUCE_SCORE;
                }
                else
                {
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
                }
            }

            return score;
        }




        public bool PlayersAreNotTiedAtFourty(Player thePlayerOne, Player thePlayerTwo)
        {
            return !(thePlayerOne.score == FORTY_POINTS && thePlayerTwo.score == FORTY_POINTS);
        }

        private bool PlayerScoresAreBelowAdvantageThreshold(Player thePlayerOne, Player thePlayerTwo)
        {
            return (thePlayerOne.score < ADVANTAGE_THRESHOLD_POINTS) && (thePlayerTwo.score < ADVANTAGE_THRESHOLD_POINTS);
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

