using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    public int damagePerSecond = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        RubyController controller = other.GetComponent<RubyController>();
        
        if(controller != null)
        {
            controller.ChangeHealth(-damagePerSecond);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
