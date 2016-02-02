using UnityEngine;
using System.Collections;

[SelectionBase]
[DisallowMultipleComponent]
[ExecuteInEditMode]
public class Unit : MonoBehaviour
{    
    [SerializeField]
    string faction;
    [SerializeField]
    bool canNotDie;
    [SerializeField]
    bool isDied;
    [SerializeField]
    MaxedInt health = new MaxedInt();
    [SerializeField]
    MaxedInt speed = new MaxedInt();

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

    public int GetSpeed()
    {
        return speed.Value;
    }
}
