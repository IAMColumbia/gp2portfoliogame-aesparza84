using Microsoft.Xna.Framework;
using MonoGameLibrary.Sprite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalGame
{
    internal class DeleteCharacter : DrawableSprite, ICharacter
    {
        public DeleteCharacter(Game game) : base(game)
        {

        }

        public int health { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public float GravityAccel { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Vector2 GravityDir { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public LifeState lifestate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IWeapon weapon { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public CharacterState characterState { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
