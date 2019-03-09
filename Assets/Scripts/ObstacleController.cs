using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public int damagePerHit;
    private GameController gameController;
    private AudioSource audio;
    private bool hit;
    // Start is called before the first frame update
    void Start()
    {
        hit = false;
        audio = GetComponent<AudioSource>();
        GameObject obj = GameObject.FindGameObjectWithTag("GameController");
        if (obj != null)
        {
            gameController = obj.GetComponent<GameController>();
        }
        else
        {
            Debug.Log("No GameController Scripts found");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (hit)
        {
            return;
        }
        if (other.CompareTag("Player"))
        {
            hit = true;
            audio.Play();
            gameController.AddDamage(damagePerHit);
        }        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
