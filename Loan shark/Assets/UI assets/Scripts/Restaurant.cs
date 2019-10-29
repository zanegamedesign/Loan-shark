using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Restaurant : MonoBehaviour
{
    private GameObject player1;
    private PlayerStats player1Stats;
    public Text uiText;
    public float countDown;
    public float timer = 120.0f;
    private bool isEating = false;
    public float cost = 3.0f;
    public float distanceLimit = 3.0f;


    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.FindGameObjectWithTag("Player1");
        player1Stats = player1.GetComponent<PlayerStats>();
        countDown = timer;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(gameObject.transform.position, player1.transform.position) <= distanceLimit)
        {
            if (player1Stats.hunger < 100)
            {
                //uiText.text = "[E] Eat $" + cost.ToString();
                //uiText.SetAllDirty();
                if (Input.GetKey(KeyCode.E))
                {
                    player1Stats.isWorking = true;
                    isEating = true;
                }
            }

            if (isEating)
            {
                countDown -= Time.deltaTime;
                if (countDown <= 0)
                {
                    player1Stats.hunger = player1Stats.hungerMax;
                    countDown = timer;
                    player1Stats.isWorking = false;
                    isEating = false;
                    player1Stats.money = player1Stats.money - cost;
                }
            }
        }

        /*if (Vector3.Distance(gameObject.transform.position, player1.transform.position) > distanceLimit)
        {
            uiText.text = "";
            uiText.SetAllDirty();
        }*/
    }
}

