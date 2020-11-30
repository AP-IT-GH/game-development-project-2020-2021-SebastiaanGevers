using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using MyGame.interfaces;
using Microsoft.Xna.Framework.Graphics;

namespace MyGame.Animation
{
    public class Animatie
    {
        public AnimatioFrame CurrentFrame { get; set; }

        private List<AnimatioFrame> frames;

        private int counter=0;

        private double frameMovement = 0;

        public Animatie()
        {
            frames = new List<AnimatioFrame>();
        }

        public void AddFrame(AnimatioFrame animationFrame)
        {
            frames.Add(animationFrame);
            CurrentFrame = frames[0];
        }
        public void Update(GameTime gametime)
        {
            CurrentFrame = frames[counter];

            frameMovement += CurrentFrame.SourceRectangle.Width*gametime.ElapsedGameTime.TotalSeconds;

            if(frameMovement>= CurrentFrame.SourceRectangle.Width/8)
            {
                counter++;
                frameMovement = 0;
            }            

            if(counter >= frames.Count)
            {
                counter = 0;
            }
        }
    
    }
}
