using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gym : MonoBehaviour
{
    private GameObject player;
    private PlayerStats playerStats;
    private BasicPlayerMovement BPM;
    public Text uiText;
    public float countDown;
    public float timer = 120.0f;
    private bool isExcersicing = false;
    public float distanceLimit = 3.0f;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerStats = player.GetComponent<PlayerStats>();
        BPM = player.GetComponent<BasicPlayerMovement>();
        countDown = timer;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(gameObject.transform.position, player.transform.position) <= distanceLimit)
        {
            if (playerStats.speed <= 3)
            {
                uiText.text = "[E] Work out";
                uiText.SetAllDirty();
                if (Input.GetKey(KeyCode.E))
                {
                    playerStats.isWorking = true;
                    isExcersicing = true;
                }
            }

            if (isExcersicing)
            {
                countDown -= Time.deltaTime;
                if (countDown <= 0)
                {
                    ++playerStats.speed;
                    BPM.zMove = BPM.zMoveBase * playerStats.speed;
                    countDown = timer;
                    playerStats.isWorking = false;
                    isExcersicing = false;
                }
            }
        }

        if (Vector3.Distance(gameObject.transform.position, player.transform.position) > distanceLimit)
        {
            uiText.text = "";
            uiText.SetAllDirty();
        }
    }
}

