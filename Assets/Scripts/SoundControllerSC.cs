using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControllerSC : MonoBehaviour
{

    public static AudioClip PlayerfireSound,SpaceExplosion;
    static AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        PlayerfireSound = Resources.Load<AudioClip>("PlayerFire");
        SpaceExplosion = Resources.Load<AudioClip>("SpaceExplosion");

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "PlayerFire":
                audioSource.PlayOneShot(PlayerfireSound);
                break;
            case "SpaceExplosion":
                audioSource.PlayOneShot(SpaceExplosion);
                break;


            default:
                break;
        }

    }
}
