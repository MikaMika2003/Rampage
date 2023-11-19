using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This class is not complete as yet but these are the basic fundamentals until
// the character and npcs have been implemented
public class HealthBarManager : MonoBehaviour
{
    
    // slider for the health bar 
    Slider _healthSlider;

    // Gets the slider component
    private void Start()
    {
        _healthSlider = GetComponent<Slider>();
    }

    // sets the max health possible
    public void SetMaxHealth(int maxHealth)
    {
        _healthSlider.maxValue = maxHealth;
        _healthSlider.value = maxHealth;
    }

    // sets the health value 
    public void SetHealth(int health)
    {
        _healthSlider.value = health;
    }


}
