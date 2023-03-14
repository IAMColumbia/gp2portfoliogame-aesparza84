using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoGameLibrary.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixedFinalGame
{
    class PlayerController
    {
        InputHandler input;
        IWeapon weapon;

        Player PassedPlayer;


        public Gravity gravity;
        public Vector2 Direction { get; set; }

        public PlayerController(Game game, Player player, IWeapon passedWeapon) 
        {
            input = (InputHandler)game.Services.GetService(typeof(IInputHandler));
            this.Direction = Vector2.Zero;
            this.weapon = passedWeapon;
            PassedPlayer = player;
        }

        //Building without weapon
        public PlayerController(Game game, Player player)
        {            
            input = (InputHandler)game.Services.GetService(typeof(IInputHandler));
            this.Direction = Vector2.Zero;
            PassedPlayer = player;

            gravity = new Gravity();
            SetGravity();
        }

        void SetGravity()
        {
            this.gravity.GravityAccel = 12f;
            this.gravity.GravityDir = new Vector2(0, 6);
        }
        public void HandleInput(GameTime gameTime)
        {
            float time = (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            this.Direction = Vector2.Zero;

            //var moustate = Mouse.GetState();
                if (input.KeyboardState.IsKeyDown(Keys.A))
                {
                    this.Direction = new Vector2(-1, 0);
                    
                }
                if (input.KeyboardState.IsKeyDown(Keys.D))
                {
                    this.Direction = new Vector2(1, 0);
                }
                if (input.KeyboardState.IsKeyDown(Keys.Space))
                {
                    if (PassedPlayer.groundState == GroundState.STANDING)
                    {                       
                        this.Direction = new Vector2(0,-2);
                        PassedPlayer.groundState = GroundState.JUMPING;
                    }
                    if (PassedPlayer.groundState == GroundState.JUMPING)
                    {
                        
                    }                    
                }
            if (input.KeyboardState.IsKeyDown(Keys.R))
            {
                PassedPlayer.ResetLocation();
            }
                //if (mouseState.LeftButton == ButtonState.Pressed)
                //{
                //    this.weapon.Use();
                //}
            
                          
        }
    }
}
