using UnityEngine;
using System.Collections;
using System;

[System.Serializable]
public struct ClampedInt
{
    [SerializeField]
    private const int _min = 0;
    [SerializeField]
    private int _max;
    [SerializeField]
    private int _val;
    /// <summary>
    /// Create a Clamped value. limits and value are automatically chosen. 
    /// </summary>
    /// <param name="val1">value1</param>
    /// <param name="val2">value2</param>
    /// <param name="val3">value3</param>
    public ClampedInt(int val1, int val2, int val3)
    {
        //_min = val1 < val2 ? val1 < val3 ? val1 : val3 : val2 < val3 ? val2 : val3;
        _max = val1 > val2 ? val1 > val3 ? val1 : val3 : val2 > val3 ? val2 : val3;
        _val = val1 > val2 ? val1 < val3 ? val1 : val2 > val3 ? val2 : val3 : val1 > val3 ? val1 : val2 < val3 ? val2 : val3;
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
            _max = value;
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
            return _min;
        }
        /*
        set
        {
            _min = value;
            Val = _val;
        }
        */
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
            _val = value < _max ? value > _min ? value : _min : _max;
        }
    }
        
}