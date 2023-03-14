using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLibrary.Sprite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixedFinalGame
{
    public class MonoTile : DrawableSprite, ICollidable
    {      
        protected Texture2D texture;

        public string TextureName;

        public MonoTile(Game game, string textureName) : base(game)
        {
            this.TextureName= textureName;
        }

        protected override void LoadContent()
        {
            this.texture = Game.Content.Load<Texture2D>(this.TextureName);
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
