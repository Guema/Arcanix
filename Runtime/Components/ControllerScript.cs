using UnityEngine;
using NaughtyAttributes;


namespace Arcanix
{
    [RequireComponent(typeof(UnitScript))]
    [DisallowMultipleComponent]
    public abstract class ControllerScript : MonoBehaviour, IUnit
    {
        [SerializeField, ReadOnly, BoxGroup]
        protected UnitScript _unit;
        UnitScript IUnit.unit => _unit;

#if UNITY_EDITOR
        void Reset() => Init();
#endif

        void Init()
        {
            _unit ??= GetComponent<UnitScript>();
        }


    }
}