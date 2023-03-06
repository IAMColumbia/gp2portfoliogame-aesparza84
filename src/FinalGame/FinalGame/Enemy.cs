using FinalGame.Interfaces;
using Microsoft.Xna.Framework;
using MonoGameLibrary.Sprite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalGame
{
    internal class Enemy : DrawableSprite, ICharacter
    {
        public int ID { get; set; }
        public int Health { get; set; }
        public IWeapon weapon { get; set; }
        public Enemy(Game game) : base(game)
        {

        }

    }
}
