using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    public RawImage itemIcon;
    public Image cooldownOverlay;

    void Update()
    {
        var item = Player.Instance?.heldItem;

        if (item == null || item.material == null)
        {
            itemIcon.enabled = false;
            cooldownOverlay.enabled = false;
            return;
        }

        itemIcon.enabled = true;
        cooldownOverlay.enabled = true;

        itemIcon.texture = item.material.mainTexture;

        cooldownOverlay.fillAmount = item.onCooldown ? 1f : 0f;
    }
}
