using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverallTimer : MonoBehaviour
{
    public float countDown;
    public float fullDay = 240.0f;
    private float day;
    public bool isDay = true;
    private GameObject player1;
    private GameObject player2;
    private PlayerStats p1Stats;
    private AI p2Stats;
    public float htScale = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.FindGameObjectWithTag("Player1");
        p1Stats = player1.GetComponent<PlayerStats>();
        player2 = GameObject.FindGameObjectWithTag("Player2");
        p2Stats = player2.GetComponent<AI>();
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

        p1Stats.hunger = p1Stats.hunger - htScale;
        p1Stats.tired = p1Stats.tired - htScale;
        p2Stats.hunger = p2Stats.hunger - htScale;
        p2Stats.tired = p2Stats.tired - htScale;
    }
}
