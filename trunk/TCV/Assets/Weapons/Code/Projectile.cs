using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    public bool isFriendly = true;
    public float speed = 20;
    public float attackPower = 1;
    public float range = 1;
    public float spread = 1;

    // Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {

        //Moves projectile forward
        transform.position = transform.position + transform.forward * (speed * Time.deltaTime);

        //If it has reached it's max range, destroy self
        if (range <= 0)
            Destroy(transform.gameObject);
        //else update range
        range -= Time.deltaTime;
	}

    //void OnCollisionEnter(Collision hit)
    //{
    //    Destroy(transform.gameObject);
    //}

    void OnTriggerEnter(Collider other)
    {
        if (isFriendly && !other.CompareTag("Player"))  //Friendly Fire
        {
            Destroy(transform.gameObject);
        }

        if (!isFriendly && !other.CompareTag("Enemy"))  //Enemy Fire
        {
            Destroy(transform.gameObject);
        }

    }
    

}
