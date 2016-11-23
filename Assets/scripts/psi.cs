using UnityEngine;
using System.Collections;

public class psi : MonoBehaviour {
    float psi0;
    public bool C;
	// Use this for initialization
	void Start () {
        if (C)
        {
            psi0 = -PlayerPrefs.GetFloat("psiC0");
        }
        else
        {
            psi0 = PlayerPrefs.GetFloat("psiG0");
        }
        transform.eulerAngles = new Vector3(0, 0, psi0);
    }
	
	// Update is called once per frame
	void Update () {
        if (C)
        {
            psi0 = -PlayerPrefs.GetFloat("psiC0");
        }
        else
        {
            psi0 = PlayerPrefs.GetFloat("psiG0");
        }
        transform.eulerAngles = new Vector3(0, 0, psi0);
    }
}
