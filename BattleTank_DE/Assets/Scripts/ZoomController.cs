using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomController : MonoBehaviour
{
    private Camera cam;
    private float zoom;
    private float view;

    //===================================================
    //カメラのzoom機能
    // Start is called before the first frame update
    //===================================================
    void Start()
    {
        cam = GetComponent<Camera>();
        view = cam.fieldOfView;
    }

    // Update is called once per frame
    void Update()
    {
        cam.fieldOfView = view + zoom;

        if (cam.fieldOfView < 20f)
        {
            cam.fieldOfView = 20f;
        }

        if (cam.fieldOfView > 60f)
        {
            cam.fieldOfView = 60f;
        }

        if (Input.GetKey(KeyCode.RightShift))
        {
            zoom -= 1.2f;

            if (zoom < -40f)
            {
                zoom = -40f;
            }
        }
        else
        {
            zoom += 1.2f;

            if (zoom > 0)
            {
                zoom = 0;
            }
        }

       // print("zoomの値" + zoom);
    }
}
