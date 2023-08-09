









using UnityEngine;
using UnityEngine.InputSystem;


public class PLayerMovement : MonoBehaviour
{
    [HideInInspector]
    public bool isjumping = false;
    [HideInInspector]
    public Rigidbody rb;
    bool Pause = false;         // pause menu
    [HideInInspector]
    public GameManager Gamemanager; // Gamemanger
    public Vector3 retainedSpeed; // variable to maintain speed after pause
    public float gravity = 0f;      // gravity operater 0 = gravity is normal, 1 is that gravity is reversed, changed in Gravityrestore.cs and Gravityreverse.cs
    public bool jump = true;  
    public Animator animation;
    private Vector3 jumpStartPos;
    private Vector3 jumpHeightPos;
    private bool JumpyYesOrNo = false;      // bool created to allow the jump checking stuff to happen yk the one that checks the player position differential from the hight position after jumping
    public Vector3 constantVelocity = new Vector3(0,0,30);
    //[HideInInspector]
    public Collider KaboomRadius;
    public bool Jumping = false;
    
    
    public float VoidHeight = -3F;
    public bool DeathVoid = false;             //so the death function only runs once
    




    ///INPUTS
    public InputMaster PlayerControls;

    public InputAction move;
    public InputAction jumpCON;
    public InputAction powerup;
    public InputAction menu;
    public InputAction pitch;
    public InputAction yaw;
    private bool JCON = false;
    private bool JPOWER = false;
    public bool JMENU = false;
    Vector2 sideways = Vector2.zero; 
    Vector2 TorqueAm = Vector2.zero;
    Vector2 YawAm = Vector2.zero;
    public float forwardForce = 2000f; // force to set forward
    public float sidewaysForce = 12500f;  // force added when clicking a or d
    public float TorqueAmount = 6000f;
    //float PauseCalled = 0;
    
    // Start is called before the first frame update

    void Awake()
    {
        PlayerControls = new InputMaster();
    }

