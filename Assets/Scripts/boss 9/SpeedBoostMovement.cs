using UnityEngine;

public class SpeedBoostMovement : MonoBehaviour
{
    public float normalSpeed = 5f;
    public float boostedSpeed = 15f;
    public float boostDuration = 3f;
    private float speed;
    private float boostEndTime = 0f;

    void Start()
    {
        speed = normalSpeed;
    }

    void Update()
    {
        if (Time.time < boostEndTime)
        {
            speed = boostedSpeed;
        }
        else
        {
            speed = normalSpeed;
        }

        MoveBoss();
    }

    void MoveBoss()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(horizontal, 0, vertical) * speed * Time.deltaTime;
        transform.Translate(move, Space.World);
    }

    public void ActivateSpeedBoost()
    {
        boostEndTime = Time.time + boostDuration;
    }
}