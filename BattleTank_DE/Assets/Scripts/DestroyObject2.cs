using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyObject2 : MonoBehaviour
{
    [SerializeField]
    private GameObject effectPrefab;

    [SerializeField]
    private GameObject effectPrefab2;
    public int objectHP;

    [SerializeField]
    private GameObject[] itemPrefabs;

    [SerializeField]
    private int scoreValue;
    private ScoreManager sm;

    private void Start()
    {
        sm = GameObject.Find("ScoreLabel").GetComponent<ScoreManager>();
    }
    //================================================
    //オブジェクトを破壊する
    //================================================
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Shell"))
        {
            objectHP -= 1;

            //HPが0より大きいとき
            if (objectHP > 0)
            {
                Destroy(other.gameObject);
                GameObject effect = Instantiate(effectPrefab, other.transform.position, Quaternion.identity);
                Destroy(effect, 2.0f);
            }
            else // そうでないとき
            {
                Destroy(other.gameObject);
                GameObject effect2 = Instantiate(effectPrefab2, other.transform.position, Quaternion.identity);
                Destroy(effect2, 2.0f);

                // Destroy(this.gameObject);
                sm.AddScore(scoreValue);

                this.gameObject.SetActive(false);

                Invoke("GoToClear", 1.5f);

               /*int itemNumber = Random.Range(0, itemPrefabs.Length);

                Vector3 pos = transform.position;

                if (itemPrefabs.Length != 0)
                {
                    Instantiate(itemPrefabs[itemNumber], new Vector3(pos.x, pos.y + 0.6f, pos.z), Quaternion.identity);
                }*/

            }
        }
    }

    void GoToClear()
    {
        SceneManager.LoadScene("GameClear");
    }


    // Update is called once per frame
    void Update()
    {

    }
}
