using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuApparaitScript : MonoBehaviour
{

    //fonction pour faire apparaitre le menu
    public void Apparait(GameObject menu)
    {
        //prendre l'état du menu
        bool etat = menu.activeSelf;
        //inverser l'état
        etat = !etat;

        //changer l'état
        menu.SetActive(etat);
    }

}
