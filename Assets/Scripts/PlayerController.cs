using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Player playerInput; 
    private CharacterController controller;
    private Vector3 playerVelocity;
    private Vector2 movementInput;
    
    private bool groundedPlayer;
    private int runSpeedMultiplier = 3;
    private float playerSpeed = 7.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    private void Awake() {
        playerInput = new Player();     
        controller = GetComponent<CharacterController>();
    }
    private void OnEnable() {
        playerInput.Enable();
    }
    private void OnDisable() {
        playerInput.Disable();
    }


    private void Start()
    {
   
    }

    void Update()
    {
         groundedPlayer = controller.isGrounded;
         if (groundedPlayer && playerVelocity.y < 0)
         {
             playerVelocity.y = 0f;
         }
        movementInput = playerInput.PlayerMain.Move.ReadValue<Vector2>();
        //Debug.Log(movementInput);
       
        Vector3 move = new Vector3(movementInput.x,0f,movementInput.y);
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        // Changes the height position of the player..
        if (playerInput.PlayerMain.Jump.triggered && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    public void IncreaseRunningSpeed(){
        playerSpeed *= runSpeedMultiplier;
        //Debug.Log("increased speed");
    }

    public void NormalRunningSpeed(){
        playerSpeed /= runSpeedMultiplier;
        //Debug.Log("low speed");
    }
    
}
