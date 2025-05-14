using UnityEngine;

public class Laser : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D damageCollider;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        damageCollider = GetComponent<BoxCollider2D>();
        // Отключаем всё по умолчанию
        spriteRenderer.enabled = false;
        damageCollider.enabled = false;
    }

    // Вызывается из Animation Event — когда лазер появляется
    public void EnableVisual()
    {

        spriteRenderer.enabled = true;
    }

    // Вызывается из Animation Event — когда лазер начинает наносить урон
    public void EnableDamage()
    {
        

        damageCollider.enabled = true;
    }

    // Вызывается из Animation Event — когда урон отключается
    public void DisableDamage()
    {

        damageCollider.enabled = false;
    }

    // Вызывается из Animation Event — в конце, чтобы удалить лазер
    public void DestroyLaser()
    {

        Destroy(gameObject);
    }
}