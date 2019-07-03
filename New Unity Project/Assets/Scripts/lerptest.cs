using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lerptest : MonoBehaviour
{

    [SerializeField] bool cursor;

    [SerializeField] float lerpStrength;
    public Transform goal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!cursor) transform.position = Vector3.Lerp(transform.position, goal.position, lerpStrength);

        else
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 10;
            transform.position = Vector3.Lerp(transform.position, Camera.main.ScreenToWorldPoint(mousePos), lerpStrength);
        }

    }
}
