using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSwitchInput : MonoBehaviour
{
    private WeaponSelector weaponSelector;
    public PickupType PickUpObject;
    public Button GunButton;
    public Image GunImage;
    private void Start()
    {
        weaponSelector = GameObject.Find("PlayerObject").GetComponent<WeaponSelector>();
        GunButton = GetComponent<Button>();
        GunImage = GetComponent<Image>();
        GunButton.enabled = false;
        GunImage.enabled = false;
    }
    private void Update()
    {
        if(weaponSelector.WeaponPool[PickUpObject] == true)
        {  
            if(GunButton)
            {
                GunButton.enabled = true;
                GunImage.enabled = true;
            }
        }
    }
    public void Pressed()
    {
        weaponSelector.WeaponWheelInput(PickUpObject);
    }


}
