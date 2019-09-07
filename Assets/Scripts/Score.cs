using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour {

    public float tempo = 0.001f;
    public bool chk = true;
    public int result=0;
	public Text score;
    private int ene;

    void Start()
    {
        int tmp = 0;
        GameObject[] enemies;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            tmp++;
        }
        ene = tmp;
    }

    void Update () {

        int i = 0;
        int x;
        GameObject[] enemies;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            i++;
        }

        x = i;

        //zwiekszanie predkosci im mniej przeciwnikow

        if (ene != i)
        {
            tempo += 0.2f;
            ene = i;
        }
        
        PlayerPrefs.SetInt("Score", result); //<-wysylanie wyniku do sceny end
        if (x == 0) 
        {
            SceneManager.LoadScene("End");
        }

        score.text = result.ToString();
    }
}
