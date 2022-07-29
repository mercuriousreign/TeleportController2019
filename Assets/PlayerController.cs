using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Ray r;
    public GameObject bullet;
    

    private RaycastHit hit;
    private RaycastHit hover;
    private RaycastHit[] hits;
    public SpawnManager manager;
    public LineRenderer line;
    public Text info;
    public float sensetivity = 0.10f;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        manager.GetComponent<SpawnManager>();
        //Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {


       //change of camera based on mouse movement
        Camera.main.transform.Rotate(Vector3.down, Input.GetAxis("Mouse X") *Time.deltaTime *sensetivity);
        Camera.main.transform.Rotate(Vector3.left, Input.GetAxis("Mouse Y") *Time.deltaTime *sensetivity);
        Camera.main.transform.Rotate(Vector3.forward, 0f);
        //Creates an ray
        r = Camera.main.ScreenPointToRay(Input.mousePosition);
        line.SetPosition(0, r.origin + offset);
        line.SetPosition(1, r.origin+ r.direction * 100);
        
        //checks if it is an eligible teleport location
        if (Physics.Raycast(r, out hover))
        {
            if (hover.collider.tag == "ground") {
                line.startColor = Color.white;
                line.endColor = Color.red;
                line.sharedMaterial.SetColor("_Color", Color.white);
                Debug.Log("Ground hover");
            }

            if (hover.collider.tag == "spawn")
            {
                Debug.Log("spawn hover");
                line.startColor = Color.red;
                line.endColor = Color.red;
                manager.ClearOne(hover.collider.gameObject);
                line.sharedMaterial.SetColor("_Color", Color.red);

            }

            //Debug.DrawRay(r.origin, r.direction * 310, Color.blue);
        }
        else {
            line.startColor = Color.black;
            line.startColor = Color.black;
            line.sharedMaterial.SetColor("_Color", Color.black);

            //Debug.DrawRay(r.origin, r.direction * 310, Color.black);
        }
        



        //Bullet Spawn
        if (Input.GetMouseButtonUp(0)) {

            GameObject.Instantiate(bullet,r.origin,Quaternion.LookRotation(r.direction));
            
        }


        //Changes all the spawncolor
        if (Input.GetMouseButtonDown(2)) {
            manager.Instantaite(r.origin, Quaternion.LookRotation(r.direction));

            hits = Physics.RaycastAll(r);

            foreach (RaycastHit i in hits) {
                if (i.collider.gameObject.tag == "spawn"){
                    Renderer m = i.collider.GetComponent<Renderer>();
                    m.material.color = new Color(Random.Range(0, 255), Random.Range(0, 255), Random.Range(0, 255));
                }
            }
        }


        //Teleportation Code
        if (Input.GetMouseButtonUp(1)) {
            
            if (Physics.Raycast(r, out hit) & hit.collider.gameObject.tag == "ground") {
                this.transform.position = hit.point;
                manager.Instantaite();
                info.text = hit.collider.gameObject.name;
            }
            Debug.Log("hitground");
        }



    }


    

}
