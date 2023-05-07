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
    public class Spear:Weapon
    {
        //public Spear() { }

        public Spear()
        {
            this.Name = "Spear";
            this.Damage = 1;
            this.timeDelay= 1.0f;
        }

        public override void Use()
        {
            base.Use(); 
        }
    }
}
