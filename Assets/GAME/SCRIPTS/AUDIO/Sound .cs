using UnityEngine;

[System.Serializable]


public class Sound
{

    public string nombre;

    public AudioClip clip;

    public bool loop;

    [Range(0f, 1f)]
    public float volume;

    [Range(-3f, 3f)]
    public float pitch;

    [HideInInspector]
    public AudioSource source;

}
