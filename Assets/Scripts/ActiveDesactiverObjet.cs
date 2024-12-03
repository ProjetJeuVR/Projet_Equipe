using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionObjetsTrigger : MonoBehaviour
{
    [Header("Objets à désactiver")]
    [Tooltip("Ajoutez ici tous les objets à désactiver.")]
    public List<GameObject> objetsADesactiver;

    [Header("Objets à activer")]
    [Tooltip("Ajoutez ici tous les objets à activer.")]
    public List<GameObject> objetsAAfficher;

    [Header("Son à jouer")]
    [Tooltip("Le son qui sera joué lorsqu'on entre dans le trigger.")]
    public AudioClip sonJouer;

    // Booléen pour s'assurer que l'événement ne se produit qu'une fois
    private bool dejaDeclenche = false;

    // Méthode appelée lorsqu'un objet entre dans le trigger
    private void OnTriggerEnter(Collider autre)
    {
        // Vérifie que l'objet entrant est le joueur et que l'événement n'a pas encore été déclenché
        if (autre.CompareTag("Joueur") && !dejaDeclenche)
        {
            dejaDeclenche = true; // Marque l'événement comme déclenché
            DeclencherEvenement(); // Exécute la logique principale
        }
    }

    // Gère l'apparition/disparition des objets et joue un son
    private void DeclencherEvenement()
    {
        // Désactive tous les objets dans la liste des objets à désactiver
        foreach (GameObject objet in objetsADesactiver)
        {
            if (objet != null)
            {
                objet.SetActive(false);
            }
        }

        // Active tous les objets dans la liste des objets à activer
        foreach (GameObject objet in objetsAAfficher)
        {
            if (objet != null)
            {
                objet.SetActive(true);
            }
        }

        // Joue le son, si un clip audio est assigné
        if (sonJouer != null)
        {
            AudioSource.PlayClipAtPoint(sonJouer, transform.position);
        }
    }
}
