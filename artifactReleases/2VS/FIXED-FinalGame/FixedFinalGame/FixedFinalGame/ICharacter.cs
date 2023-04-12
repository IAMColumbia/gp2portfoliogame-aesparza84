using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixedFinalGame
{
    public enum CharacterState { ATTACKING, NEUTRAL }
    public enum GroundState {STANDING, JUMPING, FALLING }
    public enum LifeState { ALIVE, DEAD }
    public interface ICharacter
    {
        
        int health { get; set; }
        Gravity gravity { get; set; }

        LifeState lifestate { get; set; }
        GroundState groundState { get; set; }
        IWeapon weapon { get; set; }

        CharacterState characterState { get; set; }

    }
}
