using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    CharacterController characterController;
    [SerializeField] Vector3 movement = new Vector3 (0,0,0);
    [SerializeField] float speed = 8;
    public Transform referencia;
    public GameObject balas;
    public float timeBetweenAttacks;
    bool alreadyAttacked;


    void Awake(){

        characterController = GetComponent<CharacterController>();
    }
   

    void Start()
    {
        StartCoroutine(OneShot());
    }

 
    void Update()
    {
        movement = Vector3.zero;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)){
            movement += new Vector3(0,speed,0);
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)){
            movement += new Vector3(0,-speed,0);
        }
         if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){
            movement += new Vector3(speed,0,0);
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)){
            movement += new Vector3(-speed,0,0);
        }
        if(Input.GetKeyDown(KeyCode.Space)){
          OneShot();
        }
        if(Input.GetKey(KeyCode.Space)) {
          Shoot();
        }
      
      characterController.Move(movement*Time.deltaTime);
    }  

    IEnumerator OneShot(){
        yield return new WaitForSeconds(0);

        Instantiate(balas, referencia.position, referencia.rotation);
     }

  void Shoot(){
        if (!alreadyAttacked)
        {
            
            Instantiate(balas, referencia.position, referencia.rotation);
           

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }


}
