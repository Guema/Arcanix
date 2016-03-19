using UnityEngine;
using System.Collections;

[System.Serializable]
public class MaxedInt : PropertyAttribute
{
    int value;
    [SerializeField]
    int max;
    
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
    /// Create an int bounded between 0 and the parameter's value
    /// </summary>
    public MaxedInt()
    {

    }
}