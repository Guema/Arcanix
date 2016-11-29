using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

[SelectionBase]
[DisallowMultipleComponent]
[ExecuteInEditMode]
[AddComponentMenu("Arcanix/Unit")]
public class Unit : MonoBehaviour
{
    [SerializeField]
    ClampedInt health = new ClampedInt(100, 0.5f);
    [SerializeField]
    Skill[] skills;



    // This function is called on Component Placement/Replacement
    void Reset()
    {
        
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Called every frame in editor
    void OnDrawGizmos()
    {

    }
}
