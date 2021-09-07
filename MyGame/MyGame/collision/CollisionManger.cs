using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MyGame.collision
{
    class CollisionManger
    {
        //
        List<IblockColided> colidedsBloks;
        Hero hero;
        Game1 game;
        ContentManager _content;
        GraphicsDevice _graphicsDevice;

        public CollisionManger(List<IblockColided> bloks, Game1 _game,Hero _hero, ContentManager content, GraphicsDevice graphicsDevice)
        {
            colidedsBloks = bloks;
            hero = _hero;
            game = _game;
            _content = content;
            _graphicsDevice = graphicsDevice;
        }

        public void CheakCollision()
        {
           
            foreach (var blok in colidedsBloks)
            {
                
                // hero bost op zijkanten
                if(hero.collisionRectangleA.Intersects(blok.collisionRectangleA)&& hero.collisionRectangleA.Intersects(blok.collisionRectangleB))
                {
                    //Debug.WriteLine("colided with blok left");
                    hero.stopLeft = true;
                    Console.WriteLine("colided with blok left");
                }
                if(hero.collisionRectangleB.Intersects(blok.collisionRectangleA)&& hero.collisionRectangleB.Intersects(blok.collisionRectangleB))
                {
                    //Debug.WriteLine("colided with blok right");
                }
                //hero bost op boven of onderkant

                if (blok.collisionRectangleA.Intersects(hero.collisionRectangleA)||blok.collisionRectangleA.Intersects(hero.collisionRectangleB))
                {
                   //Debug.WriteLine("colides with top off blok");
                }
                if (blok.collisionRectangleB.Intersects(hero.collisionRectangleA) || blok.collisionRectangleB.Intersects(hero.collisionRectangleB))
                {
                    //Debug.WriteLine("colides with underside off block");
                }


            }
        }
    }
}
