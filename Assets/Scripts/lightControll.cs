using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;
using UnityEngine.UI;

public class lightControll : MonoBehaviour
{
    public float timer = 8.0f;
    private Light2D light;

    // Use this for initialization
    void Start()
    {

    }

    private void Update()
    {
        lightDis();
    }
    void lightDis()
    {
        timer -= Time.deltaTime;
        light = transform.GetComponent<Light2D>();
        if (timer <= 0)
        {
            //light = transform.GetComponent<Light2D>();
            light.intensity -= 0.001f;
            if (Input.GetKeyDown(KeyCode.L))
            {
                timer = 8.0f;
                light.intensity = 1f;
            }
        }
    }
}
