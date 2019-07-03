using UnityEngine;

public class appearOnTick : MonoBehaviour
{

    [SerializeField] int appearanceIndex;
    int tickCounter;
    Transform bug;

    // Start is called before the first frame update
    void Start()
    {
        tickCounter = -1;
        appearCondition();
    }

    void incrementCounter()
    {
        tickCounter += 1;
    }

    
    private void OnEnable()
    {
        gameManager.doTick += appearCondition;
    }

    private void OnDisable()
    {
        gameManager.doTick -= appearCondition;
    }

    // Called each tick, appears on the assigned tick
    void appearCondition()
    {
        incrementCounter();
        if (tickCounter != appearanceIndex) { disappear(); }
        else 
        {
            tickCounter = -1;
            appear();
        }
    }

    public void appear()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }

    public void disappear()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }
}
