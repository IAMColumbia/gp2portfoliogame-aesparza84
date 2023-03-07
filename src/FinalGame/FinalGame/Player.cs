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
    
    public class Player : DrawableSprite, ICharacter
    {
        int ICharacter.health { get; set; }
        LifeState ICharacter.lifestate { get; set; }
        int speed;
        IWeapon ICharacter.weapon { get; set; }

        PlayerController controller;
        CharacterState ICharacter.characterState { get; set; }

        string TextureName;
        public Player(Game game) : base(game)
        {
            TextureName = "TestingSprite";

            if (InputHandler ==null)
            {

            }
        }


    }
}
