using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System;
using System.Collections.Generic;

public class PlayerController : Controller
{
    [Serializable]
    struct Binding
    {
        [SerializeField]
        string axis;
        [SerializeField]
        UnityEvent functionality;
    }
    [SerializeField]
    CameraController playerCameraController;
    [SerializeField]
    List<Binding> bindings;

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
        if (!unit)
            return;
    }
}


