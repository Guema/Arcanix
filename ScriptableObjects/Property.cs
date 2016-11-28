using UnityEngine;
using System.Collections.Generic;
using System;

public abstract class Property : ScriptableObject
{
    abstract public Type PropertyType
    {
        get;   
    }
}


