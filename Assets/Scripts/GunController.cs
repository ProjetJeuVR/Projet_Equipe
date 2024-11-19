using UnityEngine;

public class GunController : MonoBehaviour {
    public GameObject bulletPrefab;  // Le prefab de la balle
    public Transform muzzle;         // Le point de sortie de la balle
    public float bulletSpeed = 10f;  // Vitesse de la balle

    private bool isGunGrabbed = false;  // V�rifie si l'arme est attrap�e

    // Cette m�thode est appel�e automatiquement lorsque l'objet est attrap�
    public void OnGrab() {
        isGunGrabbed = true;
        Debug.Log("L'arme est attrap�e !");
    }

    // Cette m�thode est appel�e automatiquement lorsque l'objet est rel�ch�
    public void OnRelease() {
        isGunGrabbed = false;
        Debug.Log("L'arme est rel�ch�e !");
    }

    void Update() {
        // Si l'arme est attrap�e et que l'utilisateur appuie sur la g�chette
        if (isGunGrabbed && OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger)) {
            FireBullet();
        }
    }

    // M�thode pour tirer une balle
    private void FireBullet() {
        // V�rifiez que les assignations sont correctes
        if (bulletPrefab == null) {
            Debug.LogError("Le prefab de balle n'est pas assign� !");
            return;
        }
        if (muzzle == null) {
            Debug.LogError("Le point de sortie (muzzle) n'est pas assign� !");
            return;
        }

        // Instancier la balle
        GameObject bullet = Instantiate(bulletPrefab, muzzle.position, muzzle.rotation);

        // V�rifiez que l'instanciation a r�ussi
        if (bullet != null) {
            Debug.Log("Balle instanci�e !");
        } else {
            Debug.LogError("�chec de l'instanciation !");
            return;
        }

        // Ajouter une force � la balle
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null) {
            rb.velocity = muzzle.forward * bulletSpeed;
            Debug.Log("Balle tir�e avec une vitesse de " + bulletSpeed);
        } else {
            Debug.LogError("Le prefab de balle n'a pas de Rigidbody !");
        }

        // Optionnel : d�truire la balle apr�s 5 secondes
        Destroy(bullet, 5f);
    }
}
