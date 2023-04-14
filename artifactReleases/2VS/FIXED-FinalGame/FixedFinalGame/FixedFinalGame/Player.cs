﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLibrary.Sprite;
using MonoGameLibrary.Util;
using SharpDX.MediaFoundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace FixedFinalGame
{
    public enum Action {NEUTRAL, ATTACKING, BLOCKING }
    public class Player : Chracter
    {
        Texture2D normalTexture, blockingTexture;
        public int health { get; set; }
        public Vector2 speed;
        public int Speed;

        public LifeState lifestate { get; set; }
        public GroundState groundState { get; set; }

        public IWeapon weapon { get; set; }
        public CharacterState characterState { get; set; }

        //------------------Not Icharacter

        float jumpheight;
        bool invulnerable;

        private Camera cam;

        Action actionstate;

        private SpriteEffects s;

        PlayerController controller;
        string NormalTexture, BlockingTexture;

        GameConsole console;

        
        public Player(Game game, Camera camera) : base(game)
        {
            NormalTexture = "TestingSrite2";
            BlockingTexture = "TestingSrite2-Blocking";
           

            gravity = new Gravity();

            if (controller == null)
            {
                controller = new PlayerController(game, this);
            }

            console = (GameConsole)game.Services.GetService(typeof(GameConsole));
            if (console == null)
            {
                console = new GameConsole(this.Game);
                this.Game.Components.Add(console);
            }

            this.Origin = new Vector2(this.Rectagle.Width/2, this.Rectagle.Height/2);
            SetStats();

            cam = camera;

            s = SpriteEffects.None;

            actionstate = Action.NEUTRAL;
        }

        void SetStats()
        {
            this.Speed = controller.Speed;
            this.jumpheight= controller.jumpheight;
        }

        public void ResetLocation() 
        {
            this.health = 100;
            this.Direction = Vector2.Zero;
            this.Location = new Vector2(Game1.Screenwidth/2, Game1.Screenheight/2-50);            
        }

        bool intersectsRect;
        public void KeepOnScreen()
        {
            //Cheating Floor
            if (this.Location.Y >= 310||intersectsRect==true)
            {
                this.groundState = GroundState.STANDING;

                //this.Direction.Y = 0.0f;
               // this.Location.Y = 310;
            }
            else
            {
                this.groundState = GroundState.JUMPING;
            }
        }

        public void CheckIfStanding()
        {
            if (Direction.Y == 0)
            {
                groundState = GroundState.STANDING;
            }
            else if (Direction.Y != 0) 
            {
                groundState = GroundState.JUMPING;
            }
        }

        public void DetermineStanding(float time)
        {
            switch (this.groundState)
            {
                case GroundState.FALLING:
                    break;
                case GroundState.JUMPING:
                    this.Direction.X = controller.Direction.X;
                    DoGravity(time);
                    break;
                case GroundState.STANDING:
                    this.Direction.Y = 0.0f;
                    this.Direction = controller.Direction;
                    break;
            }
        }

        
        public void DoGravity(float time)
        {
            this.Direction = this.Direction + (gravity.GravityDir * gravity.GravityAccel)*(time/1000);
        }


        private void timecorrectedMove(float time) 
        {
            this.Location = this.Location + (this.Direction * Speed) * (time/1000);
        }

        public void CheckTileCollision(MonoTile passedtile)
        {
            //if (this.Rectagle.Left > passedtile.Rectagle.Left &&
            //    this.Rectagle.Right < passedtile.Rectagle.Right &&
            //    this.Rectagle.Bottom < passedtile.Rectagle.Top)
            //{
            //    //this.groundState = GroundState.STANDING;
            //    intersectsRect = true;
            //}

            if (this.Rectagle.Intersects(passedtile.Rectagle))
            {
                intersectsRect = true;

                this.Location.Y = passedtile.Rectagle.Top - this.Rectagle.Height;
            }
            else { intersectsRect = false; }
        }
       

        public override void Update(GameTime gameTime)
        {
            float time = (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            
            //If character goes past 310, then groundstate is standing
            KeepOnScreen();

            controller.DifferentHandleInput(gameTime);





            //Determines Gravity based on groundstate
            DetermineStanding(time);

            if (controller.Block)
            {
                actionstate = Action.BLOCKING;
            }
            else
            {
                actionstate = Action.NEUTRAL;
            }

           //CheckIfStanding();
            

            switch (actionstate)
            {
                case Action.NEUTRAL:
                    this.spriteTexture = normalTexture;
                    invulnerable = false;
                    break;
                case Action.ATTACKING:
                    invulnerable = false;
                    break;
                case Action.BLOCKING:
                    this.spriteTexture = blockingTexture;
                    invulnerable = true;
                    break;
                default:
                    break;
            }

            
           

            //switch (this.groundState)
            //{
            //    case GroundState.FALLING:
            //        break;
            //    case GroundState.JUMPING:
            //        this.Direction.X = controller.Direction.X;
            //        DoGravity(time);
            //        break;
            //    case GroundState.STANDING:
            //        this.Direction.Y = 0.0f;
            //        this.Direction = controller.Direction;
            //        break;
            //}

            timecorrectedMove(time);
            UpdateLog();

            base.Update(gameTime);
        }

        private void UpdateLog()
        {
            console.Log("Standing State ", this.groundState.ToString());
            console.Log("Intersect Tile ", this.intersectsRect.ToString());
            console.Log("Right Mouse B", this.controller.Block.ToString());
            console.Log("Left Mouse B", this.controller.Attack.ToString());
            console.Log("Invulnerable", this.invulnerable.ToString());
            console.Log("Action State", this.actionstate.ToString());
            console.Log("Direction.Y", this.Direction.Y.ToString());
            console.Log("Direction.X", this.Direction.X.ToString());
            //console.Log("Speed.Y", this.speed.Y.ToString());
            //console.Log("Speed.X", this.speed.X.ToString());
            console.Log("Speed", this.Speed.ToString());
            console.Log("Bottom", this.Rectagle.Bottom.ToString());
            console.Log("Top", this.Rectagle.Top.ToString());
            console.Log("Location", this.Location.ToString());
        }

        protected override void LoadContent()
        {
            this.normalTexture = this.Game.Content.Load<Texture2D>(NormalTexture);
            this.blockingTexture = this.Game.Content.Load<Texture2D>(BlockingTexture);

            this.spriteTexture = normalTexture;

            base.LoadContent();
        }

        public override void Initialize()
        {

            base.Initialize();  
        }

        public override void Draw(GameTime gameTime)
        {
            if (Direction.X < 0)
            {
                s = SpriteEffects.FlipHorizontally;
                 spriteBatch.Begin(SpriteSortMode.Deferred,null,null,null,null,null, cam.Transform);
                //spriteBatch.Begin();
                spriteBatch.Draw(this.spriteTexture, this.Location, null, Color.White, 0f, this.Origin, 1f, s, 1);
                spriteBatch.End();
            }
            if (Direction.X >= 0)
            {
                s = SpriteEffects.None;
                spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, cam.Transform);
               // spriteBatch.Begin();
                spriteBatch.Draw(this.spriteTexture, this.Location, null, Color.White, 0f, this.Origin, 1f, s, 1);
                spriteBatch.End();
            }


        }

    }
}
