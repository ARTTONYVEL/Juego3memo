using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
      Rigidbody rb;
    public float force = 1/16;
    public Vector3 Transform = new Vector3(0,0,0);

    // Start is called before the first frame update
    void Start()
    {
        
         rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.up * force, ForceMode.Impulse);
        Destroy(gameObject, 5);
    }

    void OnCollisionEnter(Collision c){

        if(c.gameObject.tag == "enemigo"){

            Destroy(gameObject);
            
        }
    }
}
