using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixedFinalGame
{
    public  class GameMap
    {
        public int BlockWidth, BlockHeight, MapWidth, MapHeight;

        //2D array of terrain blocks
        TerrainBlock[][] blocks;
        string terrainTexture;

        public string filename;
        public GameMap(string MapFile)
        {
            filename= MapFile;
        }

        public void readFromFile(ContentManager content)
        {
            string textData = File.ReadAllText(Path.Join(this.filename));
            var lines = textData.Split('\n');

            var texturename = lines[0].Trim();
            this.terrainTexture = texturename;

            var BlockDimensions = lines[1].Trim();
        }
    }
}
