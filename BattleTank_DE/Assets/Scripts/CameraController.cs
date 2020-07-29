using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera;

    [SerializeField]
    private Camera FPSCamera;
    private bool mainCameraON = true;

    [SerializeField]
    private AudioListener mainListener;

    [SerializeField]
    private AudioListener FPSListener;

    [SerializeField]
    private GameObject aimImage;


    void Start()
    {
        mainCamera.enabled = true;
        FPSCamera.enabled = false;

        mainListener.enabled = true; // オンにする
        FPSListener.enabled = false;// オフにする

        aimImage.SetActive(false);
    }
    //=====================================
    //カメラの切り替え
    //=====================================
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && mainCameraON == true)
        {
            mainCamera.enabled = false;
            FPSCamera.enabled = true;

            mainCameraON = false;

            mainListener.enabled = false; // オフにする
            FPSListener.enabled = true;// オンにする

            aimImage.SetActive(true);

        }
        else if (Input.GetKeyDown(KeyCode.C) && mainCameraON == false)
        {
            mainCamera.enabled = true;
            FPSCamera.enabled = false;

            mainCameraON = true;

            mainListener.enabled = true; // オンにする
            FPSListener.enabled = false;// オフにする

            aimImage.SetActive(false);
        }
    }
}