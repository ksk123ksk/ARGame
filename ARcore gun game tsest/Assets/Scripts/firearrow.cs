using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firearrow : MonoBehaviour
{
    Ray ray;
    string getObjName;
    RaycastHit hit;
    public Camera FirstPersonCamera;


    public GameObject arrow;
    public Transform arrowStart;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ButtonClick()
    {
        GameObject arrowclone = Instantiate(arrow, transform.position, transform.rotation) as GameObject;
        Rigidbody rb = arrowclone.GetComponent<Rigidbody>();
        RayGun();
        
    }
    public void RayGun()
    {
        Vector3 forward = FirstPersonCamera.transform.TransformDirection(Vector3.forward) * 1000;
        if (Physics.Raycast(FirstPersonCamera.transform.position, FirstPersonCamera.transform.forward, out hit, 1000))
        {
            getObjName = hit.transform.name;
        }
        Instantiate(arrow, arrowStart.position, arrowStart.rotation);
    }
}
