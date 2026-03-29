using System;
using System.IO;
using UnityEngine;

/// <summary>
/// Generic Save/Load Utility
/// Can save and load any serializable class to a JSON file.
/// Handles missing or invalid files gracefully.
/// </summary>
public static class SaveLoadUtility
{
    // Default folder for saves
    private static readonly string SaveFolder = Path.Combine(Application.persistentDataPath, "Saves");

    /// <summary>
    /// Save any serializable data to a JSON file.
    /// </summary>
    /// <typeparam name="T">Type of data to save</typeparam>
    /// <param name="fileName">Name of the file (without path)</param>
    /// <param name="data">Data object to save</param>
    public static void Save<T>(string fileName, T data)
    {
        Debug.Log(SaveFolder);
        try
        {
            if (!Directory.Exists(SaveFolder))
                Directory.CreateDirectory(SaveFolder);

            string filePath = Path.Combine(SaveFolder, fileName + ".json");
            string json = JsonUtility.ToJson(data, true); // pretty print for readability
            File.WriteAllText(filePath, json);
            Debug.Log($"[SaveLoadUtility] Saved {typeof(T)} to {filePath}");
        }
        catch (Exception e)
        {
            Debug.LogError($"[SaveLoadUtility] Failed to save {typeof(T)}: {e}");
        }
    }

    /// <summary>
    /// Load data from a JSON file.
    /// Returns default(T) if file is missing or data is invalid.
    /// </summary>
    /// <typeparam name="T">Type of data to load</typeparam>
    /// <param name="fileName">Name of the file (without path)</param>
    /// <returns>Loaded data or default(T)</returns>
    public static T Load<T>(string fileName)
    {
        string filePath = Path.Combine(SaveFolder, fileName + ".json");

        if (!File.Exists(filePath))
        {
            Debug.LogWarning($"[SaveLoadUtility] File not found: {filePath}");
            return default;
        }
        try
        {
            string json = File.ReadAllText(filePath);
            T data = JsonUtility.FromJson<T>(json);
            if (data == null)
            {
                Debug.LogWarning($"[SaveLoadUtility] Data invalid or empty in {filePath}");
                return default;
            }
            return data;
        }
        catch (Exception e)
        {
            Debug.LogError($"[SaveLoadUtility] Failed to load {typeof(T)}: {e}");
            return default;
        }
    }
    /// <summary>
    /// Delete a saved file safely.
    /// </summary>
    public static void Delete(string fileName)
    {
        string filePath = Path.Combine(SaveFolder, fileName + ".json");
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
            Debug.Log($"[SaveLoadUtility] Deleted {filePath}");
        }
        else
        {
            Debug.LogWarning($"[SaveLoadUtility] Cannot delete, file not found: {filePath}");
        }
    }
}