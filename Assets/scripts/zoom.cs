using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

public class zoom : MonoBehaviour
{
    float xRectMin;
    float yRectMin;
    float xRectMax;
    float yRectMax;
    float speed;
    float mouseX;
    float mouseY;
    float speedTouch = 1;
    bool trueCamera;
    Camera cam;
    // Use this for initialization
    void Start()
    {
        speed = 500;
        speedTouch = 1;
        xRectMin = GetComponent<Camera>().rect.x * Screen.width;
        yRectMin = GetComponent<Camera>().rect.y * Screen.height;
        xRectMax = GetComponent<Camera>().rect.xMax * Screen.width;
        yRectMax = GetComponent<Camera>().rect.yMax * Screen.height;
        trueCamera = false;
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_ANDROID
        if (Input.touchCount > 0)
        {
            Touch touch0 = Input.GetTouch(0);
            if (touch0.position.x > xRectMin && touch0.position.y > yRectMin &&
            touch0.position.x < xRectMax && touch0.position.y < yRectMax)
            {
                if (Input.touchCount ==1)
                {

                    transform.Translate(new Vector3(-touch0.deltaPosition.x, -touch0.deltaPosition.y, 0));

                }
                else if (Input.touchCount == 2)
                {
                    Touch touch1 = Input.GetTouch(1);
                    Vector2 touch0PrevPos = touch0.position - touch0.deltaPosition;
                    Vector2 touch1PrevPos = touch1.position - touch1.deltaPosition;

                    // Find the magnitude of the vector (the distance) between the touches in each frame.
                    float prevTouchDeltaMag = (touch0PrevPos - touch1PrevPos).magnitude;
                    float touchDeltaMag = (touch0.position - touch1.position).magnitude;

                    float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;
                     if (cam.orthographic)
                    {
                        // ... change the orthographic size based on the change in distance between the touches.
                        cam.orthographicSize += deltaMagnitudeDiff*speedTouch;

                        // Make sure the orthographic size never drops below zero.
                        cam.orthographicSize = Mathf.Max(cam.orthographicSize, 0.1f);
                    }
                    else
                    {
                   transform.Translate(new Vector3(0, 0, -deltaMagnitudeDiff*speedTouch ));
                    }
                        

                }


            }

        }

#else
        if (Input.mousePosition.x > xRectMin && Input.mousePosition.y > yRectMin &&
            Input.mousePosition.x < xRectMax && Input.mousePosition.y < yRectMax)
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                if (cam.orthographic)
                {
                    // ... change the orthographic size based on the change in distance between the touches.
                    cam.orthographicSize -= speed * Time.deltaTime;

                    // Make sure the orthographic size never drops below zero.
                    cam.orthographicSize = Mathf.Max(cam.orthographicSize, 0.1f);
                }
                else
                {
                    transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
                }
            }

            if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                if (cam.orthographic)
                {
                    // ... change the orthographic size based on the change in distance between the touches.
                    cam.orthographicSize += speed * Time.deltaTime;

                    // Make sure the orthographic size never drops below zero.
                    cam.orthographicSize = Mathf.Max(cam.orthographicSize, 0.1f);
                }
                else
                {
                    transform.Translate(new Vector3(0, 0, -speed * Time.deltaTime));
                }
            }
            if (Input.GetMouseButtonDown(0))
            {
                mouseX = Input.mousePosition.x;
                mouseY = Input.mousePosition.y;
                trueCamera = true;
            }

        }
        if (Input.GetMouseButton(0) && trueCamera)
        {

            float mouseX2 = Input.mousePosition.x;
            float mouseY2 = Input.mousePosition.y;

                transform.Translate(new Vector3(-(mouseX2 - mouseX), -(mouseY2 - mouseY), 0));
            
            mouseX = mouseX2;
            mouseY = mouseY2;
        }
        if (Input.GetMouseButtonUp(0))
        {

            trueCamera = false;
        }
#endif


    }
}
