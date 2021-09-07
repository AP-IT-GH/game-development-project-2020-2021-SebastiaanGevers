using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyGame.Animation
{
   public class AnimatioFrame
    {
        public Rectangle SourceRectangle { get; set; }

        public AnimatioFrame(Rectangle rectangle)
        {
            SourceRectangle = rectangle;
        }
    }
}
