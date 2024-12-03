using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffetDeclencheur : MonoBehaviour
{
    [Header("GameObject � manipuler")]
    public GameObject objetCible; // L'objet qui appara�tra.

    [Header("Son � jouer")]
    public AudioClip sonJouer; // Le son � jouer.

    [Header("Dur�e d'apparition")]
    public float dureeApparition = 3f; // Temps pendant lequel l'objet reste actif.

    private AudioSource sourceAudio; // Source audio pour jouer le son.
    private bool dejaDeclenche = false; // Variable pour v�rifier si l'effet a d�j� �t� d�clench�.

    void Start()
    {
        // V�rifie que l'objet cible est d�fini et d�sactiv�
        if (objetCible != null)
        {
            objetCible.SetActive(false);
        }

        // Ajoute ou utilise un AudioSource existant sur l'objet
        sourceAudio = gameObject.AddComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider autre)
    {
        // V�rifie si c'est le joueur qui entre et si l'effet n'a pas encore �t� d�clench�
        if (autre.CompareTag("Joueur") && !dejaDeclenche)
        {
            dejaDeclenche = true; // Marque l'effet comme d�clench�.

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

        // Attend la dur�e sp�cifi�e
        yield return new WaitForSeconds(dureeApparition);

        // D�sactive l'objet cible
        objetCible.SetActive(false);
    }
}
