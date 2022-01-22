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
    public GameObject sniperObject;
    public GameObject machinePistolObject;
    public GameObject subObject;
    public GameObject akObject;
    public GameObject m16Object;
    public GameObject shotgunObject;


    // Start is called before the first frame update
    void Start()
    {
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
        if (selectedWeapon == 5)
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

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        // Cycles through the weapons activating them or deactivating them
        if (prevSelectedWeapon != selectedWeapon)
        {
           SelectWeapon();
        }

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

    void SelectWeapon()
    {
        int i = 0;
        // Turns on the object that is selected
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }


    }

}
