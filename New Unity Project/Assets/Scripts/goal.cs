using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goal : MonoBehaviour
{
    [SerializeField] private string level;
    GameObject sceneLevel;
    Transform goalPos;
    int lvlCounter;

    private void OnTriggerEnter(Collider other)
    {
        // If player touches the goal during the tick-phase or wait-phase
        if (other.tag == "Player" && (gameMaster.phase == Phase.tick || gameMaster.phase == Phase.wait))
        {
            // Play finish animation

            other.GetComponent<movePlayer>().findStartPos(transform.position);
            other.GetComponent<movePlayer>().resetLoopPoints(); // last minute bug fix (hopefully)
            // Load next level on top of this one.

            SceneManager.LoadScene("level" + lvlCounter, LoadSceneMode.Additive);
            lvlCounter += 1;
            gameMaster.error -= 10;
            sceneLevel = GameObject.FindGameObjectWithTag("level");
            DestroyLevel();
            StartCoroutine("waitForGoalPos");
            gameMaster.GoalReached();

        }
    }

    void DestroyLevel()
    {
        Destroy(sceneLevel.gameObject, 1f);
    }

    private void Start()
    {
        // The levels start at 2 because bad naming convention...
        lvlCounter = 2;
        goalPos = GameObject.FindGameObjectWithTag("goal").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // if (goalPos != null) transform.position = Vector3.Lerp(transform.position, goalPos.position, 0.1f);
        // else goalPos = GameObject.FindGameObjectWithTag("goal").transform;
    }

    IEnumerator waitForGoalPos()
    {
        Destroy(goalPos.gameObject);
        yield return new WaitForSeconds(1.5f);
        goalPos = GameObject.FindGameObjectWithTag("goal").transform;
        transform.position = goalPos.position;

    }
}
