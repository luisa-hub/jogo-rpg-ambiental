
using UnityEngine;

public static class Settings
{
    //Obscuring item fading
    public const float fadeInSeconds = 0.25f;
    public const float fadeOutSeconds = 0.35f;
    public const float targetAlpha = 0.45f;

    //PLayer Movement
    public const float runningSpeed = 5.333f;
    public const float walkingSpeed = 2.666f;

    //Player Animation Parameters
    public static int xInput;
    public static int yInput;
    public static int isWalking;
    public static int isRunning;


    //Shared Animarion Parameters
    public static int idleUp;
    public static int idleDown;
    public static int idleLeft;
    public static int idleRight;

    //static constructor
    static Settings(){

        //Player Animation Parameters
        xInput = Animator.StringToHash("xInput");
        yInput = Animator.StringToHash("yInput");
        isWalking = Animator.StringToHash("isWalking");
        isRunning = Animator.StringToHash("isRunning");

        //Shared Animarion Parameters
        idleUp = Animator.StringToHash("idleUp");
        idleDown = Animator.StringToHash("idleDown");
        idleLeft = Animator.StringToHash("idleLeft");
        idleRight = Animator.StringToHash("idleRight");
    }
}

