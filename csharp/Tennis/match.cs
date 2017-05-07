using System;

namespace Tennis
{
    public class Match
    {
        public readonly Player playerOne;
        public readonly Player playerTwo;

        public Match(Player playerOne, Player playerTwo)
        {
            this.playerOne = playerOne;
            this.playerTwo = playerTwo;
        }

        public int AbsoluteDiffrenceBetweenPlayers()
        {
            return Math.Abs(playerOne.score - playerTwo.score);
        }

        public Player PlayerWithHighScore()
        {
            return playerOne.score > playerTwo.score ? playerOne : playerTwo;
        }

        public bool Tied()
        {
            return playerOne.score == playerTwo.score;
        }
    }
}