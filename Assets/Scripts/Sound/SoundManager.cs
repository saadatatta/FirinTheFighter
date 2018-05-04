using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : Singleton<SoundManager> {

    private AudioSource audioSource;

    public AudioClip[] PlayerHurtClips;
    public AudioClip[] EnemyHurtClips;
    public AudioClip[] HoundHurtClips;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Plays the hurt sound of the entity.
    /// </summary>
    /// <param name="audioClips">The audio clips of hurt. 
    ///                          Available in SoundManager singleton instance.
    /// </param>

    public void PlayHurtSound(AudioClip[] audioClips,string enemyBoss)
    {
        if (enemyBoss == "Hound")
            audioClips = HoundHurtClips;

        int index = Random.Range(0, audioClips.Length - 1);
        audioSource.PlayOneShot(audioClips[index]);
    }

    public void PlayHurtSound(AudioClip[] audioClips)
    {
        int index = Random.Range(0, audioClips.Length - 1);
        audioSource.PlayOneShot(audioClips[index]);
    }


}
