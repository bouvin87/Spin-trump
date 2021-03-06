﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spinScript : MonoBehaviour
{
    public Rigidbody2D player;
    public float torque = 1f;

    //initiera lite variabler
    public int spins = 0; //Totala antalet snurr
    public float currentSpeed = 0; //Akutell hastighet

    public float highestSpeed = 0;

    float deltaRotation = 0;
    float currentRotation = 0;
    float WindupRotation = 0;

    void Start()
    {
        highestSpeed = PlayerPrefs.GetFloat("highestSpeed", highestSpeed);
    }
    public void onClick()
    {
        player.AddTorque(torque, ForceMode2D.Impulse);
    }
    void Update()
    {
        //Räkna ut hur många snurr som gjorts
        deltaRotation = (currentRotation - transform.eulerAngles.z);
        currentRotation = transform.eulerAngles.z;
        if (deltaRotation >= 300)
            deltaRotation -= 360;
        if (deltaRotation <= -300)
            deltaRotation += 360;
        WindupRotation -= (deltaRotation);

        spins = (int)(WindupRotation / 360);

        //Sätt aktuell hastighet på spelaren
        currentSpeed = (player.angularVelocity * ((2 * Mathf.PI) / 60));

        if (currentSpeed > highestSpeed)
        {
            highestSpeed = currentSpeed;
            PlayerPrefs.SetFloat("highestSpeed", highestSpeed);
        }
    }
}
