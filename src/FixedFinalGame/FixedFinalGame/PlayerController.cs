using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoGameLibrary.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FixedFinalGame
{
    class PlayerController
    {
        InputHandler input;
        IWeapon weapon;

        Player PassedPlayer;
        public Vector2 Direction;
        public int Speed;
        public float jumpheight;
        public Gravity gravity;

        public bool Block, Attack;
        public int gravLvl;
        public MouseState newInput, oldInput;

        

        //Building without weapon
        public PlayerController(Game game, Player player)
        {            
            input = (InputHandler)game.Services.GetService(typeof(IInputHandler));
            
            this.Direction = Vector2.Zero;
            this.jumpheight= 2.5f;
            this.Speed = 500;

            this.gravity = new Gravity();
            this.gravity.GravityDir = new Vector2(0, 1);
            this.gravity.GravityAccel = 8.0f;

            PassedPlayer = player;
            
        }


        
        public void DifferentHandleInput(GameTime gameTime)
        {
            float time = (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            Block=false;
            Attack=false;

            newInput = Mouse.GetState();
            

            this.Direction = Vector2.Zero;
            if (input.KeyboardState.WasKeyPressed(Keys.B))
            {
                this.gravity.GravityAccel = 8.0f;
            }
            if (input.KeyboardState.WasKeyPressed(Keys.N))
            {
                this.gravity.GravityAccel = 4.0f;
            }
            if (input.KeyboardState.WasKeyPressed(Keys.M))
            {
                this.gravity.GravityAccel = 1.0f;
            }

            if (input.KeyboardState.IsKeyDown(Keys.A))
            {
                this.Direction = new Vector2(-1, 0);
                //this.Speed.X = 350;
            }
            if (input.KeyboardState.IsKeyDown(Keys.D))
            {
                this.Direction = new Vector2(1, 0);
                //this.Speed.X = 350;
            }

            if (input.KeyboardState.HasReleasedKey(Keys.Space))
            {
                if (PassedPlayer.groundState == GroundState.STANDING)
                {
                    this.Direction.Y -= jumpheight;
                }
                else if (PassedPlayer.groundState == GroundState.JUMPING)
                {
                    //Do nothing
                }
            }


            if (input.MouseState.RightButton == ButtonState.Pressed)
            {
                Block = true;
            }
            if (input.MouseState.LeftButton == ButtonState.Pressed)
            {
                Attack = true;
                //if (newInput.LeftButton == ButtonState.Pressed &&
                //    oldInput.LeftButton == ButtonState.Released)
                //{
                //    Attack = true;
                //}
            }

            if (input.KeyboardState.IsKeyDown(Keys.R))
            {
                PassedPlayer.ResetLocation();
            }
            if (input.KeyboardState.IsKeyDown(Keys.E))
            {
                PassedPlayer.Location.Y -= 35;
            }

            oldInput = input.PreviousMouseState;
        }

        public void LockInput()
        { 
            
        }
    }
}
