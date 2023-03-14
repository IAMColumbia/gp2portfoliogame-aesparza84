using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLibrary.Sprite;
using MonoGameLibrary.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalGame
{

    public class Player :DrawableSprite, ICharacter
    {
        //int health { get; set; }
        //LifeState lifestate { get; set; }
        //int speed;
        //float GravityAccel { get; set; }
        //Vector2 GravityDir { get; set; }

        //IWeapon weapon { get; set; }

        public int health { get; set; }
        int speed { get; set; }
        public float GravityAccel { get; set; }
        public Vector2 GravityDir { get; set; }
        public LifeState lifestate { get; set; }
        public IWeapon weapon { get; set; }
        public CharacterState characterState { get; set; }

        Texture2D _texture;

        PlayerController controller;
     
        string TextureName;
        public Player(Game game) : base(game)
        {
            TextureName = "TestingSprite";
            SetStats();
        }

        void SetStats()
        { 
            this.health= 100;
            this.speed= 40;
            this.GravityAccel = 1.5f;
            this.GravityDir = new Vector2(1,0);
        }

        public void DenyMovement(TerrainBlock block) 
        {
            this.Direction.X= 0;
            this.Direction.Y= 0;
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        protected override void LoadContent()
        {
            this._texture = this.Game.Content.Load<Texture2D>(TextureName);
            base.LoadContent();
        }

        public override void Initialize()
        {
            base.Initialize();  
        }
        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }

    }
}
