using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    Animator myAnimator;
    PlayerController playerControl;
    [SerializeField] Transform attackPoint;
    [SerializeField] float attackRange = 0.5f;
    public LayerMask enemyLayer;
    Health playerHealth;

    [SerializeField] private AudioSource punchVFX;
    [SerializeField] private AudioSource kickVFX;

    // Start is called before the first frame update
    void Start()
    {
        playerControl = GetComponent<PlayerController>();
        myAnimator = GetComponentInChildren<Animator>();
        playerHealth = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && playerHealth.CurrentHealth != 0)
        {
            Attack();
        }
    }

    private void Attack()
    {
        if(playerControl.IsGrounded())
        {
            punchVFX.Play();
            myAnimator.SetTrigger("punching");
        }
        else if(!playerControl.IsGrounded())
        {
            kickVFX.Play();
            myAnimator.SetTrigger("kicking");
        }

        //find enemies
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position,attackRange,enemyLayer);
        
        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("Hit" + enemy.name);
            enemy.GetComponent<Health>().TakeDamage(1);
        }
    }

    private void OnDrawGizmosSelected() 
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    
}
