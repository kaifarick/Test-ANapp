
using UnityEngine;

public class EditorTools
{
    [UnityEditor.MenuItem("Tools/Clear App Data")]
    private static void ClearAppData()
    {
        PlayerPrefs.DeleteAll();
    }
}
