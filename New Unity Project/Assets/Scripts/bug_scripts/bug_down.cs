using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bug_down : MonoBehaviour, mutationEffect
{
    public void mutatedMethod()
    {
        FindObjectOfType<movePlayer>().transform.position += Vector3.down;
    }
}
