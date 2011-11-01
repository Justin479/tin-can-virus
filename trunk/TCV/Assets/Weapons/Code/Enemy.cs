using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public Projectile shot;
    public Transform target;
    public bool isFriendly = false;
    public float attackBoost = 5;
    public float range = 5f;
    public float spread = 1;
    public float projectileSpeed = 20;
    
    public float rotationSpeed = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {



        transform.LookAt(target);
        
        Shoot();
	
	}

    public bool compare(float x, float y, float delta)
    {
        if (Mathf.Abs(x - y) < delta) return true;
        else return false;
    }

    //You shouldn't need to change the following function
    public void Shoot()
    {
        if (Input.GetMouseButtonDown(0)) //If pressing left
        {
            //Define projectile properties
            shot.isFriendly = isFriendly;
            shot.speed = projectileSpeed;
            shot.attackPower = attackBoost;
            shot.range = range;
            shot.spread = spread;
            //Create projectile clone with defined properties
            shot.transform.localScale = new Vector3(spread, spread, spread);
            shot.transform.forward = transform.forward;
            Instantiate(shot, new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z), transform.rotation);

        }
    }
}
