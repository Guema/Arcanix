using UnityEngine;
using System.Collections;

[System.Serializable]
public class MaxedInt : PropertyAttribute
{
    [SerializeField]
    int value;
    [SerializeField]
    int max = 100;
    
    public int Value
    {
        get
        {
            return value;
        }
        set
        {
            if (value <= max)
            {
                if (value >= 0)
                {
                    this.value = value;
                }
                else
                {
                    this.value = 0;
                }
            }
            else
            {
                this.value = max;
            }
        }
    }
    
    public int Max
    {
        get
        {
            return max;
        }
        set
        {
            if (max >= 0)
            {
                max = value;
                Value = Value;
            }
        }
    }

    /// <summary>
    /// Builder
    /// </summary>
    /// <param name="v">Init value.</param>
    /// <param name="m">Max value. Value will be limited to it</param>
    public MaxedInt(int v, int m = 100)
    {
        Value = v;
        max = m;
    }
}