using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootsOfSpeed : Item
{
    [SerializeField] float additionalSpeed;
    [SerializeField] float boostDuration;
    float playersSpeed;

    private void Start() {
        playersSpeed = Player.Instance.moveSpeed; 
    }


    public override void Use()
    {
        if (!onCooldown)
        {
            StartCoroutine(StartCooldown());
            
            StartCoroutine(TemporaryBoostSpeed());
        }
    }

    IEnumerator TemporaryBoostSpeed()
    {
        Player.Instance.moveSpeed += additionalSpeed;
        yield return new WaitForSeconds(boostDuration);
        Player.Instance.moveSpeed = playersSpeed;
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
        Player.Instance.moveSpeed = playersSpeed;
    }
}
