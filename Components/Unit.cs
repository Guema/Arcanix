using UnityEngine;
using System.Collections;

[SelectionBase]
[DisallowMultipleComponent]
[ExecuteInEditMode]
public class Unit : MonoBehaviour {

    [SerializeField]
    string faction;
    [SerializeField]
    MaxedInt health = new MaxedInt(0, 100);
    [SerializeField]
    int mr;

    // This function is called on Component Placement/Replacement
    void Reset()
    {

    }

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    //Called every frame in editor
    void OnDrawGizmos()
    {

    }
}
