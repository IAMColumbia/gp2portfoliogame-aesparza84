using Microsoft.Xna.Framework;
using MonoGameLibrary.Sprite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixedFinalGame
{
    public abstract class Chracter : DrawableSprite, ICharacter
    {
        protected Chracter(Game game) : base(game)
        {

        }

        public int health { get;set; }
        public Gravity gravity { get; set; }
        public LifeState lifestate { get; set; }
        public GroundState groundState { get; set; }
        public IWeapon weapon { get; set; }
        public CharacterState characterState { get; set; }
    }
}
