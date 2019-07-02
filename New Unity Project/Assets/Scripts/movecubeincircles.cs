using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movecubeincircles : MonoBehaviour
{

    [SerializeField] float radious = 5f;
    [SerializeField] float speed = 1.5f;
    [SerializeField] Vector3 center;


    void Start()
    {

    }

    float counter = 0;
    void FixedUpdate()
    {
        transform.position = new Vector3(center.x + (Mathf.Cos(counter) * radious), center.y + (Mathf.Sin(counter) * radious));

        // 2 pi is one lap around the circle
        counter += (Time.fixedDeltaTime * speed) % (2*Mathf.PI);
    }
}
