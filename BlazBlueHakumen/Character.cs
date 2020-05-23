using System;
using System.Collections.Generic;

namespace BlazBlueFighter
{
    public class Character
    {
        public readonly string Name;
        public readonly float InitialHealth;
        public readonly Dictionary<string, GameMove> MoveList;

        public Character(
            string name, 
            float health, 
            Dictionary<string, GameMove> moveList)
        {
            Name = name;
            InitialHealth = health;
            MoveList = moveList;
        }
        //public void PerformMove()
    }
}
