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
    public class Camera
    {
        Player PassedSprite;

        Vector2 Location;
        public Matrix Transform { get; set; }

        //SpriteBatch PassedSb;

        public Camera(Player TargetSprite, SpriteBatch sb)
        {
            Location = Vector2.Zero;
            PassedSprite = TargetSprite;
            //PassedSb = sb;
        }

        public void StickToSprite(Player sprite)
        {





            //--------------------
            float x = (Game1.Screenwidth / 2) - sprite.Location.X;
            float y = (Game1.Screenheight / 2) - sprite.Location.Y;

            Transform = Matrix.CreateTranslation(x, y, 0);
        }

        public void Update()
        {
            StickToSprite(PassedSprite);
        }

    }
}
