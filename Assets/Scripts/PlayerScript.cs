using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float moveForce = 0f; 
    private Rigidbody rb; 
    public GameObject bullet; 
    public Transform gun; 
    public float shootRate = 0f; 
    public float shootForce = 0f; 
    private float shootRateTimeStamp = 0f; 

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal") * moveForce; 
        float v = Input.GetAxisRaw("Vertical") * moveForce; 
        rb.velocity = new Vector3(h, v, 0);

        if (Input.GetKey(KeyCode.Space))
        {
            if(Time.time > shootRateTimeStamp)
            {
                GameObject go = (GameObject)Instantiate(bullet, gun.position, gun.rotation);
                go.GetComponent<Rigidbody>().AddForce(gun.forward * shootForce);
                shootRateTimeStamp = Time.time + shootRate; 
            }
        }

    }
}