    private void OnEnable()
    {
        move = PlayerControls.Player.Move;
        move.Enable();
        jumpCON = PlayerControls.Player.Jump;
        jumpCON.Enable();
        jumpCON.performed += Jump;
        powerup = PlayerControls.Player.PowerUp;
        powerup.Enable();
        powerup.performed += PowerUp;
        menu = PlayerControls.Player.Menu;
        menu.Enable();
        menu.performed += Menu;
        pitch = PlayerControls.Player.PitchAndRoll;
        pitch.Enable();
        yaw = PlayerControls.Player.Yaw;
        yaw.Enable();

    }
    private void OnDisable()
    {
        move.Disable();
        jumpCON.Disable();
        powerup.Disable();
        menu.Disable();
        pitch.Disable();
        yaw.Disable();
    }
    private void Menu(InputAction.CallbackContext context)
    {
        JMENU = true;            //menu
    }
    private void Jump(InputAction.CallbackContext context)
    {
        JCON = true;           // jumps
    }
    private void PowerUp(InputAction.CallbackContext context)
    {
        JPOWER = true;         //power up
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Gamemanager = FindObjectOfType<GameManager>();
        //KaboomRadius = GetComponent<Collider>();
        //rb.useGravity = false; Could be for a reverse?? might have to put in anoterh script 
        rb.velocity = new Vector3(0,0,0);
        KaboomRadius.enabled = false;   
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        //Debug.Log(rb.velocity);

        //rb.AddForce(-2*Physics.gravity, ForceMode.Acceleration);  Reverses grabity by adding upward force
        rb.AddForce(0,0,forwardForce * Time.deltaTime);

        //Debug.Log(move.ReadValue<Vector2>());   
        sideways = move.ReadValue<Vector2>();
        if (Application.isMobilePlatform == true){
            rb.AddForce (sideways.x * sidewaysForce * Time.deltaTime, 0,0);
        }
        else{
            rb.AddForce (sideways.x * 8000F * Time.deltaTime, 0,0);
        }
        




        TorqueAm = pitch.ReadValue<Vector2>();
        YawAm = yaw.ReadValue<Vector2>();
        rb.AddTorque(TorqueAm.y * TorqueAmount * Time.deltaTime,        1000 * YawAm.x * Time.deltaTime,          TorqueAm.x * -TorqueAmount * Time.deltaTime);
        

        
        
        if (JMENU == true)
        {
            
            JMENU = false;
            move.Disable();
            jumpCON.Disable();
            powerup.Disable();
            menu.Disable();
            pitch.Disable();
            yaw.Disable();
            jumpCON.Disable(); //menu is open
            Jumping = false;
            retainedSpeed = rb.velocity;
            Pause = !Pause;
            rb.constraints = RigidbodyConstraints.FreezeAll;
            Gamemanager.PauseGame();
            
            
        }
        
        if (gravity == 1){
            Debug.Log("DA HELL");
            rb.AddForce(-2*Physics.gravity);
        }
        if (rb.position.y < VoidHeight)
        {
            if (DeathVoid == false){
                Achievementmanager.DeathByVoid +=1;         // adds 1 for the achievement manager in deaths by void
                Gamemanager.EndGame();
            }
            DeathVoid = true;                                                
            //FindObjectOfType<GameManager>().EndGame();
            
        
        
        }
        if (jump == true)
        {
            if (JMENU == false)          // if pause is not on
            {
                
            if (Jumping == true && isjumping == false)        
            {
                isjumping = true;
                Jumping = false;
                //JumpyYesOrNo = true;
                jumpStartPos = transform.position;
                Achievementmanager.Jumps +=1;                                               // adds 1 for the achievement manager in jump
                //jump = false;         IF IT DOESNT WORK ITS VIKTOR'S FAULT!!!!

                if (gravity == 0){
                    rb.AddForce(0,800*Time.deltaTime,0, ForceMode.VelocityChange);
                    
                }
                if (gravity == 1){
                    rb.AddForce(0,-1200*Time.deltaTime,0, ForceMode.VelocityChange);
                }
                
                
                //Invoke("jumpReturn", 0.2f);

                //if (rb.velocity.y < 0 && gravity == 0) // need to fix all of this please kill me
                //{
                //    rb.AddForce(0,-300*Time.deltaTime,-15, ForceMode.VelocityChange);
                //    Debug.Log("jumpedDown");
                    
                //}
                //if (rb.velocity.y < 0 && gravity == 1)
                //{
                //    rb.AddForce(0,300*Time.deltaTime,0, ForceMode.VelocityChange);
                //    Debug.Log("UhOh");
                    
                //}
               
                //if (transform.position.y > jumpStartPos.y + 2){
                    //Debug.Log("IT WORKS!!");
                //}
            }
            }
           
            
        }
    
            if (Gamemanager.PowerUpType == 0){
                Invoke("ResetPowerUp", 0.1F);
            }
            
            
    }
    //void jumpReturn(){
        //Debug.Log("Booga?");
        //rb.AddForce(0,-2500*Time.deltaTime,0,ForceMode.VelocityChange);
        
    //}
    
    void Update()
    {
         
        if (JPOWER == true)
        {
            JPOWER = false;
            if (Gamemanager.PowerUpType == 1)
            {
            KaboomRadius.enabled = true;
            Gamemanager.PowerUpType = 0;
            
            }
            if (Gamemanager.PowerUpType == 3)
            {
            ImportantVariables.Money += 1;                // chooses how much money u get when using money pwoer up 
            Gamemanager.PowerUpType = 0;
            }
            
        }
         
        if (JCON == true)
        {
            Jumping = true;
            JCON = false;
        }
        
    }    
        


    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground" )
        {
            jump = true;
            isjumping = false;
            Debug.Log("AbleTO");
        }
        
       

    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground" )
        {
            jump = false;
            Debug.Log("NotAbleTo");
        }
       

    }
    // POWER UP BOOLS BECAUSE IM DUMB
    public void ResetPowerUp()
    {
        KaboomRadius.enabled = false;
    }
}
