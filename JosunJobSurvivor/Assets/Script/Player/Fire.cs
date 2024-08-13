using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public float atkSpd;
    public GameObject bullet;
    public GameObject firePos;


    IEnumerator MakeBullet()
    {
        while (true) 
        { 
            Instantiate(bullet, firePos.transform.position, firePos.transform.rotation);
            yield return new WaitForSeconds(atkSpd);
        }
    }

    private void Start()
    {
        StartCoroutine(MakeBullet());
    }

    private void FixedUpdate()
    {
        
    }

}
