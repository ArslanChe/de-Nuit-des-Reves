using UnityEngine;

public class SkeletonSkullAttack : MonoBehaviour
{
    public GameObject skullPrefab;  
    public float throwForce = 10f; 
    public float attackCooldown = 5f; 
    private float nextAttackTime = 0f;

    private Transform player;
    private Animator animator;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            ThrowSkull();
        }
    }

    void ThrowSkull()
    {
        nextAttackTime = Time.time + attackCooldown;  
        Vector2 direction = (player.position - transform.position).normalized;
        GameObject skull = Instantiate(skullPrefab, transform.position, Quaternion.identity);
        Rigidbody2D rb = skull.GetComponent<Rigidbody2D>();
        rb.linearVelocity = direction * throwForce;  

        animator.SetTrigger("ThrowSkull"); 
        Debug.Log("Скелет кидает череп!");
    }
}