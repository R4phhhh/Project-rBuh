using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;

public static class GlobalVariables
{
    public static int charCode = 1;
}
public class settingAttackHitbox : MonoBehaviour
{ 
    void Start()
    {
        // 1. Get player (ensure it has "Player" tag)
        Transform player = GameObject.FindWithTag("Player")?.transform;
        if (!player)
        {
            Debug.LogError("Player not found! Tag a GameObject as 'Player'");
            return;
        }

        // 2. Load and spawn hitbox
        string prefabName = $"attackHitbox{GlobalVariables.charCode}";
        
        #if UNITY_EDITOR
        var prefab = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(
            $"Assets/characterHitbox/{prefabName}.prefab");
        #else
        var prefab = Resources.Load<GameObject>($"characterHitbox/{prefabName}");
        #endif

        if (prefab)
        {
            Instantiate(prefab, player.position, player.rotation);
            Debug.Log($"{prefabName} spawned at player's exact position");
        }
        else Debug.LogError($"Prefab not found: {prefabName}");
    }
}
