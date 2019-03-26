using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyControl : MonoBehaviour
{

    public Score scr;
    public AudioClip death, move, move2, move3, move4, move5;
    public AudioSource srcd, srcm;
    int dir=1;
    public int far = 10;  
    float time = 0;
    public float moving_speed = 5f; // <- czas między przeskokami (im mniej tym szybciej)
    public float distance = 30f; // <- o jaką odległość robią przeskok
    public int shooting_frequency = 750; // <- co ile strzelają
    public GameObject enemybullet;
    public EnemyControl below;

    void Start()
    {
        srcm.clip = move;
        srcd.clip = death;
    }

    //niszczenie przeciwnika po trafieniu /kill/
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "bullet_player")
        {
            scr.result += 50;
            srcd.Play();
            Destroy(gameObject);
            Destroy(col.gameObject);

        }
    }

    void Update()
    {
        //strzal w losowym momencie
        if (below == null)
        {
            if (Random.Range(0, shooting_frequency) < 5)
            {
                Destroy(Instantiate(enemybullet, transform.position, transform.rotation), 2);
            }
        }
        
        //wzrost szybkosci poruszania sie przeciwnikow
        switch (scr.tempo)
        {
            case 1:
                moving_speed = 1;
                srcm.clip = move2;
                break;
            case 2:
                moving_speed = 2;
                srcm.clip = move3;
                break;
            case 3:
                moving_speed = 3;
                srcm.clip = move4;
                break;
            case 4:
                moving_speed = 4;
                srcm.clip = move5;
                break;
            default:
                moving_speed = 5;
                break;  
        }

        //Debug.Log(moving_speed);

        //poruszanie sie przeciwnikow
        time++;

        if (time == moving_speed * 10)
        {
            if (dir <= far) transform.Translate(new Vector3(1, 0, 0) * distance * Time.deltaTime);
            else if (dir == far + 1) transform.Translate(new Vector3(0, -1, 0) * distance * Time.deltaTime);

            else if (dir <= (far *2) + 1) transform.Translate(new Vector3(-1, 0, 0) * distance * Time.deltaTime);
            else if (dir == (far * 2) + 2) transform.Translate(new Vector3(0, -1, 0) * distance * Time.deltaTime);

            dir++;
            srcm.Play();
            time = 0f;
            if (dir == (far * 2) + 3) dir = 1;
        }
   
        if(gameObject.transform.position.y < -5.5f)
        {
            SceneManager.LoadScene("End");
        }
    }
}