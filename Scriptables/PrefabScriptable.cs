using UnityEngine;

[CreateAssetMenu(fileName = "Prefabs", menuName = "ScriptableObjects/Prefabs", order = 1)]
public class PrefabScriptable : ScriptableObject
{
    [SerializeField] private GameObject[] prefabs;

    public GameObject GetPrefab(int num)
    {
        if(prefabs == null || prefabs.Length < num)
        {
            Debug.LogError("Prefab load error!");

            return null;
        }

        return prefabs[num];
    }
}