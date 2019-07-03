using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bug_up : MonoBehaviour, mutationEffect
{
    public void mutatedMethod()
    {
        movePlayer player = FindObjectOfType<movePlayer>();
        player.mutate(player.moveUp);
    }
}
