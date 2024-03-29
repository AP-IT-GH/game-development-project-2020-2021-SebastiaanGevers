﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MyGame.Input
{
    class KeyBoardReader:IInputReader
    {
        public bool ReadFollower()
        {
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.M))
            {
                return true;
            }
            return false;
        }

        public Vector2 ReadInput()
        {
            var direction = Vector2.Zero;
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Left))
            {
                direction = new Vector2(-1, 0);
            }
            if (state.IsKeyDown(Keys.Right))
            {
                direction = new Vector2(+1, 0);
            }
            if (state.IsKeyDown(Keys.Up))
            {
                //Debug.WriteLine("naar boven");
                direction = new Vector2(0, -1);
            }

            return direction;
        }

        
    }
}

