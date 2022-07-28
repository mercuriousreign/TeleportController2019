using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Ray r;
    public GameObject bullet;
    

    private RaycastHit hit;
    private RaycastHit hover;
    private RaycastHit[] hits;
    public SpawnManager manager;
    public LineRenderer line;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


       //change of camera based on mouse movement
        Camera.main.transform.Rotate(Vector3.up, Input.GetAxis("Mouse X"));
        Camera.main.transform.Rotate(Vector3.left, Input.GetAxis("Mouse Y"));

        //Creates an ray
        r = Camera.main.ScreenPointToRay(Input.mousePosition);
        line.SetPosition(0, r.origin);
        line.SetPosition(1, r.origin+ r.direction * 100);
        
        //checks if it is an eligible teleport location
        if (Physics.Raycast(r, out hover))
        {
            if (hover.collider.tag=="ground")
            line.startColor=Color.blue;
            line.endColor = Color.red;
           
            Debug.DrawRay(r.origin, r.direction * 310, Color.blue);
        }
        else {
            line.startColor = Color.black;
            line.startColor = Color.black;
            Debug.DrawRay(r.origin, r.direction * 310, Color.black);
        }
        



        //Bullet Spawn
        if (Input.GetMouseButtonUp(0)) {

            GameObject.Instantiate(bullet,r.origin,Quaternion.LookRotation(r.direction));
            
        }


        //Changes all the spawncolor
        if (Input.GetMouseButtonDown(0)) {
            manager.Instantaite();

            hits = Physics.RaycastAll(r);

            foreach (RaycastHit i in hits) {
                if (i.collider.gameObject.tag == "spawn"){
                    Material m = i.collider.gameObject.GetComponent<Material>();
                    m.color = new Color(Random.Range(0, 255), Random.Range(0, 255), Random.Range(0, 255));
                }
            }
        }


        //Teleportation Code
        if (Input.GetMouseButtonUp(1)) {
            Physics.Raycast(r, out hit);
            if (hit.collider.gameObject.tag == "ground") {
                this.transform.position = hit.point;
                manager.Instantaite();
            }
            Debug.Log("hitground");
        }



    }


    

}
