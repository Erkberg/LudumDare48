using System.Collections;
using System.Collections.Generic;
using ErksUnityLibrary;
using UnityEngine;

public class GameAudio : MonoBehaviour
{
    public List<AudioClip> musics;
    public List<AudioSource> audioSourcesMusic;
    public AudioSource audioSourceSounds;

    private int currentMusicId = 0;
    private int currentAudioSourceMusic = 0;
    private float musicFadeDuration = 0.5f;

    public void OnMusicLevelChanged(int newLevel)
    {
        currentMusicId = newLevel;
        StartCoroutine(FadeOutAudioSource(audioSourcesMusic[currentAudioSourceMusic], musicFadeDuration));
        
        currentAudioSourceMusic = currentAudioSourceMusic == 0 ? 1 : 0;
        audioSourcesMusic[currentAudioSourceMusic].clip = musics[currentMusicId];
        StartCoroutine(FadeInAudioSource(audioSourcesMusic[currentAudioSourceMusic], musicFadeDuration));
    }

    private IEnumerator FadeInAudioSource(AudioSource audioSource, float duration)
    {
        audioSource.Play();
        
        while (audioSource.volume < 1f)
        {
            audioSource.volume += Time.deltaTime / duration;
            yield return null;
        }

        audioSource.volume = 1f;
    }
    
    private IEnumerator FadeOutAudioSource(AudioSource audioSource, float duration)
    {
        while (audioSource.volume > 0f)
        {
            audioSource.volume -= Time.deltaTime / duration;
            yield return null;
        }

        audioSource.volume = 0f;
        audioSource.Stop();
    }

    public void PlayOneShotRandomVolumePitch(AudioClip clip)
    {
        audioSourceSounds.PlayOneShotRandomVolumePitch(clip);
    }
}
