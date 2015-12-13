using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    enum ECameraMode
    {
        FPS,
        TPS
    }
    [SerializeField]
    bool lockX;
    [SerializeField]
    bool lockY;

    [SerializeField]
    new Camera camera;
    [SerializeField]
    ECameraMode cameraMode;

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
        if (cameraMode == ECameraMode.FPS)
        {
            camera.transform.rotation *= Quaternion.Euler(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0.0f);
        }
    }
}
