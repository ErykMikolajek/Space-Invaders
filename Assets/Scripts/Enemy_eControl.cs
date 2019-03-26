using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_eControl : EnemyControl
{
    public AudioSource erc;
    public AudioClip ec;

    void Start()
    {
        erc.clip = ec;
    }

    //niszczenie przeciwnika po trafieniu /kill/
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "bullet_player")
        {
            scr.result += 300;
            if (scr.chk)
            {
                Instantiate(gameObject, new Vector2(19, 6.5f), Quaternion.identity);
            }
            erc.Play();
            Destroy(gameObject);
            Destroy(col.gameObject);
        }
    }

    public float speed_e=3f;
    int turn = -1;

    void Update()
    {

        //strzal w losowym momencie
         if (below == null)
         {
             if (Random.Range(0, shooting_frequency) < 5)
             {
                 Destroy(Instantiate(enemybullet, transform.position, transform.rotation), 4);
             }
         }

        //poruszanie sie
        if (gameObject.transform.position.x < -19) turn = 1; 
        if (gameObject.transform.position.x > 19) turn = -1;
        transform.Translate(new Vector2(turn, 0) * speed_e * Time.deltaTime);
    }
}