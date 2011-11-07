using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public int health = 5;
	public int defense = 1;
	public int attack = 5;
	
	public Weapons weapon;
	public Transform gunTip;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
		
		weapon.currentTime += Time.deltaTime;
        if (health <= 0) Destroy(transform.gameObject);
		
		if (Input.GetKeyDown(KeyCode.T))
		{ 
			weapon.Shoot(false,gunTip, attack);
		}
    }
}
