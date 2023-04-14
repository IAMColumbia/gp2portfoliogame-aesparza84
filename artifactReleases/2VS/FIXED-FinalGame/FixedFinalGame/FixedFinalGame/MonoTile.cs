using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLibrary.Sprite;
using SharpDX.Direct2D1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixedFinalGame
{
    public class MonoTile : DrawableSprite, ICollidable
    {

        public string TextureName;

        public Rectangle rect;
        private Chracter passedSprite;
        private Camera cam;

        public MonoTile(Game game, Camera camera) : base(game)
        {
            this.TextureName= "TestTile3";

            this.Location = new Vector2(500, 240);
            cam = camera;
        }

        public MonoTile(Game game,Camera camera,string texturename) : base(game)
        {
            this.TextureName = texturename;

           // this.Location = new Vector2(200, 240);
            rect = new Rectangle();
            cam = camera;
        }

        public void Stand(Chracter character) 
        {
            character.Direction.Y= 0.0f;
        }
        protected override void LoadContent()
        {
            this.spriteTexture = Game.Content.Load<Texture2D>(this.TextureName);
            this.rect = new Rectangle((int)this.Location.X, (int)this.Location.Y, this.spriteTexture.Width, this.spriteTexture.Height);
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            

            

            base.Update(gameTime);
        }

        public override void Initialize()
        {
            this.showMarkers= true;
            base.Initialize();
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, cam.Transform);
            spriteBatch.Draw(this.spriteTexture, this.Location, Color.White );
            spriteBatch.End();
        }
    }
}
