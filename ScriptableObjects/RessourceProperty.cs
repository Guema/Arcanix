using UnityEngine;
using System.Collections;
using System;

public class RessourceProperty : Property
{
    public override Type PropertyType
    {
        get
        {
            return typeof(ClampedInt);
        }
    }
}
