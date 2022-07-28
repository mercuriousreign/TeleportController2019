using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject spawn;
    public ArrayList spawns;
    // Start is called before the first frame update
   

    


    public void Instantaite() {

        int start = Random.Range(3, 7);
        Vector3 randomVector = new Vector3(Random.Range(0,4), Random.Range(0, 4),0);
        for (int i = 0; i< start; i++){
            Vector3 randVec = new Vector3(Random.Range(0, 4), Random.Range(0, 4), 0);
            GameObject sp = GameObject.Instantiate(spawn, transform.position + randomVector ,transform.rotation);
            spawns.Add(sp);
        
        }

        changeColor();
    }

    public void ClearAll() {
        foreach (GameObject i in spawns) {
            GameObject.Destroy(i);
        }
        spawns.Clear();
    }

    public void ClearOne(GameObject d) {
        spawns.Remove(d);
        GameObject.Destroy(d);
    }

    public void changeColor() {

        foreach (GameObject i in spawns) {
            Material m = i.GetComponent<Material>();
            m.color = new Color(Random.Range(0, 255), Random.Range(0, 255), Random.Range(0, 255));
        }

    }

}
