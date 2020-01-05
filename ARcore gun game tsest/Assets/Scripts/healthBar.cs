using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthBar : MonoBehaviour
{
    // Start is called before the first frame update
    public const int maxHealth = 1000;
    public int currentHealth;
    //血量條
    public RectTransform HealthBar, Hurt;

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

        //呈現傷害量

        if (Hurt.sizeDelta.x > HealthBar.sizeDelta.x)
        {
            //讓傷害量(紅色血條)逐漸追上當前血量            
            Hurt.sizeDelta += new Vector2(-1, 0) * Time.deltaTime * 100;
        }
    }
}
