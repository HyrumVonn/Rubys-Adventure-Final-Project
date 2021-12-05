using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rig;
    RubyController owner;
    public ParticleSystem blamSystem;
    [SerializeField] AudioClip hitSound;
    [SerializeField] AudioClip successfulHitSound;
    
    // Start is called before the first frame update
    void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    public void Launch(Vector2 direction, float force)
    {
        rig.AddForce(direction * force);
    }

    public void SetOwner(RubyController newOwner)
    {
        owner = newOwner;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        EnemyController enemy = other.gameObject.GetComponent<EnemyController>();
        if(enemy != null)
        {
            if (enemy.cogFixable)
            {
                enemy.Fix();
                owner.CountRobotFixed();
            }
            owner.PlaySound(successfulHitSound);
        }
        else
        {
            owner.PlaySound(hitSound);
        }

        Instantiate(blamSystem, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.magnitude > 1000f)
        {
            Destroy(gameObject);
        }
    }
}
