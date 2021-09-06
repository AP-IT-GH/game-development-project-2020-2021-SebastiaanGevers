using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MyGame.Controls;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyGame.States
{
    public class MenuState : State
    {
        private List<Component> _components;
        public MenuState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            var buttonTexture = _content.Load<Texture2D>("Button");
            var buttonFont = _content.Load<SpriteFont>("Font");

            var newGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(300,200),
                Text = "New Game",
            };
            newGameButton.Click += NewGameButton_Click;

            var loadGameButton  = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(300, 250),
                Text = "Load Game",
            };

            loadGameButton.Click += LoadGameButton_Click;

            var quitGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(300, 250),
                Text = "quit Game",

            };

            quitGameButton.Click += quitGameButton_Click;

            _components = new List<Component>()
            {
                newGameButton,
                loadGameButton,
                quitGameButton,

            };
        }

        private void quitGameButton_Click(object sender, EventArgs e)
        {
            _game.Exit();
        }

        private void LoadGameButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Load Game");
        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            // load new state 
            _game.ChangeState(new GameState(_game,_graphicsDevice,_content));
        }
        public override void PostUpdate(GameTime gameTime)
        {
            // remove sprites als niet nodig is
            // niet gebruikt
        }

        public override void update(GameTime gameTime)
        {
            foreach (var component in _components)
                component.Update(gameTime);
        }


        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            foreach (var component in _components)
            {
                component.Draw(gameTime, spriteBatch);
            }

            spriteBatch.End();
        }
    }
}
