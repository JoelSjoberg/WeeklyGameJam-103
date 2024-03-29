﻿using UnityEngine;
using UnityEngine.Events;

public class gameManager : MonoBehaviour
{
    //public UnityEvent tick;
    public delegate void tick();
    public static event tick doTick;


    float counter;
    private void Start()
    {
        counter = 0;
    }

    void LateUpdate()
    {
        if (gameMaster.phase == Phase.tick)
        {
            counter += Time.deltaTime;
            if (counter >= gameMaster.tickSpeed)
            {
                doTick();
                gameMaster.error += 1;
                counter = 0;
            }
        }
    }
}
