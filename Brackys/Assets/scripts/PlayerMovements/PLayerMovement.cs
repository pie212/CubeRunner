










using UnityEngine;
using UnityEngine.InputSystem;
using System;
using System.Collections.Generic;

public class PLayerMovement : MonoBehaviour
{
    [Header("Vars")]
    public bool UseRelativeForwardforce = false;
    public ParticleSystem kaboomeffect;
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
    public LayerMask raycastLayer;
    
    public float VoidHeight = -3F;
    public bool DeathVoid = false;             //so the death function only runs once
    public GameObject effect;

    [Header("Physics")]
    public bool ExtraGravity;
    public float ExtraGravityAmount = 1800f;
    public float forwardForce = 2000f; // force to set forward
    public float sidewaysForce = 10000f;  // force added when clicking a or d
    public float TorqueAmount = 6000f;

    ///INPUTS
    [Header("Inputs")]
    public InputMaster PlayerControls;

    public InputAction move;
    public InputAction jumpCON;
    public InputAction powerup;
    public InputAction menu;
    public InputAction pitch;
    public InputAction yaw;
    public InputAction ability;
    public InputAction mouseclick;
    private bool JCON = false;
    private bool JPOWER = false;
    [HideInInspector]
    public bool JMENU = false;
    Vector2 sideways = Vector2.zero; 
    Vector3 TorqueAm = Vector3.zero;
    Vector2 YawAm = Vector2.zero;
    



