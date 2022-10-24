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
            [SerializeField]
            private InputActionReference _inputActionReference;
            [SerializeField]
            private EntityMovement _entityMovement;

            public InputActionReference inputActionReference => _inputActionReference;
            public EntityMovement entityMovement => _entityMovement;
        }




        [SerializeField] CharacterController _characterController;
        [SerializeField] bool _useGravity = true;
        [SerializeField]
        List<InputLink> _inputConnectionList = new List<InputLink>();



#if UNITY_EDITOR
        void Reset() => Init();
#endif
        void Init()
        {
            _characterController = GetComponent<CharacterController>();
        }

        private void OnEnable()
        {
            _inputConnectionList.ForEach(link =>
            {
                link.inputActionReference.action.performed += Perform;
                link.inputActionReference.action.canceled += Perform;
            });

        }

        private void OnDisable()
        {
            _inputConnectionList.ForEach(link =>
            {
                link.inputActionReference.action.performed -= Perform;
                link.inputActionReference.action.canceled -= Perform;
            });
        }

        private void Perform(InputAction.CallbackContext ctx)
        {


            var inputLink = _inputConnectionList.First(e => e.inputActionReference.action == ctx.action);
            var movement = inputLink.entityMovement.ComputeMovement(this, inputLink.inputActionReference.action.ReadValue<Vector2>());

            IEnumerator Move()
            {
                while (true)
                {

                    yield return NonAllocYieldInstructions.WaitForFixedUpdate;
                }

            }



        }


    }

}
