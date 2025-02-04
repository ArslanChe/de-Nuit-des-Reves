using UnityEngine;

public class SlimeBossController : MonoBehaviour
{
    public float moveSpeed = 2f;
    public Vector2 centerPosition = new Vector2(0, 0);
    public float attackCooldown = 5f;

    private float nextAttackTime = 0f;
    private bool isAtCenter = false;

    private SlimeAttack slimeAttack;
    private Animator animator;

    void Start()
    {
        slimeAttack = GetComponent<SlimeAttack>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (isAtCenter)
        {
            if (Time.time >= nextAttackTime)
            {
                nextAttackTime = Time.time + attackCooldown;
                //slimeAttack.AttackWithSlime();
            }
        }
        else
        {
            MoveToCenter();
        }
    }

    void MoveToCenter()
    {
        if ((Vector2)transform.position != centerPosition)
        {
            transform.position = Vector2.MoveTowards(transform.position, centerPosition, moveSpeed * Time.deltaTime);
        }
        else
        {
            isAtCenter = true;
        }
    }
}