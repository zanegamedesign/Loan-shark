using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackMarket : MonoBehaviour
{
    public Text uiText;
    private GameObject player1;
    private PlayerStats player1Stats;
    public int risk = 5;
    public float distanceLimit = 3.0f;
    public float wage = 10.0f;
    private float temp;
    private bool isInteractable = true;
    public float countDown;
    public float cooldown = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.FindGameObjectWithTag("Player1");
        player1Stats = player1.GetComponent<PlayerStats>();
        countDown = cooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(gameObject.transform.position, player1.transform.position) <= distanceLimit)
        {
            //uiText.text = "[E] Sell an organ?";
            //uiText.SetAllDirty();
            if (Input.GetKey(KeyCode.E) && player1Stats.organs == 5 && isInteractable)
            {
                risk = 5;
                --player1Stats.organs;
                player1Stats.money = player1Stats.money + wage;
                temp = Random.Range(0, 100);
                if (temp <= risk)
                {
                    player1Stats.isDead = true;
                }
                isInteractable = false;
            }

            if (Input.GetKey(KeyCode.E) && player1Stats.organs == 4 && isInteractable)
            {
                risk = 10;
                --player1Stats.organs;
                player1Stats.money = player1Stats.money + (wage * 1.5f);
                temp = Random.Range(0, 100);
                if (temp <= risk)
                {
                    player1Stats.isDead = true;
                }
                isInteractable = false;
            }

            if (Input.GetKey(KeyCode.E) && player1Stats.organs == 3 && isInteractable)
            {
                risk = 15;
                --player1Stats.organs;
                player1Stats.money = player1Stats.money + (wage * 2);
                temp = Random.Range(0, 100);
                if (temp <= risk)
                {
                    player1Stats.isDead = true;
                }
                isInteractable = false;
            }

            if (Input.GetKey(KeyCode.E) && player1Stats.organs == 2 && isInteractable)
            {
                risk = 20;
                --player1Stats.organs;
                player1Stats.money = player1Stats.money + (wage * 2.5f);
                temp = Random.Range(0, 100);
                if (temp <= risk)
                {
                    player1Stats.isDead = true;
                }
                isInteractable = false;
            }

            if (Input.GetKey(KeyCode.E) && player1Stats.organs == 1 && isInteractable)
            {
                risk = 25;
                --player1Stats.organs;
                player1Stats.money = player1Stats.money + (wage * 3);
                temp = Random.Range(0, 100);
                if (temp <= risk)
                {
                    player1Stats.isDead = true;
                }
                isInteractable = false;
            }

            if (Input.GetKey(KeyCode.E) && player1Stats.organs == 0 && isInteractable)
            {
                player1Stats.isDead = true;
                isInteractable = false;
            }

            if (!isInteractable)
            {
                countDown -= Time.deltaTime;
                if(countDown <= 0)
                {
                    isInteractable = true;
                    countDown = cooldown;
                }
            }
        }
    }
}

