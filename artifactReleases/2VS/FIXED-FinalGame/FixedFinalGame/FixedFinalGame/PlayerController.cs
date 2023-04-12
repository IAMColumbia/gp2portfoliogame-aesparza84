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
        public Vector2 Speed;

        public bool Block;
        public bool Attack;

        public PlayerController(Game game, Player player, IWeapon passedWeapon) 
        {
            input = (InputHandler)game.Services.GetService(typeof(IInputHandler));

            this.Direction = Vector2.Zero;
            this.Speed = new Vector2(200, 100);

            this.weapon = passedWeapon;
            PassedPlayer = player;
        }

        //Building without weapon
        public PlayerController(Game game, Player player)
        {            
            input = (InputHandler)game.Services.GetService(typeof(IInputHandler));
            
            this.Direction = Vector2.Zero;
            this.Speed = new Vector2(350, 100);

            PassedPlayer = player;
        }


        
        public void DifferentHandleInput(GameTime gameTime)
        {
            float time = (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            Block=false;
            Attack=false;

            this.Speed.X = 0;
            this.Direction = Vector2.Zero;

            if (input.KeyboardState.IsKeyDown(Keys.A))
            {
                this.Direction = new Vector2(-1, 0);
                this.Speed.X = 350;
            }
            if (input.KeyboardState.IsKeyDown(Keys.D))
            {
                this.Direction = new Vector2(1, 0);
                this.Speed.X = 350;
            }

            if (input.KeyboardState.HasReleasedKey(Keys.Space))
            {
                if (PassedPlayer.groundState == GroundState.STANDING)
                {
                    this.Direction.Y = -1;
                }
                else if (PassedPlayer.groundState == GroundState.JUMPING)
                {
                    //DoGravity(time);

                }
            }

            if (input.MouseState.RightButton == ButtonState.Pressed)
            {
                Block = true;
            }
            if (input.MouseState.LeftButton == ButtonState.Pressed)
            {
                Attack = true;
            }

            if (input.KeyboardState.IsKeyDown(Keys.R))
            {
                PassedPlayer.ResetLocation();
            }
        }

        public void LockInput()
        { 
            
        }



        //public void HandleInput(GameTime gameTime)
        //{
        //    float time = (float)gameTime.ElapsedGameTime.TotalMilliseconds;
        //    this.Direction = Vector2.Zero;

        //    //var moustate = Mouse.GetState();
        //        if (input.KeyboardState.IsKeyDown(Keys.A))
        //        {
        //            this.Direction = new Vector2(-1, 0);
                    
        //        }
        //        if (input.KeyboardState.IsKeyDown(Keys.D))
        //        {
        //            this.Direction = new Vector2(1, 0);
        //        }
        //        if (input.KeyboardState.IsKeyDown(Keys.S))
        //        {

                   
        //        }
        //        if (input.KeyboardState.IsKeyDown(Keys.Space))
        //        {
        //            if (PassedPlayer.groundState == GroundState.STANDING)
        //            {                       
        //                this.Speed = new Vector2(500,10);
        //                this.Direction = new Vector2(0,-1);
        //                PassedPlayer.groundState = GroundState.JUMPING;
        //            }
        //            if (PassedPlayer.groundState == GroundState.JUMPING)
        //            {
                        
        //            }                    
        //        }
        //    if (input.KeyboardState.IsKeyDown(Keys.R))
        //    {
        //        PassedPlayer.ResetLocation();
        //    }
        //        //if (mouseState.LeftButton == ButtonState.Pressed)
        //        //{
        //        //    this.weapon.Use();
        //        //}
            
                          
        //}
    }
}
