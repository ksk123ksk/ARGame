using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{
    // Start is called before the first frame update
    public const int maxHealth = 1000;
    public int currentHealth;
    //血量條
    public RectTransform HealthBar;
    [Header("遊戲結束的畫面")]
    public GameObject GameOverUI;
    [Header("遊戲結束的分數文字")]
    public Text GameOverScoreText;
    [Header("分數的文字")]
    public Text ScoreText;
    


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
        if (currentHealth <= 0)
        {
            GameOverUI.SetActive(true);
            GameObject.Find("First Person Camera").GetComponent<firearrow>().shootBTNfalse();
            GameOverScoreText.text = ScoreText.text;
            Time.timeScale = 0;
        }

    }
}
