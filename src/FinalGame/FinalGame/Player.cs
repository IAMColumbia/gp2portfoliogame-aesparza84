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
    public enum CharacterState {ATTACKING, NEUTRAL}
    public class Player : DrawableSprite, ICharacter
    {
        public int Health { get; set; }
        public IWeapon weapon { get; set; }

        CharacterState characterState { get; set; }
        public Player(Game game) : base(game)
        {

        }

    }
}
