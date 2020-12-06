using Microsoft.Xna.Framework;
using MyGame.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyGame.Commands
{
    class MoveCommand : IGameCommand
    {
        public Vector2 speed;

        public MoveCommand()
        {
            this.speed = new Vector2(5, 0);
        }

        void IGameCommand.Execute(ITransform transform, Vector2 direction)
        {
            direction *= speed;
            transform.Position += direction;
        }
    }
}
