using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletMove : MonoBehaviour {

    public AudioSource src;
    public AudioClip col;


    void Start () {

        src.clip = col;
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bullet_player")
        {
            src.Play();
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }

    public float speed = 10f;

	void Update () {

        //poruszanie sie pocisku
        transform.Translate(new Vector3(0, -1, 0) * speed * Time.deltaTime);

    }
}
