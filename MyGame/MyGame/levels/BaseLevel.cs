using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MyGame.world;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyGame.levels
{
    public abstract class BaseLevel
    {
        public Texture2D blokTexture;
        public Texture2D doorTopTexture;
        public Texture2D doorBotTexture;
        public Texture2D collisionTexture;

        public byte[,] byteTileArray;
        public Blok[,] blokArray;

        public BaseLevel(Texture2D _blokTexture, Texture2D _doorTopTexture, Texture2D _doorBotTexture, Texture2D colTexture)
        {
            TileArray();
            blokArray = new Blok[byteTileArray.GetLength(0), byteTileArray.GetLength(1)];

            blokTexture = _blokTexture;
            doorTopTexture = _doorTopTexture;
            doorBotTexture = _doorBotTexture;
            collisionTexture = colTexture;
            CreateWorld();
        }

        //zorgt er voor dat je een tile array kunt mee geven dat verschischilend is voor elk level
        public abstract void TileArray();

        public void CreateWorld()
        {
            for (int x = 0; x < byteTileArray.GetLength(0); x++)
            {
                for (int y = 0; y < byteTileArray.GetLength(1); y++)
                {
                    if (byteTileArray[x, y] == 1)
                    {
                        blokArray[x, y] = new Blok(blokTexture,collisionTexture, new Vector2(y * 64, x * 64));
                    }
                    if (byteTileArray[x, y] == 2)
                    {
                        blokArray[x, y] = new Blok(doorTopTexture, collisionTexture, new Vector2(y * 64, x * 64));
                    }
                    if (byteTileArray[x, y] == 3)
                    {
                        blokArray[x, y] = new Blok(doorBotTexture, collisionTexture, new Vector2(y * 64, x * 64));
                    }
                }
            }
        }


        public void DrawWorld(SpriteBatch spritebatch)
        {
            for (int x = 0; x < byteTileArray.GetLength(0); x++)
            {
                for (int y = 0; y < byteTileArray.GetLength(1); y++)
                {
                    if (blokArray[x, y] != null)
                    {
                        blokArray[x, y].Draw(spritebatch);
                    }
                }
            }

        }
    }
}
