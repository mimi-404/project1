using UnityEngine;
public class AudioManager : MonoBehaviour
{
    [Header("------Audio Source------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;
    [Header("------Audio Clips------")]
    public AudioClip background;
    public AudioClip coinCollect;
    public AudioClip fuelCollect;
    public AudioClip gameOver;
    public AudioClip engine;
    public AudioClip carCollide;
    public AudioClip time;
    public AudioClip buttonClick;

    public AudioClip highscore;
    public AudioClip fuellow;
    public AudioClip quit;
    private void Start()
    {
        musicSource.clip = background;
        musicSource.loop = true;
        musicSource.Play();
    }
    public void StopMusic()
    {
        musicSource.Stop();
    }
    public void PlayMusic()
    {
        //musicSource.clip = clip;
        musicSource.Play();
    }
    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

}