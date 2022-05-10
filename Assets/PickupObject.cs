using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour , IPickupable
{
    public PickupType PickUpObject;

    public void OnDestory()
    {
        Destroy(this.gameObject);
    }

    public PickupType ReturnType()
    {
        return PickUpObject;
    }
}
