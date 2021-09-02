using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MyGame.Input;
using MyGame.levels;
using System;

namespace MyGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        //texture2D voor Chef
        private Texture2D textureChefR;
        private Texture2D blokTexture;
        Hero hero;

        // level voorloopig
        Level1 level1;
        
        
 

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

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            textureChefR = Content.Load<Texture2D>("chefRechts");
            blokTexture = Content.Load<Texture2D>("block");

            InitializeGameObjects();
        }

        private void InitializeGameObjects()
        {
            hero = new Hero(textureChefR, new KeyBoardReader());
            level1 = new Level1(blokTexture);

        }

        protected override void Update(GameTime gameTime)
        {  

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            hero.Update(gameTime);
            level1.CreateWorld();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkGray);      

            _spriteBatch.Begin();

            
            level1.DrawWorld(_spriteBatch);
            hero.Draw(_spriteBatch);



            _spriteBatch.End();            

            base.Draw(gameTime);
        }
    }
}
