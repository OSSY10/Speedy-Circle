using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCycle : MonoBehaviour
{
    private Camera cam;
    private float cycleSeconds = 40f; // set to say 0.5f to test

    void Awake()
    {

        cam = GetComponent<Camera>();
    }

    void Update()
    {

        cam.backgroundColor = Color.HSVToRGB(
            Mathf.Repeat(Time.time / cycleSeconds, 1f), 0.4f, 0.7f);
    }
}
