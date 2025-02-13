using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] GameObject playerDestroyedVFX;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // Scriptをオフにしてもここだけは生きている
    private void OnTriggerEnter(Collider other)
    {
        Instantiate(playerDestroyedVFX, this.transform.position, Quaternion.identity);
        // Debug.Log("Hit" + other.gameObject.name);
        // Debug.Log($"Hit {other.gameObject.name}");
        Destroy(gameObject);
    }
}
