using UnityEngine;
using System.Collections;
using System;

[System.Serializable]
public struct ClampedInt
{
    [SerializeField]
    private const int MIN = 0;
    [SerializeField]
    private int _max;
    [SerializeField]
    private int _val;
    /// <summary>
    /// Create a Clamped value. Max limit and value are chosen logically. 
    /// </summary>
    /// <param name="val1">value1</param>
    /// <param name="val2">value2</param>
    public ClampedInt(int val1, int val2)
    {
        _max = val1 > val2 ? val1 > MIN ? val1 : MIN : val2 > MIN ? val2 : MIN;
        _val = val1 < val2 ? val1 > MIN ? val1 : MIN : val2 > MIN ? val2 : MIN;
    }

    public ClampedInt(int max, float val_in_percent)
    {
        _max = max > MIN ? max : MIN;
        _val = (int)((val_in_percent > 1f ? 1f : val_in_percent > 0f ? val_in_percent : 0f) * max);
    }

    /// <summary>
    /// Max bound of the ClampedInt
    /// </summary>
    public int Max
    {
        get
        {
            return _max;
        }

        set
        {
            _max = value > MIN ? value : MIN ;
            Val = _val;
        }
    }

    /// <summary>
    /// Min bound of the ClampedInt
    /// </summary>
    public int Min
    {
        get
        {
            return MIN;
        }
    }

    /// <summary>
    /// Value of the ClampedInt
    /// </summary>
    public int Val
    {
        get
        {
            return _val;
        }

        set
        {
            _val = value < _max ? value > MIN ? value : MIN : _max; 
        }
    }
        
}