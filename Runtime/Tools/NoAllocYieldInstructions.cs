using System.Runtime.CompilerServices;
using UnityEngine;

namespace Arcanix
{
    static class NonAllocYieldInstructions
    {
        static public WaitForEndOfFrame WaitForEndOfFrame
        {
            private set;
            get;
        } = new WaitForEndOfFrame();

        static public WaitForFixedUpdate WaitForFixedUpdate
        {
            private set;
            get;
        } = new WaitForFixedUpdate();
    }
}