using UnityEngine;
using System.Collections;

public class Abilities : MonoBehaviour {
	
	public Player player;
	
	//Upgradable properties
	int guardAmount = 10;
	float disruptRadius = 1;
	int recoverAmount = 10;
	int powerThrustPower = 10;
	int zoomPower = 10;
	int boostAmount = 5;
	int boostAmountTemp = 0; //Variable used to reset stats after boost
	
	//Stat boost variables
	public float boostTime = 10;
	public float boostTimeCurrent = 0;
	public float guardTime = 10;
	public float guardTimeCurrent = 0;
	public int boostType = -1; //(0 = attack, 1 = speed, 2 = salvage rate, 3 = defence, -1 = none)
	
	//upgradeIncrements
	int deltaGuardAmount = 5;
	float deltaDisruptRadius = .5f;
	int deltaRecoverAmount = 5;
	int deltaPowerThrustPower = 5;
	int deltaZoomPower = 5;
	int deltaBoostAmount = 5;
	
	//Cost to use ability
	public int guardCost = 5;
	public int disruptCost = 5;
	public int recoverCost = 5;
	public int thrustCost = 5;
	public int zoomCost = 5;
	public int boostCost = 5;
	
	//Work variables

	//Particles
	public Transform RecoverParticle;
	public Projectile powerThrustProjectile;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		//Update Time
		if (boostTimeCurrent > 0) boostTimeCurrent -= Time.deltaTime;
		else if (boostType != -1) resetStats();
		
		
		if (guardTimeCurrent > 0) guardTimeCurrent -= Time.deltaTime;
	}
	
	public void useAbilityA()
	{
		switch (player.currentStance)
		{
		case 0:		Guard(); break;
		case 1:		DisruptWave(); break;
		default: 	Recover(); break;
		}
	}
	
	public void useAbilityB()
	{
		switch (player.currentStance)
		{
		case 0:		PowerThrust(); break;
		case 1:		Zoom(); break;
		default: 	RandoBoost(); break;
		}
	}
	
	//########### Ability implementation ###########//
	void Guard()
	{
	}
	
	void DisruptWave()
	{
		
	}
	
	void Recover()
	{
		if (player.currentPower < recoverCost || player.currentHealth == player.baseHealth) return;
		Instantiate(RecoverParticle,transform.position + transform.forward * 2,transform.rotation);
		player.currentHealth += recoverAmount;
		if (player.currentHealth > player.baseHealth) player.currentHealth = player.baseHealth;
		player.currentPower -= recoverCost;
	}
	
	void PowerThrust()
	{
		if (player.currentPower < thrustCost) return;
		
	    //Define projectile properties
        powerThrustProjectile.isFriendly = true;
        powerThrustProjectile.speed = 20;
        powerThrustProjectile.totalAttack = powerThrustPower;
        powerThrustProjectile.range = 1;
        powerThrustProjectile.spread = 2;
        //Create projectile clone with defined properties
        powerThrustProjectile.transform.localScale = new Vector3(2,2,2);
        powerThrustProjectile.transform.forward = transform.forward;
        powerThrustProjectile.transform.rotation = transform.rotation;
        Instantiate(powerThrustProjectile, transform.position + transform.forward * 3 + new Vector3(0,1,0),
		            powerThrustProjectile.transform.rotation);
		
		player.currentPower -= thrustCost;
	}
	
	void Zoom()
	{
		
	}
	
	void RandoBoost()
	{
		if (player.currentPower <  boostCost || boostTimeCurrent > 0) return;
		Instantiate(RecoverParticle,transform.position + transform.forward * 2,transform.rotation);
		boostType = Random.Range(0,2);
		switch (boostType)
		{
			case 0: player.baseAttack += boostAmount; 		break;
			case 1: player.baseSpeed += boostAmount;		break;
			case 2: player.baseSalvageRate += boostAmount;	break;
		}
		
		boostAmountTemp = boostAmount;
		boostTimeCurrent = boostTime;
		player.currentPower -= boostCost;
	}
	
	//########### Upgrade functions ###########//
	public bool UpgradeGuard(int cost)
	{
		if (player.skillPoints < cost) return false;
		guardAmount += deltaGuardAmount;
		player.skillPoints -= cost;
		return true;
	}
	
	public bool UpgradeDisruptWave(int cost)
	{
		if (player.skillPoints < cost) return false;
		disruptRadius += deltaDisruptRadius;
		player.skillPoints -= cost;
		return true;
	}
	
	public bool UpgradeRecover(int cost)
	{
		if (player.skillPoints < cost) return false;
		recoverAmount += deltaRecoverAmount;
		player.skillPoints -= cost;
		return true;
	}
	
	public bool UpgradePowerThrust(int cost)
	{
		if (player.skillPoints < cost) return false;
		powerThrustPower += deltaPowerThrustPower;
		player.skillPoints -= cost;
		return true;
	}
	
	public bool UpgradeZoom(int cost)
	{
		if (player.skillPoints < cost) return false;
		zoomPower += deltaZoomPower;
		player.skillPoints -= cost;
		return true;
	}
	
	public bool UpgradeRandoBoost(int cost)
	{
		if (player.skillPoints < cost) return false;
		boostAmount += deltaBoostAmount;
		player.skillPoints -= cost;
		return true;
	}
	
	//########### Work functions ###########//
	void resetStats()
	{
		
		Debug.Log("BoostEnd");
		switch (boostType)
		{
			case 0: player.baseAttack -= boostAmountTemp; 		break;
			case 1: player.baseSpeed -= boostAmountTemp; 		break;
			case 2: player.baseSalvageRate -= boostAmountTemp; 	break;
		}
		boostType = -1;
	}
	
}
