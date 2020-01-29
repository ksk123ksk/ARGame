using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class score : MonoBehaviour
{
    [Header("總分數")]
    public int TotalScore;
    [Header("分數的文字")]
    public Text ScoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Score(int AddScore)
    {
        TotalScore += AddScore;
        ScoreText.text = "Score:" + TotalScore;
    } 
    public void ReGame()
    {
        Time.timeScale = 1;
        Application.LoadLevel(Application.loadedLevel);
    }
}
