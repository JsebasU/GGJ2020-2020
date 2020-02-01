using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [SerializeField] AudioSource relaxMusic = null;
    [SerializeField] AudioSource eventsMusic = null;
    [SerializeField] AudioSource tensionMusic = null;
    [SerializeField] AudioSource mainMenuMusic = null;

    public static AudioManager manager = null;

    int globalTension = 0;
    public int Tension
    {
        get
        {
            return Tension;
        }

        set
        {
            if (value > 2)
            {
                ModifyMusic(2);
                globalTension = 2;
            }
            else
            {
                ModifyMusic(value);
                globalTension = value;
            }
        }

    }

    private void Awake()
    {
        if (manager == null)
        {
            manager = this;
            DontDestroyOnLoad(gameObject);
            if (SceneManager.GetActiveScene().buildIndex == 0)
            {
                //mainmenu
            }
            else
            {
                //InGame
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void ModifyMusic(int value)
    {
        if(value == globalTension)
        {

        }
        else
        {

        }
    }

    IEnumerator FadeInOut(int value)
    {
        switch (value)
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                break;
        }
    }

}
