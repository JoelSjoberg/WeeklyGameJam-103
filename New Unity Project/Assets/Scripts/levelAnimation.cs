using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelAnimation : MonoBehaviour
{

    Animator anim;

    void OnEnable()
    {
        anim = GetComponent<Animator>();
        gameMaster.finishLevel += playEndAnimation;
    }
    private void OnDisable()
    {
        gameMaster.finishLevel -= playEndAnimation;
    }

    public void playEndAnimation()
    {
        anim.SetTrigger("exit");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
