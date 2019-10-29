using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Restaurant : MonoBehaviour
{
    private GameObject player;
    private PlayerStats playerStats;
    public Text uiText;
    public float countDown;
    public float timer = 120.0f;
    private bool isEating = false;
    public float cost = 3.0f;
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
            if (playerStats.hunger < 100)
            {
                uiText.text = "[E] Eat $" + cost.ToString();
                uiText.SetAllDirty();
                if (Input.GetKey(KeyCode.E))
                {
                    playerStats.isWorking = true;
                    isEating = true;
                }
            }

            if (isEating)
            {
                countDown -= Time.deltaTime;
                if (countDown <= 0)
                {
                    playerStats.hunger = playerStats.hungerMax;
                    countDown = timer;
                    playerStats.isWorking = false;
                    isEating = false;
                    playerStats.money = playerStats.money - cost;
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

