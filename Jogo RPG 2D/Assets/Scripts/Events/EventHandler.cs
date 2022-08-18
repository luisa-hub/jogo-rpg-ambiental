using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public delegate void MovementDelegate(float inputX, float inputY, bool isWalking, bool isRunning, bool isIdle, bool isCarrying, ToolEffect toolEffect, bool isUsingToolRight, 
    bool IsUsingToolLeft, bool isUsingToolUp, bool isUsingToolDown, bool isLiftingTooRight, bool isLiftingTooLeft, bool isLiftingTooUp, bool isLiftingToolDown, bool isPickingRight, 
    bool isPickingLeft, bool isPickingUp, bool isPickingDown, bool isSwingingToolRight, bool isSwingingToolLeft, bool isSwingingToolUp, bool isSwingingToolDown, bool idleUp, bool idleDown, 
    bool idleLeft, bool idleRight); 

public static class EventHandler
{

    //movement event
    public static event MovementDelegate MovementEvent;


    //movement event call for publishers

    public static void CallMovementEvent(float inputX, float inputY, bool isWalking, bool isRunning, bool isIdle, bool isCarrying, ToolEffect toolEffect, bool isUsingToolRight,
    bool IsUsingToolLeft, bool isUsingToolUp, bool isUsingToolDown, bool isLiftingTooRight, bool isLiftingTooLeft, bool isLiftingTooUp, bool isLiftingToolDown, bool isPickingRight,
    bool isPickingLeft, bool isPickingUp, bool isPickingDown, bool isSwingingToolRight, bool isSwingingToolLeft, bool isSwingingToolUp, bool isSwingingToolDown, bool idleUp, bool idleDown,
    bool idleLeft, bool idleRight)
    {
        if (MovementEvent!=null) {
            MovementEvent(inputX, inputY, isWalking, isRunning, isIdle, isCarrying, toolEffect, isUsingToolRight,
            IsUsingToolLeft, isUsingToolUp, isUsingToolDown, isLiftingTooRight, isLiftingTooLeft, isLiftingTooUp, isLiftingToolDown, isPickingRight,
            isPickingLeft, isPickingUp, isPickingDown, isSwingingToolRight, isSwingingToolLeft, isSwingingToolUp, isSwingingToolDown, idleUp, idleDown,
            idleLeft, idleRight);
        }
    }
}