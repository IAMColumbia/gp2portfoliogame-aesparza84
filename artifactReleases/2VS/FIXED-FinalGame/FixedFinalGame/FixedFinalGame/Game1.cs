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

        TileMap world;
        List<MonoTile> tiles;

        MonoTile tile;

        Camera cam;

        Player player;

        Enemy enemy;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            


            cam = new Camera();

            tiles= new List<MonoTile>();

            input = new InputHandler(this); 
            this.Components.Add(input);

            player = new Player(this, cam);                     //add Camera to the objects, matrix
            this.Components.Add(player);

            enemy= new Enemy(this, cam, player);
            this.Components.Add(enemy);

            tile = new MonoTile(this, player, cam);
            this.Components.Add(tile);
            tiles.Add(tile);

            world = new TileMap(this, cam, player);
        }

        protected override void Initialize()
        {
            Screenheight = _graphics.PreferredBackBufferHeight;
            Screenwidth  = _graphics.PreferredBackBufferWidth;


            //tiles= new List<MonoTile>();
            //for (int i = 0; i < 3; i++)
            //{
            //    MonoTile tile = new MonoTile(this,player,cam);
            //    tile.Location = new Vector2(200*i, 260);
            //    this.Components.Add(tile);
            //    tiles.Add(tile);
            //}

            //for (int i = 0; i < 3; i++)
            //{
            //    MonoTile tile = new MonoTile(this,cam);
            //    tile.Location = new Vector2(i*100, i*100);
            //    this.Components.Add(tile);
            //}


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            background = this.Content.Load<Texture2D>("SpaceBackground");
            FakePlayer = this.Content.Load<Texture2D>("TestingSrite2");

            
            
            // TODO: use this.Content to load your game content here
            // cam = new Camera(player, _spriteBatch);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            cam.Update(player);
            foreach (MonoTile item in tiles)
            {
                player.CheckTileCollision(item);
            }
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
            _spriteBatch.Draw(FakePlayer, new Vector2(40, 50), Color.White);
            _spriteBatch.End();

            //_spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, player.cam.Transform);
            //_spriteBatch.Begin();

            //_spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}