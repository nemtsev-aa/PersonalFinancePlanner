using UnityEngine;
using UnityEditor;
using System;
using System.IO;

public class ReadableTextures {
    private string _iconsPath = "Resources/Textures/CategoryIcon";

    public ReadableTextures(string iconsPath = "") {
        if (iconsPath != "")
            _iconsPath = iconsPath;

        ReimportPNGTextures();
    }

    private void ReimportPNGTextures() {
        string[] pngFiles = Directory.GetFiles(Application.dataPath + "/" + _iconsPath, "*.png");

        if (pngFiles.Length == 0)
            throw new ArgumentNullException($"Folder [{_iconsPath}] is empty");

        foreach (string filePath in pngFiles) {
            string assetPath = "Assets/" + _iconsPath + "/" + Path.GetFileName(filePath);

            TextureImporter importer = AssetImporter.GetAtPath(assetPath) as TextureImporter;
            if (importer != null) {
                importer.textureType = TextureImporterType.Default;
                importer.textureCompression = TextureImporterCompression.Uncompressed;
                importer.isReadable = true;
                importer.SaveAndReimport();
            }
        }

        Debug.Log("Done");
    }



    private void Reimport() {
        string[] guids = AssetDatabase.FindAssets("t:texture2d", new[] { _iconsPath });
        foreach (string guid in guids) {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            TextureImporter textureImporter = AssetImporter.GetAtPath(path) as TextureImporter;
            if (textureImporter != null) {
                textureImporter.textureType = TextureImporterType.Default;
                textureImporter.textureCompression = TextureImporterCompression.Uncompressed;
                textureImporter.SaveAndReimport();
            }
        }
    }

    private void StartReadable() {
        Texture2D[] textures = Resources.LoadAll<Texture2D>(_iconsPath);

        if (textures.Length == 0)
            throw new ArgumentNullException($"Folder [{_iconsPath}] is empty");

        foreach (Texture2D texture in textures) {
            TextureImporter importer = AssetImporter.GetAtPath(AssetDatabase.GetAssetPath(texture)) as TextureImporter;

            if (importer != null && !importer.isReadable) {
                importer.isReadable = true;
                importer.SaveAndReimport();
            }
        }

        Debug.Log("Finished making icons readable");
    }
}
