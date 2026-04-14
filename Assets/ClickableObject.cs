using UnityEngine;

public class ClickableObject : MonoBehaviour
{
    private Renderer objectRenderer;
    private DataLogger logger;

    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        logger = Object.FindFirstObjectByType<DataLogger>();

        if (logger == null)
        {
            Debug.LogWarning("DataLogger introuvable !");
        }
    }

    public void OnObjectClicked()
    {
        // 🎨 Changer couleur
        if (objectRenderer != null)
        {
            objectRenderer.material.color =
                new Color(Random.value, Random.value, Random.value);
        }

        // 📊 Log data
        if (logger != null)
        {
            logger.LogClick(gameObject.name);
        }

        Debug.Log("Objet cliqué : " + gameObject.name);
    }
}
