using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject soundOn;
    public GameObject soundOff;
    bool muted;

    private void Start()
    {
        if(!PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("muted", 0);
            Load();
        }
        else
        {
            Load();
        }
        UpdateButton();
        AudioListener.pause = muted;
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Sound()
    {
        if(muted == false) 
        {
            muted = true;
            AudioListener.pause = true;
        }
        else
        {
            muted = false;
            AudioListener.pause = false;
        }
        Save();
        UpdateButton();
    }

    private void UpdateButton()
    {
        if (muted == false)
        {      
            soundOn.SetActive(true);
            soundOff.SetActive(false);           
        }
        if (muted == true)
        {         
            soundOn.SetActive(false);
            soundOff.SetActive(true);          
        }
    }

    void Load()
    {
        muted = PlayerPrefs.GetInt("muted") == 1;
    }

    void Save()
    {
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
    }


}
