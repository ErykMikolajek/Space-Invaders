using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyControl : MonoBehaviour
{

    public Score scr;
    public AudioClip death, move, move2, move3, move4, move5;
    public AudioSource srcd, srcm;
    public float moving_speed = 0.1f; // <- prędkość
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
                Destroy(Instantiate(enemybullet, transform.position, transform.rotation), 200);
            }
        }

        //poruszanie sie przeciwnikow
        transform.Translate(new Vector2(0, -0.1f) * scr.tempo * Time.deltaTime);

        if(gameObject.transform.position.y < -5.5f && gameObject.transform.position.x > -6f && gameObject.transform.position.x < 6f)
        {
            SceneManager.LoadScene("End");
        }
    }
}