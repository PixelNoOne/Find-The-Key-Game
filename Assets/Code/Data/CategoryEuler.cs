using UnityEngine;

[CreateAssetMenu(fileName = "CategoryEuler", menuName = "Scriptable Objects/CategoryEuler")]
public class CategoryEuler : ScriptableObject
{
    public Quaternion openRotation = Quaternion.Euler(0f, 0f, 0f);
}
