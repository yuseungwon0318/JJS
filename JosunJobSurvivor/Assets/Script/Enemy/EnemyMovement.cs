using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyMovement : MonoBehaviour
{
    public GameObject target;
    float angle;
    float speed = 2f;

    private void Update()
    {
        //angle = Mathf.Atan2(target.transform.position.y - transform.position.y, target.transform.position.x - transform.position.x) * Mathf.Rad2Deg;
        //this.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

        transform.Translate((target.transform.position - transform.position) * speed * Time.deltaTime);
    }


}
