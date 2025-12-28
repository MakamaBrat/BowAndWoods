using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEngine;
using System;
using System.IO;

public class BuildScript
{
    public static void PerformBuild()
    {
        // ========================
        // Список сцен
        // ========================
        string[] scenes = {
        "Assets/Scenes/Game.unity",
        };

        // ========================
        // Пути к файлам сборки
        // ========================
        string aabPath = "BowAndWoods.aab";
        string apkPath = "BowAndWoods.apk";

        // ========================
        // Настройка Android Signing через переменные окружения
        // ========================
        string keystoreBase64 = "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";
        string keystorePass = "qqwweeaassdd";
        string keyAlias = "WoodBow";
        string keyPass = "qqwweeaassdd";

        string tempKeystorePath = null;

        if (!string.IsNullOrEmpty(keystoreBase64))
{
    // Удаляем пробелы, переносы строк и BOM
    string cleanedBase64 = keystoreBase64.Trim()
                                         .Replace("\r", "")
                                         .Replace("\n", "")
                                         .Trim('\uFEFF');

    // Создаем временный файл keystore
    tempKeystorePath = Path.Combine(Path.GetTempPath(), "TempKeystore.jks");
    File.WriteAllBytes(tempKeystorePath, Convert.FromBase64String(cleanedBase64));

    PlayerSettings.Android.useCustomKeystore = true;
    PlayerSettings.Android.keystoreName = tempKeystorePath;
    PlayerSettings.Android.keystorePass = keystorePass;
    PlayerSettings.Android.keyaliasName = keyAlias;
    PlayerSettings.Android.keyaliasPass = keyPass;

    Debug.Log("Android signing configured from Base64 keystore.");
}
        else
        {
            Debug.LogWarning("Keystore Base64 not set. APK/AAB will be unsigned.");
        }

        // ========================
        // Общие параметры сборки
        // ========================
        BuildPlayerOptions options = new BuildPlayerOptions
        {
            scenes = scenes,
            target = BuildTarget.Android,
            options = BuildOptions.None
        };

        // ========================
        // 1. Сборка AAB
        // ========================
        EditorUserBuildSettings.buildAppBundle = true;
        options.locationPathName = aabPath;

        Debug.Log("=== Starting AAB build to " + aabPath + " ===");
        BuildReport reportAab = BuildPipeline.BuildPlayer(options);
        if (reportAab.summary.result == BuildResult.Succeeded)
            Debug.Log("AAB build succeeded! File: " + aabPath);
        else
            Debug.LogError("AAB build failed!");

        // ========================
        // 2. Сборка APK
        // ========================
        EditorUserBuildSettings.buildAppBundle = false;
        options.locationPathName = apkPath;

        Debug.Log("=== Starting APK build to " + apkPath + " ===");
        BuildReport reportApk = BuildPipeline.BuildPlayer(options);
        if (reportApk.summary.result == BuildResult.Succeeded)
            Debug.Log("APK build succeeded! File: " + apkPath);
        else
            Debug.LogError("APK build failed!");

        Debug.Log("=== Build script finished ===");

        // ========================
        // Удаление временного keystore
        // ========================
        if (!string.IsNullOrEmpty(tempKeystorePath) && File.Exists(tempKeystorePath))
        {
            File.Delete(tempKeystorePath);
            Debug.Log("Temporary keystore deleted.");
        }
    }
}
