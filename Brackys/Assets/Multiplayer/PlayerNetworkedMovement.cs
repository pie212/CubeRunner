using UnityEngine;
using UnityEngine.InputSystem;
using System;
using System.Collections.Generic;
using System.Collections;
using Unity.Netcode;
using Unity.Networking;

public class PlayerNetworkedMovement : NetworkBehaviour
{

    public override void OnNetworkSpawn()
    {
        if (!IsOwner) { Destroy(this); }
    }

    public Vector3 Player2StartLocation;

    private void Start()
    {
        if (IsClient) { gameObject.transform.position = Player2StartLocation; }
    }


    Rigidbody rb;

    [Header("Inputs")]
    public InputMaster PlayerControls;

    public InputAction move;
    public InputAction jumpCON;
    public InputAction menu;
    public InputAction pitch;
    public InputAction yaw;
    public InputAction mouseclick;
    public bool JMENU = false;
    private bool JCON = false;

    public bool jump = true;
    public bool isjumping = false;
    public Vector2 mousePosition;
    public GameObject cursor;
    Vector2 sideways = Vector2.zero;
    [Header("Physics")]
    public bool ExtraGravity;
    public float ExtraGravityAmount = 1800f;
    public float forwardForce = 2000f; // force to set forward
    public float sidewaysForce = 10000f;  // force added when clicking a or d
    public float yawAmount = 50f;
    public float TorqueAmount = 6000f;
    public bool UseRelativeForwardforce = false;
    Vector3 TorqueAm = Vector3.zero;
    Vector2 YawAm = Vector2.zero;
    public bool Jumping = false;
    private Vector3 jumpStartPos;
    public float gravity = 0f;      // gravity operater 0 = gravity is normal, 1 is that gravity is reversed, changed in Gravityrestore.cs and Gravityreverse.cs
    public GameObject camera;



    // Start is called before the first frame update
    void Awake()
    {
        PlayerControls = new InputMaster();
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        move = PlayerControls.Player.Move;
        move.Enable();
        jumpCON = PlayerControls.Player.Jump;
        jumpCON.Enable();
        jumpCON.performed += Jump;
        menu = PlayerControls.Player.Menu;
        menu.Enable();
        menu.performed += Menu;
        pitch = PlayerControls.Player.PitchAndRoll;
        pitch.Enable();
        yaw = PlayerControls.Player.Yaw;
        yaw.Enable();
        mouseclick = PlayerControls.Player.MouseClick;
        mouseclick.performed += mouseClick;




    }

    private void OnDisable()
    {
        move.Disable();
        jumpCON.Disable();
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

            
        }




    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        //rb.AddForce(-2*Physics.gravity, ForceMode.Acceleration);  Reverses grabity by adding upward force
        if (UseRelativeForwardforce == false)
        {
            //rb.AddForce(0,0,forwardForce * Time.deltaTime *rb.mass);
            rb.AddForce(camera.transform.position * forwardForce * Time.deltaTime * rb.mass);
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
            menu.Disable();
            pitch.Disable();
            yaw.Disable();
            jumpCON.Disable(); //menu is open
            rb.constraints = RigidbodyConstraints.FreezeAll;


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
                    Achievementmanager.Jumps += 1;                                               // adds 1 for the achievement manager in jump
                                                                                                 //jump = false;         IF IT DOESNT WORK ITS VIKTOR'S FAULT!!!!

                    if (gravity == 0 && ExtraGravity == false)
                    {
                        rb.AddForce(0, 800 * Time.deltaTime * rb.mass, 0, ForceMode.VelocityChange);

                    }
                    else if (gravity == 0)
                    {
                        rb.AddForce(0, 2600 * Time.deltaTime * rb.mass, 0, ForceMode.VelocityChange);   // adds more force to compensate the extra gravity (800(jumpingforce) + 1800(gravity force))
                    }
                    else if (gravity == 1)
                    {
                        rb.AddForce(0, -1200 * Time.deltaTime * rb.mass, 0, ForceMode.VelocityChange);
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
    }

    private void Update()
    {
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
}
