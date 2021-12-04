using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableCogs : MonoBehaviour
{
    public AudioClip collectedClip;
    public ParticleSystem particleSystem;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        RubyController controller = other.GetComponent<RubyController>();
        
        if(controller != null)
        {
            Instantiate(particleSystem, transform.position, Quaternion.identity);
            controller.PlaySound(collectedClip);
            controller.PickupCogs();
            Destroy(gameObject);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
