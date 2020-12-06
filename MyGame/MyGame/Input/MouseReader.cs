using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyGame.Input
{
    class MouseReader : IInputReader
    {
        bool IInputReader.ReadFollower()
        {
            throw new NotImplementedException();
        }

        Vector2 IInputReader.ReadInput()
        {
            MouseState state = Mouse.GetState();
            var mouseVec = new Vector2(state.X, state.Y);
            return mouseVec;
        }
    }
}
