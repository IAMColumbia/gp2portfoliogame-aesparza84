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
   // public enum WeaponState{STOPPED, USING }
    public abstract class Weapon : IWeapon
    {
        //WeaponState weaponstate { get; set; }
        public string Name { get; set; }
        public int Damage { get; set; }
        public float timeDelay;

        protected Vector2 Direction, Location;
        protected int Speed;
        public Texture2D texture;
        public Weapon()
        {
            this.Direction = Vector2.Zero;
        }

        public void Use(Chracter passedCharacter)
        {
            this.Location.X += 1;
            this.Speed = 250;

            //if (weaponstate != WeaponState.STOPPED)
            //{
            //    weaponstate = WeaponState.USING;
            //}
            //weaponstate = WeaponState.STOPPED;
        }

        
    }
}
