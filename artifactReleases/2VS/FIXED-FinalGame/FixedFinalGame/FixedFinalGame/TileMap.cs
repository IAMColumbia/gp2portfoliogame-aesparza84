using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLibrary.Sprite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace FixedFinalGame
{
    public class TileMap
    {
        Camera Cam;
        public Tile[][] world;
        
        Tile[] TilesToPickFrom;
        int x, y;

        Texture2D UnderGround, TestTile, AirTile, ESpawner;
        public TileMap(ContentManager content, Camera cam)
        {
            this.Cam= cam;

            UnderGround = content.Load<Texture2D>("DirtTile");
            TestTile = content.Load<Texture2D>("TestTile3");
            AirTile = content.Load<Texture2D>("AirTile");
            ESpawner = content.Load<Texture2D>("EnemySpawnTile");


            TilesToPickFrom = new Tile[4];

            TilesToPickFrom[0] = new Tile(true, false);
            TilesToPickFrom[0].texture= UnderGround;

            TilesToPickFrom[1] = new Tile(true, false);
            TilesToPickFrom[1].texture= TestTile;

            TilesToPickFrom[2] = new Tile(false, false);
            TilesToPickFrom[2].texture= AirTile;

            TilesToPickFrom[3] = new Tile(false, true);
            TilesToPickFrom[3].texture = ESpawner;

        }

        private void CopyTile(Tile tile, int n)
        { 
            tile.iscollidable = TilesToPickFrom[n].iscollidable;
            tile.isspawner= TilesToPickFrom[n].isspawner;
            tile.texture = TilesToPickFrom[n].texture;
        }

        public void CreateMap()
        { 
            
            //This is the layout of the map that I iterate through
            //---------------------------------
            int[][] MapGrid = 
            {
               //new int[] { 2,2,2,2,2,2,1},
               //new int[] { 2,2,2,2,2,1,0},
               //new int[] { 2,2,2,2,1,0,0},
               //new int[] { 2,2,2,2,2,2,0},
               //new int[] { 2,1,1,1,1,1,0},

               new int[] { 1,1,1,2,2,2,1,2,2,2,2,2,2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
               new int[] { 0,2,2,2,2,2,0,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,0},
               new int[] { 0,2,2,2,2,1,0,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,0},
               new int[] { 0,2,2,2,2,2,0,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1,1,1,1,1,1,1,1,0},
               new int[] { 0,1,2,2,2,2,2,2,2,2,1,1,1,2,2,2,2,2,2,2,2,3,2,2,2,2,2,2,2,2,2,2,2,2,0},
               new int[] { 0,0,2,2,2,2,3,2,2,1,0,0,0,1,2,2,2,2,2,2,2,2,1,2,2,2,2,2,2,2,2,2,2,2,0},
               new int[] { 0,0,2,2,2,2,2,2,1,0,0,0,0,0,1,2,1,1,1,1,1,1,0,2,2,2,2,2,2,2,2,2,2,2,0},
               new int[] { 0,0,2,2,2,2,2,1,0,0,0,0,0,0,0,2,2,2,2,2,0,0,0,2,2,2,2,2,2,2,2,2,2,2,0},
               new int[] { 0,0,1,1,1,1,1,0,0,0,0,0,0,0,0,2,2,2,2,2,0,0,0,2,2,2,2,2,2,2,2,2,2,2,0},
               new int[] { 0,0,1,1,1,1,1,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,0,2,2,2,2,2,2,2,2,2,2,2,0},
               new int[] { 0,0,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,0},

               //new int[] { 1,2,1,2,2,2,2},
               //new int[] { 2,2,2,2,2,2,2},
               //new int[] { 2,2,2,2,2,2,2},
               //new int[] { 2,1,2,2,2,2,2,2},
               //new int[] { 2,2,2,2,2,2,2},
            };

            world = new Tile[MapGrid.Length][];


            int b = 0; 
            
            //grabs rows (3)
            for (int r = 0; r < MapGrid.Length; r++)
            {
                world[r] = new Tile[MapGrid[0].Length];
                
                //grabs columns in row (7)
                for (int c = 0; c < MapGrid[0].Length; c++)
                {
                    Tile tile = new Tile();
                    b = 0;
                    b = MapGrid[r][c];
                    CopyTile(tile, b);

                    //world[r][c] = TilesToPickFrom[b];
                    world[r][c] = tile;
                    world[r][c].location = new Vector2(c*100, r*100);

                    world[r][c].rectangle = new Rectangle((int)world[r][c].location.X, (int)world[r][c].location.Y, 100, 100);
                }
            }
            
        }

        public void Draw(SpriteBatch sp)
        {

            for (int i = 0; i < world[0].Length; i++)
            {
                for (int j = 0; j < world.Length; j++)
                {
                    //sp.Draw(Grid[i][j].texture, new Rectangle(i*100, j*100, 100, 100), Color.White);

                    sp.Draw(world[j][i].texture, new Rectangle(i * 100, j * 100, 100, 100), Color.White);

                    //sp.Draw(world[j][i].texture, world[j][i].location, Color.White);
                }
            }
        }
    }
}
