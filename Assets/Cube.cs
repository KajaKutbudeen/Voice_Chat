using Photon.Pun;
using UnityEngine;
public class Cube : MonoBehaviour
{
    [SerializeField]
    float speed = 2f;
    Rigidbody rb;
   
    private void Start()
    {
       
        

        rb = GetComponent<Rigidbody>();

      
    }

    private void Update()
    {    
      //  rb.linearVelocity = new Vector3(Input.GetAxis("Horizontal") * speed, rb.linearVelocity.y, Input.GetAxis("Vertical") * speed);
    }
}
