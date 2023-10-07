using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rbPlayer;
    public float gravityModifier;
    public float jumForce;
    // Start is called before the first frame update
    void Start()
    {
       rbPlayer =  GetComponent<Rigidbody>();
       Physics.gravity *= gravityModifier;
       
    }

    // Update is called once per frame
    void Update()
    {
      bool spaceDown = Input.GetKeyDown(KeyCode.Space);
        if (spaceDown)
        {
            rbPlayer.AddForce(Vector3.up * jumForce, ForceMode.Impulse);
        }
    }
}
