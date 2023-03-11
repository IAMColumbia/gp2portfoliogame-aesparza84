using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalGame
{
    public enum CharacterState { ATTACKING, NEUTRAL }
    public enum LifeState { ALIVE, DEAD }
    public interface ICharacter
    {
        int health { get; set; }

        LifeState lifestate { get; set; }
        IWeapon weapon { get; set; }

        CharacterState characterState { get; set; }

    }
}
