using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteCanvas : MonoBehaviour
{
    Canvas c;
    private void Start()
    {
        c = FindObjectOfType<Canvas>();
        c.gameObject.SetActive(false);
    }

}
