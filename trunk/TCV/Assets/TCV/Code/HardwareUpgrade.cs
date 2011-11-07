using UnityEngine;
using System.Collections;

public class HardwareUpgrade : MonoBehaviour {
	
	public Weapons weapon;
	public bool isMeleeUpgrade = true;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	//transform.position = transform.position + new Vector3(1 * Time.deltaTime,0,0);
	}
	
	
	void OnTriggerEnter(Collider other)
	{	
		if (other.gameObject.CompareTag("Player"))
		{
			//Change weapon
			Player temp = other.gameObject.GetComponent("Player") as Player;
			if (isMeleeUpgrade) temp.MeleeWeapon = weapon;
			else temp.RangeWeapon = weapon;
			
			//Update current weapon
			if (temp.currentStance == 0) temp.currentWeapon.setWeapon(temp.MeleeWeapon);
			if (temp.currentStance == 1) temp.currentWeapon.setWeapon(temp.RangeWeapon);
			temp.changeWeaponModel();
			
			Destroy(gameObject);
		}
	}
}
