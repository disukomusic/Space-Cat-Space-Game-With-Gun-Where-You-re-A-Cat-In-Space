using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : Interactable
{
    public Teleporter otherTeleporter;
    
    [SerializeField] private AudioSource audioSource;

    private GameObject _player;
    private bool canTP;

    void Start()
    {
        _player = Player.Instance.gameObject;
    }
    public override void Interact()
    {
        if (canTP)
        {
            audioSource.Play();
            _player.transform.position = otherTeleporter.transform.position + (Vector3.forward * 2f);
            canTP = false;
        }
        else
        {
            canTP = true;
        }
    }
}
