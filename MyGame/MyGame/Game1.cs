using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MyGame.Input;
using MyGame.levels;
using MyGame.States;
using System;
using static System.Windows.Forms.AxHost;
using State = MyGame.States.State;

namespace MyGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        //texture2D voor Chef
        //private Texture2D textureChefR;
        //private Texture2D blokTexture;
        //Hero hero;

        //// door level
        //private Texture2D doorTopTexture;
        //private Texture2D doorBotTexture;

        //// level voorloopig
        //Level1 level1;

        //states
        private State _currentState;
        private State _nextState;
        public void ChangeState(State _state)
        {
            _nextState = _state;
        }
        
 

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            
            IsMouseVisible = true;
            _graphics.PreferredBackBufferWidth = 1920;
            _graphics.PreferredBackBufferHeight = 1080;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here        
            IsMouseVisible = true;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            /*
             voor de states komt van deze video en heb hier en daar aanpassingen gedaan
                - https://github.com/Oyyou/MonoGame_Tutorials/tree/master/MonoGame_Tutorials/Tutorial012
                - https://www.youtube.com/watch?v=76Mz7ClJLoE&t=624s

            */
            _currentState = new MenuState(this, _graphics.GraphicsDevice, Content);


            InitializeGameObjects();
        }

        ////internal void ChangeState()
        ////{
        ////    throw new NotImplementedException();
        ////}

        private void InitializeGameObjects()
        {
            //hero = new Hero(textureChefR, new KeyBoardReader());
            //level1 = new Level1(blokTexture,doorTopTexture,doorBotTexture);

        }

        protected override void Update(GameTime gameTime)
        {  


            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if(_nextState != null)
            {
                _currentState = _nextState;
                _nextState = null;
            }

            _currentState.update(gameTime);
            _currentState.PostUpdate(gameTime);

            
            // updaten hero en level moet naar game state
            //hero.Update(gameTime);
            //level1.CreateWorld();


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkGray);
            _currentState.Draw(gameTime, _spriteBatch);

            // moet ook naar game state
            //_spriteBatch.Begin();            
            //level1.DrawWorld(_spriteBatch);
            //hero.Draw(_spriteBatch);
            //_spriteBatch.End();            

            base.Draw(gameTime);
        }
    }
}
