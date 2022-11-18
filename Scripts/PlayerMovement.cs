using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody playerRb;
    public float speed=2.0f;
    public GameObject wave;
     private float powerupStrength=10.0f;
    
    //strength by which enemy will be thrown away after collision
    // Start is called before the first frame update
    void Start()
    {
        playerRb=GetComponent<Rigidbody>();
      
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput=Input.GetAxis("Vertical");
        playerRb.AddForce(Vector3.forward*speed*forwardInput);
        //will move player in vertical direction

        float horizontalInput=Input.GetAxis("Horizontal");
        playerRb.AddForce(Vector3.right*speed*horizontalInput);
        //will move player in horizontal direction

        if(Input.GetMouseButtonDown(0))
        {
            Vector3 cursorPos=Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Instantiate(wave,new Vector3(cursorPos.x,cursorPos.y,0),transform.rotation);
        }
       
        
    }
    private void OnCollisionEnter(Collision collision)
    {

        if(collision.gameObject.CompareTag("Enemy"))
        {
         Rigidbody enemyRigidbody=collision.gameObject.GetComponent<Rigidbody>();
         Vector3 awayFormPlayer=(collision.gameObject.transform.position-transform.position);
         enemyRigidbody.AddForce(awayFormPlayer*powerupStrength,ForceMode.Impulse);
         //throwing enemy away after collision
        }
    }
    
}

