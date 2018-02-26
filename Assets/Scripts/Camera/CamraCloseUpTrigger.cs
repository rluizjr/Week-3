using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamraCloseUpTrigger : MonoBehaviour {

    public Camera mainCamera;
    public Camera closeUpCamera;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            mainCamera.enabled = false;
            closeUpCamera.enabled = true;
        }   
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            mainCamera.enabled = true;
            closeUpCamera.enabled = false;
        }
    }
}
