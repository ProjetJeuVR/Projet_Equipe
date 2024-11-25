using UnityEngine;

public class GunController : MonoBehaviour {
    public GameObject bulletPrefab;  // Le prefab de la balle
    public Transform muzzle;         // Le point de sortie de la balle
    public float bulletSpeed = 10f;  // Vitesse de la balle

    private bool isGunGrabbed = false;  // Vérifie si l'arme est attrapée

    // Cette méthode est appelée automatiquement lorsque l'objet est attrapé
    public void OnGrab() {
        isGunGrabbed = true;
        Debug.Log("L'arme est attrapée !");
    }

    // Cette méthode est appelée automatiquement lorsque l'objet est relâché
    public void OnRelease() {
        isGunGrabbed = false;
        Debug.Log("L'arme est relâchée !");
    }

    void Update() {
        // Si l'arme est attrapée et que l'utilisateur appuie sur la gâchette
        if (isGunGrabbed && OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger)) {
            FireBullet();
        }
    }

    // Méthode pour tirer une balle
    private void FireBullet() {
        // Vérifiez que les assignations sont correctes
        if (bulletPrefab == null) {
            Debug.LogError("Le prefab de balle n'est pas assigné !");
            return;
        }
        if (muzzle == null) {
            Debug.LogError("Le point de sortie (muzzle) n'est pas assigné !");
            return;
        }

        // Instancier la balle
        GameObject bullet = Instantiate(bulletPrefab, muzzle.position, muzzle.rotation);

        // Vérifiez que l'instanciation a réussi
        if (bullet != null) {
            Debug.Log("Balle instanciée !");
        } else {
            Debug.LogError("Échec de l'instanciation !");
            return;
        }

        // Ajouter une force à la balle
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null) {
            rb.velocity = muzzle.forward * bulletSpeed;
            Debug.Log("Balle tirée avec une vitesse de " + bulletSpeed);
        } else {
            Debug.LogError("Le prefab de balle n'a pas de Rigidbody !");
        }

        // Optionnel : détruire la balle après 5 secondes
        Destroy(bullet, 5f);
    }
}
