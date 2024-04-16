using UnityEditor;
using UnityEditor.Scripting.Python;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MenuItem_hello_Class
{
   [MenuItem("Python Scripts/hello")]
   public static void hello()
   {
       PythonRunner.RunFile("Assets/new_python_script.py");
       }
};



