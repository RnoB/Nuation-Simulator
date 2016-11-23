using UnityEngine;
using System.Collections;

public class headBehavior : MonoBehaviour
{
    public GameObject lastBone;
    float trailTime;
    float initTime;
    float timeDelay;
    // Use this for initialization
    void Awake()
    {
        trailTime = 50;
        timeDelay = .1f;
        transform.position = lastBone.transform.position;
        initTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = lastBone.transform.position;
        float T = Time.time - initTime;
        if (T < trailTime+timeDelay && T > timeDelay)
        {

            GetComponent<TrailRenderer>().enabled = true;
            GetComponent<TrailRenderer>().time = T - timeDelay;
        }
    }
}
