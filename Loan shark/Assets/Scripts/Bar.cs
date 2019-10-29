using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    private GameObject player;
    private PlayerStats playerStats;
    public Text uiText;
    public float countDown;
    public float timer = 120.0f;
    private bool isFlirting = false;
    public float distanceLimit = 3.0f;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerStats = player.GetComponent<PlayerStats>();
        countDown = timer;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(gameObject.transform.position, player.transform.position) <= distanceLimit)
        {
            if (playerStats.charisma <= 3)
            {
                uiText.text = "[E] ";
                uiText.SetAllDirty();
                if (Input.GetKey(KeyCode.E))
                {
                    playerStats.isWorking = true;
                    isFlirting = true;
                }
            }

            if (isFlirting)
            {
                countDown -= Time.deltaTime;
                if (countDown <= 0)
                {
                    ++playerStats.charisma;
                    countDown = timer;
                    playerStats.isWorking = false;
                    isFlirting = false;
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

