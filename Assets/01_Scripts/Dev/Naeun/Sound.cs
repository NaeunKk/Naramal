using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Sound : MonoBehaviour
{
    [SerializeField] private AudioSource _bgm;

    public void VolumeControll(float volume)
    {
        _bgm.volume = volume;
    }
}
