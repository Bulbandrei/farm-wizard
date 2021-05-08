using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    private static AudioManager Instance;

    [System.Serializable]
    public class ClipData
    {
        #if UNITY_EDITOR_WIN
        public string name;
        #endif
        public SFXOccurrence occurrence;
        public float volume = 1;
        public AudioClip[] audioClip;
    }

    public AudioMixer audioMixer;
    public SFXSource sfxSourcePrefab;

    [Header("SFXS")]
    public GameObject sfxAudioSources;
    public AudioMixerGroup sfxMixerGroup;
    public ClipData[] sfxClips;
    public ClipData[] sfxUiClips;
    public ClipData[] voiceClips;

    public static SFXSource SFXSourcePrefab;
    public static Dictionary<SFXOccurrence, ClipData> SFXClips = new Dictionary<SFXOccurrence, ClipData>();

    public void Initate()
    {
        Instance = this;
        SFXSourcePrefab = sfxSourcePrefab;
    }

    private void OnDestroy()
    {
        SFXClips.Clear();
    }

    public void Initialize()
    {
        for (int __i = 0; __i < sfxClips.Length; __i++)
        {
            SFXClips.Add(sfxClips[__i].occurrence, sfxClips[__i]);
        }

        for (int __i = 0; __i < sfxUiClips.Length; __i++)
        {
            SFXClips.Add(sfxUiClips[__i].occurrence, sfxUiClips[__i]);
        }

        for (int __i = 0; __i < voiceClips.Length; __i++)
        {
            SFXClips.Add(voiceClips[__i].occurrence, voiceClips[__i]);
        }
    }

    public static void PlaySFX(SFXOccurrence p_occurrence, Vector2 p_position, int p_index = 0)
    {
        SFXSource __sfxSource = Instantiate(SFXSourcePrefab, p_position, Quaternion.identity);
        AudioSource __audioSource = __sfxSource.GetComponent<AudioSource>();
        ClipData __data = SFXClips[p_occurrence];

        __audioSource.clip = __data.audioClip[p_index];
        __audioSource.volume = __data.volume;
        __audioSource.Play();

        __sfxSource.enabled = true;
    }

    public static void PlaySFX(SFXOccurrence p_occurrence, AudioSource p_source, int p_index = 0)
    {
        AudioSource __audioSource = p_source;
        ClipData __data = SFXClips[p_occurrence];

        __audioSource.clip = __data.audioClip[p_index];
        __audioSource.volume = __data.volume;
        __audioSource.Play();
    }

    public static void InitalizeAudioSource(SFXOccurrence p_occurrence, AudioSource p_source, int p_index = 0)
    {
        ClipData __data = SFXClips[p_occurrence];

        p_source.clip = __data.audioClip[p_index];
        p_source.volume = __data.volume;
    }

    public static void StopSFXSmooth(AudioSource p_source, float p_time = 1f)
    {
        Instance.StartCoroutine(RoutineStopSFX(p_source, p_time));
    }

    private static IEnumerator RoutineStopSFX(AudioSource p_source, float p_time = 1f)
    {
        while (p_source.volume > 0f)
        {
            p_source.volume -= p_time * Time.deltaTime;

            yield return null;
        }

        p_source.Stop();
    }
}
