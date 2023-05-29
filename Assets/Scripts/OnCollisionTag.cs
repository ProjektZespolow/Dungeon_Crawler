using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class OnCollisionTag : MonoBehaviour
{

    public string newTag;

    void Start()
    {
        gameObject.tag = "Map";
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            this.gameObject.tag = newTag;
            Debug.Log("2");

            var virtualCamera = GameObject.FindGameObjectWithTag("VirtualCamera");
            var confiner = virtualCamera.GetComponent<CinemachineConfiner>();
            confiner.InvalidatePathCache();
            confiner.m_BoundingShape2D = null;
            confiner.m_BoundingShape2D = GameObject.FindGameObjectWithTag("Confined").GetComponent<Collider2D>();
            Debug.Log("3");
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            this.gameObject.tag = "Map";
        }
    }

}
