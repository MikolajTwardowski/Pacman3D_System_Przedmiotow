using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPill : MonoBehaviour
{
    //[SerializeField] float pointsOnCollect = 1f;


    void PowerPillCollected()
    {
        Debug.Log("tREEEEEEEEEEEEEEEEEEEEEEEEEEEggered");
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            PowerPillCollected();
    }
}
