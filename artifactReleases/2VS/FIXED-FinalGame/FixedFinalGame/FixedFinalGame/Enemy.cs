using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLibrary.Sprite;
using MonoGameLibrary.Util;
using SharpDX.MediaFoundation;
using SharpDX.XInput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FixedFinalGame
{
    public enum Consciousness {ROAMING, CHASING, ATTACKING, STILL}
    public class Enemy : Chracter
    {
        string TextureName;
        private Camera cam;

        Texture2D Normal, Chasing;

        private Consciousness consc;

        private Chracter passedPlayer;

        private SpriteEffects s;

        Vector2 initialPosition, prevDirection, beforeColPosition;
        bool canConsc;
        //GameConsole console;
        public Enemy(Game game, Camera camera) : base(game)
        {
            

            this.health = 3;
            initialPosition = Location;
            gravity = new Gravity();
            TextureName = "TestEnemy";
            this.cam = camera;

            //console = (GameConsole)game.Services.GetService(typeof(GameConsole));
            //if (console == null)
            //{
            //    console = new GameConsole(this.Game);
            //    this.Game.Components.Add(console);
            //}

            setStats();
        }

        public void GetCharcter(Player player) 
        {
            this.passedPlayer= player;
        }

        void setStats()
        {

            this.health = 100;
            this.Speed = 150;
            this.Direction = new Vector2(1,0);

            this.gravity.GravityAccel = 5f;
            this.gravity.GravityDir = new Vector2(0,5);
        }
        private void DoGravity(float time)
        {
            this.Direction = this.Direction + (gravity.GravityDir * gravity.GravityAccel) * (time / 1000);
        }
        private void timecorrectedMove(float time)
        {
            this.Location = this.Location + (this.Direction * Speed) * (time / 1000);
        }

        public void DetermineStanding(float time)
        {
            switch (this.groundState)
            {
                case GroundState.FALLING:
                    break;
                case GroundState.JUMPING:
                    DoGravity(time);
                    break;
                case GroundState.STANDING:
                    this.Direction.Y = 0.0f;
                    break;
            }
        }
        void Roam() 
        {
            this.Speed = 150;

            //if (this.Location.X > initialPosition.X+50)
            //{
            //   Direction = new Vector2(-1,0);
            //    if (Direction.X==0)
            //    {
            //        Direction.X *= -1;
            //    }
            //}
            //else if (this.Location.X < initialPosition.X-50)
            //{
            //    Direction = new Vector2(1,0);
            //    if (Direction.X == 0)
            //    {
            //        Direction.X *= -1;
            //    }
            //}

            if (intersectLeft)
            {
                this.Direction.X = -1;
            }
            if (intersectRight)
            {
                this.Direction.X = 1;
            }

            beforeColPosition= this.Location;
           
        }

        void MoveToPlayer()
        {
            this.Speed = 250;

            if (this.Location.X < passedPlayer.Location.X)
            {
                Direction = new Vector2(1,0);
            }
            else if (this.Location.X > passedPlayer.Location.X)
            {
                Direction = new Vector2(-1,0);
            }
        }

        void Attack() 
        {
            passedPlayer.TakeDamage();
        }

        private void timecorrect(float time)
        {
            this.Location = this.Location + (this.Direction * Speed) * (time / 1000);
        }
        protected override void LoadContent()
        {
            Normal = this.Game.Content.Load<Texture2D>("TestEnemy");
            Chasing = this.Game.Content.Load<Texture2D>("TestEnemyChasing");
            this.spriteTexture = Normal;


            base.LoadContent();
        }

        float GetDistance(Chracter character)
        { 
            float distance = this.Location.X - character.Location.X;

            return distance;
        }
        bool seePlayer()
        {
            if (Math.Abs(GetDistance(passedPlayer)) <200f && Math.Abs(this.Location.Y - passedPlayer.Location.Y) <= 1)
            {
                return true;
            }
            return false;
        }

        

        public override void Update(GameTime gameTime)
        {
            //console.Log("Conscuios", this.consc.ToString());
            float time = (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            checkCollision();
            if (intersectsTop == true)
            {
                canConsc = true;
                groundState = GroundState.STANDING;
            }
            else
            {
                groundState = GroundState.JUMPING;
                canConsc = false;
                this.Direction.X = 0;
            }

            DetermineStanding(time);


            if (canConsc)
            {
                if (seePlayer())
                {
                    consc = Consciousness.CHASING;
                }
                else
                {
                    consc = Consciousness.ROAMING;
                }
                
            }
            

            //if (this.Rectagle.Intersects(passedPlayer.Rectagle))
            //{
            //    Attack();
            //}

            switch (consc)
            {
                case Consciousness.ROAMING:
                    this.spriteTexture = Normal;
                    Roam();
                    break;
                case Consciousness.CHASING:
                    this.spriteTexture = Chasing;
                    MoveToPlayer();
                    if (Math.Abs(GetDistance(passedPlayer)) > 200f)
                    {
                        consc= Consciousness.ROAMING;
                    }
                    break;
                default:
                    break;
            }


            timecorrect(time);
            //UpdateLog();

            base.Update(gameTime);
        }

        //private void UpdateLog()
        //{
        //    console.Log("Direction X ", this.Direction.X.ToString());
        //    console.Log("Location X ", this.Location.X.ToString());
        //    console.Log("BeforeCol X ", this.beforeColPosition.X.ToString());
        //    console.Log("Intersects side ", this.intersectsSide.ToString());
        //    console.Log("Intersects Right ", this.intersectRight.ToString());
        //    console.Log("Intersects Left ", this.intersectLeft.ToString());
        //    console.Log("Concioues", this.consc.ToString());
        //}

        public override void Draw(GameTime gameTime)
        {
            if (Direction.X < 0)
            {
                s = SpriteEffects.FlipHorizontally;
                spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, cam.Transform);
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
