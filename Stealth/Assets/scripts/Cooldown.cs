﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cooldown : MonoBehaviour {

    Text text;

    public static float tiempodeCooldown = 0;
    public static float moveAgain = 0;
    public static bool activado;

    // Use this for initialization
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

        text.text = "cooldown:" + tiempodeCooldown;

        if (activado == true)
        {

            tiempodeCooldown -= Time.deltaTime;
            moveAgain -= Time.deltaTime;

            if (tiempodeCooldown <= 0)
            {
                activado = false;
                Player.congActivado = false;
                tiempodeCooldown = 0;

            }
            if (moveAgain <=0)
            {
                Guard.pararguardias = false;
                Guard2.pararguardias = false;
            }
        }



    }
}
