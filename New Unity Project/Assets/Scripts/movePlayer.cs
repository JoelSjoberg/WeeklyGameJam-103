using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Should really be called user controlls!
public class movePlayer : MonoBehaviour, movement
{
   
    [Header("Layers the player can collide with")]
    [SerializeField] LayerMask layer;
    bool wallInTheWay(Vector3 dir)
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, dir);
        
        if (Physics.Raycast(transform.position, dir, out hit, 0.9f, layer))
        {
            print("Wall!");
            return true;
        }
        return false;
    }

    public void resetLoopPoints()
    {
        loopPoint = 0;
        iterationPoint = 0;
    }

    // Interface methods
    public void moveDown()
    {
        //transform.position -= Vector3.up;
       
        if (!wallInTheWay(-Vector3.up)) transform.position -= Vector3.up;// StartCoroutine(lerpToPos(-Vector3.up));
    }
    

    public void moveLeft()
    {
        //transform.position -= Vector3.right;
        if (!wallInTheWay(-Vector3.right)) transform.position -= Vector3.right;//StartCoroutine(lerpToPos(-Vector3.right));
    }

    public void moveRight()
    {
        //transform.position += Vector3.right;
        if (!wallInTheWay(Vector3.right)) transform.position += Vector3.right; // StartCoroutine(lerpToPos(Vector3.right));
    }

    public void moveUp()
    {
        //transform.position += Vector3.up;
        if (!wallInTheWay(Vector3.up)) transform.position += Vector3.up; // StartCoroutine(lerpToPos(Vector3.up));
    }

    public void skipMove()
    {
        return;
    }

    // Extra commands
    public void halt()
    {
        gameMaster.startWait();
        clearBuffer();
        StartCoroutine(startInputAfterDelay());

        // Need to reset the loops to avoid confusion!
        loopPoint = 0;
        iterationPoint = 0;

    }

    public void setIterationPoint()
    {
        print("iterationPoint = " + writer);
        iterationPoint = writer;
    }

    public void setLoopPoint()
    {
        print("LoopPoint = " + writer);
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

    IEnumerator startInputAfterDelay()
    {
        loopPoint = 0;
        iterationPoint = 0;
        yield return new WaitForSeconds(1.5f);
        // The start position of the last level will be deleted after reaching the goal, find it again
        gameMaster.startInputPhase();
    }

    void activateBuffer()
    {
        buffer[reader]();
        reader += 1;


        // The points represent an intervall, the loop will occur between them
        if (iterationPoint > loopPoint)
        {
            if (reader == iterationPoint) reader = loopPoint;
        }
        if (loopPoint > iterationPoint)
        {
            if (reader == loopPoint) reader = iterationPoint;
        }
        
        
        // halt excecution if the reader reaches the end of commands
        if (reader >= writer) halt();
    }

    void addToBuffer(System.Action method)
    {
        buffer[writer] = method;
        writer += 1;
    }

    public void mutate(System.Action method)
    {
        // avoid timing conflicts
        if (gameMaster.phase == Phase.tick)
        {
            //if(reader < gameMaster.memory - 1) buffer[reader + 1] = method;
            //else buffer[0] = method;
            buffer[reader] = method;
        }
    }

    public void findStartPos(Vector3 pos)
    {
        startPosition = pos;
    }

    void clearBuffer()
    {
        buffer = new System.Action[gameMaster.memory];
        reader = 0;
        writer = 0;
    }

    // method variables
    int reader, writer, loopPoint, iterationPoint;
    Vector3 startPosition;

    System.Action[] buffer;


    void Start()
    {

        findStartPos(transform.position);
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
        gameMaster.finishLevel += clearBuffer;
    }

    // REMOVE FROM EVENT TO AVOID ERRORS!
    private void OnDisable()
    {
        gameManager.doTick -= activateBuffer;
        gameMaster.finishLevel -= clearBuffer;
    }

    void Update()
    {

        if (gameMaster.phase == Phase.tick)
        {
            // Halt excecution if infinite loop has been created
            if (Input.GetKeyDown(KeyCode.H)) halt();
            if (Input.GetKeyDown(KeyCode.L) && reader < gameMaster.memory - 1) iterationPoint = reader + 1;
            if (Input.GetKeyDown(KeyCode.I) && reader < gameMaster.memory - 1) loopPoint = reader + 1;
        }

        if (gameMaster.phase == Phase.input)
        {
            // Lock player to start position REDUNDANT
            transform.position = startPosition;

            if (Input.GetKeyDown(KeyCode.L)) setIterationPoint();
            if (Input.GetKeyDown(KeyCode.I)) setLoopPoint();

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
            }
        }
    }

    public System.Action[] getBuffer()
    {
        return buffer;
    }

    public int getLoopPoint()
    {
        return loopPoint;
    }

    public int getIterPoint()
    {
        return iterationPoint;
    }

    public int getReader()
    {
        return reader;
    }

    public int getWriter()
    {
        return writer;
    }
}