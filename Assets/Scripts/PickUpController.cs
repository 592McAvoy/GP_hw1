using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
    public GameObject explosion;
    //public GameObject playerExplosion;
    public int scorePerHit;
    private GameController gameController;
    private AudioSource ad;

    // Start is called before the first frame update
    void Start()
    {
        ad = GetComponent<AudioSource>();
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

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Instantiate(explosion, transform.position, transform.rotation);
        gameController.AddScore(scorePerHit);
        Destroy(this.gameObject);
        
    }
}
