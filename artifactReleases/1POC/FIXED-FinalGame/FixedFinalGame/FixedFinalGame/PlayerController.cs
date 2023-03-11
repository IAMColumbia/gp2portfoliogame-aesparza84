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
        public Vector2 Direction { get; set; }

        public PlayerController(Game game, IWeapon passedWeapon) 
        {
            input = (InputHandler)game.Services.GetService(typeof(IInputHandler));
            this.Direction = Vector2.Zero;
            this.weapon = passedWeapon;
        }

        public void HandleInput(GameTime gametime)
        {
            var mouseState = Mouse.GetState();
            this.Direction = Vector2.Zero;

            if (input.KeyboardState.IsKeyDown(Keys.Left))
            {
                this.Direction = new Vector2(-1,0);
            }
            if (input.KeyboardState.IsKeyDown(Keys.Right))
            {
                this.Direction = new Vector2(1,0);
            }
            if (input.KeyboardState.IsKeyDown(Keys.Space))
            {
                this.Direction = new Vector2(0,1);
            }
            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                this.weapon.Use();
            }
        }
    }
}
