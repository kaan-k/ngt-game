using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectScript : MonoBehaviour
{
    public objectAttributes objAttribs;
    public float DamageDistance = 5;
    RaycastHit hit;
    Vector3 fwd = Vector3.forward;
    public float DamageTime = 1.5f;
    int layer_mask = 6;


    void Update()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red); // sonradan sil burayý 
        if (Input.GetKeyDown(KeyCode.E))
        {
            InvokeRepeating("RayCastHit", 0f, DamageTime);
        }
        if (objAttribs.shouldDie())
        {
            objAttribs.gatherLoot();
            Destroy(this.gameObject);
        }
    }
    

    void RayCastHit()
    {

        if (objAttribs.objType == objectAttributes.objectType.Item)

        {
            if (Physics.Raycast(transform.position, fwd, out hit, DamageDistance))
            {
                if (hit.collider != null)
                {
                    if (objAttribs.shouldDisappear())
                    {
                        Destroy(transform.Find("RightSword"));
                    }

                    RayCastAttack();
                }
            }
        }



    }
    void RayCastAttack()
    {
        if (hit.transform.gameObject.CompareTag("tree"))
        {
            Debug.Log("hasar verildi.");
            objAttribs.durability = objAttribs.durability - 0.5f;
            hit.transform.GetComponent<objectScript>().objAttribs.objectHealt = hit.transform.GetComponent<objectScript>().objAttribs.objectHealt - 0.5f;
        }

    }

}
