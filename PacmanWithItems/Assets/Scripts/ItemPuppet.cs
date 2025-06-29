using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPuppet : MonoBehaviour
{   
    public GameObject itemPrefab; // prefab logicznego przedmiotu (Item)

    [SerializeField] MeshRenderer mr;
    
    private void Start()
    {
        mr.material = itemPrefab.GetComponent<Item>().material;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject itemInstance = Instantiate(itemPrefab);
            Player.Instance.PickUpItem(itemInstance.GetComponent<Item>());
            Destroy(this.gameObject);
        }
    }
}
