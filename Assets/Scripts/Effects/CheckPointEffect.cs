using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointEffect : MonoBehaviour
{
    [SerializeField] private ParticleSystem checkPointEffect;

    private void OnTriggerEnter(Collider other)
    {
        if(other != null)
        {
            if (other.gameObject.CompareTag("CheckPointTrigger"))
            {
                SoundController.instance.CheckPointSound();
                checkPointEffect.Play();
            }
        }
    }
}
