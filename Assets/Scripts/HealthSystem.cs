using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    private Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
    }

    public void ChangeMaxHealth(float MaxHealth)
    {
        slider.maxValue = MaxHealth;
        
    }

    public void ChangeNowHealth(float countHealth)
    {
        slider.value = countHealth;
    }

    public void InitHealth(float Health)
    {
        ChangeMaxHealth(Health);
        ChangeNowHealth(Health);
    }
}
