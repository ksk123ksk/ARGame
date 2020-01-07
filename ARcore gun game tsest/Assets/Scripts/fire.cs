using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{
    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.up * Speed;
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject, 5);
    }
    void OnTriggerEnter(Collider GetObj)
    {
        if (GetObj.gameObject.tag == "enemy")
            Destroy(this.gameObject);
    }
}
