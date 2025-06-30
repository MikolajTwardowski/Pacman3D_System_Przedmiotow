using System.Collections;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public AudioClip useClip;
    public float cooldown = 3;
    public bool onCooldown = false;
    public Material material;
    public GameObject puppetPrefab;
    public abstract void Use();

    public virtual IEnumerator StartCooldown()
    {
        onCooldown = true;

        if (useClip != null)
            AudioManager.Instance.PlayOneShot(useClip, transform.position);

        yield return new WaitForSeconds(cooldown);
        onCooldown = false;
    }


}