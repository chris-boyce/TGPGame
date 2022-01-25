using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NewBehaviourScript : MonoBehaviour
{




    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ChangeVolume(Slider volume_slider)
    {
        AudioListener.volume = volume_slider.value;

    }

}
