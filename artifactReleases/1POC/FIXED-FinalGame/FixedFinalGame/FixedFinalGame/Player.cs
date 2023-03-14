using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLibrary.Sprite;
using MonoGameLibrary.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FixedFinalGame
{

    public class Player : DrawableSprite, ICharacter
    {
        public int health { get; set; }
        public int speed { get; set; }

        public LifeState lifestate { get; set; }
        public GroundState groundState { get; set; }
        public IWeapon weapon { get; set; }
        public CharacterState characterState { get; set; }

        public Gravity gravity { get; set; }
        PlayerController controller;
        string TextureName;

        GameConsole console;

        public Player(Game game) : base(game)
        {
            TextureName = "TestingSrite2";


            gravity = new Gravity();

            if (controller == null)
            {
                controller = new PlayerController(game, this);
            }

            console = new GameConsole(game);
            this.Game.Components.Add(console);

            SetStats();
        }

        void SetStats()
        {
            this.health = 100;
            this.speed = 50;

            this.gravity.GravityAccel = controller.gravity.GravityAccel;
            this.gravity.GravityDir = controller.gravity.GravityDir;

            //this.gravity.GravityAccel = 22f;
            //this.gravity.GravityDir = new Vector2(0, 1);
        }

        public void ResetLocation() 
        {
            this.Direction = Vector2.Zero;
            this.Location = new Vector2(Game1.Screenwidth/2, Game1.Screenheight/2);
        }
        public void KeepOnScreen(GraphicsDevice gd) 
        {
            //Cheating Floor
            if (this.Location.Y > 250)
            {
                this.Direction.Y= 0;
            }
        }

        public void CheckIfStanding()
        {
            if (Direction.Y == 0)
            {
                groundState = GroundState.STANDING;
            }
            else { groundState= GroundState.JUMPING; }
        }
        
        public void DoGravity(float time)
        {
            this.Direction = this.Direction + (gravity.GravityDir * gravity.GravityAccel)*(time/1000);
        }

        private void timecorrect(float time) 
        {
            this.Location = this.Location + (this.Direction * speed) * (time/1000);
            DoGravity(time);
        }

       
        public override void Update(GameTime gameTime)
        {

            console.Log("Direction.Y",this.Direction.Y.ToString());
            console.Log("Direction.X", this.Direction.X.ToString());
            console.Log("Standing State ", this.groundState.ToString());
            console.Log("Location", this.Location.ToString());

            float time = (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            
            CheckIfStanding();

            controller.HandleInput(gameTime);
            this.Direction += controller.Direction;

            
            timecorrect(time);
            KeepOnScreen(this.Game.GraphicsDevice);
            base.Update(gameTime);
        }

        protected override void LoadContent()
        {
            this.spriteTexture = this.Game.Content.Load<Texture2D>(TextureName);
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
