using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundController : MonoBehaviour
{
    [SerializeField] private AudioClip[] _audioClips;

    private AudioSource _audioSource;
    private int _currentClipIndex;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        _audioSource = GetComponent<AudioSource>();

        StartPlay();
    }

    public void StartPlay()
    {
        ChangeClip(0);
    }

    private void LateUpdate()
    {
        if (_audioSource.isPlaying)
            return;

        ChangeClipToNext();
    }

    private void ChangeClipToNext()
    {
        var nextIndex = (_currentClipIndex + 1) % _audioClips.Length;
        ChangeClip(nextIndex);
    }
    private void ChangeClip(int index)
    {
        _audioSource.clip = _audioClips[index];
        _audioSource.Play();
    }
}