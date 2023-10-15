using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rbPlayer;
    public float gravityModifier;
    public float jumForce;
    private bool onGround = true;
    public bool gameOver = false;

    private Animator animPlayer;

    // Start is called before the first frame update
    void Start()
    {
       rbPlayer =  GetComponent<Rigidbody>();
       Physics.gravity *= gravityModifier;

       animPlayer= GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
      bool spaceDown = Input.GetKeyDown(KeyCode.Space);
        //conditions met to jump!
        if (spaceDown && onGround && !gameOver )
        {
            //jumd code
            rbPlayer.AddForce(Vector3.up * jumForce, ForceMode.Impulse);
            onGround= false;
            animPlayer.SetTrigger("Jump_trig");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }
        //Game is over with this condition met
        else if(collision.gameObject.CompareTag("Obstacle"))
        {

            Debug.Log("Game Over");
            gameOver= true;
            animPlayer.SetBool("Death_b", true);
            animPlayer.SetInteger("DeathType_int",2);
        }

    }
}
