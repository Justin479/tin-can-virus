using UnityEngine;
using System.Collections;


public class Player : MonoBehaviour
{
    //Weapon Properties
    bool isFriendly = true;
    public Weapons MeleeWeapon;
    public Weapons RangeWeapon;
	public Weapons SupportWeapon;
	public Weapons currentWeapon;
	
	public Transform [] weaponModels;

    //Player Properties 
    public int baseHealth = 100;    //Base
    public int basePower = 25;
    public int baseAttack = 1;
    public int baseDefense = 0;
    public int baseSpeed = 3;
    public float baseSalvageRate = 1;
    public int currentHealth; //Current
    public int currentPower;
	public int skillPoints = 0;

    //Refrenced GameObjects
    public Transform cameraRef;     //Refrence to camera
	public Abilities abilities;

    //Stance Variables
    const int MELEE = 0;
    const int RANGE = 1;
    const int SUPPORT = 2;
    public int currentStance = MELEE;

    //Crosshair variables
    public Texture2D crossHair;
    Rect crossHairPos;

    //Control Variables
    KeyCode SwitchToMelee = KeyCode.Alpha1;
    KeyCode SwitchToRange = KeyCode.Alpha2;
    KeyCode SwitchToSupport = KeyCode.Alpha3;

    void Start()
    {
		
		//Calculates crosshair position.
        crossHairPos = new Rect((Screen.width - crossHair.width)/2, (Screen.height -
            crossHair.height)/2, crossHair.width, crossHair.height);
		
		currentWeapon.setWeapon(MeleeWeapon);
		//turns off all weapon models except the model for current weapon
		for (int i = 0; i< weaponModels.Length; i++)
		{
			if (currentWeapon.weaponModelIndex != i)
			weaponModels[i].gameObject.SetActiveRecursively(false);	
		}
    }

    void Update()
    {
        currentWeapon.currentTime += Time.deltaTime;

		//Shoot
        if (Input.GetMouseButtonDown(0)) //If pressing left
        {
            currentWeapon.Shoot(true,cameraRef,baseAttack);
        }
		
		//Use ability A
		if (Input.GetMouseButtonDown(1))
		{
			abilities.useAbilityA();
		}
		
		//Use ability B
		if (Input.GetKeyDown(KeyCode.LeftShift))
		{
			abilities.useAbilityB();
		}
		
		
		//Switch Stances
        if (Input.GetKeyDown(SwitchToMelee))
		{
			currentStance = MELEE; //Change to melee stance
			currentWeapon.setWeapon(MeleeWeapon);
			changeWeaponModel();
			

		}
        if (Input.GetKeyDown(SwitchToRange)) 
		{
			currentStance = RANGE; //Change to range stance
			currentWeapon.setWeapon(RangeWeapon);
			changeWeaponModel();

		}
        if (Input.GetKeyDown(SwitchToSupport))
		{
			currentStance = SUPPORT; //Change to support stance
			currentWeapon.setWeapon(SupportWeapon);
			changeWeaponModel();
		}
		
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.LoadLevel("MainMenu");
		}

    }

    //Draw Crosshair
    void OnGUI()
    {
        GUI.DrawTexture(crossHairPos, crossHair);
    }
	
	public void changeWeaponModel()
	{
		//turns off all weapon models except the model for current weapon
		for (int i = 0; i< weaponModels.Length; i++)
		{
			if (currentWeapon.weaponModelIndex != i)
				weaponModels[i].gameObject.SetActiveRecursively(false);
			else
				weaponModels[i].gameObject.SetActiveRecursively(true);
		}
			
	}
	
	//void OnControllerColliderHit(ControllerColliderHit hit)
	//{
	//	if (hit.gameObject.CompareTag("Projectile")) 
	//}
}
