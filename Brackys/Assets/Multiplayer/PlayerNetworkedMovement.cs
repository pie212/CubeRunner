using UnityEngine;
using UnityEngine.InputSystem;
using System;
using System.Collections.Generic;
using System.Collections;
using Unity.Netcode;
using Unity.Networking;
using UnityEngine.SceneManagement;

public class PlayerNetworkedMovement : NetworkBehaviour
{

    public Vector3 Player2Pos;

    public override void OnNetworkSpawn()
    {
        if (!IsOwner) { Destroy(this); }
        if (IsClient) { rb.transform.position = Player2Pos; }
    }

    private bool Cooldown = false;


    [Header("Vars")]
    private PowerupTypeUI powerUpTypeUI;       // to update the powerupui instead of using update
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
    public Vector3 constantVelocity = new Vector3(0, 0, 30);
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
    public float yawAmount = 50f;
    public float TorqueAmount = 6000f;
    public float JumpAmount;

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
    public Vector2 mousePosition;
    //float PauseCalled = 0;

    public GameObject cursor;
    // Start is called before the first frame update

    [Header("Powerup Length")]
    public float KaboomLength = 10;
    public float KaboomCooldown = 5;
    public float SlowLength = 10;
    public float SlowCooldown = 5;
    public float Slow2Length = 10;
    public float Slow2Cooldown = 5;

    

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
        if (JMENU == false)          // if pause is not on
            {

                if (Jumping == true && isjumping == false)
                {
                    isjumping = true;
                    Jumping = false;
                    //JumpyYesOrNo = true;
                    jumpStartPos = transform.position;
                    Achievementmanager.Jumps += 1;                                               // adds 1 for the achievement manager in jump
                                                                                                 //jump = false;         IF IT DOESNT WORK ITS VIKTOR'S FAULT!!!!

                    if (gravity == 0 && ExtraGravity == false)
                    {
                        rb.velocity = new Vector3(rb.velocity.x, JumpAmount * Time.deltaTime * rb.mass, rb.velocity.z);

                    }
                    else if (gravity == 0)
                    {
                        rb.velocity = new Vector3(rb.velocity.x, JumpAmount * Time.deltaTime * rb.mass * 8, rb.velocity.z);
                    }
                    else if (gravity == 1)
                    {
                        rb.velocity = new Vector3(rb.velocity.x, -JumpAmount * Time.deltaTime * rb.mass, rb.velocity.z);
                    }
                }
            }
    }
    private void PowerUp(InputAction.CallbackContext context)
    {
        // JPOWER = true;         //power up
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
        powerUpTypeUI = FindObjectOfType<PowerupTypeUI>();
        powerUpTypeUI.UpdateUI();

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
        rb.velocity = new Vector3(0, 0, 0);
        KaboomRadius.enabled = false;
        lineRenderer = GetComponent<LineRenderer>();

    }

    public void mouseClick(InputAction.CallbackContext context)
    {

        if (context.performed)
        {

            if (ImportantVariables.MouseVisible == true)
            {
                mousePosition = Mouse.current.position.ReadValue();
            }
            if (ImportantVariables.MouseVisible == false)
            {
                if (cursor != null)
                {
                    mousePosition = new Vector2(cursor.transform.position.x, cursor.transform.position.y);
                }
            }
            //Vector2 mousePosition = Mouse.current.position.ReadValue();
            //Vector2 mousePosition = new Vector2(cursor.transform.position.x, cursor.transform.position.y);
            Debug.Log(mousePosition);

            Ray ray = Camera.main.ScreenPointToRay(mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000, raycastLayer, QueryTriggerInteraction.Ignore))
            {


                if (lineRenderer != null)
                {
                    lineRenderer.SetPosition(0, new Vector3(transform.position.x, transform.position.y, transform.position.z + 2)); // Start position
                    lineRenderer.SetPosition(1, hit.point);

                    Debug.Log(hit.transform.name);
                    Debug.Log("hit");
                    Obstacle target = hit.transform.GetComponent<Obstacle>();
                    GameObject target2 = hit.collider.gameObject;
                    if (target != null)
                    {
                        if (target2.GetComponent<MeshRenderer>() != null)
                        {
                            target2.GetComponent<MeshRenderer>().material = litmat;

                        }
                        ABLtarglist.Add(target2);
                    }

                }
            }
        }




    }
    void Ability(InputAction.CallbackContext context)
    {

        if (context.performed)
        {
            if (ImportantVariables.AbilityNumb != 0 && this != null)
            {
                Debug.Log("start cooldown code");
                StartCoroutine(AbilityCounter());
            }

            if (ImportantVariables.AbilityNumb == 1 && Cooldown == false && this != null)
            {
                TimeSlowMo = true;
                Time.timeScale = 0.2F;
                EventManager.OnEagleEye();
            }

            else if (ImportantVariables.AbilityNumb == 2 && Cooldown == false && this != null)
            {
                Time.timeScale = 0.02F;
                mouseclick.Enable();
                if (ImportantVariables.MouseVisible == false)
                {
                    if (cursor != null)
                    {
                        cursor.SetActive(true);
                    }
                }
            }

            else if (ImportantVariables.AbilityNumb == 3 && Cooldown == false && this != null)
            {
                TimeSlowMo = true;
                Time.timeScale = 0.2F;
            }



        }




        //rb.constraints = RigidbodyConstraints.FreezeAll;

        // Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
        // if (Physics.Raycast (ray, out hit, 100)) {
        //     Debug.Log (hit.transform.name);
        //     Debug.Log ("hit");
        // }


        if (context.canceled)
        {

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
            if (item.GetComponent<Obstacle>() != null)
            {
                item.GetComponent<Obstacle>().DestroyABL(force);
                Instantiate(effect, item.transform.position, Quaternion.identity);
            }
        }
        ABLtarglist.Clear();
        if (ImportantVariables.MouseVisible == false)
        {
            if (cursor != null)
            {
                cursor.SetActive(false);
            }
        }
        // rb.velocity = retainedSpeed;     // can't use rb for some fucking reason
    }

    IEnumerator AbilityCounter()
    {
        if (ImportantVariables.AbilityNumb == 1)
        {
            yield return new WaitForSeconds(KaboomLength);
            AbilityEnded();
            Cooldown = true;
            yield return new WaitForSeconds(KaboomCooldown);
            Cooldown = false;
        }
        if (ImportantVariables.AbilityNumb == 2)
        {
            yield return new WaitForSeconds(SlowLength);
            AbilityEnded();
            Cooldown = true;
            yield return new WaitForSeconds(SlowCooldown);
            Cooldown = false;
        }
        if (ImportantVariables.AbilityNumb == 3)
        {
            yield return new WaitForSeconds(Slow2Length);
            AbilityEnded();
            Cooldown = true;
            yield return new WaitForSeconds(Slow2Cooldown);
            Cooldown = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // if (rb.position.y > 5)
        // {
        //     rb.velocity = new Vector3(rb.velocity.x, -ExtraGravityAmount, rb.velocity.z);
        // }

        //Debug.Log(forwardForce * Time.deltaTime *rb.mass);
        if (ExtraGravity == true)
        {
            rb.AddForce(0, ExtraGravityAmount * Time.deltaTime, 0);       // adds downward force to keep the block near the ground
        }


        //Debug.Log(rb.velocity);

        //rb.AddForce(-2*Physics.gravity, ForceMode.Acceleration);  Reverses grabity by adding upward force
        if (UseRelativeForwardforce == false)
        {
            //rb.AddForce(0,0,forwardForce * Time.deltaTime *rb.mass);
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, forwardForce * Time.deltaTime * rb.mass);
        }
        else
        {
            rb.AddRelativeForce(0, 0, forwardForce * Time.deltaTime * rb.mass);
        }

        //Debug.Log(move.ReadValue<Vector2>());   
        sideways = move.ReadValue<Vector2>();
        if (Application.isMobilePlatform == true)
        {
            rb.AddForce(sideways.x * (sidewaysForce * ImportantVariables.MobileSensitivity * rb.mass) * Time.deltaTime, 0, 0);
        }
        else
        {
            rb.AddForce(sideways.x * (sidewaysForce * ImportantVariables.MobileSensitivity * rb.mass) * Time.deltaTime, 0, 0);
        }





        TorqueAm = pitch.ReadValue<Vector3>();
        YawAm = yaw.ReadValue<Vector3>();
        //Debug.Log(TorqueAm);
        //Debug.Log(YawAm);
        rb.AddTorque(TorqueAm.y * TorqueAmount * Time.deltaTime, yawAmount * -TorqueAm.z * Time.deltaTime, TorqueAm.x * -TorqueAmount * Time.deltaTime);




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

        if (gravity == 1)
        {
            Debug.Log("DA HELL");
            rb.AddForce(-2 * Physics.gravity);               // upside down
        }
        if (rb.position.y < VoidHeight)
        {
            if (DeathVoid == false)
            {
                Achievementmanager.DeathByVoid += 1;         // adds 1 for the achievement manager in deaths by void
                Gamemanager.EndGame();
            }
            DeathVoid = true;
            //FindObjectOfType<GameManager>().EndGame();



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

        // if (JPOWER == true)    moved this into the actual click funtion
        // {

        //     JPOWER = false;
        //     //if ((Gamemanager.PowerUpType == 1 ||Gamemanager.PowerUpType == 3 ) && slowmo == true){Time.timeScale = 1; slowmo = false;}
        //     if (Gamemanager.PowerUpType == 1)
        //     {
        //     kaboomeffect.Play();
        //     KaboomRadius.enabled = true;
        //     Gamemanager.PowerUpType = 0;
        //     // 2 is not included since it is a health one and does not need to be pressed
        //     }
        //     if (Gamemanager.PowerUpType == 3)
        //     {

        //     ImportantVariables.Money += 1;                // chooses how much money u get when using money pwoer up 
        //     Gamemanager.PowerUpType = 0;
        //     }

        //     // Time.fixedDeltaTime = 0.01F * Time.timeScale;



        // //Time.fixedDeltaTime = 0.01F;

        // }




        if (JCON == true)
        {
            Jumping = true;
            JCON = false;
        }

    }




    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            jump = true;
            isjumping = false;
            Debug.Log("AbleTO");
        }



    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            if (isjumping == true)
            {
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
