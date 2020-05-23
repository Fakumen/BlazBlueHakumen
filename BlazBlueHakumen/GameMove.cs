using System;
using System.Collections.Generic;
using System.Drawing;

namespace BlazBlueFighter
{
    public class GameMove
    {
        public readonly string Name;
        //public readonly Input Input;
        public readonly Animation Animation;
        public readonly string ConditionalMove = null;
        public readonly MoveType MType = MoveType.GroundOnly;
        //public readonly Rectangle HurtBox;
        //public readonly Rectangle HitBox;
        public readonly float Damage;
        private readonly Action<Player> action;

        public GameMove(string name, Animation animation, MoveType type = MoveType.GroundOnly, string condMove = null, float damage = 0, Action<Player> action = null)
        {
            Name = name;
            //Input = input;
            Animation = animation;
            MType = type;
            ConditionalMove = condMove;
            Damage = damage;
            this.action = action;
        }

        public void Perform(Player player)
        {
            Animation.Reset();
            action?.Invoke(player);
            return;
        }
    }
}
