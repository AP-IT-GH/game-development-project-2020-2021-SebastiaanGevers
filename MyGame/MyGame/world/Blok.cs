using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MyGame.collision;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyGame.world
{
    public class Blok:IblockColided
    {

        // code meneer
        public Texture2D _texture { get; set; }
        public Vector2 Positie { get; set; }

        //collision
        private Rectangle _collisionRectangleTop;
        private Rectangle _collisionRectangleBot;
        Texture2D collisionTexture;

        public Blok(Texture2D texture,Texture2D colTexture, Vector2 pos)
        {
            _texture = texture;
            Positie = pos;
            collisionTexture = colTexture;

            _collisionRectangleTop = new Rectangle((int)pos.X,(int)pos.Y,64,20);
            _collisionRectangleBot = new Rectangle((int)pos.X, (int)pos.Y + 44, 64, 20);
        }

        Rectangle IblockColided.collisionRectangleA { get => _collisionRectangleTop; set => _collisionRectangleTop = value; }
        Rectangle IblockColided.collisionRectangleB { get => _collisionRectangleTop; set => _collisionRectangleTop = value; }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Positie, Color.AliceBlue);
            spriteBatch.Draw(collisionTexture, _collisionRectangleTop, Color.AliceBlue);
            spriteBatch.Draw(collisionTexture, _collisionRectangleBot, Color.AliceBlue);

        }

        public void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
