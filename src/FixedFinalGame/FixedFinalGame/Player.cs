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
        public int Speed;

        public LifeState lifestate { get; set; }
        public GroundState groundState { get; set; }

        public IWeapon weapon { get; set; }
        public CharacterState characterState { get; set; }

        //------------------Not Icharacter

        public Tile[][] collisionmap { get; set; }
        public Tile[] ColMap { get; set; }
        bool hasMap;

        Vector2 initPos;

        float jumpheight;

        bool invulnerable;

        bool intersectsTop;
        bool intersectLeft;
        bool intersectRight;
        bool intersectBottom;
        bool intersects;

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
            hasMap = false;
           

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
            this.Location = new Vector2(300, 150);            
        }

        
        public void KeepOnScreen()
        {
            //Cheating Floor
            if (this.Location.Y >= 350 || intersectsTop==true)
            {

                if (intersectsTop==true)
                {
                    this.groundState = GroundState.STANDING;
                }
                else if (this.Location.Y>=350)
                {
                    this.Location.Y = 350;
                    this.groundState = GroundState.STANDING;
                }
            }
            else
            {
                this.groundState = GroundState.JUMPING;
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

        
        public void GetMap(Tile[][] passedmap)
        {
            int n = passedmap.Length*passedmap[0].Length;
            collisionmap = new Tile[passedmap.Length][];
            ColMap = new Tile[n];

            int m = 0;

            for (int r = 0; r < passedmap.Length; r++)
            {
                collisionmap[r] = new Tile[passedmap[0].Length];

                //grabs columns in row (7)
                for (int c = 0; c < passedmap[r].Length; c++)
                {
                    collisionmap[r][c] = passedmap[r][c];

                    ColMap[m] = passedmap[r][c];
                    m++;
                }
            }
            hasMap= true;
        }
        
        public override void Update(GameTime gameTime)
        {
            float time = (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            initPos = this.Location;

            intersects = false;
            intersectsTop= false;
            intersectRight= false;
            intersectLeft= false;
            if (hasMap)
            {
                Tile tile = new Tile();
                for (int i = 0; i < ColMap.Length; i++)
                {
                    tile = ColMap[i];
                    if (this.Rectagle.Intersects(tile.rectangle)
                        && tile.iscollidable == true)
                    {
                        intersects = true;
                        if (this.Rectagle.IntersectsRight(tile.rectangle))
                        {
                            intersectRight = true;

                            if (Direction.X < 0)
                            {
                                this.Location.X = tile.rectangle.Right+1;
                            }
                           
                        }

                        if (this.Rectagle.IntersectsLeft(tile.rectangle))
                        {
                            intersectLeft = true;
                            if (Direction.X > 0)
                            {
                                this.Location.X = tile.rectangle.Left-this.Rectagle.Width+1;
                                
                            }
                        }

                        if (this.Rectagle.IntersectsTop(tile.rectangle) &&
                            this.Rectagle.IntersectSide(tile.rectangle))
                        {
                            intersectsTop = true;
                            this.Location.Y=tile.rectangle.Top-this.Rectagle.Height+1;
                        }
                    }
                }
            }

            //If character goes past 350, then groundstate is standing
            if (intersectsTop == true)
            {
                groundState = GroundState.STANDING;
            }
            else { groundState = GroundState.JUMPING; }

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

            timecorrectedMove(time);
            UpdateLog();

            base.Update(gameTime);
        }

        private void UpdateLog()
        {
            console.Log("Standing State ", this.groundState.ToString());
            console.Log("intersect ", this.intersects.ToString());
            console.Log("intersect Top", this.intersectsTop.ToString());
            console.Log("intersect Right", this.intersectRight.ToString());
            console.Log("intersect Left", this.intersectLeft.ToString());
            //console.Log("Right Mouse B", this.controller.Block.ToString());
            //console.Log("Left Mouse B", this.controller.Attack.ToString());
            //console.Log("Invulnerable", this.invulnerable.ToString());
            //console.Log("Action State", this.actionstate.ToString());
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
            this.showMarkers = true;

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
