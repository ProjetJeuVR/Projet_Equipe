using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ColliderCle : MonoBehaviour
{
    // Tableau des objets à supprimer
    public GameObject[] objetsASupprimer;

    // Détecte quand un objet entre dans le collider
    private void OnTriggerEnter(Collider other)
    {
        // Vérifie si l'objet entrant a le tag "Cle"
        if (other.CompareTag("Cle"))
        {
            // Boucle pour supprimer chaque objet dans le tableau
            foreach (GameObject obj in objetsASupprimer)
            {
                if (obj != null)
                {
                    Destroy(obj);
                }
            }
        }
    }
}
