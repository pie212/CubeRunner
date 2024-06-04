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
            rb.AddForce(FindObjectOfType<Camera>().transform.forward * forwardForce * Time.deltaTime * rb.mass);
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
