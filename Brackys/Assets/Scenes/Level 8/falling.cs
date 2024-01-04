





using UnityEngine;

public class falling : MonoBehaviour
{
    public GameObject FallingTree;
    private float TypeFall;

    //private Collider area;
    

    // Start is called before the first frame update
    

    // Update is called once per frame
    void OnTriggerEnter(Collider collider){
        TypeFall = Random.Range(1,5);
            if (collider.tag == "Player"){
            GetComponent<Rigidbody>().isKinematic = false;
            }
            if (TypeFall == 1){
                GetComponent<Rigidbody>().AddForce(Random.Range(25000,40000) * Time.deltaTime,0,0);

            }
            if (TypeFall == 2){
                GetComponent<Rigidbody>().AddForce(Random.Range(-40000,-25000) * Time.deltaTime,0,0);

            }
            if (TypeFall == 3){
                GetComponent<Rigidbody>().AddForce(0,0,Random.Range(25000,40000) * Time.deltaTime);

            }
            if (TypeFall == 4){
                GetComponent<Rigidbody>().AddForce(0,0,Random.Range(-40000,-25000) * Time.deltaTime);

            }
            
            //GetComponent<Transform>().rotation = Quaternion.Euler(0,0,20);
            //  GetComponent<Rigidbody>().AddForce(25000 * Time.deltaTime,0,0);
        }
}

