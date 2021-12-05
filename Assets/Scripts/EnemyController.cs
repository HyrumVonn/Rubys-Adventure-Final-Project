using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 1.5f;
    public bool vertical;
    public float changeTime = 3.0f;
    public int damage = 1;
    public ParticleSystem smokeEffect;
    float timer;
    int direction = 1;
    bool broken = true;
    Animator anim;
    Rigidbody2D rig;
    AudioSource brokenSound;
    public bool cogFixable = true;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        timer = changeTime;
        anim = GetComponent<Animator>();
        brokenSound = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        RubyController player = other.gameObject.GetComponent<RubyController>();
        if(player != null)
        {
            player.ChangeHealth(-damage);
        }
    }

    void FixedUpdate()
    {
        if(!broken)
        {
            return;
        }
            Vector2 position = rig.position;

        
            if(vertical)
            {
                anim.SetFloat("Move X", 0);
                anim.SetFloat("Move Y", direction);
                position.y = position.y + Time.deltaTime * speed * direction;
            }
            else
            {
                anim.SetFloat("Move X", direction);
                anim.SetFloat("Move Y", 0);
                position.x = position.x + Time.deltaTime * speed * direction;
            }
        
            rig.MovePosition(position);
        
    }

    public void Fix()
    {
        broken = false;
        rig.simulated = false;
        anim.SetTrigger("Fixed");
        smokeEffect.Stop();
        brokenSound.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if(!broken)
        {
            return;
        }

            if(timer <= 0)
            {
                timer = changeTime;
                direction = -direction;
            }
            else
            {
                timer -= Time.deltaTime;
            }
        
    }
}
