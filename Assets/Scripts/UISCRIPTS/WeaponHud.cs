using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHud : MonoBehaviour
{
    public WeaponSwitcher _WeaponSwitchReference;
    public GameObject _PistolImage;
    public GameObject _SniperImage;
    public GameObject _MachinePistol;
    public GameObject _P90Image;
    public GameObject _AKImage;
    public GameObject _M16Image;
    public GameObject _ShotgunImage;
   

    // Update is called once per frame
    void Update()
    {
       
        //DONT OPEN ITS UGLY

        //FOR EACH WEAPON SELECTION - EACH CASE WILL DISABLE ALL OTHER WEAPONS AS SELECTED CHOICE , MAKE THE GUN BOUND TO INT (KEY BOARD INPUT) SELECT IMAGE ACTIVE
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

     

     
     
    }
}
