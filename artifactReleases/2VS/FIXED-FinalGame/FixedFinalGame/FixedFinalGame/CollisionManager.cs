using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixedFinalGame
{
    public class CollisionManager
    {
        public  bool intersects, 
            intersectsTop, 
            intersectLeft, 
            intersectRight,
            intersectBottom;

        List<Chracter> characterList;

        public CollisionManager() 
        {
            characterList= new List<Chracter>();
        }

        public Tile[] ColMap { get; set; }

        public  void GetMap(Tile[][] passedmap)
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
        }

        private void CheckCollision()
        {
            intersects = false;
            intersectsTop = false;
            intersectRight = false;
            intersectLeft = false;
            intersectBottom = false;

            foreach (Chracter passedChar in characterList)
            {
                Tile tile = new Tile();
                for (int i = 0; i < ColMap.Length; i++)
                {
                    tile = ColMap[i];
                    if (passedChar.Rectagle.Intersects(tile.rectangle)
                        && tile.iscollidable == true)
                    {
                        intersects = true;
                        if (passedChar.Rectagle.IntersectsRight(tile.rectangle))
                        {
                            intersectRight = true;

                            if (passedChar.Direction.X < 0)
                            {
                                passedChar.Location.X = tile.rectangle.Right + 1;
                            }

                        }

                        if (passedChar.Rectagle.IntersectsLeft(tile.rectangle))
                        {
                            intersectLeft = true;
                            if (passedChar.Direction.X > 0)
                            {
                                passedChar.Location.X = tile.rectangle.Left - passedChar.Rectagle.Width - 1;

                            }
                        }

                        if (passedChar.Rectagle.IntersectsBot(tile.rectangle))
                        {
                            intersectBottom = true;
                            passedChar.Direction.Y = 1;
                        }

                        if (passedChar.Rectagle.IntersectsTop(tile.rectangle) &&
                            passedChar.Rectagle.IntersectSide(tile.rectangle))
                        {
                            intersectsTop = true;
                            passedChar.Location.Y = tile.rectangle.Top - passedChar.Rectagle.Height + 1;
                        }
                    }
                }
            }
        }
    }
}
