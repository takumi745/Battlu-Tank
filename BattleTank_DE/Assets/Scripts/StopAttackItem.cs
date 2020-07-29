﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAttackItem : MonoBehaviour
{
    private GameObject[] targets;

    [SerializeField]
    private AudioClip getSound;

    [SerializeField]
    private GameObject effectPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        targets = GameObject.FindGameObjectsWithTag("EnemyShotShell");
    }

    private void OnTriggerEnter(Collider other)
    {
        //==============================================
        //攻撃停止時間の設定
        //==============================================
        if (other.gameObject.tag == "Player")
        {
            for (int i = 0; i < targets.Length; i++)
            {
                targets[i].GetComponent<EnemyShotShell>().AddStopTimer(3.0f);
            }

            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(getSound, transform.position);
            GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
            Destroy(effect, 0.5f);
        }
    }
}
