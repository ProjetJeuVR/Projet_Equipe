using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveDesactiverObjet : MonoBehaviour
{
    // Objets à activer/désactiver lorsque le joueur entre dans la zone
    public GameObject objetADesactiver; // L'objet qui sera désactivé
    public GameObject objetActiver;    // L'objet qui sera activé

    // Clip audio à jouer lors du déclenchement
    public AudioClip sonJouer;
    private AudioSource sourceAudio; // Source audio pour jouer le son.

    // Booléen pour éviter que l'événement se déclenche plusieurs fois
    private bool dejaDeclenche = false;

    // Méthode appelée automatiquement lorsqu'un autre Collider entre dans celui de cet objet (si "Is Trigger" est activé)
    private void OnTriggerEnter(Collider autre)
    {
        // Vérifie si l'objet entrant a le tag "Joueur" et si l'événement n'a pas encore été déclenché
        if (autre.CompareTag("Joueur") && !dejaDeclenche)
        {
            dejaDeclenche = true; // Marque l'événement comme déjà déclenché pour éviter les répétitions

            if (sonJouer != null)
            {
                sourceAudio.PlayOneShot(sonJouer); // Joue le son.
            }

            AfficherObjet();      // Appelle la méthode pour activer/désactiver les objets
        }
    }

    // Méthode qui gère l'activation/désactivation des objets et le son
    private void AfficherObjet()
    {
        // Désactive l'objet spécifié, si celui-ci est assigné
        if (objetADesactiver != null)
        {
            objetADesactiver.SetActive(false);
        }

        // Active l'autre objet spécifié, si celui-ci est assigné
        if (objetActiver != null)
        {
            objetActiver.SetActive(true);
        }
    }
}
