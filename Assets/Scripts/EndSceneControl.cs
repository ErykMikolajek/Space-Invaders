using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndSceneControl : MonoBehaviour {

    public Text scrtext;
	
    // Use this for initialization
	void Start () {
        scrtext.text = PlayerPrefs.GetInt("Score").ToString();
    }

	// Update is called once per frame
	void Update () {
		
	}
}
