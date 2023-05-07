using Microsoft.Xna.Framework;
using MonoGameLibrary.Sprite;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace FixedFinalGame
{
    public abstract class Chracter : DrawableSprite, ICharacter
    {
        protected Chracter(Game game) : base(game)
        {

        }

        protected bool intersectsTop;
        protected bool intersectLeft;
        protected bool intersectRight;
        protected bool intersectBottom;
        protected bool intersectsSide;

        
        public int health { get;set; }
        public int Speed;
        public Gravity gravity { get; set; }
        public LifeState lifestate { get; set; }
        public GroundState groundState { get; set; }
        public Weapon weapon { get; set; }
        public CharacterState characterState { get; set; }
        public Tile[] ColMap { get; set; }
        public Weapon[] Weaponslist { get; set; }

        protected bool hasMap { get; set; }

        public virtual void TakeDamage() { }

        public void GetWeapons(Weapon[] w) 
        {
            Weaponslist = new Weapon[w.Length];
            for (int i = 0; i < w.Length; i++)
            {
                Weaponslist[i] = w[i];
            }

            this.weapon = Weaponslist[0];
        }
        public void GetMap(Tile[][] passedmap)
        {
            int n = passedmap.Length * passedmap[0].Length;
            ColMap = new Tile[n];

            int m = 0;

            for (int r = 0; r < passedmap.Length; r++)
            {

                //grabs columns in row (7)
                for (int c = 0; c < passedmap[r].Length; c++)
                {

                    ColMap[m] = passedmap[r][c];
                    m++;
                }
            }
            hasMap = true;
        }

        protected void checkCollision()
        {
            intersectsTop = false;
            intersectRight = false;
            intersectLeft = false;
            intersectBottom = false;
            intersectsSide = false;

            if (hasMap)
            {
                Tile tile = new Tile();
                for (int i = 0; i < ColMap.Length; i++)
                {
                    tile = ColMap[i];
                    if (this.Rectagle.Intersects(tile.rectangle)
                        && tile.iscollidable == true)
                    {

                        
                        if (this.Rectagle.IntersectsRight(tile.rectangle))
                        {
                            intersectRight = true;

                            if (Direction.X < 0)
                            {
                                this.Location.X = tile.rectangle.Right + 1;
                            }

                        }

                        if (this.Rectagle.IntersectsLeft(tile.rectangle))
                        {
                            intersectLeft = true;
                            if (Direction.X > 0)
                            {
                                this.Location.X = tile.rectangle.Left - this.Rectagle.Width - 1;

                            }
                        }

                        if (intersectRight==true || intersectLeft==true)
                        {
                            intersectsSide = true;
                        }

                        if (this.Rectagle.IntersectsBot(tile.rectangle))
                        {
                            intersectBottom = true;
                            this.Direction.Y = 1;
                        }

                        if (this.Rectagle.IntersectsTop(tile.rectangle) &&
                            this.Rectagle.IntersectSide(tile.rectangle))
                        {
                            intersectsTop = true;
                            this.Location.Y = tile.rectangle.Top - this.Rectagle.Height + 1;
                        }
                    }
                }
            }
        }

    }
}
