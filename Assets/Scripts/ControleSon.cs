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

        //si le joeur n'a pas choisit de son le mettre à 1
        if (!PlayerPrefs.HasKey("choixSon"))
        {
            PlayerPrefs.SetFloat("choixSon", 1);
            Chargement();
        }
        //sinon charger le volume qu'il a choisit
        else { Chargement(); }
        
    }
    
    //fonction pour changer le son
    public void ChangementSon()
    {
        //changer le volume par rapport au slider et enregistrer
        AudioListener.volume = son.value;
        Sauvegarde();
    }

    //fonction pour enregistrer le son
    private void Sauvegarde()
    {
        //mettre une variable qui aura la valeur du slider dans les preferences du joueur
        PlayerPrefs.SetFloat("choixSon", son.value);
    }

    //fonction pour cherger le son
    private void Chargement()
    {
        //aller chercher la valeur de la variable
        son.value = PlayerPrefs.GetFloat("choixSon");
    }

}
