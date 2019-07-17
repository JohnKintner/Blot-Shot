using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineSounds : MonoBehaviour
{
    AudioClip[] engines = new AudioClip[9];
    public static string[] names = new string[9];
    List<AudioSource> newAudios = new List<AudioSource>();
    List<GameObject> newObjects = new List<GameObject>();

    void Start()
    {
        engines[0] = Resources.Load<AudioClip>("Sounds/Rhino/SFX_Char_Rhino_Engine"); ;//Rhino
        engines[1] = Resources.Load<AudioClip>("Sounds/Sprayer/SFX_Char_Bat_Engine");//Sprayer
        engines[2] = Resources.Load<AudioClip>("Sounds/ManOWar/SFX_Char_ManOWar_Engine");//ManOWar
        engines[3] = Resources.Load<AudioClip>("Sounds/Burster/SFX_Char_Caiman_Engine");//Burster
        engines[4] = Resources.Load<AudioClip>("Sounds/Hive/SFX_Char_Hive_Engine");//Hive
        engines[5] = Resources.Load<AudioClip>("Sounds/Shark/SFX_Char_Shark_Engine");//Shark
        engines[6] = Resources.Load<AudioClip>("Sounds/Falcon/SFX_Char_Troop_Engine");//Falcon
        engines[7] = Resources.Load<AudioClip>("Sounds/Wolf/SFX_Char_Wold_Engines");//Falcon;//Wolf
        engines[8] = Resources.Load<AudioClip>("Sounds/Bee/SFX_Char_Bee_Engine");//Bee

        names[0] = "Rhino(Clone)";//Rhino
        names[1] = "Sprayer(Clone)";//Sprayer
        names[2] = "ManOWar(Clone)";//ManOWar
        names[3] = "Burster(Clone)";//Burster
        names[4] = "Hive(Clone)";//Hive
        names[5] = "Shark(Clone)";//Shark
        names[6] = "Falcon(Clone)";//Falcon
        names[7] = "Wolf(Clone)";//Wolf
        names[8] = "Bee(Clone)";//Bee

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name != "playerBullet(Clone)" && other.gameObject.name != "enemyBullet(Clone)")
        {
            for(int i = 0; i < 9; i++)
            {
                if(other.gameObject.name == names[i])//checks which object it is
                {
                    if(engines[i] != null)
                    {
                        AudioSource newAudio = other.gameObject.AddComponent<AudioSource>();
                        newAudio.clip = engines[i];
                        newAudio.loop = true;
                        newAudio.Play();
                        newAudios.Add(newAudio);
                        newObjects.Add(other.gameObject);
                        return;
                    }
                    else
                    {
                        print(names[i] + "Missing sounds");
                        return;
                    }
                }
            }
            return;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<AudioSource>() != null)
        {
            for (int i = 0; i < newAudios.Count; i++)
            {
                if (newAudios[i] == other.gameObject.GetComponent<AudioSource>())
                {
                    newAudios.Remove(newAudios[i]);
                    Destroy(other.gameObject.GetComponent<AudioSource>());
                }
            }
        }
    }
}

