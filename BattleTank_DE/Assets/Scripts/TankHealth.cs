﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class TankHealth : MonoBehaviour
{
    [SerializeField]
    private GameObject effectPrehab1;

    [SerializeField]
    private GameObject effectPrefab2;
    public int tankHP;

    [SerializeField]
    private Text HPLabel;

    public int tankMaxHP = 10;

    void Start()
    {
        tankHP = tankMaxHP;
        HPLabel.text = "HP:" + tankHP;
    }

    private void OnTriggerEnter(Collider other)
    {
        //=========================================================
        //PlayerにHPをつける
        //敵の砲弾と、Playerを破壊する
        //=========================================================
        if (other.gameObject.tag == "EnemyShell")
        {
            tankHP -= 1;

            HPLabel.text = "HP:" + tankHP;

            Destroy(other.gameObject);

            if (tankHP > 0)
            {
                GameObject effect1 = Instantiate(effectPrehab1, transform.position, Quaternion.identity);
                Destroy(effect1, 1.0f);
            }
            else
            {
                GameObject effect2 = Instantiate(effectPrefab2, transform.position, Quaternion.identity);
                Destroy(effect2, 1.0f);

                // Destroy(gameObject);

                this.gameObject.SetActive(false);

                Invoke("GoToGameOver", 1.5f);
            }
        }
    }

    void GoToGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void AddHP(int amount)
    {
        tankHP += amount;

        if (tankHP > tankMaxHP)
        {
            tankHP = tankMaxHP;
        }

        HPLabel.text = "HP:" + tankHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
