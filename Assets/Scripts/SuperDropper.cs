using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperDropper : MonoBehaviour
{
    RubyController owner;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetOwner(RubyController newOwner)
    {
        owner = newOwner;
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        EnemyController controller = collision.GetComponent<EnemyController>();

        if (controller != null)
        {
            controller.Fix();
            owner.CountRobotFixed();
            Destroy(gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
