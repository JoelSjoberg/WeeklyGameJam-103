using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goal : MonoBehaviour
{
    [SerializeField] private string level;
    GameObject sceneLevel;
    Transform goalPos;


    private void OnTriggerEnter(Collider other)
    {
        // If player touches the goal during the tick-phase or wait-phase
        if (other.tag == "Player" && (gameMaster.phase == Phase.tick || gameMaster.phase == Phase.wait))
        {
            // Play finish animation
            print("Player reached goal");
            

            // Load next level on top of this one.

            SceneManager.LoadScene(level, LoadSceneMode.Additive);

            sceneLevel = GameObject.FindGameObjectWithTag("level");
            DestroyLevel();
            gameMaster.GoalReached();

        }
    }

    void DestroyLevel()
    {
        Destroy(sceneLevel.gameObject, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (goalPos != null) transform.position = Vector3.Lerp(transform.position, goalPos.position, 0.1f);
        else goalPos = GameObject.FindGameObjectWithTag("goal").transform;

    }
}
