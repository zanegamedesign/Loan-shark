using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour

{
    GameObject player;
    public Animator Anim;

    // Start is called before the first frame update
    void Start()
    {
        player = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            //print("here");
        }

        if (Input.GetKey(KeyCode.W))
        {
            Anim.SetBool("Is walking", true);
        }
        else
        {
            Anim.SetBool("Is walking", false);
        }

    }
}
