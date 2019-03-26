using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour
{
    public AudioClip sound;
    public AudioSource audiosrc;

    void Start()
    {
        audiosrc.clip = sound;
    }

    public GameObject bullet;
    float speed = 5.0f;

    //smierc gracza /death/
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "bullet_enemy")
        {
            //Destroy(gameObject);
            Destroy(col.gameObject);
            SceneManager.LoadScene("End");
        }
    }

    void Update()
    {

        //poruszanie sie
        var move = new Vector3(Input.GetAxis("Horizontal"), 0);
        transform.position += move * speed * Time.deltaTime;
        if ((transform.position.x > 11) || (transform.position.x < -11))
        {
            transform.position -= move * speed * Time.deltaTime;
        }


        //strzelanie
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            audiosrc.Play();
            Destroy(Instantiate(bullet, transform.position, transform.rotation), 2);
        }

        if (GameObject.FindGameObjectsWithTag("Enemy") == null)
        {
            SceneManager.LoadScene("End");
        }

    }
}
