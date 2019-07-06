using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// inherits bug_left, which extends MonoBehaviour
public class bug_collider : bug_left
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //other.GetComponent<movePlayer>().mutate(mutatedMethod);
            mutatedMethod();
        }
    }
}
