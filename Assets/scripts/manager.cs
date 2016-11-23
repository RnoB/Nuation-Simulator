using UnityEngine;
using System.Collections;

public class manager : MonoBehaviour {
    public GameObject orca;
    public GameObject camera1;
    public GameObject camera2;
    bool growth;
    bool subapical;
    GameObject fish;
	// Use this for initialization
	void Start () {
       


        growth = false;
        subapical = false;

        fish = Instantiate(orca);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("escape"))
            Application.Quit();

    }

    public void psiGslider(float value)
    {


        PlayerPrefs.SetFloat("psiG0", value);
    }
    public void psiCSlider(float value)
    {


        PlayerPrefs.SetFloat("psiC0", -value);
    }
    public void cSlider(float value)
    {


        PlayerPrefs.SetFloat("C0", value);
    }
    public void wSlider(float value)
    {


        PlayerPrefs.SetFloat("psi0", value);
    }
    public void PSlider(float value)
    {

         
        PlayerPrefs.SetFloat("gamma", value);
    }
    public void eSlider(float value)
    {


        PlayerPrefs.SetFloat("E0", Mathf.Pow(10,value-5));
    }
    public void dSlider(float value)
    {


        PlayerPrefs.SetFloat("Delta0", value);
    }
    public void growthToggle()
    {
        growth = !growth;
        if (growth)
        {
            PlayerPrefs.SetInt("growth", 1);
        }
        else
        {
            PlayerPrefs.SetInt("growth", 0);
        }
    }
    public void subapicalToggle()
    {
        subapical = !subapical;
        
        if (subapical)
        {
            PlayerPrefs.SetInt("subapical", 1);
        }
        else
        {
            PlayerPrefs.SetInt("subapical", 0);
        }
    }
    public void restart()
    {

        transform.eulerAngles = new Vector3(25, 180, 0);
        transform.position = new Vector3(0,125  ,150);
        camera1.transform.eulerAngles = new Vector3(90, 180, 0);
        camera1.transform.position = new Vector3(0, 1000, 0);
        camera1.GetComponent<Camera>().orthographicSize = 100;
        camera2.transform.eulerAngles = new Vector3(0, 180, 0);
        camera2.transform.position = new Vector3(0, 25, 1000);
        camera2.GetComponent<Camera>().orthographicSize = 100;
        Destroy(fish);

                    fish = Instantiate(orca);
        

    }
}
