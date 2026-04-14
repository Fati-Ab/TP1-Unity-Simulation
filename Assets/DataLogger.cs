using UnityEngine;
using System.IO;
using System.Collections.Generic;

[System.Serializable]
public class SessionData
{
    public int totalClicks = 0;
    public float timeInScene = 0f;
    public List<string> clickedObjects = new List<string>();
    public List<string> playerPositions = new List<string>();
}

public class DataLogger : MonoBehaviour
{
    public Transform player;
    public float logInterval = 2f;

    private SessionData data = new SessionData();
    private float timer = 0f;

    void Update()
    {
        // ⏱ Temps total
        data.timeInScene += Time.deltaTime;

        // 📍 Position joueur
        timer += Time.deltaTime;

        if (timer >= logInterval && player != null)
        {
            timer = 0f;

            string pos =
                $"Time:{Time.time:F2} | X:{player.position.x:F1}, Y:{player.position.y:F1}, Z:{player.position.z:F1}";

            data.playerPositions.Add(pos);
        }
    }

    public void LogClick(string objectName)
    {
        data.totalClicks++;

        string log =
            objectName + " | Time: " + Time.time.ToString("F2");

        data.clickedObjects.Add(log);
    }

    void OnApplicationQuit()
    {
        string path =
            Application.persistentDataPath + "/donnees_simulation.json";

        string content = JsonUtility.ToJson(data, true);

        File.WriteAllText(path, content);

        Debug.Log("Données sauvegardées ici : " + path);
    }
}
