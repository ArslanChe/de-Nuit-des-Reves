using UnityEngine;

public class RhinoDirtAttack : MonoBehaviour
{
    public GameObject dirtPrefab;
    public float dirtLifetime = 5f;
    public float dirtSpeed = 3f;
    public int dirtDamage = 20;
    private Animator animator;
    private float dirtCooldown = 7f;
    private float nextDirtTime = 0f;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Time.time >= nextDirtTime)
        {
            CleanseAndReleaseDirt();
        }
    }

    void CleanseAndReleaseDirt()
    {
        nextDirtTime = Time.time + dirtCooldown;
        animator.SetTrigger("Cleanse"); 
        ReleaseDirt();
    }

    void ReleaseDirt()
    {
        GameObject dirt = Instantiate(dirtPrefab, transform.position, Quaternion.identity);
        Dirt dirtScript = dirt.GetComponent<Dirt>();
        dirtScript.InitializeDirt(dirtSpeed, dirtLifetime, dirtDamage);
    }
}