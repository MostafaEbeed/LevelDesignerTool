using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


namespace MostafaEbeed.Tools
{
    public class IP_ReplaceObject_Editor : EditorWindow
    {
        #region Variables

        int currentSelectionCount = 0;
        GameObject wantedObject;

        #endregion




        #region BuiltinMethods

        public static void LaunchEditor()
        {
            var editorWin = GetWindow<IP_ReplaceObject_Editor>("Replace Objects");
            editorWin.Show();
        }


        private void OnGUI()
        {
            // Check the amount of selected objects
            GetSelection();

            EditorGUILayout.BeginVertical();
            EditorGUILayout.Space();

            EditorGUILayout.LabelField("Selection Count: " + currentSelectionCount.ToString(), EditorStyles.boldLabel);
            EditorGUILayout.Space();


            wantedObject = (GameObject) EditorGUILayout.ObjectField("Replace Object", wantedObject, typeof(GameObject), true);
            if (GUILayout.Button("Replace", GUILayout.ExpandWidth(true), GUILayout.Height(40)))
            {
                ReplaceSelectedObjects();
            }

            EditorGUILayout.Space();
            EditorGUILayout.EndVertical();

            Repaint();
        }

        #endregion




        #region CustomMethods

        void GetSelection()
        {
            currentSelectionCount = 0;
            currentSelectionCount = Selection.gameObjects.Length;
        }

        void ReplaceSelectedObjects()
        {
            if (currentSelectionCount == 0)
            {
                CustomDialog("Make sure you have at least one Object selected");
                return;
            }

            if (!wantedObject)
            {
                CustomDialog("The Target Object is Empty, Please assign something!");
                return;
            }


            //Replace Implementation
            GameObject[] selectedObjects = Selection.gameObjects;
            for (int i = 0; i < selectedObjects.Length; i++)
            {
                Transform selectedTransform = selectedObjects[i].transform;
                GameObject newObject = Instantiate(wantedObject, selectedTransform.position, selectedTransform.rotation);
                newObject.transform.localScale = selectedTransform.localScale;
                Undo.RegisterCreatedObjectUndo(newObject, "Replace With Prefabs");


                Undo.DestroyObjectImmediate(selectedObjects[i]);
                
            }
            
        }


        void CustomDialog(string message)
        {
            EditorUtility.DisplayDialog("No Objects Detected", message, "Ok");
        }

        #endregion
    }
}
