using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnScript : MonoBehaviour
{
    // Start is called before the first frame update
    private SpawnManager manager;
    void Start()
    {
        manager = FindObjectOfType<SpawnManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "bullet") {
            manager.ClearOne(this.gameObject);
        }
    }
}
