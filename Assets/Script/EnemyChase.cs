using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    [SerializeField]float speed;
    [SerializeField] Transform target;
    [SerializeField] float minimumDistance;
    [SerializeField] float detectDistance;
    private bool isFacingRight = true;
    private Animator anim;
    Health enemyHealth;
    [SerializeField] private Rigidbody2D rb;

    void Awake()
    {
        anim = GetComponent<Animator>();
        enemyHealth = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null) {return;}
        if(Vector2.Distance(transform.position,target.position) <= detectDistance && target != null)
        {
            ChasePlayer();
        }
        else
        {
            anim.SetBool("isWalk",false);
        }
        if(enemyHealth.CurrentHealth >0)
        {
            Flip();
        }
        
    }

    private void ChasePlayer()
    {
        if(target == null) {return;}
        if (Vector2.Distance(transform.position, target.position) > minimumDistance && enemyHealth.CurrentHealth !=0)
        {
            anim.SetBool("isWalk",true);
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else
        {
            anim.SetBool("isWalk",false);
        }
    }

    private void OnDrawGizmosSelected() 
    {
        Gizmos.DrawWireSphere(transform.position, detectDistance);
    }

    private void Flip() 
    {
        if(IsPlayerRight() && !isFacingRight || !IsPlayerRight() && isFacingRight)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }

    }

    private bool IsPlayerRight()
    {
        return(target.position.x > transform.position.x);
    }
}
