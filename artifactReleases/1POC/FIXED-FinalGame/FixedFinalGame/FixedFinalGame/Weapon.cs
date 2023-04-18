using MonoGameLibrary.Sprite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixedFinalGame
{
    public enum WeaponState{STOPPED, USING }
    public abstract class Weapon : IWeapon
    {
        WeaponState weaponstate { get; set; }
        public string Name { get; set; }
        public int Damage { get; set; }
        public Weapon() 
        {
            
        }

        public virtual void Use()
        {
            if (weaponstate != WeaponState.STOPPED)
            {
                weaponstate = WeaponState.USING;
            }
            weaponstate = WeaponState.STOPPED;
        }
    }
}
