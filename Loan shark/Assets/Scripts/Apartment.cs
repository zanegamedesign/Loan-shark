using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Apartment : MonoBehaviour
{
    private GameObject player;
    private PlayerStats playerStats;
    public Text uiText;
    public float countDown;
    public float timer = 120.0f;
    private bool isSleeping = false;
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
            if (playerStats.tired < 100)
            {
                uiText.text = "[E] Sleep";
                uiText.SetAllDirty();
                if (Input.GetKey(KeyCode.E))
                {
                    playerStats.isWorking = true;
                    isSleeping = true;
                }
            }

            if (isSleeping)
            {
                countDown -= Time.deltaTime;
                if (countDown <= 0)
                {
                    playerStats.tired = playerStats.tiredMax;
                    countDown = timer;
                    playerStats.isWorking = false;
                    isSleeping = false;
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
