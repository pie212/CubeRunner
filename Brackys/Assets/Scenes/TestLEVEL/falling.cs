



using UnityEngine;

public class falling : MonoBehaviour
{
    public GameObject FallingTree;
    public float test;
    private Collider area;
    private int amount;
    private int x;
    private float y;
    private int z;

    // Start is called before the first frame update
    void Start()
    {
    
        //FallingTree = GetComponent<GameObject>();
        area =  GetComponentInChildren<Collider>();
        Destroy(this);
        for(int i=0; i<50; i++){
            x =  Random.Range( 100,  297);
            y = -0.6F;
            z =  Random.Range( 20,  855);
            Instantiate(FallingTree, new Vector3(x,y,z), Quaternion.Euler(0,0,0));
        }
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider collider){
        if (collider.tag == "Player"){
            GetComponent<Rigidbody>().isKinematic = false;
            //GetComponent<Transform>().rotation = Quaternion.Euler(0,0,20);
            GetComponent<Rigidbody>().AddForce(25000 * Time.deltaTime,0,0);
        }
    }
}
