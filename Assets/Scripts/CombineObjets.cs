using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Combine 2 objets ensembles pour le transformer en 1 autre

public class CombineObjets : MonoBehaviour
{
    // Référence du prefab de l'objet 3 dans l'inspecteur
    public GameObject objet3Prefab;

    // Tag des objets
    public string tagObjet1 = "Objet1";
    public string tagObjet2 = "Objet2";

    private void OnCollisionEnter(Collision collision)
    {
        // Vérifie si l'objet avec lequel cette l'objet1 entre en collision est l'objet1 ou l'objet2
        if (gameObject.CompareTag(tagObjet1) && collision.gameObject.CompareTag(tagObjet2) ||
            gameObject.CompareTag(tagObjet2) && collision.gameObject.CompareTag(tagObjet1))
        {
            // Position où l'objet 3 va apparaître (moyenne des positions des deux objets)
            Vector3 positionMoyenne = (transform.position + collision.transform.position) / 2;

            // Instancie l'objet 3
            Instantiate(objet3Prefab, positionMoyenne, Quaternion.identity);

            // Détruit les deux objets originales
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
