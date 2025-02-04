using UnityEngine;

public class SkeletonShieldBlock : MonoBehaviour
{
    public bool isBlocking = false;
    public float blockDuration = 2f;
    private float blockTime = 0f;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (isBlocking)
        {
            blockTime += Time.deltaTime;
            if (blockTime >= blockDuration)
            {
                StopBlocking();
            }
        }
    }

    public void StartBlocking()
    {
        if (!isBlocking)
        {
            isBlocking = true;
            blockTime = 0f;
            animator.SetTrigger("Block");  
            Debug.Log("Скелет блокирует урон!");
        }
    }

    public void StopBlocking()
    {
        if (isBlocking)
        {
            isBlocking = false;
            animator.SetTrigger("StopBlock");  
            Debug.Log("Скелет прекратил блокировать урон.");
        }
    }

    public bool IsBlocking()
    {
        return isBlocking;
    }
}