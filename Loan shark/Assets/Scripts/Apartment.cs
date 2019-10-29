using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Apartment : MonoBehaviour
{
    private GameObject player1;
    private PlayerStats player1Stats;
    public Text uiText;
    public float countDown;
    public float timer = 120.0f;
    private bool isSleeping = false;
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
            if (player1Stats.tired < 100)
            {
                uiText.text = "[E] Sleep";
                uiText.SetAllDirty();
                if (Input.GetKey(KeyCode.E))
                {
                    player1Stats.isWorking = true;
                    isSleeping = true;
                }
            }

            if (isSleeping)
            {
                countDown -= Time.deltaTime;
                if (countDown <= 0)
                {
                    player1Stats.tired = player1Stats.tiredMax;
                    countDown = timer;
                    player1Stats.isWorking = false;
                    isSleeping = false;
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
