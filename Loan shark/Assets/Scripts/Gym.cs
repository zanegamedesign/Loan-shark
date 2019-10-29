using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gym : MonoBehaviour
{
    private GameObject player1;
    private PlayerStats player1Stats;
    private BasicPlayerMovement BPM;
    public Text uiText;
    public float countDown;
    public float timer = 120.0f;
    private bool isExcersicing = false;
    public float distanceLimit = 3.0f;


    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.FindGameObjectWithTag("Player1");
        player1Stats = player1.GetComponent<PlayerStats>();
        BPM = player1.GetComponent<BasicPlayerMovement>();
        countDown = timer;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(gameObject.transform.position, player1.transform.position) <= distanceLimit)
        {
            if (player1Stats.speed <= 3)
            {
                uiText.text = "[E] Work out";
                uiText.SetAllDirty();
                if (Input.GetKey(KeyCode.E))
                {
                    player1Stats.isWorking = true;
                    isExcersicing = true;
                }
            }

            if (isExcersicing)
            {
                countDown -= Time.deltaTime;
                if (countDown <= 0)
                {
                    ++player1Stats.speed;
                    BPM.zMove = BPM.zMoveBase * player1Stats.speed;
                    countDown = timer;
                    player1Stats.isWorking = false;
                    isExcersicing = false;
                }
            }
        }

        if (Vector3.Distance(gameObject.transform.position, player1.transform.position) > distanceLimit)
        {
            uiText.text = "";
            uiText.SetAllDirty();
        }
    }
}

