using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteCanvas : MonoBehaviour
{
    Canvas c;
    private void Start()
    {
        c = FindObjectOfType<Canvas>();

        Destroy(c.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
