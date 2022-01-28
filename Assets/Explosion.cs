using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Explosion : MonoBehaviour
{
    public AudioSource explosionSound;
    public ParticleSystem explosion;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Floor"))
        {
            explosion.Play();
            explosionSound.Play();
        }
    }

}
