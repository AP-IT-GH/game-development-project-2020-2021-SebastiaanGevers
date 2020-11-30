using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MyGame.Animation;
using MyGame.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyGame
{
    class Hero:IGameObject
    {
        //private Rectangle deelRectangle;
        //private int schuifOp_X = 0;

        Texture2D heroTexture;
        Animatie animatie;

        public Hero(Texture2D texture)
        {
            heroTexture = texture;
            
            animatie = new Animatie();
            animatie.AddFrame(new AnimatioFrame(new Rectangle(0,0,120,161)));
            animatie.AddFrame(new AnimatioFrame(new Rectangle(130, 0, 120, 161)));
            animatie.AddFrame(new AnimatioFrame(new Rectangle(260, 0, 120, 161)));
            animatie.AddFrame(new AnimatioFrame(new Rectangle(390, 0, 120, 161)));
        }

        public void Update(GameTime gameTime)
        {            
            animatie.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(heroTexture, new Vector2(10, 10),animatie.CurrentFrame.SourceRectangle, Color.White, 0, new Vector2(0, 0), 0.5f, SpriteEffects.None, 0);
        }
    }
}
