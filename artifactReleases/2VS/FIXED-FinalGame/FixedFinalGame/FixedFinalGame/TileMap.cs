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
        Tile[][] Grid;
        //Tile[,] map;
        Tile[][] world;
        
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
            //x= X; y = Y;

            Random random= new Random();
            //map = new Tile[x,y];
            
            Grid = new Tile[x][];


            //for map[,]
            //for (int i = 0; i < y; i++)
            //{
            //    for (int j = 0; j < x; j++)
            //    {
            //        int g = 0;
            //        switch (i)
            //        {
            //            case 0:
            //                g = 2;
            //                break;
            //            case 1:
            //                g = 0;
            //                break;
            //            case 2:
            //                g = 1;
            //                break;
            //            case 3:
            //                g = 1;
            //                break;
            //            case 4:
            //                g = 1;
            //                break;
            //            case 5:
            //                g = 1;
            //                break;
            //        }
            //        map[j, i] = TilesToPickFrom[g];
            //    }
            //}


            //for Grid[][]
            for (int i = 0; i < x; i++)
            {
                Grid[i] = new Tile[x];

                for (int j = 0; j < y; j++)
                {
                    int g=0;
                    if (j==0)
                    {
                        g = 2;
                    }
                    if (j==1)
                    {
                        g = 0;
                    }
                    if (j ==2)
                    {
                        g = 1;
                    }

                    Grid[i][j] = TilesToPickFrom[g];
        
                }
            }

            //---------------------------------
            int[][] MapGrid = 
            {
               new int[] { 2,0,2,2,0,0,0},
               new int[] { 0,0,0,0,0,0,0},
               new int[] { 1,1,0,1,0,0,0}
            };

            world = new Tile[MapGrid.Length][];

            //world = new Tile[MapGrid[0].Length][MapGrid.Length];

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
                }
            }


        }

        public void Draw(SpriteBatch sp)
        {
            for (int i = 0; i < world.Length; i++)
            {
                for (int j = 0; j < world[0].Length; j++)
                {
                    //sp.Begin();
                    ////sp.Draw(Grid[i][j].texture, new Rectangle(i*100, j*100, 100, 100), Color.White);
                    //sp.Draw(world[i][j].texture, new Rectangle(i * 100, j * 100, 100, 100), Color.White);
                    //sp.End();

                    //sp.Begin(SpriteSortMode.Deferred, null, null, null, null, null, Cam.Transform);
                    sp.Draw(world[i][j].texture, new Rectangle(i * 100, j * 100, 100, 100), Color.White);
                    //sp.End();

                }
            }
        }
    }
}
