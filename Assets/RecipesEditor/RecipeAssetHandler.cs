using Unity.GraphToolsFoundation.Editor;
using UnityEditor;
using UnityEditor.Callbacks;

namespace RecipesEditor {
    static class RecipeAssetHandler {
        [OnOpenAsset(1)]
        public static bool OpenGraphAsset(int instanceId, int line) {
            if (EditorUtility.InstanceIDToObject(instanceId) is not RecipeAsset graphAsset) return false;
            var window = GraphViewEditorWindow.ShowGraphInExistingOrNewWindow<RecipeWindow>(graphAsset);
            return window != null;
        }
    }
}
