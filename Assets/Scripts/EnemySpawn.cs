using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy;
    public int frequency = 15;
    public float height = 8f;
    int cnt = 0;

    void Start()
    {
        
    }

    
    void Update()
    {
        cnt++;
        if (cnt == frequency)
        {
            gameObject.transform.position = new Vector2(Random.Range(-3.5f, 3.5f), height);
            Instantiate(enemy, transform.position, transform.rotation);
            cnt = 0;
        }
    }
}
