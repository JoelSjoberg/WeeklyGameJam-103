﻿public class gameMaster
{

    public static Phase phase = Phase.input;
    public static float gridstep = 1;


    public static void startInputPhase() { phase = Phase.input; }

    public static void startTicks() { phase = Phase.tick; }

    public static void startWait() { phase = Phase.wait; }

    public delegate void begin();
    public static event begin startLevel;

    public delegate void finish();
    public static event finish finishLevel;


    public static void GoalReached()
    {
        startInputPhase();
        finishLevel();
    }

    public static void startNextLevel()
    {
        startLevel();
    }

    public static int memory = 10;

    public static float tickSpeed = 0.80f;

    public static int error = 0;
}

public enum Phase
{
    input,
    tick,
    wait,
    beginning,
    finish
}
