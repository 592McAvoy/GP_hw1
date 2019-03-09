using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockRoll : MonoBehaviour
{
    private Rigidbody rd;//刚体变量
    public int force ;//力量
    public float direction;
    
    // Use this for initialization
    void Start()
    {
        rd = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //float h = Input.GetAxis("Horizontal");
        //float v = Input.GetAxis("Vertical");
        rd.AddForce(new Vector3(direction, 0.0f, 0.0f) * force);
    }

}
