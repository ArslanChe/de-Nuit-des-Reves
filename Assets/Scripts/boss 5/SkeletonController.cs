using UnityEngine;

public class SkeletonController : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float attackRange = 2f;
    private Transform player;
    private SkeletonMeleeAttack meleeAttack;
    private SkeletonShieldBlock shieldBlockScript;
    private SkeletonSkullAttack skullAttack;
    private SkeletonBoneExplosion boneExplosion;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        meleeAttack = GetComponent<SkeletonMeleeAttack>();
        shieldBlockScript = GetComponent<SkeletonShieldBlock>();
        skullAttack = GetComponent<SkeletonSkullAttack>();
        boneExplosion = GetComponent<SkeletonBoneExplosion>();
    }

    void Update()
    {
        MoveTowardsPlayer();

        if (Vector2.Distance(transform.position, player.position) <= attackRange)
        {
            //meleeAttack.PerformMeleeAttack();
        }
    }

    void MoveTowardsPlayer()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }
}