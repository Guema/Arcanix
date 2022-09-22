using UnityEngine;
using NaughtyAttributes;
using System.Collections.Generic;

namespace Arcanix
{
    [AddComponentMenu("Arcanix/Entity Movement")]
    [RequireComponent(typeof(UnitScript))]
    [Tooltip("Entity movement define a movement ability for a ?gameobject?")]
    public class EntityMovementScript : MonoBehaviour
    {
        #region InternalSetup

        static readonly DropdownList<(Vector3Int, Vector3Int)> LIST = new DropdownList<(Vector3Int, Vector3Int)>
        {
            {"X (button)", (Vector3Int.right, Vector3Int.zero)},
            {"Y (button)", (Vector3Int.up, Vector3Int.zero)},
            {"Z (button)", (Vector3Int.forward, Vector3Int.zero)},
            {"XY (vector2)", (Vector3Int.right, Vector3Int.up)},
            {"XZ (vector2)", (Vector3Int.right, Vector3Int.forward)},
            {"YX (vector2)", (Vector3Int.up, Vector3Int.right)},
            {"YZ (vector2)", (Vector3Int.up, Vector3Int.forward)},
            {"ZX (vector2)", (Vector3Int.forward, Vector3Int.right)},
            {"ZY (vector2)", (Vector3Int.forward, Vector3Int.up)},
        };
        #endregion

        [SerializeField] bool _localSpace = true;
        [SerializeField, Dropdown("LIST")] (Vector3Int, Vector3Int) _movementAxis = (Vector3Int.forward, Vector3Int.right);
        [SerializeField] float intensity = 3f;

        void Reset()
        {
            Init();
        }

        void OnValidate()
        {
            Init();
        }

        void Init()
        {

        }

        public void Move(Vector3 value)
        {

        }
    }
}