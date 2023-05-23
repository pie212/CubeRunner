
using UnityEngine;

public class PLayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;
    bool Pause = false;
    public GameManager Gamemanager;
    public Vector3 retainedSpeed;
    public float gravity = 0f;
    private bool jump = true;

    //float PauseCalled = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        //rb.useGravity = false; Could be for a reverse?? might have to put in anoterh script 
     
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        

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
            Debug.Log("ESC pressed");
            retainedSpeed = rb.velocity;
            Pause = !Pause;
            rb.constraints = RigidbodyConstraints.FreezeAll;
            Debug.Log(retainedSpeed);
            Gamemanager.PauseGame();
            
            
        }
        
        if (gravity == 1){
            rb.AddForce(-2*Physics.gravity, ForceMode.Acceleration);
        }
        if (rb.position.y < -5)
        {
            FindObjectOfType<GameManager>().EndGame();
        
        }
    }
    void jumpReturn(){
        Debug.Log("Booga?");
        rb.AddForce(0,-2500*Time.deltaTime,0,ForceMode.VelocityChange);
        
    }
    void Update(){
        if (jump == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jump = false;
                Debug.Log(jump);
                rb.AddForce(0,1500*Time.deltaTime,0, ForceMode.VelocityChange);
                rb.AddTorque(20,0,0);
                Invoke("jumpReturn", 0.2f);

            }
        }
        


    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            jump = true;
            Debug.Log(jump);
        }
    }
}

