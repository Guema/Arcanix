using NaughtyAttributes;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

namespace Arcanix
{
    [AddComponentMenu("Arcanix/Entity Movement")]
    [RequireComponent(typeof(UnitScript))]
    [Tooltip("Entity movement define a movement ability for a ?gameobject?")]
    public class EntityMovementScript : MonoBehaviour
    {
        #region InternalSetup

        public enum MovementAxis
        {
            X,
            Y,
            Z,
            XY,
            XZ,
            YX,
            YZ,
            ZX,
            ZY
        }

        static readonly DropdownList<MovementAxis> AXIS_LIST = new DropdownList<MovementAxis>
        {
            {"X (bool)", MovementAxis.X },
            {"Y (bool)", MovementAxis.Y },
            {"Z (bool)", MovementAxis.Z },
            {"XY (Vector2)", MovementAxis.XY },
            {"XZ (Vector2)", MovementAxis.XZ },
            {"YX (Vector2)", MovementAxis.YX },
            {"YZ (Vector2)", MovementAxis.YZ },
            {"ZX (Vector2)", MovementAxis.ZX },
            {"ZY (Vector2)", MovementAxis.ZY }
        };

        static readonly Dictionary<MovementAxis, (Vector3Int, Vector3Int)> AXIS_VECTORS = new Dictionary<MovementAxis, (Vector3Int, Vector3Int)>
        {
            {MovementAxis.X, (Vector3Int.right, Vector3Int.zero)},
            {MovementAxis.Y, (Vector3Int.up, Vector3Int.zero)},
            {MovementAxis.Z, (Vector3Int.forward, Vector3Int.zero)},
            {MovementAxis.XY, (Vector3Int.right, Vector3Int.up)},
            {MovementAxis.XZ, (Vector3Int.right, Vector3Int.forward)},
            {MovementAxis.YX, (Vector3Int.up, Vector3Int.right)},
            {MovementAxis.YZ, (Vector3Int.up, Vector3Int.forward)},
            {MovementAxis.ZX, (Vector3Int.forward, Vector3Int.right)},
            {MovementAxis.ZY, (Vector3Int.forward, Vector3Int.up)}
        };

        #endregion

        [SerializeField] string Name;
        [ShowNonSerializedField, BoxGroup] Rigidbody _rigidBody;
        [SerializeField, BoxGroup] bool _localSpace = true;
        [SerializeField, Dropdown(nameof(AXIS_LIST)), BoxGroup] MovementAxis _movementAxis = MovementAxis.XZ;
        [SerializeField, BoxGroup] float power = 3f;


        Coroutine _currentMovement;
        Vector3 _input = Vector3.zero;

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
            _rigidBody = GetComponent<Rigidbody>();
        }

        public void Perform(float value)
        {
            Perform(new Vector2(value, 0));
        }

        public void Perform(Vector2 value)
        {
            _input = value;

            IEnumerator Move()
            {
                Vector3 movement = (Vector3)AXIS_VECTORS[_movementAxis].Item1 * _input.x +
                    (Vector3)AXIS_VECTORS[_movementAxis].Item2 * _input.y;
                do
                {
                    _rigidBody.AddForce(transform.rotation * movement * power, ForceMode.Impulse);
                    yield return NonAllocYieldInstructions.WaitForFixedUpdate;
                } while ((Vector3)value == _input);
            }

            if (_currentMovement != null)
            {
                StopCoroutine(_currentMovement);
                _currentMovement = null;
            }

            _currentMovement = StartCoroutine(Move());

        }
    }
}