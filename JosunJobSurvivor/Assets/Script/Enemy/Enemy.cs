using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float health;
    public float maxHealth;
    public Rigidbody2D target;

    bool isLive;
    bool isHit;

    Rigidbody2D rigid;
    Collider2D coll;
    WaitForFixedUpdate wait;
    SpriteRenderer spriteRenderer;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        wait = new WaitForFixedUpdate();
        spriteRenderer = GetComponent<SpriteRenderer>();
        target = GameObject.Find("Player").GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 dirVec = target.position - rigid.position;
        Vector2 nextVec = dirVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
        rigid.velocity = Vector2.zero;

        if(!isLive)
        {
            Dead();
        }

    }

    
    void OnEnable()
    {
        isLive = true;

        coll.enabled = true;
        rigid.simulated = true;
        health = maxHealth;

        StartCoroutine(IsHit());
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Bullet") || !isLive)
            return;

        health -= collision.GetComponent<Bullet>().damage;
        StartCoroutine(KnockBack());
        isHit = true;
       
        
        if (health > 0)
        {
            // 애니메이션(넉백)
        }
        else
        {
            isLive = false;
            coll.enabled = false;
            rigid.simulated = false;
        }

    }

    IEnumerator KnockBack()
    {
        yield return wait; 
        Vector3 dirVec = transform.position - target.transform.position;
        rigid.AddForce(dirVec.normalized * 3, ForceMode2D.Impulse);

    }
    IEnumerator IsHit()
    {
        if(isHit)
        {
            spriteRenderer.color = Color.white;
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.color = Color.black;
            isHit = false;
        }
       
    }

    void Dead()
    {
        gameObject.SetActive(false);
    }


}
