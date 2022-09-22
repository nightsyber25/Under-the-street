using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int maxHealth = 5;
    [SerializeField] int currentHealth;
    [SerializeField] GameObject heartDrop;
    public int CurrentHealth {get{return currentHealth;}}
    Animator animator;
    BoxCollider2D myColider;
    Rigidbody2D rb;
    ScoreManager scoreManager;
    UIController gameCanvas;
    [SerializeField] private AudioSource onHitVFX;
    [SerializeField] private AudioSource onDeathVFX;
    
    // Start is called before the first frame update
    void Awake()
    {
        currentHealth = maxHealth;
        animator = GetComponentInChildren<Animator>();
        myColider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        scoreManager = FindObjectOfType<ScoreManager>();
        gameCanvas = FindObjectOfType<UIController>();
    }
    public void TakeDamage(int amount)
    {
        animator.SetTrigger("hurting");
        if(gameObject.tag == "Player"){
            onHitVFX.Play();
        }
        currentHealth -= amount;
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal()
    {
        if(currentHealth >= 5) 
        {
            scoreManager.IncreaseScore(1);
            return;
        }
        else
        {
            currentHealth += 1;
        }
  
    }

    private void Die()
    {
        if(gameObject.tag == "Enemy")
        {
            scoreManager.IncreaseScore(1);
            int randomHeart = Random.Range(1,100);
            if(randomHeart <= 10)
            {
                Instantiate(heartDrop,gameObject.transform.position,Quaternion.identity);
                Debug.Log("HeartDrop");
            }
            onDeathVFX.Play();
        }
        else if(gameObject.tag == "Player")
        {
            gameCanvas.GameOverScene();
        }
        else if(gameObject.tag == "Boss")
        {
            Instantiate(heartDrop,gameObject.transform.position,Quaternion.identity);
            scoreManager.IncreaseScore(10);
            gameCanvas.WinGameScene();
            Destroy(gameObject);
            
        }
        
        myColider.enabled = false;
        rb.isKinematic = true;
        animator.SetTrigger("death");
        Destroy(gameObject,1f);
    }
}
