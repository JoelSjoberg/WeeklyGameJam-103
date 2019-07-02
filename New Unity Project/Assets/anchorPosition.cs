using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anchorPosition : MonoBehaviour
{
    Transform Player;
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void OnEnable()
    {
        gameMaster.finishLevel += setAnchorPosition;
    }
    private void OnDisable()
    {
        gameMaster.finishLevel -= setAnchorPosition;
    }

    void setAnchorPosition()
    {
        transform.position = Player.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
