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

        protected Chracter player;
        protected bool hasPassedPlayer;
        public int Damage { get; set; }
        public float timeDelay;

        protected Vector2 prevDirection;
        public DrawableWeapon(Game game) : base(game)
        {
            this.Direction = Vector2.Zero;
            hasPassedPlayer= false;
        }

        public virtual void Use(Chracter passedCharacter) { }
        public void GetCharacter(Chracter passedCharacter)
        {
            player = passedCharacter;
            hasPassedPlayer= true;
        }
    }
}
