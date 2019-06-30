public class gameMaster
{

    public static Phase phase = Phase.input;
    public static float gridstep = 1;


    public static void startInputPhase() { phase = Phase.input; }

    public static void startTicks() { phase = Phase.tick; }

    public static void startWait() { phase = Phase.wait; }

    public static int memory = 10;

    public static float tickSpeed = 1f;
}

public enum Phase
{
    input,
    tick,
    wait
}
