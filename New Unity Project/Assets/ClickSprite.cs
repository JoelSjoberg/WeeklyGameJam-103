using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ClickSprite : MonoBehaviour
{

    RaycastHit hit;

    [SerializeField]GameObject speachBuble;

    Animator anim;
    [SerializeField]Animator avatarAnim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    
    Ray ray;
    void Update()
    {
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0))
        {
            
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform != null)
                {
                    if (hit.transform.tag == "goal")
                    {
                        StartCoroutine(loadScene());
                    }
                }
            }
        }

        Vector3 mouse;
        mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouse.z = 10;
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform != null)
            {
                if (hit.transform.tag == "goal")
                {
                    speachBuble.SetActive(true);
                }

            }
            else
            {
                speachBuble.SetActive(false);
            }
        }
    }
    IEnumerator loadScene()
    {
        anim.SetTrigger("exit");
        avatarAnim.SetTrigger("exit");
        yield return new WaitForSeconds(1.2f);

        SceneManager.LoadScene("SampleScene");
    }
}
