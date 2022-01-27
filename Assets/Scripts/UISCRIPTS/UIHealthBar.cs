using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIHealthBar : MonoBehaviour
{
    public Slider _HealthSlider;
    public Health _HealthScriptReference;

    // Update is called once per frame
    void Update()
    {
        _HealthSlider.value = _HealthScriptReference.currentHealth;
    }
}
