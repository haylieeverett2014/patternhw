using UnityEngine;
using System.Collections;

public class SphereGravity : MonoBehaviour
{

    private ArrayList num = new ArrayList();
    GameObject o;

    // Use this for initialization
    void OnTriggerEnter(Collider other)
    {
        o = other.gameObject;
        num.Add(o);
    }

    void OnTriggerExit(Collider other)
    {
        o = other.gameObject;
        num.Remove(o);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Iterating to apply, add , remove
        for (int i = 0; i < num.Count; i++)
        {
            if(num[i].Equals(null))
            {
                num.Remove(num[i]);
                break;
            }
           
           o=(GameObject)num[i];
            Vector3 diff = o.transform.position - transform.position;

            diff.Normalize();

            o.transform.position -= diff * .02f;
        }
    }
}
