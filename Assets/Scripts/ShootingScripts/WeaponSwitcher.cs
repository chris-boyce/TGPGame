using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WeaponSwitcher : MonoBehaviour
{
    private int selectedWeapon;

    public bool canSwitchWeaponToSniper;
    public bool canSwitchWeaponToMachinePistol;
    public bool canSwitchWeaponToSub;
    public bool canSwitchWeaponToAK;
    public bool canSwitchWeaponToM16;
    public bool canSwitchWeaponToShotgun;

    public Gun pistol;
    public Sniper sniper;
    public MachinePistol machinePistol;
    public Submachinegun sub;
    public AK ak;
    public M16 m16;
    public Shotgun shotgun;

    private GameObject sniperObject;
    private GameObject machinePistolObject;
    private GameObject subObject;
    private GameObject akObject;
    private GameObject m16Object;
    private GameObject shotgunObject;

    [SerializeField]
    HandIK handL;
    [SerializeField]
    HandIK handR;

    // Start is called before the first frame update
    void Start()
    {
        sniperObject = GameObject.FindGameObjectWithTag("SniperObject");
        machinePistolObject = GameObject.FindGameObjectWithTag("MachinePistol");
        subObject = GameObject.FindGameObjectWithTag("Sub");
        akObject = GameObject.FindGameObjectWithTag("AK");
        m16Object = GameObject.FindGameObjectWithTag("M16");
        shotgunObject = GameObject.FindGameObjectWithTag("Shotgun");



        canSwitchWeaponToSniper = false;
        canSwitchWeaponToMachinePistol = false;
        canSwitchWeaponToSub = false;
        canSwitchWeaponToAK = false;
        canSwitchWeaponToM16 = false;
        canSwitchWeaponToShotgun = false;
        selectedWeapon = 0;
    }

    // Update is called once per frame
    void Update()
    {
        int prevSelectedWeapon = selectedWeapon;

        // Input for each selected weapon
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedWeapon = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && canSwitchWeaponToSniper == true)
        {
            selectedWeapon = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && canSwitchWeaponToMachinePistol == true)
        {
            selectedWeapon = 2;
        }    
        if (Input.GetKeyDown(KeyCode.Alpha4) && canSwitchWeaponToSub == true)
        {
            selectedWeapon = 3;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5) && canSwitchWeaponToAK == true)
        {
            selectedWeapon = 4;
        }   
        if (Input.GetKeyDown(KeyCode.Alpha6) && canSwitchWeaponToM16 == true)
        {
            selectedWeapon = 5;
        }
        if (Input.GetKeyDown(KeyCode.Alpha7) && canSwitchWeaponToShotgun == true)
        {
            selectedWeapon = 6;
        }

        // "if" statements to turn on the weapon depending which key has been pressed
        //Sniper
        if (selectedWeapon == 0)      
        {

            pistol.objPistol.SetActive(true);
        }
        else
        {

            pistol.objPistol.SetActive(false);
        }
        //Pistol
        if (selectedWeapon == 1)
        {
            sniper.objSniper.SetActive(true);

        }
        else
        {
            sniper.objSniper.SetActive(false);

        }
        // Machine Pistol
        if (selectedWeapon == 2)
        {
            machinePistol.objMachinePistol.SetActive(true);
        }
        else
        {
            machinePistol.objMachinePistol.SetActive(false);
        }
        // Submachine gun
        if (selectedWeapon == 3)
        {
            sub.objSub.SetActive(true);
        }
        else
        {
            sub.objSub.SetActive(false);
        }
        // AK
        if (selectedWeapon == 4)
        {
            ak.objAK.SetActive(true);
        }
        else
        {
            ak.objAK.SetActive(false);
        }
        // M16
        if (selectedWeapon == 5 && canSwitchWeaponToM16 == true)
        {
            m16.objM16.SetActive(true);
        }
        else
        {
            m16.objM16.SetActive(false);
        }
        // Shotgun
        if (selectedWeapon == 6)
        {
            shotgun.objShotgun.SetActive(true);
        }
        else
        {
            shotgun.objShotgun.SetActive(false);
        }

        UpdateHands();
    }

    // Detect Weapon On Floor 
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("SniperObject"))
        {
            canSwitchWeaponToSniper = true;
            Destroy(sniperObject);
        }
        if (other.CompareTag("MachinePistol"))
        {
            canSwitchWeaponToMachinePistol = true;
            Destroy(machinePistolObject);
        } 
        if (other.CompareTag("Sub"))
        {
            canSwitchWeaponToSub = true;
            Destroy(subObject);
        }
        if (other.CompareTag("AK"))
        {
            canSwitchWeaponToAK = true;
            Destroy(akObject);
        } 
        if (other.CompareTag("M16"))
        {
            canSwitchWeaponToM16 = true;
            Destroy(m16Object);
        }
        if (other.CompareTag("Shotgun"))
        {
            canSwitchWeaponToShotgun = true;
            Destroy(shotgunObject);
        }
    }

    public GameObject GetCurrentWeapon() {
        GameObject weaponHeld = pistol.objPistol;
        switch (selectedWeapon) {
            case 0:
                weaponHeld = pistol.objPistol;
                break;
            case 1:
                weaponHeld = sniper.objSniper;
                break;
            case 2:
                weaponHeld = machinePistol.objMachinePistol;
                break;
            case 3:
                weaponHeld = sub.objSub;
                break;
            case 4:
                weaponHeld = ak.objAK;
                break;
            case 5:
                weaponHeld = m16.objM16;
                break;
            case 6:
                weaponHeld = shotgun.objShotgun;
                break;

		}
        return weaponHeld;
	}

    private void UpdateHands() {
        handL.UpdateHeldItem();
        handR.UpdateHeldItem();
	}
}
