using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    [SerializeField] private bool isPlayer;
    [SerializeField] private ParticleSystem hitParticle;

    [SerializeField] private int playerDamage, enemyDamage;

    Rigidbody2D rb;
    BulletSystem bulletSystem;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bulletSystem = FindObjectOfType<BulletSystem>();

    }

    private void Update()
    {
        playerDamage = bulletSystem.playerDamage;
        enemyDamage = bulletSystem.enemyDamage;

        if (!isPlayer)
            rb.velocity = Vector2.down * bulletSpeed;

        else
            rb.velocity = Vector2.up * bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isPlayer)
        {
            var health = other.GetComponent<PlayerHealth>();

            if (health != null)
            {
                health.TakeDamage(enemyDamage);
                Destroy(gameObject);
                Instantiate(hitParticle, transform.position, Quaternion.identity);

            }
        }
        else
        {
            var health = other.GetComponent<EnemyHealth>();

            if(health != null)
            {
                health.TakeDamage(playerDamage);
                Destroy(gameObject);
                Instantiate(hitParticle, transform.position, Quaternion.identity);
            }
            
        }
        
    }
}
