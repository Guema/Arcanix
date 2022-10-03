using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arcanix
{
    [Icon("Packages/com.guema.arcanix/Gizmos/UnitScript icon.png")]
    [AddComponentMenu("Arcanix/Unit")]
    [SelectionBase, DisallowMultipleComponent]
    public class UnitScript : MonoBehaviour, IUnit
    {
        UnitScript IUnit.unit => this;
    }
}
