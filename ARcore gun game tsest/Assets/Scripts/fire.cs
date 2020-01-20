using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{
    public float Speedz ;
    public float Speedy ;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 5);
        //GetComponent<Rigidbody>().velocity = transform.up * Speed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, Speedy, Speedz);
        
    }
    void OnTriggerEnter(Collider GetObj)
    {
        if (GetObj.gameObject.tag == "enemy")
            Destroy(this.gameObject);
    }
}
