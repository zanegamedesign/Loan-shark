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
    private GameObject player3;
    private GameObject player4;
    private GameObject player5;
    private GameObject player6;
    private GameObject player7;
    private GameObject player8;
    private PlayerStats p1Stats;
    private AI p2Stats;
    private AI p3Stats;
    private AI p4Stats;
    private AI p5Stats;
    private AI p6Stats;
    private AI p7Stats;
    private AI p8Stats;
    public float htScale = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.FindGameObjectWithTag("Player1");
        p1Stats = player1.GetComponent<PlayerStats>();
        player2 = GameObject.FindGameObjectWithTag("Player2");
        p2Stats = player2.GetComponent<AI>();
        player3 = GameObject.FindGameObjectWithTag("Player3");
        p3Stats = player3.GetComponent<AI>();
        player4 = GameObject.FindGameObjectWithTag("Player4");
        p4Stats = player4.GetComponent<AI>();
        player5 = GameObject.FindGameObjectWithTag("Player5");
        p5Stats = player5.GetComponent<AI>();
        player6 = GameObject.FindGameObjectWithTag("Player6");
        p6Stats = player6.GetComponent<AI>();
        player7 = GameObject.FindGameObjectWithTag("Player7");
        p7Stats = player7.GetComponent<AI>();
        player8 = GameObject.FindGameObjectWithTag("Player8");
        p8Stats = player8.GetComponent<AI>();
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
        p3Stats.hunger = p3Stats.hunger - htScale;
        p3Stats.tired = p3Stats.tired - htScale;
        p4Stats.hunger = p4Stats.hunger - htScale;
        p4Stats.tired = p4Stats.tired - htScale;
        p5Stats.hunger = p5Stats.hunger - htScale;
        p5Stats.tired = p5Stats.tired - htScale;
        p6Stats.hunger = p6Stats.hunger - htScale;
        p6Stats.tired = p6Stats.tired - htScale;
        p7Stats.hunger = p7Stats.hunger - htScale;
        p7Stats.tired = p7Stats.tired - htScale;
        p8Stats.hunger = p8Stats.hunger - htScale;
        p8Stats.tired = p8Stats.tired - htScale;
    }
}
