using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class ProtectorChange : MonoBehaviour {

    public GameObject proxy;

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "bullet_enemy")
        {
            Destroy(col.gameObject);
            Instantiate(proxy, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        if (col.gameObject.tag == "bullet_player")
        {
            Destroy(col.gameObject);
        }
    }
    
}