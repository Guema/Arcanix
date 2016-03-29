using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]
[ExecuteInEditMode]
public class CameraController : MonoBehaviour
{
    enum ECameraMode
    {
        FPS,
        TPS,
        RTS
    }
    [SerializeField]
    Transform cameraPointOfView;
    new Camera camera;
    [SerializeField]
    bool lockX;
    [SerializeField]
    bool lockY;
    float zoom;
    
    [SerializeField]
    ECameraMode cameraMode;

    void Reset()
    {
        
    }

    // Use this for initialization
    void Start ()
    {
        camera = GetComponent<Camera>();
        zoom = (cameraPointOfView.transform.position - transform.position).magnitude;
    }
    
    // Update is called once per frame
    void Update ()
    {
        if (cameraMode == ECameraMode.FPS)
        {
            camera.transform.rotation *= Quaternion.Euler(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0.0f);
        }
        else if (cameraMode == ECameraMode.TPS)
        {

        }
        else if (cameraMode == ECameraMode.RTS)
        {
            camera.transform.LookAt(cameraPointOfView);
            Vector3 vec = (cameraPointOfView.transform.position - transform.position);
            vec *= Input.GetAxis("Mouse ScrollWheel");
            transform.position += vec;
        }
    }
}
