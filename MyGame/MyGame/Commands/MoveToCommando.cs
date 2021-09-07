using Microsoft.Xna.Framework;
using MyGame.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyGame.Commands
{
    public class MoveToCommando : IGameCommand
    {
        private Vector2 snelheid;

        public MoveToCommando()
        {
            snelheid = new Vector2(1, 0);
        }
        void IGameCommand.Execute(ITransform transform, Vector2 direction)
        {
            direction = Vector2.Add(direction, -transform.Position);
            direction.Normalize();
            direction = Vector2.Multiply(direction, 0.5f);

            
            snelheid += direction;
            snelheid = Limit(snelheid, 5);
            transform.Position += snelheid;
        }

        //normaal eigen vector klasse schrijven
        private Vector2 Limit(Vector2 v, float max)
        {
            if (v.Length() > max)
            {
                var ratio = max / v.Length();
                v.X *= ratio;
                v.Y *= ratio;
            }
            return v;
        }
    }
   
}
