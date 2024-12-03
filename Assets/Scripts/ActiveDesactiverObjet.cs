using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionObjetsTrigger : MonoBehaviour
{
    [Header("Objets � d�sactiver")]
    [Tooltip("Ajoutez ici tous les objets � d�sactiver.")]
    public List<GameObject> objetsADesactiver;

    [Header("Objets � activer")]
    [Tooltip("Ajoutez ici tous les objets � activer.")]
    public List<GameObject> objetsAAfficher;

    [Header("Son � jouer")]
    [Tooltip("Le son qui sera jou� lorsqu'on entre dans le trigger.")]
    public AudioClip sonJouer;

    // Bool�en pour s'assurer que l'�v�nement ne se produit qu'une fois
    private bool dejaDeclenche = false;

    // M�thode appel�e lorsqu'un objet entre dans le trigger
    private void OnTriggerEnter(Collider autre)
    {
        // V�rifie que l'objet entrant est le joueur et que l'�v�nement n'a pas encore �t� d�clench�
        if (autre.CompareTag("Joueur") && !dejaDeclenche)
        {
            dejaDeclenche = true; // Marque l'�v�nement comme d�clench�
            DeclencherEvenement(); // Ex�cute la logique principale
        }
    }

    // G�re l'apparition/disparition des objets et joue un son
    private void DeclencherEvenement()
    {
        // D�sactive tous les objets dans la liste des objets � d�sactiver
        foreach (GameObject objet in objetsADesactiver)
        {
            if (objet != null)
            {
                objet.SetActive(false);
            }
        }

        // Active tous les objets dans la liste des objets � activer
        foreach (GameObject objet in objetsAAfficher)
        {
            if (objet != null)
            {
                objet.SetActive(true);
            }
        }

        // Joue le son, si un clip audio est assign�
        if (sonJouer != null)
        {
            AudioSource.PlayClipAtPoint(sonJouer, transform.position);
        }
    }
}
