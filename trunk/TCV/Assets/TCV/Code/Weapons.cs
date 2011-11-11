using UnityEngine;
using System.Collections;

public class Weapons : MonoBehaviour
{
	


    //Properties
    public int weaponAttack;
    public float weaponRange;
    public float weaponSpread;
    public float weaponProjectileSpeed;
    public float weaponFireRate;
	public int weaponModelIndex;
    float timeSinceLastFire = 0;
    public float currentTime = 0;
	public Projectile shot;
	
	void Start(){
    }
	
	void Update(){
    }
	

    public void setWeapon(int attack, float range, float spread, float speed, float rate, int modelIndex, Projectile pShot)
    {
		
        weaponAttack = attack;
        weaponRange = range;
        weaponSpread = spread;
        weaponProjectileSpeed = speed;
        weaponFireRate = rate;
		weaponModelIndex = modelIndex;
		shot = pShot;
    }

    public void setWeapon(Weapons weapon)
    {
		setWeapon(weapon.weaponAttack,weapon.weaponRange,weapon.weaponSpread,
			                        weapon.weaponProjectileSpeed,weapon.weaponFireRate, weapon.weaponModelIndex, weapon.shot);
    }

    public void Shoot(bool isFriendly, Transform rotation, int baseAttack)
    {
        if (currentTime > weaponFireRate)
        {
            //Define projectile properties
            shot.isFriendly = isFriendly;
            shot.speed = weaponProjectileSpeed;
            shot.totalAttack = weaponAttack + baseAttack;
            shot.range = weaponRange;
            shot.spread = weaponSpread;
            //Create projectile clone with defined properties
            shot.transform.localScale = new Vector3(weaponSpread, weaponSpread, weaponSpread);
            shot.transform.forward = transform.forward;
            shot.transform.rotation = rotation.rotation;
            shot.transform.RotateAround(rotation.up, -Mathf.PI / 2);
            Instantiate(shot, new Vector3(rotation.position.x, rotation.position.y + 0.2f, rotation.position.z), shot.transform.rotation);
            currentTime = 0;
        }
            
	}
}
