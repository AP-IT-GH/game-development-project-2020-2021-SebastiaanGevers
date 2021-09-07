using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MyGame.collision;
using MyGame.Input;
using MyGame.levels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyGame.States
{
    public class GameState : State
    {
        //texture2D voor Chef
        private Texture2D textureChefR;
        private Texture2D textureChefL;
        private Texture2D blokTexture;
        Hero hero;

        // door level
        private Texture2D doorTopTexture;
        private Texture2D doorBotTexture;
        private Texture2D collisionTexture;

        // level voorloopig
        Level1 level1;

        //collision
        CollisionManger collisionLevel1;
        Game1 _game;
        
        GraphicsDevice _grapichDevice;
        ContentManager _content;



        public GameState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            _game = game;
            _content = content;
            _graphicsDevice = graphicsDevice;
            


            LoadContent();
            
        }

        protected void LoadContent()
        {

            textureChefR = _content.Load<Texture2D>("chefRechts");
            textureChefL = _content.Load<Texture2D>("chefLinks");
            blokTexture = _content.Load<Texture2D>("block");
            doorTopTexture = _content.Load<Texture2D>("doorAangepastBoven");
            doorBotTexture = _content.Load<Texture2D>("doorAangepastOnder");
            collisionTexture = _content.Load<Texture2D>("collision block");
            InitializeGameObjects();          
            
        }

        private void InitializeGameObjects()
        {
            hero = new Hero(textureChefR,textureChefL, collisionTexture, new KeyBoardReader());
            level1 = new Level1(blokTexture,doorTopTexture,doorBotTexture,collisionTexture);
            collisionLevel1 = new CollisionManger(level1.Collides, _game,hero,_content,_graphicsDevice);
        }        

        public override void PostUpdate(GameTime _gameTime)
        {
           // gebruiken we niet
        }

        public override void update(GameTime _gameTime)
        {
            level1.CreateWorld();          
            hero.Update(_gameTime);



        }

        public override void Draw(GameTime _gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();            
            level1.DrawWorld(spriteBatch);
            hero.Draw(spriteBatch);
            spriteBatch.End(); 
        }
    }
}
