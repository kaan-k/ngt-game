using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectScript : MonoBehaviour
{
    public objectAttributes objAttribs;
    int layer_mask = 6;

    void Update()
    {
        if(objAttribs.shouldDie())
        {
            objAttribs.gatherLoot();
            Destroy(this.gameObject);
        }
    }
    void FixedUpdate()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        RaycastHit hit;
        if(objAttribs.objType == objectAttributes.objectType.Item)
        {
            if(Physics.Raycast(transform.position, fwd, out hit, 10f))
            {
                if(hit.collider != null)
                {
                      if(objAttribs.shouldDisappear())
                      {
                          Destroy(this.gameObject);
                      }
                      if(hit.transform.gameObject.CompareTag("tree"))
                      {
                         objAttribs.durability = objAttribs.durability - 0.5f;
                         hit.transform.GetComponent<objectScript>().objAttribs.objectHealt = hit.transform.GetComponent<objectScript>().objAttribs.objectHealt - 0.5f;
                      }
                      //

                }
            }
        }

    }
}
