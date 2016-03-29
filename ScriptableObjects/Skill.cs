using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class Skill : ScriptableObject
{
    [SerializeField]
    UnityEvent OnStart;
}
