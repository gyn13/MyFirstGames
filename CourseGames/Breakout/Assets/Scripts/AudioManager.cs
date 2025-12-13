using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private AudioSource sfxSource;
    
    private void Awake() =>  Instance = this;
    
    public void PlaySfx(AudioClip clip)  => sfxSource.PlayOneShot(clip);
}
