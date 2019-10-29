using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float money = 0.0f;
    public float hungerMax = 100.0f;
    public float hunger;
    public float tiredMax = 100.0f;
    public float tired;
    public float charisma = 1.0f;
    public float speed = 1.0f;
    public float organs = 5.0f;
    public bool isWorking = false;
    public bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        tired = tiredMax;
        hunger = hungerMax;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
