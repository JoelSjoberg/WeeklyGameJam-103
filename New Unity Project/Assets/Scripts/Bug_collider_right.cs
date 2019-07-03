using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bug_collider_right : bug_right
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<movePlayer>().mutate(mutatedMethod);
        }
    }
}
