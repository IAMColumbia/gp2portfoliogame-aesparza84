using FinalGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalGame
{
    public enum WeaponState{STOPPED, USING }
    public abstract class Weapon : IWeapon
    {
        WeaponState wpstate { get; set; }
        public string Name { get; set; }
        public int Damage { get; set; }
        public Weapon() 
        {
            
        }

        public virtual void Use()
        {
            if (wpstate != WeaponState.STOPPED)
            {
                wpstate = WeaponState.USING;
            }
            wpstate = WeaponState.STOPPED;
        }
    }
}
