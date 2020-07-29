using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPItem : MonoBehaviour
{
    [SerializeField]
    private GameObject effectPrefab;

    [SerializeField]
    private AudioClip getSound;
    private TankHealth th;
    private int reward = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        th = GameObject.Find("Tank").GetComponent<TankHealth>();

        th.AddHP(reward);

        Destroy(gameObject);
        GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
        Destroy(effect, 0.5f);
        AudioSource.PlayClipAtPoint(getSound, transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
