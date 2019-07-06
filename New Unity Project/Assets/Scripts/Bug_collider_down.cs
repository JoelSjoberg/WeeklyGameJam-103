using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bug_collider_down : bug_down
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            mutatedMethod();
        }
    }
}
