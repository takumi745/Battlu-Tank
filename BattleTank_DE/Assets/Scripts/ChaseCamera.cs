using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseCamera : MonoBehaviour
{
    [SerializeField]
    private GameObject target;
    private Vector3 offset;

    //====================================================
    //カメラの位置を取得する
    // Start is called before the first frame update
    //====================================================
    void Start()
    {
        offset = transform.position - target.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //=======================================
        //一定の距離を維持
        //=======================================
        if (target != null)
        {
            transform.position = target.transform.position + offset;
        }
    }
}
