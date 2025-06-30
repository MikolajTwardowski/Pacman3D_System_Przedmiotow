using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootsOfSpeed : Item
{
    [SerializeField] float additionalSpeed;
    [SerializeField] float boostDuration;

    [SerializeField] AudioClip boostStepsAudio;
    AudioClip oryginalPlayerStepsAudio;
    AudioSource playerStepsHandler;

    float playersSpeed;

    private void Start()
    {
        playersSpeed = Player.Instance.moveSpeed;

        playerStepsHandler = Player.Instance.GetComponentsInChildren<AudioSource>()[1];

        oryginalPlayerStepsAudio = playerStepsHandler.clip;
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
        playerStepsHandler.clip = boostStepsAudio;

        yield return new WaitForSeconds(boostDuration);

        playerStepsHandler.clip = oryginalPlayerStepsAudio;
        Player.Instance.moveSpeed = playersSpeed;

    }

    private void OnDestroy()
    {
        StopAllCoroutines();
        try
        {
            playerStepsHandler.clip = oryginalPlayerStepsAudio;
        }
        catch{ }
        Player.Instance.moveSpeed = playersSpeed;
    }
}
