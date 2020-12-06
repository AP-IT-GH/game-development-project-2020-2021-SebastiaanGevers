using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MyGame.Animation;
using MyGame.Commands;
using MyGame.Input;
using MyGame.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyGame
{
    class Hero:IGameObject, ITransform
    {
        
        //picture
        Texture2D heroTexture;
        Animatie animatie;

        //movement    
        private Vector2 snelheid;
        private Vector2 versnelling;       
        public Vector2 Position { get ; set; }

        // inputs
        private IInputReader inputReader;
        //private IInputReader mouseReader;
        // commando's
        private IGameCommand moveCommand;
        //private IGameCommand moveToComannd;

           

        public Hero(Texture2D texture, IInputReader reader)
        {
            heroTexture = texture;
            
            animatie = new Animatie();
            animatie.AddFrame(new AnimatioFrame(new Rectangle(0,0,120,161)));
            animatie.AddFrame(new AnimatioFrame(new Rectangle(130, 0, 120, 161)));
            animatie.AddFrame(new AnimatioFrame(new Rectangle(260, 0, 120, 161)));
            animatie.AddFrame(new AnimatioFrame(new Rectangle(390, 0, 120, 161)));

            // positie = new Vector2(10, 10);
            snelheid = new Vector2(1, 1);
            versnelling = new Vector2(0.1f,0.1f);

            //Read the input for my hero
            //keyboard
            this.inputReader = reader;
            moveCommand = new MoveCommand();
           //Mouse
           // mouseReader = new MouseReader();           
           // moveCommand = new MoveToCommando();

        }

        public void Update(GameTime gameTime)
        {
            var direction = inputReader.ReadInput();
            MoveHorizontal(direction);

            /* if (inputReader.ReadFollower())
             {
                 Move(mouseReader.ReadInput());
             }*/


            animatie.Update(gameTime);
        }

        private void MoveHorizontal(Vector2 _direction)
        {
            moveCommand.Execute(this, _direction);
        }


       /* private void Move(Vector2 mous)
        {
            moveToComannd.Execute(this, mous);

            //if (positie.x >600 || positie.x<0)
            //{
            //    snelheid.x *= -1;
            //    versnelling.x *= -1;
            //}
            //if (positie.y>400 || positie.y<0)
            //{
            //    snelheid.y *= -1;
            //    versnelling.y *= -1;
            //}
        }*/
       

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(heroTexture, Position, animatie.CurrentFrame.SourceRectangle, Color.White, 0, new Vector2(0, 0), 0.5f, SpriteEffects.None, 0);
        }
    }
}
