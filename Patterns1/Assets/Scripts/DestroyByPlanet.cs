using UnityEngine;
using System.Collections;

public class DestroyByPlanet : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        // Destroy everything that leaves the trigger
        Destroy(other.gameObject);
    }
}
