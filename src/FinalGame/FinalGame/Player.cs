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
        int health { get; set; }
        LifeState lifestate { get; set; }
        int speed;
        float GravityAccel { get; set; }
        Vector2 GravityDir { get; set; }

        IWeapon weapon { get; set; }

        PlayerController controller;
        InputHandler input;
        CharacterState ICharacter.characterState { get; set; }
        int ICharacter.health { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        float ICharacter.GravityAccel { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        Vector2 ICharacter.GravityDir { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        LifeState ICharacter.lifestate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        IWeapon ICharacter.weapon { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        string TextureName;
        public Player(Game game) : base(game)
        {
            this.GravityDir = new Vector2(1,0);
            this.GravityAccel = 1.5f;

            TextureName = "TestingSprite";
            speed = 40;

            if (input==null)
            {
                input = new InputHandler(game);
            }
        }


    }
}
