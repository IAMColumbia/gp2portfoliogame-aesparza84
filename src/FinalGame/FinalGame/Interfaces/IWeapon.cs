using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalGame.Interfaces
{
    public interface IWeapon
    {
        string Name { get; set; }
        int Damage { get; set; }
    }
}
