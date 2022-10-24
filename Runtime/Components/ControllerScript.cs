using UnityEngine;
using UnityEngine.AI;


namespace Arcanix
{
    [Icon("Packages/com.guema.arcanix/Gizmos/AIControllerScript icon.png")]
    [RequireComponent(typeof(UnitScript))]
    [DisallowMultipleComponent]
    public abstract class ControllerScript : MonoBehaviour, IUnit
    {
        [SerializeField]
        protected UnitScript _unit;
        UnitScript IUnit.unit => _unit;

#if UNITY_EDITOR
        void Reset() => Init();
#endif
        public struct ControllerType
        {
            Rigidbody rigidbody;
            Rigidbody2D rigidbody2D;
            NavMeshAgent navMeshAgent;
            CharacterController characterController;

        }

        void Init()
        {
            _unit ??= GetComponent<UnitScript>();
        }


    }
}