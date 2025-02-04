using UnityEngine;

public class SkeletonBoneExplosion : MonoBehaviour
{
    public GameObject bonePrefab; 
    public int boneCount = 10;  
    public float explosionForce = 5f; 
    public float explosionRadius = 3f;  
    public int explosionDamage = 30;  
    public float cooldownTime = 8f; 
    private float nextExplosionTime = 0f;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Time.time >= nextExplosionTime)
        {
            PerformBoneExplosion();
        }
    }

    void PerformBoneExplosion()
    {
        nextExplosionTime = Time.time + cooldownTime; 

        animator.SetTrigger("Explode"); 
        Debug.Log("Скелет взрывается костями!");

        for (int i = 0; i < boneCount; i++)
        {
            GameObject bone = Instantiate(bonePrefab, transform.position, Quaternion.identity);
            Rigidbody2D rb = bone.GetComponent<Rigidbody2D>();

            Vector2 randomDirection = Random.insideUnitCircle.normalized;  
            rb.linearVelocity = randomDirection * explosionForce; 

            bone.GetComponent<Bone>().SetDamage(explosionDamage);  
            Destroy(bone, 2f); 
        }
    }
}