using UnityEngine;
using NaughtyAttributes;

namespace Arcanix
{
    [AddComponentMenu("Arcanix/Unit Movement")]
    [RequireComponent(typeof(UnitScript))]
    public class UnitMovementScript : MonoBehaviour, IUnit
    {
        [SerializeField, ReadOnly, BoxGroup]
        UnitScript _unit;
        UnitScript IUnit.unit => _unit;



        /// <summary>
        /// Reset is called when the user hits the Reset button in the Inspector's
        /// context menu or when adding the component the first time.
        /// </summary>
        void Reset()
        {
            Init();
        }

        /// <summary>
        /// Called when the script is loaded or a value is changed in the
        /// inspector (Called in the editor only).
        /// </summary>
        void OnValidate()
        {
            Init();
        }

        /// <summary>
        /// 
        /// </summary>
        void Init()
        {
            _unit ??= GetComponent<UnitScript>();
        }
    }

}


