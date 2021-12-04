using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RubyController : MonoBehaviour
{
    Vector2 move;
    Vector2 lookDirection = new Vector2(1,0);
    public int maxHealth = 5;

    public int health { get { return currentHealth; }}
    int currentHealth;

    public float speed = 3.0f;

    public float timeInvincible = 2.0f;
    bool isInvincible;
    float invincibleTimer;

    Rigidbody2D rig;
    Animator anim;
    public Projectile proj;
    AudioSource audioSource;
    public AudioClip throwSound;
    public AudioClip hitSound;
    public ParticleSystem healEffect;
    public ParticleSystem ouchEffect;
    bool movementEnabled = true;
    int robotsFixed = 0;
    bool gameEnded = false;
    AudioSource musicPlayer;

    [SerializeField] AudioClip loseMusic;

    [SerializeField] AudioClip winMusic;

    int cogCount = 4;

    static int currentLevel = 1;

    // Start is called before the first frame update
    void Start()
    {

        musicPlayer = GameObject.FindWithTag("Music").GetComponent<AudioSource>();
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        UICogCount.instance.SetValue(cogCount);

        currentHealth = maxHealth;
        audioSource = GetComponent<AudioSource>();
    }

    public void ChangeHealth(int amount)
    {
        if(amount < 0)
        {
            if(isInvincible)
            {

            }
            else
            {
                currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
                invincibleTimer = timeInvincible;
                isInvincible = true;
                PlaySound(hitSound);
                anim.SetTrigger("Hit");
                Instantiate(ouchEffect, transform.position, Quaternion.identity);
                if(currentHealth <= 0)
                {
                    DeathProcess();
                }
            }
        }
        else
        {
            currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
            //Instantiate(healEffect, transform.position, Quaternion.identity);

            //healEffect.Play();
        }
        
        UIHealthBar.instance.SetValue(currentHealth/ (float)maxHealth);

    }

    public void PickupCogs()
    {
        cogCount += 4;
        UICogCount.instance.SetValue(cogCount);
    }

    void DeathProcess()
    {
        movementEnabled = false;
        Destroy(GetComponent<SpriteRenderer>());
        rig.simulated = false;
        UIWinText.instance.SetText("Oh no! You lost! Sad day");
        gameEnded = true;
        musicPlayer.clip = loseMusic;
        musicPlayer.Play();
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    void FixedUpdate()
    {
        Vector2 position = transform.position;
        position.x = position.x + speed * move.x * Time.deltaTime;
        position.y = position.y + speed * move.y * Time.deltaTime;

        rig.MovePosition(position);
    }

    void Launch()
    {
        

        Projectile projectile = Instantiate(proj, rig.position + Vector2.up * 0.5f, Quaternion.identity);

/*
        float tempX = Mathf.Abs(lookDirection.x);
        float tempY = Mathf.Abs(lookDirection.y);
        Vector2 tempLook = new Vector2 (1.0f , 0.0f);

        if(tempX > tempY)
        {
            if(lookDirection.x > 0)
            {
                tempLook = new Vector2 (1, 0);
            }
            else
            {
                tempLook = new Vector2 (-1, 0);
            }
        }
        else
        {
            if(lookDirection.y > 0)
            {
                tempLook = new Vector2 (0, 1);
            }
            else
            {
                tempLook = new Vector2 (0, -1);
            }

        }
        */

        projectile.Launch(lookDirection, 300);
        projectile.SetOwner(this);

        anim.SetTrigger("Launch");
    }

    public void CountRobotFixed()
    {
        robotsFixed++;
        if(robotsFixed >= 4)
        {
            switch(currentLevel)
            {
                case 1: UIWinText.instance.SetText("Talk to Jambi to visit the next level!");
                break;
                case 2: UIWinText.instance.SetText("You winned!\nCongratulate!\nGame by Hyrum");
                gameEnded = true;
                musicPlayer.clip = winMusic;
                musicPlayer.Play();
                break;
            }
        }


        UIRobotsFixed.instance.SetValue(robotsFixed);
    }

    public void GoToNextLevel()
    {
        currentLevel = 2;
        SceneManager.LoadScene("Level Dos");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        if(movementEnabled)
        {
            if(Input.GetKeyDown(KeyCode.C))
            {
                if(cogCount >= 1)
                {
                    Launch();
                    PlaySound(throwSound);
                    cogCount -= 1;
                    UICogCount.instance.SetValue(cogCount);
                }
            }

            if(Input.GetKeyDown(KeyCode.X))
            {
                RaycastHit2D hit = Physics2D.Raycast(rig.position + Vector2.up * 0.2f, lookDirection, 1.5f, LayerMask.GetMask("NPC"));
                if(hit.collider != null)
                {
                    if(robotsFixed >= 4)
                    {
                        GoToNextLevel();
                    }
                    NonPlayerCharacter npc = hit.collider.GetComponent<NonPlayerCharacter>();
                    if(npc != null)
                    {
                        npc.DisplayDialog(robotsFixed);
                    }
                }
            }
        }

        if(gameEnded)
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }


        if(isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if(invincibleTimer <= 0)
            {
                isInvincible = false;
            }
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if(movementEnabled)
        {
            move = new Vector2(horizontal, vertical);
        }

        if(!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }

        anim.SetFloat("Look X", lookDirection.x);
        anim.SetFloat("Look Y", lookDirection.y);
        anim.SetFloat("Speed", move.magnitude);
    }
}
