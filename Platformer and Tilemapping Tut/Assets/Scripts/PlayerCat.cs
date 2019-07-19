﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCat : MonoBehaviour
{
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator> ();
    }

    void Update()
    {
        //Idle -> running animation 
        if (Input.GetKeyDown (KeyCode.LeftArrow))
        {
            anim.SetInteger("State", 1);
        }

         if (Input.GetKeyUp (KeyCode.LeftArrow))
        {
            anim.SetInteger("State", 0);
        }

        if (Input.GetKeyDown (KeyCode.RightArrow))
        {
            anim.SetInteger("State", 1);
        }

        if (Input.GetKeyUp (KeyCode.RightArrow))
        {
            anim.SetInteger("State", 0);
        }

        //idle - jumping animation
        if (Input.GetKeyDown (KeyCode.UpArrow))
        {
            anim.SetInteger("State", 2);
        }

        if (Input.GetKeyUp (KeyCode.UpArrow))
        {
            anim.SetInteger("State", 0);
        }
    }
}
