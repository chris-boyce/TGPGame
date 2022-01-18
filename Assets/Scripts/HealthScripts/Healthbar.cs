using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    // Start is called before the first frame update


    public Slider Slider;
    public GameObject canvas;
    public GameObject SliderPos;
    private Slider newSlider;
    public GameObject thisObject;


   public void Start()
    {
        newSlider = Instantiate(Slider, SliderPos.transform.position, SliderPos.transform.rotation);
        newSlider.transform.parent = canvas.transform;
    }

    // Update is called once per frame
   public void Update()
    {
        Vector3 healthPos = Camera.main.WorldToScreenPoint(SliderPos.transform.position);
        newSlider.transform.position = healthPos;  
    }

}
