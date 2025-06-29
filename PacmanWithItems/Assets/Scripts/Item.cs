using System.Collections;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public float cooldown = 3;
    public bool onCooldown = false;
    public Material material;
    public GameObject puppetPrefab;
    public abstract void Use();

    public virtual IEnumerator StartCooldown()
    {
        onCooldown = true;
        yield return new WaitForSeconds(cooldown);
        onCooldown = false;
    }


}