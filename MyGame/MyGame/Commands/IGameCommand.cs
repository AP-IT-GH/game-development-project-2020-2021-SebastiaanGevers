using Microsoft.Xna.Framework;

using MyGame.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyGame.Commands
{
   public interface IGameCommand
    {
        void Execute(ITransform transform , Vector2 direction);
    }

}
