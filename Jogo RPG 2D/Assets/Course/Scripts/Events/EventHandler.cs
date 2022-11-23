using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public delegate void MovementDelegate(float xInput, float yInput, bool isWalking, bool isRunning, bool isIdle, 
 bool idleUp, bool idleDown, 
    bool idleLeft, bool idleRight); 

public static class EventHandler
{

    //movement event
    public static event MovementDelegate MovementEvent;


    //movement event call for publishers

    public static void CallMovementEvent(float xInput, float yInput, bool isWalking, bool isRunning, bool isIdle,
    bool idleUp, bool idleDown,
    bool idleLeft, bool idleRight)
    {
        if (MovementEvent!=null) {
            MovementEvent(xInput, yInput, isWalking, isRunning, isIdle, idleUp, idleDown, idleLeft, idleRight);
        }
    }
}