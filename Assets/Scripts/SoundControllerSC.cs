using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControllerSC : MonoBehaviour
{

    public static AudioClip PlayerfireSound,SpaceExplosion,MenuSelection,EnemyFire;
    static AudioSource audioSource;
    void Start()
    {
        PlayerfireSound = Resources.Load<AudioClip>("PlayerFire");
        SpaceExplosion = Resources.Load<AudioClip>("SpaceExplosion");
        MenuSelection = Resources.Load<AudioClip>("MenuSelection");
        EnemyFire = Resources.Load<AudioClip>("EnemyFire");

        audioSource = GetComponent<AudioSource>();
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
            case "MenuSelection":
                audioSource.PlayOneShot(MenuSelection);
                break;
            case "EnemyFire":
                audioSource.PlayOneShot(EnemyFire);
                break;

            default:
                break;
        }

    }
}
