using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponEquip : MonoBehaviour
{
    private WeaponSelector weaponSelector;
    private PickupType cachedType;
    public IGun CurrentIGUN;
    private GameObject CurrentGunObject;

    //Creates Varient of Each Gun
    AWP AWP = new AWP();
    SMG SMG = new SMG();
    AK47 AK47 = new AK47();
    Pistol Pistol = new Pistol();
    M16_Burst M16_Burst = new M16_Burst();
    Pistol_Auto Pistol_Auto = new Pistol_Auto();
    SuperShotgun SuperShotgun = new SuperShotgun();

    public GameObject[] GunsGO;

    [SerializeField]
    HandIK handL;
    [SerializeField]
    HandIK handR;

    private void Start()
    {
        //Looks Up to The selector script
        weaponSelector = GetComponent<WeaponSelector>();
        //Makes Sure Gun has Game Object Loaded For "Resources"
        AWP.GetGun();
        SMG.GetGun();
        AK47.GetGun();
        Pistol.GetGun();
        M16_Burst.GetGun();
        Pistol_Auto.GetGun();
        SuperShotgun.GetGun();

        //Makes List of all Objects
        GunsGO = new GameObject[7];
        GunsGO[0] = Instantiate(AWP.GunObject, transform , false );
        GunsGO[1] = Instantiate(SMG.GunObject, transform , false);
        GunsGO[2] = Instantiate(AK47.GunObject, transform, false);
        GunsGO[3] = Instantiate(Pistol.GunObject, transform , false);
        GunsGO[4] = Instantiate(M16_Burst.GunObject, transform , false);
        GunsGO[5] = Instantiate(Pistol_Auto.GunObject, transform , false);
        GunsGO[6] = Instantiate(SuperShotgun.GunObject, transform , false);
        //Hides All objects
        DisableGuns();
    }
    void DisableGuns()
    {
        foreach (GameObject i in GunsGO)
        {
            i.SetActive(false);
        }
    }
    private void Update()
    {
        if(weaponSelector.CurrentWeapon != cachedType) //Effiency : Only Run Switch Once after weapon swap
        {
            DisableGuns();
            switch (weaponSelector.CurrentWeapon)
            {
                case PickupType.AK:             //If AK Selected
                    CurrentIGUN = AK47 as IGun; //Sets IGun to the one be fired
                    CurrentGunObject = AK47.GunObject; //Sets Gameobject
                    GunsGO[2].SetActive(true);  //Activates that gun so it can be seen
                    break;
                case PickupType.AutoPistol:
                    CurrentIGUN = Pistol_Auto as IGun;
                    CurrentGunObject = Pistol_Auto.GunObject;
                    GunsGO[5].SetActive(true);
                    break;
                case PickupType.Empty:
                    //Hand Empty
                    break;
                case PickupType.M16:
                    CurrentIGUN = M16_Burst as IGun;
                    CurrentGunObject = M16_Burst.GunObject;
                    GunsGO[4].SetActive(true);
                    break;
                case PickupType.P90:
                    CurrentIGUN = SMG as IGun;
                    CurrentGunObject = SMG.GunObject;
                    GunsGO[1].SetActive(true);
                    break;
                case PickupType.Pistol:
                    CurrentIGUN = Pistol as IGun;
                    CurrentGunObject = Pistol.GunObject;
                    GunsGO[3].SetActive(true);
                    break;
                case PickupType.Shotgun:
                    CurrentIGUN = SuperShotgun as IGun;
                    CurrentGunObject = SuperShotgun.GunObject;
                    GunsGO[6].SetActive(true);
                    break;
                case PickupType.Sniper:
                    CurrentIGUN = AWP as IGun;
                    CurrentGunObject = AWP.GunObject;
                    AWP.Timer = 2f;
                    GunsGO[0].SetActive(true);
                    break;

            }
            
        }
        cachedType = weaponSelector.CurrentWeapon;

        if (Input.GetMouseButton(0) && CurrentIGUN != Pistol)
        {
            CurrentIGUN.Fire();
        }
        if(Input.GetMouseButtonDown(0) && CurrentIGUN == Pistol)
        {
            CurrentIGUN.Fire();
        }

        UpdateHands();
    }

    public GameObject GetCurrentWeapon()
    {
        GameObject weaponHeld = CurrentGunObject;
        switch (weaponSelector.CurrentWeapon)
        {
            case PickupType.Pistol:
                weaponHeld = GunsGO[3];
                break;
            case PickupType.Sniper:
                weaponHeld = GunsGO[0];
                break;
            case PickupType.AutoPistol:
                weaponHeld = GunsGO[5];
                break;
            case PickupType.P90:
                weaponHeld = GunsGO[1];
                break;
            case PickupType.AK:
                weaponHeld = GunsGO[2];
                break;
            case PickupType.M16:
                weaponHeld = GunsGO[4];
                break;
            case PickupType.Shotgun:
                weaponHeld = GunsGO[6];
                break;

        }
        return weaponHeld;
    }

    private void UpdateHands()
    {
        handL.UpdateHeldItem();
        handR.UpdateHeldItem();
    }
}
