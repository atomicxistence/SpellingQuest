using UnityEngine;
using UnityEditor;

[CustomEditor (typeof(GameEvent))]
public class GameEventEditor : Editor
{
    public override void OnInspectorGUI()
    {
        var gameEvent = (GameEvent)target;
        var targetName = gameEvent.name;

        base.OnInspectorGUI();

        GUILayout.Space(8f);

        if (GUILayout.Button($"Invoke {targetName}"))
        {
            gameEvent.Raise();
        }
    }
}
