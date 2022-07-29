using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    // Start is called before the first frame update
    [Range(0.0f, 10.0f)]
    public float bulletSpeed;
    void Start()
    {
        Destroy(this, 10);
       

    }

    // Update is called once per frame
    void Update()
    {

        this.transform.position += this.transform.forward * bulletSpeed;
        


    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "spawn") {
    //        collision.manager.clearOne(collision);
    //    }
    //}
}
