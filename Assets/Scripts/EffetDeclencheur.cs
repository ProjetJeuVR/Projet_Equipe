using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffetDeclencheur : MonoBehaviour
{
    [Header("GameObject à manipuler")]
    public GameObject objetCible; // L'objet qui apparaîtra.

    [Header("Son à jouer")]
    public AudioClip sonJouer; // Le son à jouer.

    [Header("Durée d'apparition")]
    public float dureeApparition = 3f; // Temps pendant lequel l'objet reste actif.

    private AudioSource sourceAudio; // Source audio pour jouer le son.
    private bool dejaDeclenche = false; // Variable pour vérifier si l'effet a déjà été déclenché.

    void Start()
    {
        // Vérifie que l'objet cible est défini et désactivé
        if (objetCible != null)
        {
            objetCible.SetActive(false);
        }

        // Ajoute ou utilise un AudioSource existant sur l'objet
        sourceAudio = gameObject.AddComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider autre)
    {
        // Vérifie si c'est le joueur qui entre et si l'effet n'a pas encore été déclenché
        if (autre.CompareTag("Joueur") && !dejaDeclenche)
        {
            dejaDeclenche = true; // Marque l'effet comme déclenché.

            if (objetCible != null)
            {
                StartCoroutine(AfficherObjet());
            }

            if (sonJouer != null)
            {
                sourceAudio.PlayOneShot(sonJouer); // Joue le son.
            }
        }
    }

    private System.Collections.IEnumerator AfficherObjet()
    {
        // Active l'objet cible
        objetCible.SetActive(true);

        // Attend la durée spécifiée
        yield return new WaitForSeconds(dureeApparition);

        // Désactive l'objet cible
        objetCible.SetActive(false);
    }
}
