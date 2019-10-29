using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverallTimer : MonoBehaviour
{
    public float countDown;
    public float fullDay = 240.0f;
    private float day;
    public bool isDay = true;

    // Start is called before the first frame update
    void Start()
    {
        day = fullDay / 2;
        countDown = fullDay;
    }

    // Update is called once per frame
    void Update()
    {
        countDown -= Time.deltaTime;

        if (countDown <= day)
        {
            isDay = false;
        }
    }
}
