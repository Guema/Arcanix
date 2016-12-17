using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]
[ExecuteInEditMode]
public class CameraController : MonoBehaviour
{
    [SerializeField]
    Transform cameraFocus;

    void Reset()
    {
        
    }

    // Use this for initialization
    void Start()
    {

    }
    
    // Update is called once per frame
    void Update ()
    {

    }

    void OnValidate()
    {
        if (cameraFocus)
            transform.LookAt(cameraFocus);
    }
}
