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
        public bool isEnSpawner { get; set; }
        public bool isPlyrSpawn { get; set; }
        public Rectangle rectangle { get; set; }

        public Texture2D texture;

        public Vector2 location { get; set; }

        public Tile() { }
        public Tile(bool IsCollidable, bool isSpawner, bool isplyrspawn) 
        {
            iscollidable= IsCollidable;
            isEnSpawner = isSpawner;
            isPlyrSpawn= isplyrspawn;
            location = new Vector2(0,0);

            rectangle= new Rectangle(0,0,100,100);
        }
    }
}
