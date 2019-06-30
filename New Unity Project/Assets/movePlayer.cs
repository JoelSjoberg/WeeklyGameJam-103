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

    public void loop()
    {
        reader = 0;
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
    int reader, writer, commands;

    System.Action[] buffer;

    // Start is called before the first frame update
    void Start()
    {
        // The reader holds the index for which method should be excecuted
        reader = 0;
        // Writer holds the index of the current input position, can be max == length of buffer
        writer = 0;
        // The amount of commands inside the buffer
        commands = 0;

        // Array for storing methods
        buffer = new System.Action[gameMaster.memory];

        // Delete these
        // buffer[0] = moveUp;
        // buffer[1] = moveLeft;
        // buffer[2] = moveDown;
        // buffer[3] = moveRight;
        // commands = 4;
        gameManager.doTick += activateBuffer;
    }

    void activateBuffer()
    {
        buffer[reader]();
        reader += 1;

        // halt excecution if the reader reaches the end of commands
        if (reader >= commands) halt();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameMaster.phase == Phase.input)
        {
            // Start the excecution
            if (Input.GetKeyDown(KeyCode.LeftControl)) initiate();

            // Unit controlls
            if (writer < gameMaster.memory)
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) buffer[writer] = moveLeft;
                if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) buffer[writer] = moveRight;
                if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) buffer[writer] = moveUp;
                if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) buffer[writer] = moveDown;

                if (Input.GetKeyDown(KeyCode.Space)) buffer[writer] = skipMove;
                if (Input.GetKeyDown(KeyCode.H)) buffer[writer] = halt;
                if (Input.GetKeyDown(KeyCode.L)) buffer[writer] = loop;
                if (Input.GetKeyDown(KeyCode.Backspace)) buffer[writer] = undo;

            }
        }
    }
}