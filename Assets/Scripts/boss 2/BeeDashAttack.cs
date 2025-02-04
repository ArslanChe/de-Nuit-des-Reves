using UnityEngine;

public class BeeDashAttack : MonoBehaviour
{
    public float dashSpeed = 15f;
    public float dashCooldown = 5f;
    public float dashDuration = 0.4f;
    
    private Transform player;
    private Rigidbody2D rb;
    private bool isDashing = false;
    private float nextDashTime = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player == null || Time.time < nextDashTime || isDashing) return;

        StartDash();
        nextDashTime = Time.time + dashCooldown;
    }

    void StartDash()
    {
        isDashing = true;
        Vector2 dashDirection = new Vector2(Mathf.Sign(player.position.x - transform.position.x), 0);
        rb.linearVelocity = dashDirection * dashSpeed;

        Invoke("StopDash", dashDuration);
    }

    void StopDash()
    {
        rb.linearVelocity = Vector2.zero;
        isDashing = false;
    }
}