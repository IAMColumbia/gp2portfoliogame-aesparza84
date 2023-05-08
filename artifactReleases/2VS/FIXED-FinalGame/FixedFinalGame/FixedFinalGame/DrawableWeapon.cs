using Microsoft.Xna.Framework;
using MonoGameLibrary.Sprite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixedFinalGame
{
    public enum WeaponState { STOPPED, USING }
    public class DrawableWeapon : DrawableSprite, IWeapon
    {
        WeaponState weaponstate { get; set; }
        public string Name { get; set; }
        public int Damage { get; set; }
        public float timeDelay;

        protected Vector2 prevDirection;
        public DrawableWeapon(Game game) : base(game)
        {
            this.Direction = Vector2.Zero;
        }

        public virtual void Use(Chracter passedCharacter) { }
    }
}
