using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour {

    public int tempo=5;
    public bool chk = true;
    public int result=0;
	public Text score;

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
        switch (i)
        {
            case 1:
                tempo = 1;
                break;
            case 2:
                tempo = 2;
                break;
            case 3:
                tempo = 3;
                break;
            case 4:
                tempo = 4;
                break;
            default:
                tempo = 5;
                break;
        }

        if (i<=6) chk = false;
        //Debug.Log(tempo);


        
        PlayerPrefs.SetInt("Score", result); //<-wysylanie wyniku do sceny end
        if (x == 0) 
        {
            SceneManager.LoadScene("End");
        }

        score.text = result.ToString();
    }
}
