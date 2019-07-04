using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quitScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(quit());
    }

    IEnumerator quit()
    {
        yield return new WaitForSeconds(10f);
        Application.Quit();
    }

}
