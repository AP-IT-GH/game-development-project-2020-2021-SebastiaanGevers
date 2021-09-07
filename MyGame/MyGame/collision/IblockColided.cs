using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyGame.collision
{
    public interface IblockColided
    {
         Rectangle collisionRectangleA { get; set; }
         Rectangle collisionRectangleB { get; set; }

        void Draw(SpriteBatch spriteBatch);
        void Update(GameTime gameTime);
    }
}
