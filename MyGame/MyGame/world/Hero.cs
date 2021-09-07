using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MyGame.Animation;
using MyGame.collision;
using MyGame.Commands;
using MyGame.Input;
using MyGame.interfaces;
using System;
using System.Collections.Generic;
using System.Text;


namespace MyGame
{
    class Hero:IGameObject, ITransform,IblockColided
    {
        
        //picture
        Texture2D heroTextureR;
        Texture2D heroTextureL;
        Animatie animatieR;
        Animatie animatieL;

        //movement    
        private Vector2 snelheid;
        private Vector2 versnelling;       
        //public Vector2 Position { get ; set; }

        private Vector2 _positionCol { get; set; }

        public Vector2 Position
        {
            get { return _positionCol; }
            set
            {
                _positionCol = value;
                Rectangle temp = _collisionRectangleA;
                temp.Location = _positionCol.ToPoint();
                temp.X += 10;
                collisionRectangleA = temp;
                temp.X += temp.Width + 0;
                collisionRectangleB = temp;
            }
        }

        private bool moveRight = false;
        

        // inputs
        private IInputReader inputReader;
        //private IInputReader mouseReader;
        // commando's
        private IGameCommand moveCommand;
        //private IGameCommand moveToComannd;

        //collision
        private Rectangle _collisionRectangleA;
        private Rectangle _collisionRectangleB;
        private Texture2D collisionTexture;
        public bool stopLeft = false;




        public Hero(Texture2D textureR, Texture2D textureL ,Texture2D textureColision, IInputReader reader)
        {
            heroTextureR = textureR;
            heroTextureL = textureL;
            collisionTexture = textureColision;
            
            animatieR = new Animatie();
            animatieR.AddFrame(new AnimatioFrame(new Rectangle(0,0,120,161)));
            animatieR.AddFrame(new AnimatioFrame(new Rectangle(130, 0, 120, 161)));
            animatieR.AddFrame(new AnimatioFrame(new Rectangle(260, 0, 120, 161)));
            animatieR.AddFrame(new AnimatioFrame(new Rectangle(390, 0, 120, 161)));

            //animatieL = new Animatie();
            //animatieL.AddFrame(new AnimatioFrame(new Rectangle(0, 0, 120, 161)));
            //animatieL.AddFrame(new AnimatioFrame(new Rectangle(130, 0, 120, 161)));
            //animatieL.AddFrame(new AnimatioFrame(new Rectangle(260, 0, 120, 161)));
            //animatieL.AddFrame(new AnimatioFrame(new Rectangle(390, 0, 120, 161)));

            animatieL = new Animatie();
            animatieL.AddFrame(new AnimatioFrame(new Rectangle(390, 0, 120, 161)));
            animatieL.AddFrame(new AnimatioFrame(new Rectangle(260, 0, 120, 161)));
            animatieL.AddFrame(new AnimatioFrame(new Rectangle(130, 0, 120, 161)));
            animatieL.AddFrame(new AnimatioFrame(new Rectangle(0, 0, 120, 161)));


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

            //collision
            _collisionRectangleA = new Rectangle((int)Position.X, (int)Position.Y, 10, 50);
            _collisionRectangleB = new Rectangle((int)Position.X+120, (int)Position.Y, 10, 50);

        }

         public Rectangle collisionRectangleA { get => _collisionRectangleA; set => _collisionRectangleA = value; }
         public Rectangle collisionRectangleB { get => _collisionRectangleB; set => _collisionRectangleB = value; }

        public void Update(GameTime gameTime)
        {
            var direction = inputReader.ReadInput();            
            MoveHorizontal(direction);

            if (direction.X == 1)
            {
                moveRight = true;
            }
            else if(direction.X==-1)
            {
                moveRight = false;
            }
            _collisionRectangleA = new Rectangle((int)Position.X+65, (int)Position.Y+945, 10, 85);
            _collisionRectangleB = new Rectangle((int)Position.X +115, (int)Position.Y+945, 10, 85);


            //stoppen van uit collision manger

            if (stopLeft)
            {
                if (direction.X ==-1)
                {
                    direction.X = 0;
                }
                stopLeft = false;
            }


            /* if (inputReader.ReadFollower())
             {
                 Move(mouseReader.ReadInput());
             }*/


            animatieR.Update(gameTime);
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

            if (moveRight)
            {
                spriteBatch.Draw(heroTextureR, Position, animatieR.CurrentFrame.SourceRectangle, Color.White, 0, new Vector2(-130,-1890), 0.5f, SpriteEffects.None, 0);
            }
            else
            {
                spriteBatch.Draw(heroTextureL, Position, animatieR.CurrentFrame.SourceRectangle, Color.White, 0, new Vector2(-130,-1890), 0.5f, SpriteEffects.None, 0);
            }

            //spriteBatch.Draw(collisionTexture,Position ,_collisionRectangleA, Color.AliceBlue, 0, new Vector2(-130, -1890), 0.5f, SpriteEffects.None, 0);
            //spriteBatch.Draw(collisionTexture,Position, _collisionRectangleB, Color.AliceBlue, 0, new Vector2(-250, -1890), 0.5f, SpriteEffects.None, 0);


            spriteBatch.Draw(collisionTexture, _collisionRectangleA, Color.AliceBlue);
            spriteBatch.Draw(collisionTexture, _collisionRectangleB, Color.AliceBlue);
        }
    }
}
