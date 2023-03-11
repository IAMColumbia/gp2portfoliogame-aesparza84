using Microsoft.Xna.Framework;
using MonoGameLibrary.Sprite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalGame
{
    public  class Enemy : DrawableSprite, ICharacter
    {
        public int ID { get; set; }
         int ICharacter.health { get; set; }
         LifeState ICharacter.lifestate { get; set; }

         CharacterState ICharacter.characterState { get; set; }

         IWeapon ICharacter.weapon { get; set; }
        public Enemy(Game game) : base(game)
        {

        }

    }
}
