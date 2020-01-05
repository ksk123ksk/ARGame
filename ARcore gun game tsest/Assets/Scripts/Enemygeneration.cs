using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemygeneration : MonoBehaviour
{
    public GameObject enemy;//接收需要加載的物體
    public GameObject enemyclone;
    public Transform parent;
    public GameObject plane;
    public GameObject tower;
    public int enemyCount;//定義生成的個數
    public float WaitTime; //定義時間，讓怪物在平面創建後開始生成
    public float NextTime;//生成下一波怪物的時間間隔
    public float posX;
    public float posY;
    public float posZ;
    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(spawnWaves());//定義一個函數來限制怪物產生的時間
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator spawnWaves()

    {  
        yield return new WaitForSeconds(WaitTime); //在遊戲開始後會在waittime時間後才開始執行

        while(true)

        {
            for (int i = 0; i < enemyCount; )   
             {
                    posX = plane.transform.position.x;
                    posY = plane.transform.position.y;
                    posZ = plane.transform.position.z;
                    Vector3 enemyPosition = new Vector3(Random.Range(posX - 1.3f, posX + 1.3f), Random.Range(posY + 0.0015f, posY + 0.002f), Random.Range(posZ - 1f, posZ + 1.3f));//生成物體的隨機座標
                    Quaternion enemyRotation = Quaternion.Euler(Random.Range(0, 0), Random.Range(-45, 45), Random.Range(0, 0));//生成物體的隨機角度
                    GameObject enemyclone=Instantiate(enemy, enemyPosition, enemyRotation, parent);//生成物體   
                    enemyclone.name = "enemyclone";
                    enemyclone.SetActive(true);
                    Destroy(enemyclone, 10f);
                    enemyCount++;
                    yield return new WaitForSeconds(NextTime);//限制生成時間間隔
             }  
        }
    }
}
