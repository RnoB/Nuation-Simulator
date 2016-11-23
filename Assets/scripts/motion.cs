using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
public class motion : MonoBehaviour {
    public List<Transform> Children;

    public List<double> C;
    public List<double> psiC;
    public List<double> psiG;
    public List<double> ds;
    public List<double> s;

    float C0;
     
    double ds0;
    double L;
    double Lgz;
    double psi0;
    float psiC0;
    float psiG0;
    float Delta;
    double E0;
    double gamma;
    bool growth;
    bool subapical;
    // Use this for initialization
    void Start ()
    {
        C0 = PlayerPrefs.GetFloat("C0");
        psiG0 = -Mathf.PI*PlayerPrefs.GetFloat("psiG0")/180;
        psiC0 =Mathf.PI* PlayerPrefs.GetFloat("psiC0")/180;
        L = (double)PlayerPrefs.GetFloat("L");
        Lgz = (double)PlayerPrefs.GetFloat("Lgz");
        Delta = PlayerPrefs.GetFloat("Delta0");
        E0 = (double)PlayerPrefs.GetFloat("E0");

        psi0 = E0*(double)PlayerPrefs.GetFloat("psi0");
        gamma =  (double) PlayerPrefs.GetFloat("gamma");
        growth = (PlayerPrefs.GetInt("growth") > 0) ? true : false;
        subapical = (PlayerPrefs.GetInt("subapical") > 0) ? true : false;
        ds0 = L/128f;


        foreach (Transform child in transform)
        {
            Children.Add(child);
       }
        int j = 0;
        while (Children[j].childCount>0)
        {
            foreach (Transform child in Children[j])
            {
                Children.Add(child);
                C.Add((double)C0);
                psiC.Add((double)psiC0);
                psiG.Add(-(double)psiG0);
                ds.Add((double)ds0);
                s.Add((double)(j*ds0));
                float A = 180f * (float)C.Last() * (float)ds.Last() / Mathf.PI;
                float psi = (float)psiC.Last();
                child.localRotation = Quaternion.Euler(A * Mathf.Sin(Mathf.PI * psi / 180), 0, A * Mathf.Cos(Mathf.PI * psi / 180));


            }
            j++;
        }
        

    }

    // Update is called once per frame
    void Update() {

        float j = 1;
        double sPrevious = 0;
        double dt = 1.0/60.0;
        
        for (int k=0;k<Children.Count-1;k++)
        {
            //Debug.Log(k);
            Transform child = Children[k];
            
            if ((growth && (!subapical || ((L - s[k]) < Lgz  && subapical ))) || !growth)

            {
                float A =  (float)C[k] * (float)ds[k];
                
                float psi = (float)psiC[k];
                child.localRotation = Quaternion.Euler(rad2deg(A * Mathf.Sin( psi)), 0, rad2deg(A * Mathf.Cos(psi)));


                j++;

                psiG[k] += psi0 * dt;
                psiG[k] = modulo2(psiG[k]);
                
                float Ad = angleDifference(psiG[k], psiC[k]);
                psiC[k] += E0*dt *(1/C[k])* Delta * (double)Mathf.Sin(Ad);
                psiC[k] = modulo2(psiC[k]);
                C[k] += E0*dt * Delta * ( Mathf.Cos(Ad) - gamma*C[k]);
                
                if (growth)
                {
                    ds[k] += ds[k]*dt * E0;
                    child.localPosition = (new Vector3(0f, (float)(.01* 128 * ds[k]), 0f));
                    //child.localScale = (new Vector3(1, 1+(float)(.01*(1-128 * ds[k])), 1));
                }

            }
            s[k] = sPrevious + ds[k];
            sPrevious = s[k];
            //child.localScale = (new Vector3(1,(float)(128* ds[k]), 1));
        }


        L = s.Last() ;


    }

    private float angleDifference(double A1, double A2)
    {
        float Ad;
        Ad = (float)A1 - (float)A2;
        Ad += (Ad > Mathf.PI) ? -2* Mathf.PI : (Ad < -Mathf.PI) ? 2* Mathf.PI : 0;
            return Ad;

    }

    private double modulo2(double A1)
    {
        double A2=A1;
        A2 += (A2 > Mathf.PI) ? -2* Mathf.PI : (A2 < -Mathf.PI) ? 2* Mathf.PI : 0;
        return A2;
    }

    private float rad2deg(double A)
    {

        float At;
        At = 180f * (float)A / Mathf.PI;
        return At;
    }
}
