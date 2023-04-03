using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLibrary.Sprite;
using MonoGameLibrary.Util;
using SharpDX.MediaFoundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FixedFinalGame
{
    public class Enemy : Chracter
    {
        string TextureName;
        public Enemy(Game game) : base(game)
        {
            this.health = 3;
            gravity = new Gravity();
            TextureName = "TestEnemy";
        }


        protected override void LoadContent()
        {
            this.spriteTexture = this.Game.Content.Load<Texture2D>(TextureName);
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
