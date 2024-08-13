using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.InputSystem;

public class Lookat : MonoBehaviour
{
    float angle;

    public Vector2 direction;

    private Vector2 target;
    private Vector2 mouse;

    private void Start()
    {
        target = transform.position;
    }

    public void LookAt()
    {
        mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        angle = Mathf.Atan2(mouse.y - target.y, mouse.x - target.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    void Update()
    {
        LookAt();
    }
}
