using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setCamAnchorOnStart : MonoBehaviour
{
    Transform anchor;

    void OnEnable()
    {
        anchor = GameObject.FindGameObjectWithTag("camAnchor").transform;
        anchor.position = transform.position;
    }
}
