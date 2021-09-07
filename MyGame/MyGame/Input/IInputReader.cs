using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace MyGame.Input
{
    interface IInputReader
    {
        Vector2 ReadInput();

        bool ReadFollower();
    }
}
