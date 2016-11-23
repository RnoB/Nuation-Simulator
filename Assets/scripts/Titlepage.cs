using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class Titlepage : MonoBehaviour {

	// Use this for initialization
	void Start () {

        PlayerPrefs.SetFloat("C0", .4f);
        PlayerPrefs.SetFloat("psi0", 75f);
        PlayerPrefs.SetFloat("psiC0", 0f);
        PlayerPrefs.SetFloat("psiG0", 90f);
        PlayerPrefs.SetFloat("L", 1f);
        PlayerPrefs.SetFloat("Lgz", 1f);
        PlayerPrefs.SetFloat("Delta0", 30f);
        PlayerPrefs.SetFloat("E0", 1.5f*Mathf.Pow(10,-2));

        PlayerPrefs.SetFloat("gamma", 0f);
        PlayerPrefs.SetInt("growth", 0);
        PlayerPrefs.SetInt("subapical", 0);
    }
	
	// Update is called once per frame
	void Update () {
	    if(Time.time>3)
        {
            SceneManager.LoadScene("movtest");
        }
            
	}
}
