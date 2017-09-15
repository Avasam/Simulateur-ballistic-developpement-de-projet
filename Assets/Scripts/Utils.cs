using System;
using UnityEngine;

public static class Utils {
    public static Sprite emptySprite = Resources.Load<Sprite>("empty");

    public static Transform FindChildByName(this Transform objectTransform, string childName) {
        for (int i = 0; i < objectTransform.childCount; i++) {
            if (childName.Equals(objectTransform.GetChild(i).name)) {
                return objectTransform.GetChild(i);
            }
        }
        return null;
    }


    public static Sprite LoadSpriteFromSheet(string path, int index) {
        try {
            return (Sprite)Resources.LoadAll(path)[index+1];
        }
        catch (IndexOutOfRangeException) {
            Debug.LogWarning("Error getting: " + path + " #" + index);
            return null;
        }
        catch (InvalidCastException) {
            Debug.LogWarning("Error getting: " + path + " #" + index);
            return Resources.Load<Sprite>("path");
        }
    }


    public static bool HasParent(this Transform childTransform, Transform parentTransform, bool includeSelf = true) {
        if (includeSelf && childTransform == parentTransform) return true;
        while (childTransform.parent != null) {
            if (childTransform.parent == parentTransform) return true;
            childTransform = childTransform.parent;
        }
        return false; // Could not find given parent.
    }
    public static bool HasParent(this Transform childTransform, GameObject parentObject, bool includeSelf = true) {
        return HasParent(childTransform, parentObject.transform, includeSelf);
    }
    public static bool HasParent(this GameObject childObject, GameObject parentObject, bool includeSelf = true) {
        return HasParent(childObject.transform, parentObject.transform, includeSelf);
    }
    public static bool HasParent(this Collider2D childObject, GameObject parentObject, bool includeSelf = true) {
        return HasParent(childObject.transform, parentObject.transform, includeSelf);
    }
    public static bool HasParent(this RaycastHit2D childObject, GameObject parentObject, bool includeSelf = true) {
        return HasParent(childObject.transform, parentObject.transform, includeSelf);
    }

}
