using UnityEngine;
using System.Collections;

[DisallowMultipleComponent]
public class Projectile : MonoBehaviour
{
    public delegate Vector3 Vector3Getter();
    SkillShot skillshot;
    Vector3Getter goal;
    float speed = 0.001f;

    void Awake()
    {
        enabled = false;
        gameObject.SetActive(false);
    }

    public void Init(IProjectable projectable)
    {
        //goal = initTrigger;
        enabled = true;
        gameObject.SetActive(true);    
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, goal.Invoke(), 1f);
    }

    void IsValid()
    {

    }
}