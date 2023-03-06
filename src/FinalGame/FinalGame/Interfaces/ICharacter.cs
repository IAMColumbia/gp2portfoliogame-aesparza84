using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalGame.Interfaces
{
    public interface ICharacter
    {
        public int Health { get; set; }
        public IWeapon weapon { get; set; }

    }
}
