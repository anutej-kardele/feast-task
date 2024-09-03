using System;

public class EventManager
{
    public static Action<int> enemyKilled;
    public static Action<int> playerHit;
    public static Action gameOver;
}
