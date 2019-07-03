using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bug_left : MonoBehaviour, mutationEffect
{
    // Not the best choise, but it allows me to keep the structure simple!
    public void mutatedMethod()
    {
        movePlayer player = FindObjectOfType<movePlayer>();
        player.mutate(player.moveLeft);
    }
}
