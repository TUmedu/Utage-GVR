using System.Collections;


   using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    // speedを制御する
    public float speed = 100;

    void FixedUpdate()
    {
       // float x = Input.GetAxis("Horizontal");
        //float z = Input.GetAxis("Vertical");

        
        float x = CrossPlatformInputManager.GetAxis("Horizontal");
        float z = CrossPlatformInputManager.GetAxis("Vertical");

        Rigidbody rigidbody = GetComponent<Rigidbody>();

        // xとzにspeedを掛ける
        // rigidbody.AddForce(x * speed, 0, z * speed);
        rigidbody.AddForce(x * speed,0,0);
    }
}