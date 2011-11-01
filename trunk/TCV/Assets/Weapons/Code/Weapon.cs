using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

    //Standard properties; All weaons will have these; Change these to generate different weapons.
    public Projectile shot;
    public bool isFriendly = true;
    public float attackBoost = 5;
    public float range = 5f;
    public float spread = 1;
    public float projectileSpeed = 20;
    public Transform cameraRef;

	void Start () {}
	
	void Update () {
        
        Shoot();

        if (Input.GetKeyDown(KeyCode.Alpha4))   //Change to melee weapon (Hard to visualize in game, but it is there)
            changeWeapon(1, 0.5f, 20, 2);
        if (Input.GetKeyDown(KeyCode.Alpha5))   //Change to range weapon
            changeWeapon(20, 5, 5, 1);

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
            Instantiate(shot, new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z), cameraRef.rotation);
        
        }
    }

    //Used to upgrade/change weapon
    public void changeWeapon(float pSpeed, float pRange, float pPower, float pSpread)
    {
        projectileSpeed = pSpeed;
        range = pRange;
        attackBoost = pPower;
        spread = pSpread;
    }
}
