using UnityEngine;
using System.Collections;
using UnityEngine.Events;


[RequireComponent(typeof(Unit))]
public class PlayerController : Controller
{
    [SerializeField]
    new Rigidbody rigidbody;
    [SerializeField]
    new Camera camera;

    Vector3 direction;

    void Reset()
    {
        unit = transform.GetComponent<Unit>();
        rigidbody = transform.GetComponent<Rigidbody>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (rigidbody)
        {
            MoveByRigidbody();
        }
        else
        {
            MoveByTransform();
        }
    }

    void MoveByTransform()
    {
        direction.Set(0, 0, 0);
        if (Input.GetAxisRaw("Vertical") != 0.0f)
        {
            if (Input.GetAxisRaw("Vertical") > 0.0f)
            {
                //Move Forward
                direction += Vector3.forward;
            }
            else
            {
                //Move Backward
                direction += Vector3.back;
            }
        }

        if (Input.GetAxisRaw("Horizontal") != 0.0f)
        {
            if (Input.GetAxisRaw("Horizontal") > 0.0f)
            {
                //Move Right
                direction += Vector3.right;
            }
            else
            {
                //Move Left
                direction += Vector3.left;
            }
        }
        direction.Normalize();
        //direction *= unit.GetSpeed() * Time.deltaTime / 15.0f;
        transform.position += direction;
    }

    void MoveByRigidbody()
    {
        direction.Set(0, 0, 0);
        if (Input.GetAxisRaw("Vertical") != 0.0f)
        {
            if (Input.GetAxisRaw("Vertical") > 0.0f)
            {
                //Move Forward
                rigidbody.position += Vector3.forward;
            }
            else
            {
                //Move Backward
                rigidbody.position += Vector3.back;
            }
        }

        if (Input.GetAxisRaw("Horizontal") != 0.0f)
        {
            if (Input.GetAxisRaw("Horizontal") > 0.0f)
            {
                //Move Right
                rigidbody.position += Vector3.right;
            }
            else
            {
                //Move Left
                rigidbody.position += Vector3.left;
            }
        }
        direction.Normalize();
        //direction *= unit.GetSpeed() * Time.deltaTime;
        transform.position += direction;
    }
}


