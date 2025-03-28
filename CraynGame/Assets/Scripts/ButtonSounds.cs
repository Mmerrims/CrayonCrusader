using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSounds : MonoBehaviour
{
    [SerializeField] private GameObject Button;
    [SerializeField] private AudioClip Sound;
    public void OnButtonPress()
    {
        AudioSource.PlayClipAtPoint(Sound, Button.transform.position);
    }
}
