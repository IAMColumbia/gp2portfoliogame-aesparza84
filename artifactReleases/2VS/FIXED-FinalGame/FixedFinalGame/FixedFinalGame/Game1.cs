using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameLibrary.Util;
using System.Collections.Generic;

namespace FixedFinalGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public static int Screenheight, Screenwidth;

        Texture2D background;
        Texture2D FakePlayer;

        InputHandler input;

        TileMap GameWorld;

        Camera cam;

        Player player;

        Enemy enemy;

        List<Enemy> enemies;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;


            enemies = new List<Enemy>(); 

            cam = new Camera();

            input = new InputHandler(this); 
            this.Components.Add(input);

            player = new Player(this, cam);                     //add Camera to the objects, matrix
            this.Components.Add(player);

            enemy= new Enemy(this, cam);
            this.Components.Add(enemy);

            //enemy= new Enemy(this, cam, player);
            //this.Components.Add(enemy);

        }

        protected override void Initialize()
        {
            Screenheight = _graphics.PreferredBackBufferHeight;
            Screenwidth  = _graphics.PreferredBackBufferWidth;

            GameWorld = new TileMap(this.Content, cam);
            GameWorld.CreateMap();


            Tile tile = new Tile();
            for (int i = 0; i < GameWorld.world[0].Length; i++)
            {
                for (int j = 0; j < GameWorld.world.Length; j++)
                {
                    tile = GameWorld.world[j][i];
                    if (tile.isspawner==true)
                    {
                        Enemy en = new Enemy(this, cam);
                        this.Components.Add(en);
                        en.GetMap(GameWorld.world);
                        en.GetCharcter(player);
                        en.Location = new Vector2(tile.location.X, tile.location.Y - en.Rectagle.Height);
                        en.Location = tile.location;

                        enemies.Add(en);
                    }
                   
                }
            }

           

            player.Enabled = false;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            //background = this.Content.Load<Texture2D>("SpaceBackground");
            //FakePlayer = this.Content.Load<Texture2D>("TestingSrite2");


            //this.enemy.GetMap(GameWorld.world);
            //this.enemy.GetCharcter(player);
            //this.enemy.Location = new Vector2(300,150);

            player.GetMap(GameWorld.world);
            player.Enabled = true;
            player.Location = new Vector2(300, 150);

            

            // TODO: use this.Content to load your game content here
            // cam = new Camera(player, _spriteBatch);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            cam.Update(player);

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkCyan);

            // TODO: Add your drawing code here

            //_spriteBatch.Begin();
            _spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, cam.Transform);
            //_spriteBatch.Draw(background, new Vector2(-100, -150), Color.White);
            //_spriteBatch.Draw(FakePlayer, new Vector2(400, 50), Color.White);
            GameWorld.Draw(_spriteBatch);
            _spriteBatch.End();

            

            //_spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, player.cam.Transform);
            //_spriteBatch.Begin();

            //_spriteBatch.End();
            
            base.Draw(gameTime);
        }
    }
}