using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float attackCd;
    [SerializeField] private float range = 1;
    [SerializeField] private float colliderDistance;
    [SerializeField] private int damage = 1;
    [SerializeField] BoxCollider2D boxCollider;
    [SerializeField] private LayerMask playerLayer;
    private float cdTimer = Mathf.Infinity;

    private Animator anim;
    private Health playerHealth;
    
    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        cdTimer += Time.deltaTime;

        if(DetectPlayer())
        {
            if(cdTimer >= attackCd)
            {
                cdTimer = 0;
                anim.SetTrigger("attack");
            }
        }
    }
    private bool DetectPlayer()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center +transform.right * range * transform.localScale.x * colliderDistance,
        new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z)
        ,0,Vector2.left,0,playerLayer);

        if(hit.collider != null)
        {
            playerHealth = hit.transform.GetComponent<Health>();
        }

        return hit.collider != null;
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center+transform.right * range* transform.localScale.x * colliderDistance,
        new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    public void DamagePlayer()
    {
        if(DetectPlayer())
        {
            playerHealth.TakeDamage(damage);
        }

    }

    public void Immune()
    {
        boxCollider.enabled = false;
    }

    public void UnImmune()
    {
        boxCollider.enabled = true;
    }
}
