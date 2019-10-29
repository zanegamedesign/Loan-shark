using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPlayerMovement : MonoBehaviour
{
    public float zMoveBase = 0.5f;
    private float zMove;
    public float yRotate = 5f;
    private GameObject player;
    private PlayerStats playerStats;

    // Start is called before the first frame update
    void Start()
    {
        playerStats = gameObject.GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        zMove = zMoveBase;
        if (!playerStats.isWorking)
        {
            if (Input.GetKey(KeyCode.W))
            {
                gameObject.transform.Translate(new Vector3(0, 0, zMove));
            }
            if (Input.GetKey(KeyCode.S))
            {
                gameObject.transform.Translate(new Vector3(0, 0, -zMove));
            }
            if (Input.GetKey(KeyCode.A))
            {
                gameObject.transform.Rotate(new Vector3(0, -yRotate, 0));
            }
            if (Input.GetKey(KeyCode.D))
            {
                gameObject.transform.Rotate(new Vector3(0, yRotate, 0));
            }
        }
        
    }
}
