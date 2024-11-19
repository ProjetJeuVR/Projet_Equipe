using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuApparaitScript : MonoBehaviour
{

    public void Apparait(GameObject menu)
    {
        bool etat = menu.activeSelf;
        etat = !etat;

        menu.SetActive(etat);
    }

}
