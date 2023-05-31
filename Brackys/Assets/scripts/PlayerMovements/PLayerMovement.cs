
using UnityEngine;

public class PLayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float forwardForce = 2000f; // force to set forward
    public float sidewaysForce = 500f;  // force added when clicking a or d
    bool Pause = false;         // pause menu
    public GameManager Gamemanager; // Gamemanger
    public Vector3 retainedSpeed; // variable to maintain speed after pause
    public float gravity = 0f;      // gravity operater 0 = gravity is normal, 1 is that gravity is reversed, changed in Gravityrestore.cs and Gravityreverse.cs
    private bool jump = true;  
    public Animator animation;
    private Vector3 jumpStartPos;
    private Vector3 jumpHeightPos;
    private bool JumpyYesOrNo = false;      // bool created to allow the jump checking stuff to happen yk the one that checks the player position differential from the hight position after jumping
    public Vector3 constantVelocity = new Vector3(0,0,30);

    //float PauseCalled = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        //rb.useGravity = false; Could be for a reverse?? might have to put in anoterh script 
        rb.velocity = new Vector3(0,0,0);
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log(rb.velocity);

        //rb.AddForce(-2*Physics.gravity, ForceMode.Acceleration);  Reverses grabity by adding upward force
        rb.AddForce(0,0,forwardForce * Time.deltaTime);

        if (Input.GetKey("d"))
        {
            rb.AddForce(sidewaysForce * Time.deltaTime,0,0, ForceMode.VelocityChange);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime,0,0,ForceMode.VelocityChange);
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            retainedSpeed = rb.velocity;
            Pause = !Pause;
            rb.constraints = RigidbodyConstraints.FreezeAll;
            Debug.Log(retainedSpeed);
            Gamemanager.PauseGame();
            
            
        }
        
        if (gravity == 1){
            rb.AddForce(-1*Physics.gravity);
        }
        if (rb.position.y < -3)
        {
            FindObjectOfType<GameManager>().EndGame();
        
        }
    }
    //void jumpReturn(){
        //Debug.Log("Booga?");
        //rb.AddForce(0,-2500*Time.deltaTime,0,ForceMode.VelocityChange);
        
    //}
    void Update()
    {
        if (jump == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                JumpyYesOrNo = true;
                jumpStartPos = transform.position;
                //jump = false;         IF IT DOESNT WORK ITS VIKTOR'S FAULT!!!!
                if (gravity == 0){
                    rb.AddForce(0,1200*Time.deltaTime,0, ForceMode.VelocityChange);
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
         if (JumpyYesOrNo == true)
            {
                if (transform.position.y >= jumpStartPos.y + 2)
                {
                    retainedSpeed = rb.velocity;
                    if (gravity == 0)
                    {
                    rb.velocity = new Vector3(retainedSpeed.x,-1000*Time.deltaTime,retainedSpeed.z);
                    }   
                    if (gravity == 1)
                    {
                    rb.velocity = new Vector3(retainedSpeed.x,1000*Time.deltaTime,retainedSpeed.z);
                    }
                    
                    JumpyYesOrNo = false;
                }
            }
    }    
        


    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground" )
        {
            jump = true;
            Debug.Log(jump);
        }
       

    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground" )
        {
            jump = false;
            Debug.Log(jump);
        }
       

    }
}
