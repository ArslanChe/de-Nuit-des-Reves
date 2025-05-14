using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour{
    public Collider2D collider2D;
    private Animator animator;

    public int health = 3;
    public float invulnerabilityTime = 6f;

    public UnityEvent<int> OnPlayerHealthChange = new UnityEvent<int>();
    public UnityEvent OnPlayerDeath = new UnityEvent(); 
    private bool canBeDamaged = true;

    public void DisableDamage()
    {
        canBeDamaged = false;
    }

    public int getHealth(){
        return health;
    }

    private void Start() {
        animator = GetComponent<Animator>();
        OnPlayerHealthChange.Invoke(health);
    }

    public void takeDamage(){
        if (!canBeDamaged) return;
        
        health -= 1;
        OnPlayerHealthChange.Invoke(health);
        // animator.SetTrigger("hit");
        if (health <= 0){
            collider2D.enabled = false;
            animator.SetTrigger("death");
            FindObjectOfType<GameOverManager>().ShowGameOver();

        } else {
            Invulnerability();
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        Enemy enemy = other.gameObject.GetComponent<Enemy>();
        if (enemy != null && health > 0){
            takeDamage();
        }
    }

    public void finishHit(){
        // animator.ResetTrigger("hit");
    }

    void Invulnerability(){
        StartCoroutine(BlinkSprite());
        StartCoroutine(StartInvulnerability());
    }

    IEnumerator StartInvulnerability(){
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Enemy"), true);
        yield return new WaitForSeconds(invulnerabilityTime);
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Enemy"), false);
    }

    IEnumerator BlinkSprite(){
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        for (int i = 0; i < 6; i++){
            spriteRenderer.color = new Color(1f,1f,1f,0.5f);
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.color = new Color(1f,1f,1f,1f);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
