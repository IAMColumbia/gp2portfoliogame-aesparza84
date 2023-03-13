using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLibrary.Sprite;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixedFinalGame
{
    public class Camera:DrawableGameComponent
    {
        DrawableSprite PassedSprite;
        public Matrix Transform { get; set; }

        SpriteBatch PassedSb;
        public Camera(Game game, DrawableSprite TargetSprite, SpriteBatch sb) : base(game)
        {
            PassedSprite = TargetSprite;
            PassedSb = sb;
        }

      

        public void StickToSprite(DrawableSprite sprite)    
        {
            //Matrix Loc = Matrix.CreateTranslation
            //    (
            //        -sprite.Location.X - (sprite.Rectagle.Width / 2),        //middle of sprite x-axis  
            //        -sprite.Location.Y - (sprite.Rectagle.Height / 2),       //middle of sprite y-axis  
            //        0
            //    ) ;

            //Matrix center = Matrix.CreateTranslation(Game1.Screenwidth / 2, Game1.Screenheight / 2, 0);

            //Transform = Loc * center;

            //------Other method--------------
            var x = (Game1.Screenwidth / 2) - sprite.Location.X;
            var y = (Game1.Screenheight / 2) - sprite.Location.Y;
            Transform = Matrix.CreateTranslation(x,y,0f);
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            base.LoadContent();
        }
        public override void Update(GameTime gameTime)  
        {
            StickToSprite(PassedSprite);
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            PassedSb.Begin(transformMatrix: this.Transform);

            PassedSb.End();

            base.Draw(gameTime);
        }
    }
}
