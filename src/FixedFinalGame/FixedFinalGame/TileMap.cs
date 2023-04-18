using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixedFinalGame
{
    public class TileMap:DrawableGameComponent
    {
        public List<MonoTile> tiles;

        private Camera cam;
        private Game passedgame;
        private Chracter c;
        public TileMap(Game game, Camera camera, Chracter passedcharacter) : base(game)
        {
            this.tiles = new List<MonoTile>();
            passedgame= game;
            c = passedcharacter;
            this.cam = camera;  
        }

        public void CreateTileMap(int tileSize, int[,] worldLayout)
        {
            for (int x = 0; x < worldLayout.GetLength(1); x++)
            {
                for (int y = 0; y < worldLayout.GetLength(0); y++)
                {
                    int block = worldLayout[y,x];
                    switch (block)
                    {
                        case 0:
                            break;
                        case 2: tiles.Add(new MonoTile(passedgame, cam, c, "TestTile2-Dirt"));
                                
                            break;
                        case 1: tiles.Add(new MonoTile(passedgame, cam, c,"TestTile2"));
                            break;
                    }
                }
            }

            foreach (MonoTile item in tiles)
            {
                passedgame.Components.Add(item);
            }
        }


        public override void Draw(GameTime gameTime)
        {
            foreach (MonoTile item in tiles)
            {
                item.Draw(gameTime);
            }
        }
    }
}
