﻿using UnityEngine;
using System.Collections;

public class deathtrigger : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {



    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            livesmanager.lostlifes(1);

            Application.LoadLevel(Application.loadedLevel);

        }
    }

}