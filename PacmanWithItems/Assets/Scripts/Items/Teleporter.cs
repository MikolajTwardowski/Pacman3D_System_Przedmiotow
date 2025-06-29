using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : Item
{
    [SerializeField] float range = 2.5f;
    public override void Use()
    {
        if (!onCooldown)
        {
            var playerTransform = Player.Instance.transform;

            Collider[] hits = Physics.OverlapBox(playerTransform.position + playerTransform.forward * range, playerTransform.localScale / 2, Quaternion.identity);

            if (hits.Length == 0)
            {   
                StartCoroutine(StartCooldown());
                Player.Instance.transform.position += playerTransform.forward * range;
            }

        }
    }

    private void Update() {
        //DrawDebugBox(Player.Instance.transform.position + Player.Instance.transform.forward * range, Player.Instance.transform.localScale / 2, Color.red);
    }
    

    void DrawDebugBox(Vector3 center, Vector3 size, Color color)
    {
        Vector3 half = size / 2f;

        // 8 narożników pudełka
        Vector3[] corners = new Vector3[8]
        {
            center + new Vector3(-half.x, -half.y, -half.z),
            center + new Vector3( half.x, -half.y, -half.z),
            center + new Vector3( half.x, -half.y,  half.z),
            center + new Vector3(-half.x, -half.y,  half.z),
            center + new Vector3(-half.x,  half.y, -half.z),
            center + new Vector3( half.x,  half.y, -half.z),
            center + new Vector3( half.x,  half.y,  half.z),
            center + new Vector3(-half.x,  half.y,  half.z)
        };

        // Dolna podstawa
        Debug.DrawLine(corners[0], corners[1], color);
        Debug.DrawLine(corners[1], corners[2], color);
        Debug.DrawLine(corners[2], corners[3], color);
        Debug.DrawLine(corners[3], corners[0], color);

        // Górna podstawa
        Debug.DrawLine(corners[4], corners[5], color);
        Debug.DrawLine(corners[5], corners[6], color);
        Debug.DrawLine(corners[6], corners[7], color);
        Debug.DrawLine(corners[7], corners[4], color);

        // Pionowe krawędzie
        Debug.DrawLine(corners[0], corners[4], color);
        Debug.DrawLine(corners[1], corners[5], color);
        Debug.DrawLine(corners[2], corners[6], color);
        Debug.DrawLine(corners[3], corners[7], color);
    }
}
