using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBullet : MonoBehaviour {

	void Start () {
		
	}

    //niszczenie przy kontakcie z przeciwnikiem
    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(gameObject);
    }

    public float speed = 40f;
    
    void Update () {
        
        //poruszanie sie pocisku
        transform.Translate(new Vector3(0, 1, 0) * speed * Time.deltaTime);

    }

}
