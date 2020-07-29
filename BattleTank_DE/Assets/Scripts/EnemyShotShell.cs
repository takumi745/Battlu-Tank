using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyShotShell : MonoBehaviour
{
    public float shotSpeed;

    [SerializeField]
    private GameObject enemyShellPrefab;

    [SerializeField]
    private AudioClip shotSound;
    private int interval;

    public float stopTimer = 5.0f;

    [SerializeField]
    private Text stopLabel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        interval += 1;

        stopTimer -= Time.deltaTime;

        if (stopTimer < 0)
        {
            stopTimer = 0;
        }

        stopLabel.text = "" + stopTimer.ToString("0");

        //=====================================
        //一定時間ごとに発射
        //=====================================
        if (interval % 60 == 0 && stopTimer <= 0)
        {
            GameObject enemyShell = Instantiate(enemyShellPrefab, transform.position, Quaternion.identity);

            Rigidbody enemyShellRb = enemyShell.GetComponent<Rigidbody>();

            enemyShellRb.AddForce(transform.forward * shotSpeed);

            AudioSource.PlayClipAtPoint(shotSound, transform.position);

            Destroy(enemyShell, 3.0f);
        }
    }

    //===========================================
    //敵の攻撃を止める
    //===========================================
    public void AddStopTimer(float amount)
    {
        //複数取得すると、それだけ加算
        stopTimer += amount;

        stopLabel.text = "" + stopTimer.ToString("0");
    }
}
