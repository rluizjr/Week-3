using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombUnlitHandler : MonoBehaviour {

    public GameObject bomblit;

    private void OnMouseDown()
    {
        Instantiate(bomblit, transform.transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
