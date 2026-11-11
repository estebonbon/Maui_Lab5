using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;


namespace Lab5.Models
{
    public enum Difficulty
    {
        Hard,
        Intermediate,
        Easy
    }

    public class Games
    {
        public string? Name { get; set; }

        //public string? Description { get; set; }

        public Difficulty Difficulty { get; set; }

        public int? NumberOfPlayers { get; set; }

        public int? Rounds { get; set; } //meaning how many times the game has been played

        public override string ToString()
        {
            return $"{NumberOfPlayers} player(s) are currently playing the {Name}. \n The current difficulty for the game is {Difficulty}. \n The total Rounds:{Rounds}";
        }
    }
}

