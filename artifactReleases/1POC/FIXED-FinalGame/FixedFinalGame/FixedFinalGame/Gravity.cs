using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixedFinalGame
{
    public class Gravity
    {
        public Vector2 GravityDir;
        public float GravityAccel;
        public float Accel;
        public Gravity() 
        {
            GravityDir = new Vector2(0, 5);
            GravityAccel= 00.0f;
        }
    }
}
