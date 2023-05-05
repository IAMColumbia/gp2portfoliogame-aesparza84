using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixedFinalGame
{
    public class Tile : ICollidable
    {
        public bool iscollidable { get; set; }
        public bool isspawner { get; set; }
        public Rectangle rectangle { get; set; }

        public Texture2D texture;

        public Vector2 location { get; set; }

        public Tile() { }
        public Tile(bool IsCollidable, bool isSpawner) 
        {
            iscollidable= IsCollidable;
            isspawner= isSpawner;
            location = new Vector2(0,0);

            rectangle= new Rectangle(0,0,100,100);
        }
    }
}
