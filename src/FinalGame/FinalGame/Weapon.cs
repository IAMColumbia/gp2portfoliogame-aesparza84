using FinalGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalGame
{
    public enum WeaponState{STOPPED, SWINGING }
    public class Weapon : IWeapon
    {
        WeaponState wpstate { get; set; }
        public string Name { get; set; }
        public int Damage { get; set; }
        public Weapon() { }
    }
}
