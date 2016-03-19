using UnityEngine;
using System.Collections;

[SelectionBase]
[DisallowMultipleComponent]
[ExecuteInEditMode]
public class Unit : MonoBehaviour
{    
    [SerializeField]
    string faction = "" ;
    [SerializeField]
    bool canNotDie;
    [SerializeField]
    bool isDied;
    [SerializeField]
    int health = 100;
    [SerializeField]
    int speed = 100;

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
        return speed;
    }

    public string GetFaction()
    {
        return faction;
    }
}
