using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowJump : MonoBehaviour
{
    public Rigidbody2D rig;
    //public Collider2D coll;
    public RubyController player;


    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        //coll = GetComponent<Collider2D>();
        //coll.enabled = false;
    }

    //void OnTriggerStay2D(Collider2D collision)
    //{
    //    Debug.Log(collision.name);

    //    if(collision.bounds.Contains(player.GetComponent<Collider2D>().bounds.min) && collision.bounds.Contains(player.GetComponent<Collider2D>().bounds.max))
    //    {
    //        player.ChangeHealth(-99);
    //    }

    //    //if (collision.tag == "Terrain")
    //    //{
    //    //    player.ChangeHealth(-99);
    //    //    enabled = false;
    //    //}
    //}
    
    // Update is called once per frame
    void Update()
    {
        
    }


}
