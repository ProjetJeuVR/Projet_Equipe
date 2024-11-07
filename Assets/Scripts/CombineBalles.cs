using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Combine 2 objets ensembles pour le transformer en 1 autre

public class CombineBalles : MonoBehaviour
{
    // Référence du prefab de la balle mauve dans l'inspecteur
    public GameObject balleMauvePrefab;

    // Tag des balles rouge et bleu
    public string tagBalleRouge = "BalleRouge";
    public string tagBalleBleue = "BalleBleue";

    private void OnCollisionEnter(Collision collision)
    {
        // Vérifie si l'objet avec lequel cette balle entre en collision est une balle volante rouge ou une balle volante bleue
        if (gameObject.CompareTag(tagBalleRouge) && collision.gameObject.CompareTag(tagBalleBleue) ||
            gameObject.CompareTag(tagBalleBleue) && collision.gameObject.CompareTag(tagBalleRouge))
        {
            // Position où la nouvelle balle mauve va apparaître (moyenne des positions des deux balles)
            Vector3 positionMoyenne = (transform.position + collision.transform.position) / 2;

            // Instancie la balle mauve
            Instantiate(balleMauvePrefab, positionMoyenne, Quaternion.identity);

            // Détruit les deux balles originales
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
