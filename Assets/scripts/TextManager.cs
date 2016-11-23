using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextManager : MonoBehaviour {
    public Text C;
    public Text psiC;
    public Text psiG;
    public Text w0;
    public Text gamma;
    public Text Lgz;
    public Text E0;
    public Text E0ss;
    public Slider Cslider;
    public Slider psiCslider;
    public Slider psiGslider;
    public Slider w0slider;
    public Slider gammaslider;
    public Slider Lgzslider;
    public Slider E0slider;

    public Toggle subap;
    public Toggle growth;
    // Use this for initialization
    void Start ()
    {
        cTextUpdate(PlayerPrefs.GetFloat("C0"));
        psiGTextUpdate(PlayerPrefs.GetFloat("psiG0"));
        psiCTextUpdate(PlayerPrefs.GetFloat("psiC0"));

        LgzTextUpdate(PlayerPrefs.GetFloat("Delta0"));
        E0TextUpdate(PlayerPrefs.GetFloat("E0"));

        w0TextUpdate(PlayerPrefs.GetFloat("psi0"));
        gammaTextUpdate(PlayerPrefs.GetFloat("gamma"));

        Cslider.value=(PlayerPrefs.GetFloat("C0"));
        psiGslider.value = (PlayerPrefs.GetFloat("psiG0"));
        psiCslider.value = (PlayerPrefs.GetFloat("psiC0"));

        Lgzslider.value = (PlayerPrefs.GetFloat("Delta0"));
        Debug.Log(PlayerPrefs.GetFloat("E0"));
        float E0 = PlayerPrefs.GetFloat("E0");
        Debug.Log(5 + Mathf.Log10(E0));
        E0slider.value =5+Mathf.Log10(E0);

        w0slider.value = (PlayerPrefs.GetFloat("psi0"));
        gammaslider.value = (PlayerPrefs.GetFloat("gamma"));
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Alpha0) )
        {
            PlayerPrefs.SetFloat("C0", .4f);
            PlayerPrefs.SetFloat("psi0", 75f);
            PlayerPrefs.SetFloat("psiC0", 0f);
            PlayerPrefs.SetFloat("psiG0", 90f);
            PlayerPrefs.SetFloat("L", 1f);
            PlayerPrefs.SetFloat("Lgz", 1f);
            PlayerPrefs.SetFloat("Delta0", 30f);
            PlayerPrefs.SetFloat("E0", 1.5f * Mathf.Pow(10, -2));

            PlayerPrefs.SetFloat("gamma", 0f);
            PlayerPrefs.SetInt("growth", 0);
            PlayerPrefs.SetInt("subapical", 0);
            updateValues();
        }
        if (Input.GetKey(KeyCode.Alpha1))
        {
            PlayerPrefs.SetFloat("C0", .4f);
            PlayerPrefs.SetFloat("psi0", 75f);
            PlayerPrefs.SetFloat("psiC0", 0f);
            PlayerPrefs.SetFloat("psiG0", 270f);
            PlayerPrefs.SetFloat("L", 1f);
            PlayerPrefs.SetFloat("Lgz", 1f);
            PlayerPrefs.SetFloat("Delta0", 30f);
            PlayerPrefs.SetFloat("E0", 1.5f * Mathf.Pow(10, -2));

            PlayerPrefs.SetFloat("gamma", 0f);
            PlayerPrefs.SetInt("growth", 0);
            PlayerPrefs.SetInt("subapical", 0);
            updateValues();
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            PlayerPrefs.SetFloat("C0", .4f);
            PlayerPrefs.SetFloat("psi0", 0f);
            PlayerPrefs.SetFloat("psiC0", 0f);
            PlayerPrefs.SetFloat("psiG0", 270f);
            PlayerPrefs.SetFloat("L", 1f);
            PlayerPrefs.SetFloat("Lgz", 1f);
            PlayerPrefs.SetFloat("Delta0", 30f);
            PlayerPrefs.SetFloat("E0", 1.5f * Mathf.Pow(10, -2));

            PlayerPrefs.SetFloat("gamma", 0f);
            PlayerPrefs.SetInt("growth", 0);
            PlayerPrefs.SetInt("subapical", 0);
            updateValues();
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            PlayerPrefs.SetFloat("C0", .4f);
            PlayerPrefs.SetFloat("psi0", 75f);
            PlayerPrefs.SetFloat("psiC0", 0f);
            PlayerPrefs.SetFloat("psiG0", 270f);
            PlayerPrefs.SetFloat("L", 1f);
            PlayerPrefs.SetFloat("Lgz", 1f);
            PlayerPrefs.SetFloat("Delta0", 30f);
            PlayerPrefs.SetFloat("E0", 1.5f * Mathf.Pow(10, -2));

            PlayerPrefs.SetFloat("gamma", 2f);
            PlayerPrefs.SetInt("growth", 0);
            PlayerPrefs.SetInt("subapical", 0);
            updateValues();
        }
        if (Input.GetKey(KeyCode.Alpha4))
        {
            PlayerPrefs.SetFloat("C0", .4f);
            PlayerPrefs.SetFloat("psi0", 75f);
            PlayerPrefs.SetFloat("psiC0", 0f);
            PlayerPrefs.SetFloat("psiG0", 270f);
            PlayerPrefs.SetFloat("L", 1f);
            PlayerPrefs.SetFloat("Lgz", 1f);
            PlayerPrefs.SetFloat("Delta0", 30f);
            PlayerPrefs.SetFloat("E0", 1.5f * Mathf.Pow(10, -2));

            PlayerPrefs.SetFloat("gamma", 2f);
            PlayerPrefs.SetInt("growth", 1);
            PlayerPrefs.SetInt("subapical", 0);
            updateValues();
        }
        if (Input.GetKey(KeyCode.Alpha5))
        {
            PlayerPrefs.SetFloat("C0", .4f);
            PlayerPrefs.SetFloat("psi0", 75f);
            PlayerPrefs.SetFloat("psiC0", 0f);
            PlayerPrefs.SetFloat("psiG0", 270f);
            PlayerPrefs.SetFloat("L", 1f);
            PlayerPrefs.SetFloat("Lgz", 1f);
            PlayerPrefs.SetFloat("Delta0", 30f);
            PlayerPrefs.SetFloat("E0", 1.5f * Mathf.Pow(10, -2));

            PlayerPrefs.SetFloat("gamma", 2f);
            PlayerPrefs.SetInt("growth", 1);
            PlayerPrefs.SetInt("subapical", 1);
            updateValues();
        }
    }

    public void cTextUpdate(float value)
    {
        C.text = value.ToString("#.0");
    }
    public void psiCTextUpdate(float value)
    {
        psiC.text = value.ToString("#");
    }
    public void psiGTextUpdate(float value)
    {
        psiG.text = value.ToString("#");
    }
    public void w0TextUpdate(float value)
    {
        
        w0.text = (value/(2*Mathf.PI)).ToString("#");
    }
    public void gammaTextUpdate(float value)
    {
        gamma.text = value.ToString("#.0");
    }
    public void LgzTextUpdate(float value)
    {
       Lgz.text = value.ToString("#");
    }
    public void E0TextUpdate(float value)
    {
        float value2 = 5 - value;
        E0.text =( Mathf.Pow(10,(Mathf.Ceil(value2)-value2))).ToString("#")+".10";
        E0ss.text = (-Mathf.Ceil(value2)).ToString("#");

    }

    public void updateValues()
    {
        cTextUpdate(PlayerPrefs.GetFloat("C0"));
        psiGTextUpdate(PlayerPrefs.GetFloat("psiG0"));
        psiCTextUpdate(PlayerPrefs.GetFloat("psiC0"));

        LgzTextUpdate(PlayerPrefs.GetFloat("Delta0"));
        E0TextUpdate(PlayerPrefs.GetFloat("E0"));

        w0TextUpdate(PlayerPrefs.GetFloat("psi0"));
        gammaTextUpdate(PlayerPrefs.GetFloat("gamma"));

        Cslider.value = (PlayerPrefs.GetFloat("C0"));
        psiGslider.value = (PlayerPrefs.GetFloat("psiG0"));
        psiCslider.value = (PlayerPrefs.GetFloat("psiC0"));

        Lgzslider.value = (PlayerPrefs.GetFloat("Delta0"));
        E0slider.value = 5 + Mathf.Log10(PlayerPrefs.GetFloat("E0"));

        w0slider.value = (PlayerPrefs.GetFloat("psi0"));
        gammaslider.value = (PlayerPrefs.GetFloat("gamma"));

        if (PlayerPrefs.GetInt("growth")== 1)
        {
            growth.isOn = true;
        }
        else
        {
            growth.isOn = false;
        }
        if (PlayerPrefs.GetInt("subapical") == 1)
        {
            subap.isOn = true;
        }
        else
        {
            subap.isOn = false;
        }
    }
}
