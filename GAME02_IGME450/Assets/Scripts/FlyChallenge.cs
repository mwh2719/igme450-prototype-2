﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyChallenge : MonoBehaviour
{
    FlyState state = FlyState.Entering;

    public float enteringSpeed = 200f;
    public float leavingSpeed = 400f;

    private int startPosition = 100;
    private int direction = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        int startX = startPosition * -1;
        this.gameObject.transform.position = new Vector3(startX, Screen.height / 2, 0);
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case FlyState.Entering:
                Move(true, enteringSpeed);

                if (Mathf.Abs(transform.position.x - (Screen.width / 2)) < 25)
                {
                    state = FlyState.Sitting;
                }
                break;
            case FlyState.Leaving:
                Move(false, leavingSpeed);

                break;
        }
    }

    private void Move(bool towardsFlower, float speed)
    {
        int change = towardsFlower ? direction : direction * -1;

        Vector3 vector = new Vector3(Screen.width / 2, Screen.height / 2, 1) - this.transform.position * change;
        vector.Normalize();
        vector *= Time.deltaTime * speed;
        this.transform.position += vector;
    }


    public void Click()
    {
        state = FlyState.Leaving;
    }

    private void OnMouseDown()
    {
        state = FlyState.Leaving;
    }
}

public enum FlyState
{
    Entering,
    Sitting,
    Leaving
}