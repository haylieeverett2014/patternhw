using UnityEngine;
using System.Collections;

public class DestroyBallsByTime : MonoBehaviour
{

    public float lifetime;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

}

