using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyGame.collision
{
    interface IblockColided
    {
        protected Rectangle collisionRectangleA { get; set; }
        protected Rectangle collisionRectangleB { get; set; }

        void Draw(SpriteBatch spriteBatch);
        void Update(GameTime gameTime);
    }
}
