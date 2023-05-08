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
    public class Spear:DrawableWeapon
    {
        //public Spear() { }
        private SpriteEffects s;
        private Camera cam;
        public Spear(Game game, Camera Cam) : base(game)
        {
            this.cam = Cam;
            this.Name = "Spear";
            this.Damage = 1;
            this.timeDelay= 1.0f;
        }
        public override void Use(Chracter passedCharacter)
        {
            this.Speed = 250;
            this.Location = passedCharacter.Origin;
            this.Direction.X = passedCharacter.Direction.X;

            //if (weaponstate != WeaponState.STOPPED)
            //{
            //    weaponstate = WeaponState.USING;
            //}
            //weaponstate = WeaponState.STOPPED;
        }
        protected override void LoadContent()
        {
            this.spriteTexture = this.Game.Content.Load<Texture2D>("Spear");
            base.LoadContent();
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            if (this.Direction.X != 0)
            {
                prevDirection.X = this.Direction.X;
            }
            if (Direction.X == 0)
            {
                this.Direction.X = prevDirection.X;
            }
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            if (prevDirection.X < 0)
            {
                s = SpriteEffects.FlipHorizontally;
                spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, cam.Transform);
                //spriteBatch.Begin();
                spriteBatch.Draw(this.spriteTexture, this.Location, null, Color.White, 0f, this.Origin, 1f, s, 1);
                spriteBatch.End();
            }
            if (prevDirection.X >= 0)
            {
                s = SpriteEffects.None;
                spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, cam.Transform);
                // spriteBatch.Begin();
                spriteBatch.Draw(this.spriteTexture, this.Location, null, Color.White, 0f, this.Origin, 1f, s, 1);
                spriteBatch.End();
            }
        }
    }
}
