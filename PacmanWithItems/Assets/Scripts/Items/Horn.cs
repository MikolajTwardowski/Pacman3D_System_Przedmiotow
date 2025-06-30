using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horn : Item
{
    public override void Use()
    {
        AudioManager.Instance.PlayOneShot(useClip, Player.Instance.transform.position);
    }
}
