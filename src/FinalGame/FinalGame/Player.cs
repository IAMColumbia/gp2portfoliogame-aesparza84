using FinalGame.Interfaces;
using Microsoft.Xna.Framework;
using MonoGameLibrary.Sprite;
using MonoGameLibrary.Util;
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
        int ICharacter.health { get; set; }
        LifeState ICharacter.lifestate { get; set; }
        int speed;
        IWeapon ICharacter.weapon { get; set; }

        PlayerController controller;
        CharacterState characterState { get; set; }

        public Player(Game game) : base(game)
        {

        }

    }
}
