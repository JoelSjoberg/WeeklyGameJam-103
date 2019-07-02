using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bug_right : MonoBehaviour, mutationEffect
{
    public void mutatedMethod()
    {
        FindObjectOfType<movePlayer>().transform.position += Vector3.right;
    }
}
