using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using System.Collections;
using NaughtyAttributes;

namespace Arcanix
{

    [AddComponentMenu("Arcanix/Player Controller")]
    public class PlayerControllerScript : ControllerScript
    {

        [System.Serializable]
        public struct InputLink
        {
            [SerializeField]
            InputActionReference _inputActionReference;
            [SerializeField]
            EntityMovementScript _entityMovementScript;
        }


        [SerializeField, BoxGroup]
        List<InputLink> InputConnectionList = new List<InputLink>();

    }


}