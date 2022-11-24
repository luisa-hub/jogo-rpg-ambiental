
using UnityEngine;

public class Player : SingletonMonobehaviour<Player>
{

    public float xInput;
    public float yInput;
    private bool isWalking;
    private bool isRunning;
    private bool isIdle;
    private bool idleUp;
    private bool idleDown;
    private bool idleLeft;
    private bool idleRight;


    public bool firstInteraction = false;
    public bool canMove = true;
    private Rigidbody2D rigidbody2D;
    public PlayerController playerController;
    private float movementSpeed;

    private Direction playerDirection;

    

    private bool _playerInputIsDisabled = false;

    public bool PlayerInputIsDisabled
    {
        get => _playerInputIsDisabled; set => _playerInputIsDisabled = value;
    }

   
    protected override void Awake()
    {
        base.Awake();


        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        #region

        PlayerMovementInput();

        PlayerWalkInput();

        EventHandler.CallMovementEvent(xInput, yInput, isWalking, isRunning, isIdle,
        false, false, false, false);
        #endregion
    }

    private void FixedUpdate()
    {

        PlayerMovement();
    }

    public void PlayerMovementState(bool status)
    {
        canMove = status;
    }

    private void PlayerMovement()
    {
        Vector2 move = new Vector2(xInput * movementSpeed * Time.deltaTime,
            yInput * movementSpeed * Time.deltaTime);


        rigidbody2D.MovePosition(rigidbody2D.position + move);
    }


    //Impede que o jogador interaja com o ambiente caso esteja realizando alguma interação
    public void PlayerPauseInteraction(bool isMenu = false)
    {
        if (isMenu && !canMove)
            firstInteraction = false;
        else
        {

            PlayerMovementState(false);

            xInput = 0;
            yInput = 0;

            GameObject.Find("Player").GetComponent<PlayerController>().CanInteract(false);

            firstInteraction = true;
        }
       

    }

    public void PlayerReturnInteraction()
    {
        if (firstInteraction)
        {
            PlayerMovementState(true);
            GameObject.Find("Player").GetComponent<PlayerController>().CanInteract(true);
           
        }
        else
        {
            PlayerMovementState(false);
            GameObject.Find("Player").GetComponent<PlayerController>().CanInteract(false);
            firstInteraction = true;


        }


    }



    private void PlayerMovementInput()
    {
        // Impede que o player se movimente caso seja falso
        if (!canMove)
            return;

        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");


        if (xInput != 0 || yInput != 0)
        {
            isRunning = true;
            isWalking = false;
            isIdle = false;
            movementSpeed = Settings.runningSpeed;

            //Capture player direction for save game
            if (xInput < 0)
            {
                playerDirection = Direction.left;
            }

            else if (xInput > 0)
            {
                playerDirection = Direction.right;
            }

            else if (yInput < 0)
            {
                playerDirection = Direction.down;
            }

            else
            {
                playerDirection = Direction.up;
            }


        }

        else if (xInput == 0 && yInput == 0)
        {
            isRunning = false;
            isWalking = false;
            isIdle = true;
        }
    }

    private void PlayerWalkInput()
    {
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            isRunning = false;
            isWalking = true;
            isIdle = false;
            movementSpeed = Settings.walkingSpeed;

        }
        else
        {
            isRunning = true;
            isWalking = false;
            isIdle = false;
            movementSpeed = Settings.runningSpeed;
        }
    }
}

