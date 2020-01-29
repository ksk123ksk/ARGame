using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyController : MonoBehaviour
{
    public GameObject tower;
    public Animator enemyAnimator;
   // public float speed = 0.005f;
    private float firstSpeed;//紀錄第一次移動的距離
    public int i=1;
    public int AddScore;



    // Start is called before the first frame update
    void Start()
    {
        enemyAnimator = GetComponent<Animator>();
       // firstSpeed = Vector3.Distance(transform.position, tower.transform.position) * speed;
        if (System.Math.Abs(tower.transform.position.z - transform.position.z) <= 1.2f || System.Math.Abs(tower.transform.position.x - transform.position.x)<=0.7f)
        {
            enemyAnimator.Play("Walk");
        }
        else 
        {
            enemyAnimator.Play("Run"); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (i == 1)
        {
            Vector3 dir = tower.transform.position - transform.position;
            dir.y = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 0.3f);
            transform.position = Vector3.Lerp(transform.position, tower.transform.position, 0.02f);
            // speed = calculateNewSpeed();
        }  
    }
    /*private float calculateNewSpeed()
    {
        //因為每次移動都是 Obj 在移動，所以要取得 Obj 和 PathB 的距離
        float tmp = Vector3.Distance(transform.position, tower.transform.position);

        //當距離為0的時候，就代表已經移動到目的地了。
        if (tmp == 0)
            return tmp;
        else
            return (firstSpeed / tmp);
    }*/
    /// <summary>
    /// 碰到塔(攻擊)
    /// </summary>
    /// <param name="other"></param>
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "RoundTower_High")
        {
            i = 2;
            //InvokeRepeating("enemyattack",0,5);
            StartCoroutine(enemyattack());
        }
    }
    /// <summary>
    /// 被箭射到(死亡)
    /// </summary>
    /// <param name="GetObj"></param>
    private void OnTriggerEnter(Collider GetObj)
    {
        
        StopCoroutine(enemyattack());
        if (GetObj.GetComponent<Collider>().tag == "arrow")
        {
            Debug.Log("射中");
            GameObject.Find("PlanePOS").GetComponent<score>().Score(AddScore);
            Destroy(this.gameObject);
        }
    }
    IEnumerator enemyattack()
    {
        while (true)
        {
            transform.position = Vector3.Lerp(transform.position, tower.transform.position, 0);
            enemyAnimator.Play("RoundKick");
            yield return new WaitForSeconds(2);
            tower.GetComponent<healthBar>().TakeDamage(50);
            yield return new WaitForSeconds(3);
        }
    }  
}
