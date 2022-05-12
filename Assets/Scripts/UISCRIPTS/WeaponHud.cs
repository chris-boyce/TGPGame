using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHud : MonoBehaviour
{
    //public WeaponSwitcher _WeaponSwitchReference;
    public WeaponSelector WeaponSelector;
    public GameObject _PistolImage;
    public GameObject _SniperImage;
    public GameObject _MachinePistol;
    public GameObject _P90Image;
    public GameObject _AKImage;
    public GameObject _M16Image;
    public GameObject _ShotgunImage;
   
    /// <summary>
    /// Chris has noticed you could use a function here. Talk to me in class
    /// </summary>

    void Update()
    {

        //DONT OPEN ITS UGLY

        //FOR EACH WEAPON SELECTION - EACH CASE WILL DISABLE ALL OTHER WEAPONS AS SELECTED CHOICE , MAKE THE GUN BOUND TO INT (KEY BOARD INPUT) SELECT IMAGE ACTIVE
        /*
        switch(_WeaponSwitchReference.selectedWeapon)
        {

            case 0:
                _PistolImage.SetActive(true);
                
                _SniperImage.SetActive(false);
                _MachinePistol.SetActive(false);
                _P90Image.SetActive(false);
                _AKImage.SetActive(false);
                _M16Image.SetActive(false);
                _ShotgunImage.SetActive(false);

                break;
            case 1:

                _SniperImage.SetActive(true);
               
                _PistolImage.SetActive(false);
                _MachinePistol.SetActive(false);
                _P90Image.SetActive(false);
                _AKImage.SetActive(false);
                _M16Image.SetActive(false);
                _ShotgunImage.SetActive(false);

                break;
            case 2:

               _MachinePistol.SetActive(true);
                
                _PistolImage.SetActive(false);
                _SniperImage.SetActive(false);
                _P90Image.SetActive(false);
                _AKImage.SetActive(false);
                _M16Image.SetActive(false);
                _ShotgunImage.SetActive(false);
                break;
            case 3:

                _P90Image.SetActive(true);
                
                _MachinePistol.SetActive(false);
                _PistolImage.SetActive(false);
                _SniperImage.SetActive(false);
                _AKImage.SetActive(false);
                _M16Image.SetActive(false);
                _ShotgunImage.SetActive(false);
                break;
            case 4:

                _AKImage.SetActive(true);
               
                _P90Image.SetActive(false);
                _MachinePistol.SetActive(false);
                _PistolImage.SetActive(false);
                _SniperImage.SetActive(false);
                _M16Image.SetActive(false);
                _ShotgunImage.SetActive(false);
                break;
            case 5:
                _M16Image.SetActive(true);

                _AKImage.SetActive(false);
                _P90Image.SetActive(false);
                _MachinePistol.SetActive(false);
                _PistolImage.SetActive(false);
                _SniperImage.SetActive(false);
                _ShotgunImage.SetActive(false);
                break;
            case 6:
                _ShotgunImage.SetActive(true);

                
                _M16Image.SetActive(false);
                _PistolImage.SetActive(false);
                _SniperImage.SetActive(false);
                _AKImage.SetActive(false);
                _P90Image.SetActive(false);
                _MachinePistol.SetActive(false);

                break;



        }
        */
        switch(WeaponSelector.CurrentWeapon)
        {
            case PickupType.AK:
                ResetHUD();
                _AKImage.SetActive(true);
                break;
            case PickupType.AutoPistol:
                ResetHUD();
                _MachinePistol.SetActive(true);
                break;
            case PickupType.Empty:
                //Hand Empty
                break;
            case PickupType.M16:
                ResetHUD();
                _M16Image.SetActive(true);
                break;
            case PickupType.P90:
                ResetHUD();
                _P90Image.SetActive(true);
                break;
            case PickupType.Pistol:
                ResetHUD();
                _PistolImage.SetActive(true);
                break;
            case PickupType.Shotgun:
                ResetHUD();
                _ShotgunImage.SetActive(true);
                break;
            case PickupType.Sniper:
                ResetHUD();
                _SniperImage.SetActive(true);
                break;
        }
        

    }
    void ResetHUD()
    {
        _PistolImage.SetActive(false);
        _SniperImage.SetActive(false);
        _MachinePistol.SetActive(false);
        _P90Image.SetActive(false);
        _AKImage.SetActive(false);
        _M16Image.SetActive(false);
        _ShotgunImage.SetActive(false);
    }
}
