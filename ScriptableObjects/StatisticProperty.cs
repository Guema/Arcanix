using UnityEngine;
using System.Collections;
using System;

public class StatisticProperty : Property
{
    public override Type PropertyType
    {
        get
        {
            return typeof(int);
        }
    }
}
