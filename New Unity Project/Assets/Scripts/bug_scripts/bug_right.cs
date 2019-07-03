using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bug_right : MonoBehaviour, mutationEffect
{
    public void mutatedMethod()
    {
        movePlayer player = FindObjectOfType<movePlayer>();
        player.mutate(player.moveRight);
    }
}
