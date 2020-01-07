using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthBar : MonoBehaviour
{
    // Start is called before the first frame update
    public const int maxHealth = 1000;
    public int currentHealth;
    //血量條
    public RectTransform HealthBar;

    void Start()
    {
        currentHealth = maxHealth;      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int damage)
    {
        currentHealth = currentHealth - damage;
        HealthBar.sizeDelta = new Vector2(currentHealth, HealthBar.sizeDelta.y);


    }
}
