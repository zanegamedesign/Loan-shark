using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public float money;
    public float hungerMax = 100.0f;
    public float hunger;
    public float tiredMax = 100.0f;
    public float tired;
    public float speed = 1.0f;
    public float charisma = 1.0f;
    public float cost = 3.0f;
    private float aCountDown;
    private float bCountDown;
    private float wCountDown;
    public float timerMax = 120.0f;
    public float wTimerMax = 90.0f;
    private GameObject apartment;
    private GameObject bar;
    private GameObject blackMarket;
    private GameObject gym;
    private GameObject restaurant;
    private GameObject work;
    private ShopWork shopWork;
    private bool isWorking = false;

    // Start is called before the first frame update
    void Start()
    {
        hunger = hungerMax;
        tired = tiredMax;
        apartment = GameObject.FindGameObjectWithTag("Apartment");
        bar = GameObject.FindGameObjectWithTag("Bar");
        blackMarket = GameObject.FindGameObjectWithTag("BlackMarket");
        gym = GameObject.FindGameObjectWithTag("Gym");
        restaurant = GameObject.FindGameObjectWithTag("FeckDonalds");

        aCountDown = timerMax;
        bCountDown = timerMax;
        wCountDown = wTimerMax;
    }

    // Update is called once per frame
    void Update()
    {
        if (tired <= 25)
        {
            if (!isWorking)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(Random.Range((apartment.transform.position.x - 2), (apartment.transform.position.x + 2)), transform.position.y, Random.Range((apartment.transform.position.z - 2), (apartment.transform.position.z + 2))), (speed / 4));
                Vector3 relativePos = apartment.transform.position - transform.position;
                Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.forward);
                transform.rotation = rotation;
                isWorking = true;
                aCountDown -= Time.deltaTime;
                if (aCountDown <= 0)
                {
                    isWorking = false;
                    aCountDown = timerMax;
                    tired = tiredMax;
                }
            }
        }
        if (hunger <= 25)
        {
            if (!isWorking)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(Random.Range(restaurant.transform.position.x - 2, restaurant.transform.position.x + 2), transform.position.y, Random.Range(restaurant.transform.position.z - 2, restaurant.transform.position.z + 2)), (speed / 4));
                Vector3 relativePos = restaurant.transform.position - transform.position;
                Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.forward);
                transform.rotation = rotation;
                isWorking = true;
                bCountDown -= Time.deltaTime;
                if (bCountDown <= 0)
                {
                    isWorking = false;
                    bCountDown = timerMax;
                    hunger = hungerMax;
                    money = money - cost;
                }
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(ClosestWork().transform.position.x, transform.position.y, ClosestWork().transform.position.z), (speed / 4));
            shopWork = work.GetComponent<ShopWork>();
            Vector3 relativePos = work.transform.position - transform.position;
            Vector3 newDir = Vector3.RotateTowards(transform.forward, relativePos, 0, 0.0f);
            Quaternion rotation = Quaternion.LookRotation(newDir);
            transform.rotation = rotation;
            wCountDown -= Time.deltaTime;
            isWorking = true;
            if(wCountDown <= 0)
            {
                money = money + shopWork.wage;
                isWorking = false;
            }
        }
    }

    private GameObject ClosestWork()
    {
        GameObject[] jobs;
        jobs = GameObject.FindGameObjectsWithTag("Work");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in jobs)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
                work = go;
            }
        }
        return closest;
    }
}
