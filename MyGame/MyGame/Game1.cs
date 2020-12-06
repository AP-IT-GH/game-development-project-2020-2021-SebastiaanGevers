using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MyGame.Input;
using System;

namespace MyGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        //texture2D voor Chef
        private Texture2D textureChefR;
        Hero hero;
        
 

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

           

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            textureChefR = Content.Load<Texture2D>("chefRechts");

            InitializeGameObjects();
        }

        private void InitializeGameObjects()
        {
            hero = new Hero(textureChefR, new KeyBoardReader());
        }

        protected override void Update(GameTime gameTime)
        {

            

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            hero.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkGray);      

            _spriteBatch.Begin();

            hero.Draw(_spriteBatch);
                     
            _spriteBatch.End();            

            base.Draw(gameTime);
        }
    }
}
