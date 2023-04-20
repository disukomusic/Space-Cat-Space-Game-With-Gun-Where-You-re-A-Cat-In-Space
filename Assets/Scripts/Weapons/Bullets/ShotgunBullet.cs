using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

/// <summary>
/// shamelessly stolen from https://www.youtube.com/watch?v=zHDcpvYxjJo
/// </summary>

public class ShotgunBullet : Bullet
{
    public int pelletCount;
    public float spreadAngle;
    public GameObject pellet;
    private List<Quaternion> pellets;
    public override void Awake()
    {
        SoundManager.PlaySoundAtPosition(SoundManager.Sound.ShotgunFire, transform.position);
        
        //todo:AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAHHHHHHHHHHHHHHHHHHHHHH
        // pellets = new List<Quaternion>(pelletCount);
        // for (int i = 0; i < pelletCount; i++)
        // {
        //     pellets.Add(Quaternion.Euler(Vector3.zero));
        // }
        //
        // for (int i = 0; i < pelletCount; i++)
        // {
        //     pellets[i] = Random.rotation;
        //     GameObject p = Instantiate(pellet, transform.position, transform.rotation);
        //     p.transform.rotation = new Quaternion(flatAimTarget.x, flatAimTarget.y, flatAimTarget.z, flatAimTarget.z) * Quaternion.RotateTowards(p.transform.rotation, pellets[i], spreadAngle);
        //     p.GetComponent<Rigidbody>().AddForce(p.transform.right * speed);
        // }
            
        base.Awake();
    }
}
