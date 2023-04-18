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

        public MonoTile(Game game, Chracter character, Camera camera) : base(game)
        {
            this.TextureName= "TestTile2";

            this.Location = new Vector2(500, 240);
            rect= new Rectangle();
            passedSprite = character;
            cam = camera;
        }

        public MonoTile(Game game,Camera camera, Chracter character,string texturename) : base(game)
        {
            this.TextureName = texturename;

            rect = new Rectangle();
            cam = camera;
            passedSprite= character;
        }

        public void Stand(Chracter character) 
        {
            character.Direction.Y= 0;
        }
        protected override void LoadContent()
        {
            this.spriteTexture = Game.Content.Load<Texture2D>(this.TextureName);
            this.rect = new Rectangle((int)this.Location.X, (int)this.Location.Y, this.spriteTexture.Width, this.spriteTexture.Height);
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            

            //if (this.Intersects(passedSprite))
            //{
            //    Stand(passedSprite);
            //}
            //else
            //{
            //    passedSprite.groundState = GroundState.JUMPING;
            //}



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
