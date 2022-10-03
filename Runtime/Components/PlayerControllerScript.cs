using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace Arcanix
{

    [Icon("Packages/com.guema.arcanix/Gizmos/PlayerControllerScript icon.png")]
    [AddComponentMenu("Arcanix/Player Controller")]
    public class PlayerControllerScript : ControllerScript
    {

        [System.Serializable]
        private class InputLink
        {
            [SerializeField, HideLabel]
            public InputActionReference _inputActionReference;
            [SerializeField, HideLabel, InLineEditor(false, true)]
            public EntityMovementScript _entityMovementScript;
            [SerializeField]
            public (Object, Object) test;

        }

        [SerializeField, ReorderableList(ListStyle.Boxed, elementLabel: "", Foldable = false)]
        List<InputLink> _inputConnectionList = new List<InputLink>();

        private void OnEnable()
        {
            _inputConnectionList.ForEach(link =>
            {
                link._inputActionReference.action.performed += Propagate;
                link._inputActionReference.action.canceled += Propagate;
            });

        }

        private void OnDisable()
        {
            _inputConnectionList.ForEach(link =>
            {
                link._inputActionReference.action.performed -= Propagate;
                link._inputActionReference.action.canceled -= Propagate;
            });
        }

        private void Propagate(InputAction.CallbackContext ctx)
        {

            if (ctx.valueType == typeof(Vector2))
                _inputConnectionList.First(link => link._inputActionReference.action == ctx.action)
                    ._entityMovementScript.Perform(ctx.ReadValue<Vector2>());
            else if (ctx.valueType == typeof(float))
                _inputConnectionList.First(link => link._inputActionReference.action == ctx.action)
                    ._entityMovementScript.Perform(ctx.ReadValue<float>());
        }

    }

}
