using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax;
}

public class playerController : MonoBehaviour
{
    
    public float speed;
    public float jumpSpeed;
    public Boundary boundary;

    private Rigidbody rb;
    private bool onGround;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        onGround = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (onGround)
        {
            //Debug.Log("on the ground");
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, 1.0f) * speed;
            rb.velocity = movement;

            rb.position = new Vector3
            (
                Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
                rb.position.y,
                Mathf.Clamp(rb.position.z, 0.0f, 337.0f)
            );

            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.velocity += new Vector3(0, 5, 0);
                rb.AddForce(jumpSpeed * new Vector3(0.0f,1.0f,1.0f));
                onGround = false;
            }
        }
        else
        {
            rb.velocity = new Vector3(0.0f, -1.5f, 1.5f) * speed;
        }    

        

    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Hit something");
        if (other.CompareTag("Ground"))
        {
            //Debug.Log("Hit ground");
            onGround = true;
            return;
        }
    }
}
