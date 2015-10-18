using UnityEngine;
using System.Collections;

[SelectionBase]
[DisallowMultipleComponent]
public class Unit : MonoBehaviour {

    [SerializeField]
    string faction;
    [SerializeField]
    int maxHeath = 100;
    [SerializeField]
    int health;

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
}
