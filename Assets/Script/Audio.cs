using UnityEngine;

public class Audio : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static Audio instance;
    public AudioSource backgroungSource;
    public AudioSource sfxSource;

    public AudioClip shootClip;
    public AudioClip dieClip;
    public AudioClip backgroundClip;

    private void Awake()
    {
        instance = this;
        PlayBackgroundAudio();
    }
    void PlayBackgroundAudio()
    {
        backgroungSource.clip = backgroundClip;
        backgroungSource.Play();
    }
    public void PlayShootClip()
    {
        sfxSource.PlayOneShot(shootClip);

    }
    public void PlayDieClip()
    {
        sfxSource.PlayOneShot(dieClip);
    }
}
