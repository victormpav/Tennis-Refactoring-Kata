using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Tennis
{
    public class TennisGame3 : ITennisGame
    {
        private readonly Player playerOne;
        private readonly Player playerTwo;
        private TennisGameScores tennisGameScores;

        private const string DEUCE = "Deuce";
        private const string ALL = "All";
        private const string ADVANTAGE = "Advantage";
        private const string WIN_FOR = "Win for";

        public TennisGame3(string player1Name, string player2Name)
        {
            playerOne = new Player(player1Name);
            playerTwo = new Player(player2Name);
            tennisGameScores = new TennisGameScores();
        }

        public string GetScore()
        {
            var bothPlayersUnderMaxScore = (playerOne.IsUnderMaxScore() && playerTwo.IsUnderMaxScore());
            var bothPlayersSumUnderSix = (playerOne.Score + playerTwo.Score < 6);

            if (playerOne.SameScoreAsPlayer(playerTwo))
            {
                if (bothPlayersUnderMaxScore && bothPlayersSumUnderSix)
                {
                    return tennisGameScores.GetScore(playerOne.Score) + "-" + ALL;
                }

                return DEUCE;
            }

            if (bothPlayersUnderMaxScore && bothPlayersSumUnderSix)
            {
                return tennisGameScores.GetScore(playerOne.Score) + "-" + tennisGameScores.GetScore(playerTwo.Score);
            }

            string playerNameBestScore = playerOne.Score > playerTwo.Score ? playerOne.Name : playerTwo.Name;

            if (Math.Abs(playerOne.Score - playerTwo.Score) == 1)
            {
                return ADVANTAGE + " " + playerNameBestScore;
            }

            return WIN_FOR + " " + playerNameBestScore;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                playerOne.IncreaseScore();
            else
                playerTwo.IncreaseScore();
        }
    }
}