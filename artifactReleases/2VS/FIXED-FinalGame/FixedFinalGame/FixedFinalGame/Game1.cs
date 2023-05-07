using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameLibrary.Util;
using System.Collections.Generic;
using System.Drawing.Imaging;

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
        Tile[] map { get; set; }

        Weapon[] weapons { get; set; }

        Camera cam;

        Player player;

        Enemy enemy;

        List<Enemy> enemies;
        List<Enemy> enemiesToRemove;
        List<Enemy> enemiesToAddBack;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;


            enemies = new List<Enemy>();
            enemiesToRemove = new List<Enemy>();
            enemiesToAddBack= new List<Enemy>();

            weapons = new Weapon[1];

            //add Camera to the objects, matrix
            cam = new Camera();

            input = new InputHandler(this); 
            this.Components.Add(input);


            player = new Player(this, cam);
            this.Components.Add(player);

            //enemy= new Enemy(this, cam);
            //this.Components.Add(enemy);
        }

        protected override void Initialize()
        {
            Screenheight = _graphics.PreferredBackBufferHeight;
            Screenwidth  = _graphics.PreferredBackBufferWidth;

            GameWorld = new TileMap(this.Content, cam);
            GameWorld.CreateMap();

            int n = GameWorld.world.Length * GameWorld.world[0].Length;
            map = new Tile[n];

            int m = 0;
            for (int r = 0; r < GameWorld.world.Length; r++)
            {

                //grabs columns in row (7)
                for (int c = 0; c < GameWorld.world[r].Length; c++)
                {

                    map[m] = GameWorld.world[r][c];
                    m++;
                }
            }


            Tile tile = new Tile();
            for (int i = 0; i < map.Length; i++)
            {
                tile = map[i];
                if (tile.isEnSpawner == true)
                {
                    Enemy en = new Enemy(this, cam);
                    this.Components.Add(en);
                    en.GetMap(GameWorld.world);
                    en.Location = new Vector2(tile.location.X, tile.location.Y - en.Rectagle.Height);
                    en.Location = tile.location;

                    enemies.Add(en);
                }
                if (tile.isPlyrSpawn)
                {
                    player.Location = tile.location;
                }
            }

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

            Spear s = new Spear();
            s.texture = this.Content.Load<Texture2D>("Spear");
            weapons[0] = s;

            

            player.GetMap(GameWorld.world);
            player.GetEnemyList(enemies);
            player.GetWeapons(weapons);
            player.Enabled = true;
            


            foreach (Enemy en in enemies)
            {
                en.GetCharcter(player);
            }

            // TODO: use this.Content to load your game content here
            // cam = new Camera(player, _spriteBatch);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            cam.Update(player);


            // TODO: Add your update logic here
            foreach (Enemy en in enemies)
            {
                if (player.Rectagle.Intersects(en.Rectagle) && player.ActionState==Action.ATTACKING)
                {
                    enemiesToRemove.Add(en);
                }
            }

            foreach (Enemy en in enemiesToRemove)
            {
                en.Enabled = false;
                en.Visible= false;
                enemiesToAddBack.Add(en);
            }

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