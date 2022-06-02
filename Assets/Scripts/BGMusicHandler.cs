using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class BGMusicHandler : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] AudioMixerGroup bgmMixer;
    //nova commented that
    // [SerializeField] GameObject audioValues;
    [SerializeField] AudioSource audioPlayer;
    [SerializeField] AudioClip[] bgClips;
    //nova commented this line
    // [SerializeField] float thisvolume = 0.2f;

    void Awake()
    {
        // nova commented the following lines
        /*/ audioValues = GameObject.FindGameObjectWithTag("AudioMixer");
         if (audioValues != null)
         {
           audioPlayer = this.GetComponent<AudioSource>();
        thisvolume = PlayerPrefs.GetFloat("BGMVolume", 0.2f);
        audioPlayer.PlayOneShot(bgClips[0], thisvolume);
         }
         else
         {

         }
 /*/
        //nova added these
        audioPlayer = this.GetComponent<AudioSource>();
        audioPlayer.outputAudioMixerGroup = bgmMixer;
        audioPlayer.PlayOneShot(bgClips[0]);
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioPlayer.isPlaying)
        {
            audioPlayer.outputAudioMixerGroup = bgmMixer;
            audioPlayer.PlayOneShot(bgClips[1]);
            audioPlayer.loop = true;
        }

    }
}
