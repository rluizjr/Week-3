using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionHandler : MonoBehaviour {

    public GameObject plusOne;

    void Explode()
    {
        Instantiate(plusOne, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
