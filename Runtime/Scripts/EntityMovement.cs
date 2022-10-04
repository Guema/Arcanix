using Toolbox;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

namespace Arcanix
{
    [Icon("Packages/com.guema.arcanix/Gizmos/Generic icon.png")]
    [Tooltip("Entity movement define a movement ability for a ?gameobject?")]
    [CreateAssetMenu]
    public class EntityMovement : ScriptableObject
    {
        #region InternalSetup

        public enum MovementAxis
        {
            [InspectorName("X (Float)")]
            X,
            [InspectorName("Y (Float)")]
            Y,
            [InspectorName("Z (Float)")]
            Z,
            [InspectorName("XY (Vector2)")]
            XY,
            [InspectorName("XZ (Vector2)")]
            XZ,
            [InspectorName("YX (Vector2)")]
            YX,
            [InspectorName("YZ (Vector2)")]
            YZ,
            [InspectorName("ZX (Vector2)")]
            ZX,
            [InspectorName("ZY (Vector2)")]
            ZY
        }

        static readonly Dictionary<MovementAxis, (Vector3, Vector3)> AXIS_VECTORS = new Dictionary<MovementAxis, (Vector3, Vector3)>
        {
            {MovementAxis.X, (Vector3.right, Vector3.zero)},
            {MovementAxis.Y, (Vector3.up, Vector3.zero)},
            {MovementAxis.Z, (Vector3.forward, Vector3.zero)},
            {MovementAxis.XY, (Vector3.right, Vector3.up)},
            {MovementAxis.XZ, (Vector3.right, Vector3.forward)},
            {MovementAxis.YX, (Vector3.up, Vector3.right)},
            {MovementAxis.YZ, (Vector3.up, Vector3.forward)},
            {MovementAxis.ZX, (Vector3.forward, Vector3.right)},
            {MovementAxis.ZY, (Vector3.forward, Vector3.up)}
        };
#if UNITY_EDITOR
        private void Reset() => Init(true);
        private void OnValidate() => Init();
#endif
        #endregion

        Rigidbody _rigidBody;
        [SerializeField] bool _localSpace = true;
        [SerializeField] bool _isConstant = false;
        [SerializeField] MovementAxis _movementAxis = MovementAxis.XZ;
        [SerializeField] float _power = 3f;

        void Init(bool onReset = false)
        {

        }


        public Vector3 ComputeMovement(GameObject gameObject, Vector2 vector2) =>
            ComputeMovement(gameObject.transform, vector2.y, vector2.x);
        public Vector3 ComputeMovement(Component component, Vector2 vector2) =>
            ComputeMovement(component.gameObject.transform, vector2.y, vector2.x);
        public Vector3 ComputeMovement(Transform transform, Vector2 vector2) =>
            ComputeMovement(transform, vector2.y, vector2.x);
        public Vector3 ComputeMovement(Component component, float input1, float input2 = 0f) =>
            ComputeMovement(component.gameObject.transform, input1, input2);
        public Vector3 ComputeMovement(Transform transform, float input1, float input2 = 0f)
        {
            Quaternion rotation = _localSpace ? transform.rotation : Quaternion.identity;
            Vector3 translation = AXIS_VECTORS[_movementAxis].Item1 * input1 + AXIS_VECTORS[_movementAxis].Item2 * input2;
            return rotation * translation * _power;
        }

    }
}