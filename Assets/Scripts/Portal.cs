using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class Portal : MonoBehaviour
{

    public GameObject PortalDoors;
    public GameObject Player;




    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) //moze tu jest blad
        {
            StartCoroutine(Teleport ());
            Debug.Log("no dzialaj");

            //var virtualCamera = GameObject.FindGameObjectWithTag("VirtualCamera");
            //var confiner = virtualCamera.GetComponent<CinemachineConfiner>();
            //confiner.m_BoundingShape2D = null;
            //confiner.m_BoundingShape2D = GameObject.FindGameObjectWithTag("Confined").GetComponent<Collider2D>();

            //kazdy klon obiektu mapy ma tag "confined" (ale nie zawsze)
            //Kamera zmienia GameObjectWithTag dopiero po podwojnym wejsciu do teleporta!!!
            //juz nie

        }

    }

    IEnumerator Teleport()
    {
        yield return new WaitForSeconds(0.3f);
        Player.transform.position = new Vector2(PortalDoors.transform.position.x, PortalDoors.transform.position.y);
        Debug.Log("teleport");

    }



}
