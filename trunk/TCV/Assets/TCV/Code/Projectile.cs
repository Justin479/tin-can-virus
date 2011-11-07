using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
	public Transform StartParticle;
	public Transform EndParticle;
    public bool isFriendly = true;
    public float speed = 20;
    public int totalAttack = 1;
    public float range = 1;
    public float spread = 1;

    // Use this for initialization
    void Start()
    {
		Instantiate(StartParticle,transform.position,transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
		
        //Moves projectile forward
        transform.position = transform.position + transform.forward * (speed * Time.deltaTime);

        //If it has reached it's max range, destroy self
        if (range <= 0)
            Destroy(transform.gameObject);
        //else update range
        range -= Time.deltaTime;
        
    }
	
	void OnCollisionEnter(Collision collision)
	{
		//Enemy Fire
		if (!isFriendly && collision.gameObject.CompareTag("Player"))
		{
			Player temp = collision.gameObject.GetComponent("Player") as Player;
			int damageCalc = totalAttack - temp.baseDefense;
			if (damageCalc > 0)
				temp.currentHealth-= damageCalc;
			
			Instantiate(EndParticle,transform.position,transform.rotation);
			Destroy(transform.gameObject);
			return;
		}
		//Friendly Fire
		if (isFriendly && collision.gameObject.CompareTag("Enemy"))
		{
		
        	Enemy temp = collision.gameObject.GetComponent("Enemy") as Enemy;
                int damageCalc = totalAttack - temp.defense;
			if (damageCalc > 0)
				temp.health-= damageCalc;

			Instantiate(EndParticle,transform.position,transform.rotation);
			Destroy(transform.gameObject);
			return;
			
		}
		
		//To collide with terrain, terrain must have a rigid body, must not be isKinematic, and must have it position and rotation locked
		if (collision.gameObject.CompareTag("Terrain"))
		{
			Instantiate(EndParticle,transform.position,transform.rotation);
			Destroy(transform.gameObject);
		}

	}

}
