using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floorMethod : MonoBehaviour
{

    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        gameMaster.finishLevel += playAnimation;
    }
    private void OnDisable()
    {
        gameMaster.finishLevel -= playAnimation;
    }

    public void playAnimation()
    {
        StartCoroutine(waitAnim());
        

        gameMaster.finishLevel -= playAnimation;
        Destroy(transform.parent.gameObject, 3f);
    }

    IEnumerator waitAnim()
    {
        yield return new WaitForSeconds(Random.Range(0, 1));
        anim.SetTrigger("activate");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
