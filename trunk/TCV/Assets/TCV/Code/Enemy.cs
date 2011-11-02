using UnityEngine;
using System.Collections;



public class Enemy : MonoBehaviour {

    public int health = 20;
    public int defense = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (health <= 0) Die();
	
	}

    void Die()
    {
        Destroy(transform.gameObject);
    }
}