    // ability
    [Header("Ability")]
    public int abilityType = 0;
    public float AbilityTimer = 0.0f;
    public bool TimeSlowMo = false;
    private LineRenderer lineRenderer;
    public List<GameObject> ABLtarglist = new List<GameObject>();
    public bool slowmo; 
    public int SlowMoTime;
    public Material litmat;
    public int force = 1000;
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
        ability = PlayerControls.Player.Ability;
        ability.Enable();
        ability.performed += Ability;
        ability.canceled += Ability;
        mouseclick = PlayerControls.Player.MouseClick;
        mouseclick.performed += mouseClick;
       



    }

    private void OnDisable()
    {
        move.Disable();
        jumpCON.Disable();
        powerup.Disable();
        menu.Disable();
        pitch.Disable();
        yaw.Disable();
        mouseclick.Disable();
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
        AbilityTimer = 0;
        Debug.Log(Time.timeScale);
        Debug.Log(Time.fixedDeltaTime);
        rb = GetComponent<Rigidbody>();
        Gamemanager = FindObjectOfType<GameManager>();
        //KaboomRadius = GetComponent<Collider>();
        //rb.useGravity = false; Could be for a reverse?? might have to put in anoterh script 
        rb.velocity = new Vector3(0,0,0);
        KaboomRadius.enabled = false;   
        lineRenderer = GetComponent<LineRenderer>();
        
    }

    public void mouseClick(InputAction.CallbackContext context)
    {
        
        if (context.performed)
        {
            Vector2 mousePosition = Mouse.current.position.ReadValue();
            Ray ray = Camera.main.ScreenPointToRay(mousePosition);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit, 1000, raycastLayer, QueryTriggerInteraction.Ignore) )
            {
                
                
                if (lineRenderer != null){
                lineRenderer.SetPosition(0, new Vector3(transform.position.x, transform.position.y, transform.position.z + 2)); // Start position
                lineRenderer.SetPosition(1, hit.point); 

                Debug.Log(hit.transform.name);
                Debug.Log("hit");
                Obstacle target = hit.transform.GetComponent<Obstacle>();
                GameObject target2 = hit.collider.gameObject;
                if (target != null)
                {
                    if (target2.GetComponent<MeshRenderer>() != null){
                    target2.GetComponent<MeshRenderer>().material = litmat;
                    
                    }
                    ABLtarglist.Add(target2);
                }
                
             }
            }
        }
    
    
    
                    
    }
    void Ability(InputAction.CallbackContext context){
    
        if (context.performed){
            
        
            if (ImportantVariables.AbilityNumb == 1){
            TimeSlowMo = true;
            Time.timeScale = 0.2F;  
            EventManager.OnEagleEye();  
            }     

            if (ImportantVariables.AbilityNumb == 2){
            mouseclick.Enable();
            Time.timeScale = 0.02f;
            
            
            }
            //rb.constraints = RigidbodyConstraints.FreezeAll;

            // Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
            // if (Physics.Raycast (ray, out hit, 100)) {
            //     Debug.Log (hit.transform.name);
            //     Debug.Log ("hit");
            // }
            
        }
        if (context.canceled){
            
            AbilityEnded();



            
        }
        
        
    }
    void AbilityEnded()
    {       
                    mouseclick.Disable();
                    TimeSlowMo = false;
                    Time.timeScale = 1F;
                    EventManager.OnEagleEyeEnd();   
                    foreach (GameObject item in ABLtarglist)
                    {
                        if (item.GetComponent<Obstacle>() != null){
                        item.GetComponent<Obstacle>().DestroyABL(force);
                        Instantiate(effect, item.transform.position, Quaternion.identity);
                        }
                    }
                    ABLtarglist.Clear();
                    // rb.velocity = retainedSpeed;     // can't use rb for some fucking reason
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(forwardForce * Time.deltaTime *rb.mass);
        if (ExtraGravity == true ){
        rb.AddForce(0,ExtraGravityAmount * Time.deltaTime,0 );       // adds downward force to keep the block near the ground
        }
        
        
        //Debug.Log(rb.velocity);

        //rb.AddForce(-2*Physics.gravity, ForceMode.Acceleration);  Reverses grabity by adding upward force
        if (UseRelativeForwardforce == false){
        //rb.AddForce(0,0,forwardForce * Time.deltaTime *rb.mass);
        rb.AddForce(FindObjectOfType<Camera>().transform.forward * forwardForce * Time.deltaTime *rb.mass);
        }
        else{
        rb.AddRelativeForce(0,0,forwardForce * Time.deltaTime * rb.mass);
        }

        //Debug.Log(move.ReadValue<Vector2>());   
        sideways = move.ReadValue<Vector2>();
        if (Application.isMobilePlatform == true){
            rb.AddForce (sideways.x * (sidewaysForce * ImportantVariables.MobileSensitivity * rb.mass) * Time.deltaTime, 0,0);
        }
        else{
            rb.AddForce (sideways.x * (sidewaysForce * ImportantVariables.MobileSensitivity * rb.mass) * Time.deltaTime, 0,0);
        }
         




        TorqueAm = pitch.ReadValue<Vector3>();
        YawAm = yaw.ReadValue<Vector3>();
        Debug.Log(TorqueAm);
        Debug.Log(YawAm);
        rb.AddTorque(TorqueAm.y * TorqueAmount * Time.deltaTime,        50 * -TorqueAm.z * Time.deltaTime,          TorqueAm.x * -TorqueAmount * Time.deltaTime);
        

        
        
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
            rb.AddForce(-2*Physics.gravity );               // upside down
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

                if (gravity == 0 && ExtraGravity == false){
                    rb.AddForce(0,800*Time.deltaTime * rb.mass,0, ForceMode.VelocityChange );
                    
                }
                else if(gravity == 0){
                    rb.AddForce(0,2600*Time.deltaTime * rb.mass,0, ForceMode.VelocityChange );   // adds more force to compensate the extra gravity (800(jumpingforce) + 1800(gravity force))
                }
                else if (gravity == 1){
                    rb.AddForce(0,-1200*Time.deltaTime * rb.mass,0, ForceMode.VelocityChange);
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
        
        if (TimeSlowMo)
        {
            AbilityTimer += Time.deltaTime;
            float seconds = Convert.ToInt32((AbilityTimer % 60) * 5);
            Debug.Log("seconds" + seconds.ToString());
            if (seconds >= 10)
            {
                mouseclick.Disable();
                TimeSlowMo = false;
                AbilityTimer = 0;
                seconds = 0;
                Time.timeScale = 1F;
                AbilityEnded();
            }
        else
        {
            Vector2 mousePosition = Mouse.current.position.ReadValue();

        }
        }
         
        if (JPOWER == true)
        {
            
            JPOWER = false;
            //if ((Gamemanager.PowerUpType == 1 ||Gamemanager.PowerUpType == 3 ) && slowmo == true){Time.timeScale = 1; slowmo = false;}
            if (Gamemanager.PowerUpType == 1)
            {
            kaboomeffect.Play();
            KaboomRadius.enabled = true;
            Gamemanager.PowerUpType = 0;
            // 2 is not included since it is a health one and does not need to be pressed
            }
            if (Gamemanager.PowerUpType == 3)
            {
                
            ImportantVariables.Money += 1;                // chooses how much money u get when using money pwoer up 
            Gamemanager.PowerUpType = 0;
            }
           
            // Time.fixedDeltaTime = 0.01F * Time.timeScale;
                
                
            
        //Time.fixedDeltaTime = 0.01F;
            
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
            if (isjumping == true){
            jump = false;
            
            Debug.Log("NotAbleTo");
            }
        }
       

    }
    // POWER UP BOOLS BECAUSE IM DUMB
    public void ResetPowerUp()
    {
        KaboomRadius.enabled = false;
    }
}
