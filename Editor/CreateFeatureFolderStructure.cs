using System.IO;
using UnityEditor;
using UnityEngine;

namespace WeNeedAGoodOrganizationName.EditorTools
{
    public static class FeatureFolderStructure
    {
        private static readonly string _rootname = "FeatureName";

        // "Drive:/ProjectPath/Assets/OptionalSelection/_rootname/" + _subDirPaths
        private static readonly string[] _subDirPaths = new string[]
        {
            "Resources",
            "Scripts",

            "Scripts/ScriptableObjects",
            "Scripts/Networking",

            "Resources/Materials",
            "Resources/Textures",
            "Resources/Prefabs",
            "Resources/Shader",
            "Resources/Models",
        };
 

        [MenuItem("Assets/Create/Create Feature Structure", false, 20)]
        public static void CreateDefaultStructure()
        {
            string basePath = GetProjectPath();
            CreateDirectories(basePath);

            AssetDatabase.Refresh();
        }

        /// <summary>
        /// Returns the path where the feature folder will be placed in.
        /// If no location is selected it will return the standard Asset folder path.
        /// </summary>
        private static string GetProjectPath()
        {
            string localPath = AssetDatabase.GetAssetPath(Selection.activeObject);
            string basePath = Application.dataPath;
            
            // Remove the "/Assets" at the end because we use it from the local path.
            basePath = basePath.Remove(basePath.Length - 7, 7);

            if (localPath == "") localPath = "Assets";

            return basePath + "/" + localPath;
        }

        private static void CreateDirectories(string basePath)
        {
            basePath = basePath + "/" + _rootname;

            foreach (string dirPath in _subDirPaths)
            {
                Directory.CreateDirectory(basePath + "/" + dirPath);
            }
        }
    }
}
