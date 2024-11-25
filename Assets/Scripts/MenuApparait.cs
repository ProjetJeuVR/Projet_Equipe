using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuApparaitScript : MonoBehaviour
{

    //fonction pour faire apparaitre le menu
    public void Apparait(GameObject menu)
    {
        //prendre l'�tat du menu
        bool etat = menu.activeSelf;
        //inverser l'�tat
        etat = !etat;

        //changer l'�tat
        menu.SetActive(etat);
    }

}
