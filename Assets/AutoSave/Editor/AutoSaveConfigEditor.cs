using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

[CustomEditor(typeof(AutoSaveConfig))]
public class AutoSaveConfigEditor : Editor
{
    private static AutoSaveConfig _config;
    private static CancellationTokenSource _tokenSource;
    private static Task _task;

    [InitializeOnLoadMethod]
    private static void OnInitialize()
    {
        FetchConfig();
        CancelTask();
        
        _tokenSource = new CancellationTokenSource();
        _task = SaveInterval(_tokenSource.Token);
    }

    private static void FetchConfig()
    {
        while (true)
        {
            if (_config != null) return;

            string path = GetConfigPath();

            if (path == null)
            {
                AssetDatabase.CreateAsset(CreateInstance<AutoSaveConfig>(), $"Assets/AutoSave/{nameof(AutoSaveConfig)}.asset");
                continue;
            }

            _config = AssetDatabase.LoadAssetAtPath<AutoSaveConfig>(path);
            break;
        }
    }

    private static string GetConfigPath()
    {
        List<string> paths = AssetDatabase.FindAssets(nameof(AutoSaveConfig)).Select(AssetDatabase.GUIDToAssetPath).Where(c => c.EndsWith(".asset")).ToList();
        if (paths.Count > 1) Debug.LogWarning("Multiple auto save config assets found. Delete one.");
        return paths.FirstOrDefault();
    }

    private static void CancelTask()
    {
        if (_task == null) return;
        _tokenSource.Cancel();
        _task.Wait();
    }

    private static async Task SaveInterval(CancellationToken token)
    {
        while (!token.IsCancellationRequested)
        {
            await Task.Delay(_config.Frequency * 1000 * 60, token);
            if (_config == null) FetchConfig();
            if (!_config.Enable || Application.isPlaying || BuildPipeline.isBuildingPlayer || EditorApplication.isCompiling) continue;
            if (!UnityEditorInternal.InternalEditorUtility.isApplicationActive) continue;

            EditorSceneManager.SaveOpenScenes();
            if (_config.Logging) Debug.Log($"Auto-saved at {DateTime.Now:h:mm:ss tt}");
        }
    }

    [MenuItem("Window/Auto save/Find config")]
    public static void ShowConfig()
    {
        FetchConfig();

        string path = GetConfigPath();
        EditorGUIUtility.PingObject(AssetDatabase.LoadAssetAtPath<AutoSaveConfig>(path).GetInstanceID());
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
    }
}
