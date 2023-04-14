using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixedFinalGame
{
    public static class CollisionDirection
    {
        public static bool IntersectsLeft(this Rectangle c, Rectangle tile)
        { 
            return c.Left < tile.Left &&
                   c.Right <= tile.Left+10;
        }
        public static bool IntersectsRight(this Rectangle c, Rectangle tile)
        {
            return c.Right > tile.Right &&
                   c.Left <= tile.Right-10 &&
                   (c.Top  >  tile.Bottom ||
                   c.Bottom< tile.Top);
        }

        public static bool IntersectsTop(this Rectangle c, Rectangle tile)
        { 
            return c.Bottom >= tile.Top + 1 &&
                   c.Bottom <= tile.Top+10 &&
                   c.Left   <= tile.Right &&
                   c.Right  >= tile.Left;
        }

        
    }
}
