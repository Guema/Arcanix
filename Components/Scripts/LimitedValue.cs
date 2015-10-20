using UnityEngine;
using System.Collections;

[System.Serializable]
public class LimitedValue
{
    [SerializeField]
    int value;
    [SerializeField]
    int min = 0;
    [SerializeField]
    int max = 100;

    public LimitedValue(int val, int min, int max)
    {
        this.min = min;
        this.max = max;
        value = val;
    }
}