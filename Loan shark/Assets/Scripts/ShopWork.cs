using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopWork : MonoBehaviour
{
    private OverallTimer timer;
    private GameObject player;
    private PlayerStats playerStats;
    public int tier;
    private bool isInteractable = true;
    public float distanceLimit = 1.0f;
    public Text uiText;
    public bool isNocturnal = false;
    private bool isActive = false;
    private float countDown;
    public float timerReset = 90.0f;
    public float wage;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        timer = GameObject.Find("Game Manager").GetComponent<OverallTimer>();
        playerStats = player.GetComponent<PlayerStats>();
        countDown = timerReset;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isNocturnal)
        {
            if (timer.isDay)
            {
                isInteractable = true;
            }
            if (!timer.isDay)
            {
                isInteractable = false;
            }
        }
        if (isNocturnal)
        {
            if (timer.isDay)
            {
                isInteractable = false;
            }
            if (!timer.isDay)
            {
                isInteractable = true;
            }
        }
        
        if (tier == 1)
        {
            if (isInteractable)
            {
                if (Vector3.Distance(gameObject.transform.position, player.transform.position) <= distanceLimit)
                {
                    uiText.text = "[E] to Interact";
                    uiText.SetAllDirty();
                    if (Input.GetKey(KeyCode.E))
                    {
                        playerStats.isWorking = true;
                        isActive = true;
                        isInteractable = false;
                    }
                }
                if (Vector3.Distance(gameObject.transform.position, player.transform.position) > distanceLimit)
                {
                    uiText.text = "";
                }
            }
        }

        if (tier == 2)
        {
            if(playerStats.charisma == 2)
            {
                if (isInteractable)
                {
                    if (Vector3.Distance(gameObject.transform.position, player.transform.position) <= distanceLimit)
                    {
                        uiText.text = "[E] to Interact";
                        uiText.SetAllDirty();
                        if (Input.GetKey(KeyCode.E))
                        {
                            playerStats.isWorking = true;
                            isActive = true;
                            isInteractable = false;
                        }
                    }
                    if (Vector3.Distance(gameObject.transform.position, player.transform.position) > distanceLimit)
                    {
                        uiText.text = "";
                    }
                }
            }
            else
            {
                if (Vector3.Distance(gameObject.transform.position, player.transform.position) <= distanceLimit)
                {
                    uiText.text = "Requires 2 Charisma";
                }
                if (Vector3.Distance(gameObject.transform.position, player.transform.position) > distanceLimit)
                {
                    uiText.text = "";
                }
            }
        }

        if (tier == 3)
        {
            if (isInteractable)
            {
                if (Vector3.Distance(gameObject.transform.position, player.transform.position) <= distanceLimit)
                {
                    uiText.text = "[E] to Interact";
                    uiText.SetAllDirty();
                    if (Input.GetKey(KeyCode.E))
                    {
                        playerStats.isWorking = true;
                        isActive = true;
                        isInteractable = false;
                    }
                }
                if (Vector3.Distance(gameObject.transform.position, player.transform.position) > distanceLimit)
                {
                    uiText.text = "";
                }
            }
            else
            {
                if (Vector3.Distance(gameObject.transform.position, player.transform.position) <= distanceLimit)
                {
                    uiText.text = "Requires 2 Charisma";
                }
                if (Vector3.Distance(gameObject.transform.position, player.transform.position) > distanceLimit)
                {
                    uiText.text = "";
                }
            }
        }

        if (isActive)
        {
            countDown -= Time.deltaTime;
            if(countDown <= 0)
            {
                isActive = false;
                isInteractable = true;
                playerStats.isWorking = false;
                playerStats.money = playerStats.money + wage;
            }
        }
    }
}
