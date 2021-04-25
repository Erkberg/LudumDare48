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

    private const float FadeDuration = 3f;

    public void OnMusicLevelChanged(int newLevel)
    {
        if (newLevel != currentMusicId)
        {
            StartCoroutine(NewMusicLevelSequence(newLevel));
        }
    }

    private IEnumerator NewMusicLevelSequence(int newLevel)
    {
        currentMusicId = newLevel;
        StartCoroutine(FadeOutAudioSource(audioSourcesMusic[currentAudioSourceMusic], FadeDuration));
        
        currentAudioSourceMusic = currentAudioSourceMusic == 0 ? 1 : 0;
        float time = audioSourcesMusic[currentAudioSourceMusic].time;
        audioSourcesMusic[currentAudioSourceMusic].Stop();
        audioSourcesMusic[currentAudioSourceMusic].clip = musics[currentMusicId];
        audioSourcesMusic[currentAudioSourceMusic].Play();
        audioSourcesMusic[currentAudioSourceMusic].time = time;
        yield return StartCoroutine(FadeInAudioSource(audioSourcesMusic[currentAudioSourceMusic], FadeDuration));
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
        //audioSource.Stop();
    }

    public void PlayOneShotRandomVolumePitch(AudioClip clip)
    {
        audioSourceSounds.PlayOneShotRandomVolumePitch(clip);
    }
}
