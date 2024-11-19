using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControleSon : MonoBehaviour
{
    //aller chercher le slider
    public Slider son;

    // Start is called before the first frame update
    void Start()
    {

        
        if (!PlayerPrefs.HasKey("choixSon"))
        {
            PlayerPrefs.SetFloat("choixSon", 1);
            Chargement();
        }
        else { Chargement(); }
        
    }
    
    public void ChangementSon()
    {
        AudioListener.volume = son.value;
        Sauvegarde();
    }
    private void Sauvegarde()
    {
        PlayerPrefs.SetFloat("choixSon", son.value);
    }

    private void Chargement()
    {
        son.value = PlayerPrefs.GetFloat("choixSon");
    }

}
