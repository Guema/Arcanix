using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Unit))]
public class Controller : MonoBehaviour
{
    [SerializeField]
    protected Unit unit;
    void Reset()
    {
        unit = GetComponent<Unit>();
    }
}