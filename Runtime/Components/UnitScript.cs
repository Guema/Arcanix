using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arcanix
{
    [AddComponentMenu("Arcanix/Unit")]
    [SelectionBase, DisallowMultipleComponent]
    public class UnitScript : MonoBehaviour, IUnit
    {
        UnitScript IUnit.unit => this;
    }
}
