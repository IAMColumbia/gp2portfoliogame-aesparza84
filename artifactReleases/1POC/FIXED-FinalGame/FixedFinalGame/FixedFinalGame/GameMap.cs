using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLibrary.Sprite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixedFinalGame
{
    public class GameMap: DrawableSprite
    {
        public int BlockWidth, BlockHeight, MapWidth, MapHeight;

        //--------
        string LevelLayout;
        Texture2D ground;
        //----------
        string terrainTexture;

        public string filename;
        Game passedGame;

        public GameMap(Game game, string MapFile) : base(game)
        {
            filename = MapFile;
            passedGame= game;
        }


        public void ReadFromFile(ContentManager content)
        {
            string textData = File.ReadAllText(Path.Join(this.filename));
            var lines = textData.Split('\n');

            var texturename = lines[0].Trim();
            this.terrainTexture = texturename;

            var BlockDimensions = lines[1].Split(",");
            this.BlockWidth = int.Parse(BlockDimensions[0]);
            this.BlockHeight= int.Parse(BlockDimensions[1]);

            var WorldDimensions = lines[2].Split(",");
            this.MapHeight= int.Parse(WorldDimensions[0]);
            this.MapWidth= int.Parse(WorldDimensions[1]);            
        }

        public void createLevel()
        {
            MapWidth = 20;
            MapHeight = 10;
            LevelLayout += "n-------------------";
            LevelLayout += "n-------------------";
            LevelLayout += "n-------------------";
            LevelLayout += "n-------------------";
            LevelLayout += "n-------------------";
            LevelLayout += "n----------------nn-";
            LevelLayout += "n------------nnnn---";
            LevelLayout += "n--nnnnnnnnnn-------";
            LevelLayout += "n-------------------";
            LevelLayout += "n-------------------";

            //switch (LevelLayout)
            //{
            //    case"n":
            //        break;
            //    case "-":
            //        spriteBatch.Draw();
            //        break;
            //}
        }

        public void BuildMap()
        {
            //2D array of terrain blocks
            MonoTile[,] blocks = new MonoTile[MapHeight,MapWidth];

            //for (int w = 0; w < MapWidth; w++)
            //{
            //    blocks[w, 0] = new MonoTile(passedGame, terrainTexture);

            //    for (int h = 0; h < MapHeight; h++)
            //    {
            //        blocks[w,h] = new MonoTile(passedGame, terrainTexture);
            //    }
            //}
        }

        public override void Draw(GameTime gameTime)
        {
            
            base.Draw(gameTime);
        }
    }
}
