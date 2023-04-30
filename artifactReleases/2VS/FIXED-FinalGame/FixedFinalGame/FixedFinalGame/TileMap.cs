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

        Texture2D UnderGround, TestTile, AirTile;
        public TileMap(ContentManager content, Camera cam)
        {
            this.Cam= cam;

            UnderGround = content.Load<Texture2D>("DirtTile");
            TestTile = content.Load<Texture2D>("TestTile3");
            AirTile = content.Load<Texture2D>("AirTile");


            TilesToPickFrom = new Tile[3];

            TilesToPickFrom[0] = new Tile(true);
            TilesToPickFrom[0].texture= UnderGround;

            TilesToPickFrom[1] = new Tile(true);
            TilesToPickFrom[1].texture= TestTile;

            TilesToPickFrom[2] = new Tile(false);
            TilesToPickFrom[2].texture= AirTile;


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

               new int[] { 2,2,2,2,2,2,1},
               new int[] { 1,2,2,2,2,2,0},
               new int[] { 2,2,2,2,2,1,0},
               new int[] { 2,2,2,2,2,2,0},
               new int[] { 1,1,1,1,1,1,0},
            };

            world = new Tile[MapGrid.Length][];


            int b = 0;
            //grabs rows (3)
            for (int r = 0; r < MapGrid.Length; r++)
            {
                world[r] = new Tile[MapGrid[0].Length];
                
                //grabs columns in row (7)
                for (int c = 0; c < MapGrid[r].Length; c++)
                {
                    b = 0;
                    b = MapGrid[r][c];

                    world[r][c] = TilesToPickFrom[b];
                    world[r][c].location = new Vector2(r*100, c*100);
                }
            }
            
            for (int i = 0; i < world[0].Length; i++)
            {
                for (int j = 0; j < world.Length; j++)
                {
                    world[j][i].rectangle = new Rectangle(i*100, j*100, 100,100);
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
                }
            }
        }
    }
}
