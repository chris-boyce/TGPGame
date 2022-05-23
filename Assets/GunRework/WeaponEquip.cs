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

    [Header("Gun Gameobjects Currently On the Player")]
    public GameObject SniperGO;
    public GameObject SMGGO;
    public GameObject AKGO;
    public GameObject AutoPistolGO;
    public GameObject PistolGO;
    public GameObject M16GO;
    public GameObject ShotgunGO;

    [Header("Player Left Right Hand")]
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


        //GunsGO[0] = Instantiate(AWP.GunObject, transform, false);
        //GunsGO[1] = Instantiate(SMG.GunObject, transform , false);
        //GunsGO[2] = Instantiate(AK47.GunObject, transform, false);
        //GunsGO[3] = Instantiate(Pistol.GunObject, transform , false);
        //GunsGO[4] = Instantiate(M16_Burst.GunObject, transform , false);
        //GunsGO[5] = Instantiate(Pistol_Auto.GunObject, transform , false);
        //GunsGO[6] = Instantiate(SuperShotgun.GunObject, transform, false);
        //Hides All objects
        DisableGuns();
    }

    void DisableGuns()
    {
        SniperGO.SetActive(false);
        SMGGO.SetActive(false);
        AKGO.SetActive(false);
        AutoPistolGO.SetActive(false);
        ShotgunGO.SetActive(false);
        PistolGO.SetActive(false);
        M16GO.SetActive(false);

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
                    AKGO.SetActive(true);  //Activates that gun so it can be seen
                    break;
                case PickupType.AutoPistol:
                    CurrentIGUN = Pistol_Auto as IGun;
                    CurrentGunObject = Pistol_Auto.GunObject;
                    AutoPistolGO.SetActive(true);
                    break;
                case PickupType.Empty:
                    //Hand Empty
                    break;
                case PickupType.M16:
                    CurrentIGUN = M16_Burst as IGun;
                    CurrentGunObject = M16_Burst.GunObject;
                    M16GO.SetActive(true);
                    break;
                case PickupType.P90:
                    CurrentIGUN = SMG as IGun;
                    CurrentGunObject = SMG.GunObject;
                    SMGGO.SetActive(true);
                    break;
                case PickupType.Pistol:
                    CurrentIGUN = Pistol as IGun;
                    CurrentGunObject = Pistol.GunObject;
                    PistolGO.SetActive(true);
                    break;
                case PickupType.Shotgun:
                    CurrentIGUN = SuperShotgun as IGun;
                    CurrentGunObject = SuperShotgun.GunObject;
                    SuperShotgun.Timer = 1f;
                    ShotgunGO.SetActive(true);
                    break;
                case PickupType.Sniper:
                    CurrentIGUN = AWP as IGun;
                    CurrentGunObject = AWP.GunObject;
                    AWP.Timer = 2f;
                    SniperGO.SetActive(true);
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
                weaponHeld = PistolGO;
                break;
            case PickupType.Sniper:
                weaponHeld = SniperGO;
                break;
            case PickupType.AutoPistol:
                weaponHeld = AutoPistolGO;
                break;
            case PickupType.P90:
                weaponHeld = SMGGO;
                break;
            case PickupType.AK:
                weaponHeld = AKGO;
                break;
            case PickupType.M16:
                weaponHeld = M16GO;
                break;
            case PickupType.Shotgun:
                weaponHeld = ShotgunGO;
                break;

        }
        return weaponHeld;
    }
    public void WeaponMaxAmmo()
    {
        AWP.GunReserveAmmo = AWP.GunMaxAmmo;
        SMG.GunReserveAmmo = SMG.GunMaxAmmo;
        AK47.GunReserveAmmo = AK47.GunMaxAmmo;
        Pistol.GunReserveAmmo = Pistol.GunMaxAmmo;
        M16_Burst.GunReserveAmmo = M16_Burst.GunMaxAmmo;
        Pistol_Auto.GunReserveAmmo = Pistol_Auto.GunMaxAmmo;
        SuperShotgun.GunReserveAmmo = SuperShotgun.GunMaxAmmo;
    }

    private void UpdateHands()
    {
        handL.UpdateHeldItem();
        handR.UpdateHeldItem();
    }
}
