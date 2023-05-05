using Microsoft.Xna.Framework;
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
    public enum Consciousness {ROAMING, CHASING, ATTACKING, STILL}
    public class Enemy : Chracter
    {
        string TextureName;
        private Camera cam;

        private Consciousness consc;

        private Chracter passedPlayer;

        private SpriteEffects s;

        Vector2 initialPosition;

        GameConsole console;
        public Enemy(Game game, Camera camera) : base(game)
        {
            //console = (GameConsole)game.Services.GetService(typeof(GameConsole));
            //if (console==null)
            //{
            //    console = new GameConsole(this.Game);
            //    this.Game.Components.Add(console);
            //}

            this.health = 3;
            initialPosition = Location;
            gravity = new Gravity();
            TextureName = "TestEnemy";
            this.cam = camera;

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

        void Roam() 
        {
            this.Speed = 150;
            if (this.Location.X > initialPosition.X+200)
            {
               Direction = new Vector2(-1,0);
            }
            else if (this.Location.X < initialPosition.X-200)
            {
                Direction = new Vector2(1,0);
            }

        }

        void MoveToPlayer()
        {
            this.Speed = 200;

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
            this.spriteTexture = this.Game.Content.Load<Texture2D>(TextureName);
            base.LoadContent();
        }

        float GetDistance(Chracter character)
        { 
            float distance = this.Location.X - character.Location.X;

            return distance;
        }
        bool seePlayer()
        {
            if (Math.Abs(GetDistance(passedPlayer)) <200f)
            {
                return true;
            }
            return false;
        }

        

        public override void Update(GameTime gameTime)
        {
            //console.Log("Conscuios", this.consc.ToString());
            float time = (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            this.Speed = 0;

            //if (seePlayer())
            //{
            //    consc = Consciousness.CHASING;
            //}
            //else
            //{
            //    consc = Consciousness.ROAMING;
            //}

            //if (this.Rectagle.Intersects(passedPlayer.Rectagle))
            //{
            //    Attack();
            //}

            //switch (consc)
            //{
            //    case Consciousness.ROAMING:
            //        Roam();
            //        break;
            //    case Consciousness.CHASING:
            //        MoveToPlayer();
            //        if (Math.Abs(GetDistance(passedPlayer)) > 200f)
            //        {
            //            this.Location = initialPosition;
            //        }
            //        break;

            //    case Consciousness.ATTACKING:
            //        Attack();
            //            break;
            //    default:
            //        break;
            //}


            timecorrect(time);

            base.Update(gameTime);
        }

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
