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
        }

        public void HandleInput(GameTime gametime)
        {
            var mouseState = Mouse.GetState();
            this.Direction = Vector2.Zero;
            if (input != null)
            {
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
                        this.Direction = new Vector2(0,-5);
                        PassedPlayer.groundState = GroundState.JUMPING;
                    }
                    if (PassedPlayer.groundState == GroundState.JUMPING)
                    {                        
                        
                    }                    
                }
                //if (mouseState.LeftButton == ButtonState.Pressed)
                //{
                //    this.weapon.Use();
                //}
            }
            else 
            {
                this.Direction = Vector2.Zero;
            }
                          
        }
    }
}
