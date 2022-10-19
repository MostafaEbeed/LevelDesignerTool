using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace MostafaEbeed.Tools
{
    public class IP_ReplaceObject_Menu
    {
        [MenuItem("MostafaEbeed/Utils/Level Tools/Replace Selected Objects")]
        public static void ReplaceSelectedObjects()
        {
            IP_ReplaceObject_Editor.LaunchEditor();
        }
    }
}
