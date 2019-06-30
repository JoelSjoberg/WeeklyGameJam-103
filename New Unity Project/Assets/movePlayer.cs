using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Should really be called user controlls!
public class movePlayer : MonoBehaviour, movement
{

    // Interface methods
    public void moveDown()
    {
        transform.position -= Vector3.up;
    }
    

    public void moveLeft()
    {
        transform.position -= Vector3.right;
    }

    public void moveRight()
    {
        transform.position += Vector3.right;
    }

    public void moveUp()
    {
        transform.position += Vector3.up;
    }


    // Extra commands
    public void skipMove()
    {
        return;
    }

    public void halt()
    {
        gameMaster.startWait();
    }

    public void setIterationPoint()
    {
        iterationPoint = writer;
    }

    public void setLoopPoint()
    {
        loopPoint = writer;
    }

    public void undo()
    {
        if (writer > 0)
        {
            buffer[writer - 1] = null;
            writer -= 1;
        }
    }

    public void initiate()
    {
        gameMaster.startTicks();
    }

    // method variables
    int reader, writer, loopPoint, iterationPoint;

    System.Action[] buffer;

    // Start is called before the first frame update
    void Start()
    {
        // The reader holds the index for which method should be excecuted
        reader = 0;
        // Writer holds the index of the current input position, can be max == length of buffer
        writer = 0;

        // Index of the buffer where reader will return if loop is called
        loopPoint = 0;

        // The point in memory where the loop will iterate
        iterationPoint = 0;

        // Array for storing methods
        buffer = new System.Action[gameMaster.memory];
    }


    // IN HANDLING EVENTS, ALWAYS PERFORM THE FOLLOWING
    // ADD TO EVENT
    private void OnEnable()
    {
        gameManager.doTick += activateBuffer;
    }

    // REMOVE FROM EVENT TO AVOID ERRORS!
    private void OnDisable()
    {
        gameManager.doTick -= activateBuffer;
    }

    void activateBuffer()
    {
        buffer[reader]();
        reader += 1;

        // If reader is on a iteration point, we jump to loop point to 
        if (reader == iterationPoint) reader = loopPoint;
        // halt excecution if the reader reaches the end of commands
        if (reader >= writer) halt();
    }

    void addToBuffer(System.Action met)
    {
        buffer[writer] = met;
        writer += 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameMaster.phase == Phase.input)
        {
            // Start the excecution
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                initiate();
            }

            // undo last command, should not increase writer index, so just call it immediately
            if (Input.GetKeyDown(KeyCode.Backspace)) undo();

            // Unit controlls
            if (writer < gameMaster.memory)
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) addToBuffer(moveLeft);
                if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) addToBuffer(moveRight);
                if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) addToBuffer(moveUp);
                if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) addToBuffer(moveDown);

                if (Input.GetKeyDown(KeyCode.Space)) addToBuffer(skipMove);
                if (Input.GetKeyDown(KeyCode.H)) addToBuffer(halt);
                if (Input.GetKeyDown(KeyCode.L)) setIterationPoint();
                if (Input.GetKeyDown(KeyCode.I)) setLoopPoint();
            }
        }
    }
}