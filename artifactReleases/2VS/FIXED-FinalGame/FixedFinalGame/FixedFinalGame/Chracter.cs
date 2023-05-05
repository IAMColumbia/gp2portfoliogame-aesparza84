using Microsoft.Xna.Framework;
using MonoGameLibrary.Sprite;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace FixedFinalGame
{
    public abstract class Chracter : DrawableSprite, ICharacter
    {
        protected Chracter(Game game) : base(game)
        {

        }

        public int health { get;set; }
        public int Speed;
        public Gravity gravity { get; set; }
        public LifeState lifestate { get; set; }
        public GroundState groundState { get; set; }
        public IWeapon weapon { get; set; }
        public CharacterState characterState { get; set; }
        public Tile[][] collisionmap { get; set; }
        public Tile[] ColMap { get; set; }

        protected bool hasMap { get; set; }

        public virtual void TakeDamage() { }

        public void GetMap(Tile[][] passedmap)
        {
            int n = passedmap.Length * passedmap[0].Length;
            collisionmap = new Tile[passedmap.Length][];
            ColMap = new Tile[n];

            int m = 0;

            for (int r = 0; r < passedmap.Length; r++)
            {
                collisionmap[r] = new Tile[passedmap[0].Length];

                //grabs columns in row (7)
                for (int c = 0; c < passedmap[r].Length; c++)
                {
                    collisionmap[r][c] = passedmap[r][c];

                    ColMap[m] = passedmap[r][c];
                    m++;
                }
            }
            hasMap = true;
        }

    }
}
