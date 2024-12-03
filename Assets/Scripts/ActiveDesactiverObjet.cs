using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveDesactiverObjet : MonoBehaviour
{
    // Objets � activer/d�sactiver lorsque le joueur entre dans la zone
    public GameObject objetADesactiver; // L'objet qui sera d�sactiv�
    public GameObject objetActiver;    // L'objet qui sera activ�

    // Clip audio � jouer lors du d�clenchement
    public AudioClip sonJouer;
    private AudioSource sourceAudio; // Source audio pour jouer le son.

    // Bool�en pour �viter que l'�v�nement se d�clenche plusieurs fois
    private bool dejaDeclenche = false;

    // M�thode appel�e automatiquement lorsqu'un autre Collider entre dans celui de cet objet (si "Is Trigger" est activ�)
    private void OnTriggerEnter(Collider autre)
    {
        // V�rifie si l'objet entrant a le tag "Joueur" et si l'�v�nement n'a pas encore �t� d�clench�
        if (autre.CompareTag("Joueur") && !dejaDeclenche)
        {
            dejaDeclenche = true; // Marque l'�v�nement comme d�j� d�clench� pour �viter les r�p�titions

            if (sonJouer != null)
            {
                sourceAudio.PlayOneShot(sonJouer); // Joue le son.
            }

            AfficherObjet();      // Appelle la m�thode pour activer/d�sactiver les objets
        }
    }

    // M�thode qui g�re l'activation/d�sactivation des objets et le son
    private void AfficherObjet()
    {
        // D�sactive l'objet sp�cifi�, si celui-ci est assign�
        if (objetADesactiver != null)
        {
            objetADesactiver.SetActive(false);
        }

        // Active l'autre objet sp�cifi�, si celui-ci est assign�
        if (objetActiver != null)
        {
            objetActiver.SetActive(true);
        }
    }
}
