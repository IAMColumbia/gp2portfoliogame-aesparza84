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

namespace FixedFinalGame
{

    public class Player : Chracter
    {
        public int health { get; set; }
        public Vector2 speed;

        public LifeState lifestate { get; set; }
        public GroundState groundState { get; set; }
        public IWeapon weapon { get; set; }
        public CharacterState characterState { get; set; }

        //------------------Not Icharacter

        private Camera cam;

        private SpriteEffects s;

        public Gravity gravity { get; set; }

        PlayerController controller;
        string TextureName;

        GameConsole console;

        
        public Player(Game game, Camera camera) : base(game)
        {
            TextureName = "TestingSrite2";
           

            gravity = new Gravity();

            if (controller == null)
            {
                controller = new PlayerController(game, this);
            }

            console = new GameConsole(game);
            this.Game.Components.Add(console);
            this.Origin = new Vector2(this.Rectagle.Width/2, this.Rectagle.Height/2);
            SetStats();

            this.health = 3;
            cam = camera;

            s = SpriteEffects.None;
        }

        void SetStats()
        {
            this.health = 100;
            this.speed = controller.Speed;

            this.gravity.GravityAccel = 5f;
            this.gravity.GravityDir = new Vector2(0,5);

            //this.gravity.GravityAccel = 22f;
            //this.gravity.GravityDir = new Vector2(0, 1);
        }

        public void ResetLocation() 
        {
            this.Direction = Vector2.Zero;
            this.Location = new Vector2(Game1.Screenwidth/2, Game1.Screenheight/2-50);
        }
        public void KeepOnScreen()
        {
            //Cheating Floor
            if (this.Location.Y > 250)
            {
                this.Direction.Y = 0.0f;
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

        private void DirectionLimit() 
        {
            if (Direction.X > 1)
            {
                Direction.X = 1;
            }
            if (Direction.X < -1)
            {
                Direction.X = -1;
            }
            if (Direction.Y < -10)
            {
                Direction.Y = -10;
            }
            if (Direction.Y > 15)
            {
                Direction.Y = 15;
            }
        }
        
        public void DoGravity(float time)
        {
            this.Direction = this.Direction + (gravity.GravityDir * gravity.GravityAccel)*(time/1000);

            if (groundState == GroundState.JUMPING)
            {
                this.Direction = this.Direction + (gravity.GravityDir * gravity.GravityAccel) * (time / 1000);
            }
        }

        private void timecorrect(float time) 
        {
            this.Location = this.Location + (this.Direction * speed) * (time/1000);
        }

        
       
        public override void Update(GameTime gameTime)
        {
            //cam.Update();

            console.Log("Direction.Y", this.Direction.Y.ToString());
            console.Log("Direction.X", this.Direction.X.ToString());
            console.Log("Speed.Y", this.speed.Y.ToString());
            console.Log("Speed.X", this.speed.X.ToString());
            console.Log("Standing State ", this.groundState.ToString());
            console.Log("Location", this.Location.ToString());

            float time = (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (health > 0)
            {
                lifestate = LifeState.ALIVE;
            }
            else
            {
                lifestate = LifeState.DEAD;
            }

            CheckIfStanding();
            if (groundState == GroundState.JUMPING)
            {
                DoGravity(time);
            }

            controller.DifferentHandleInput(gameTime);

            // this.Direction.X = controller.Direction.X;
            // this.Direction.Y += controller.Direction.Y;

            this.speed = controller.Speed;
            this.Direction += controller.Direction;


            DirectionLimit();

            timecorrect(time);
            KeepOnScreen();

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
