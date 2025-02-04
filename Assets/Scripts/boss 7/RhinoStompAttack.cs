using UnityEngine;

public class RhinoStompAttack : MonoBehaviour
{
    public float stompCooldown = 5f;
    public float waveSpeed = 5f;
    public float waveRadius = 3f;
    public int stompDamage = 40;
    private float nextStompTime = 0f;
    private Animator animator;
    public GameObject wavePrefab;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Time.time >= nextStompTime)
        {
            StompAttack();
        }
    }

    void StompAttack()
    {
        nextStompTime = Time.time + stompCooldown;
        animator.SetTrigger("Stomp"); 
        CreateStompWave();
    }

    void CreateStompWave()
    {
        GameObject wave = Instantiate(wavePrefab, transform.position, Quaternion.identity);
        Wave waveScript = wave.GetComponent<Wave>();
        waveScript.InitializeWave(waveSpeed, waveRadius, stompDamage);
    }
}