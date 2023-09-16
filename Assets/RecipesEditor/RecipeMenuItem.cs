using Unity.GraphToolsFoundation.Editor;
using UnityEditor;

namespace RecipesEditor {
    static class RecipeMenuItem {
        [MenuItem("Assets/Create/Recipe")]
        public static void CreateGraph(MenuCommand menuCommand) {
            const string path = "Assets";
            var template = new GraphTemplate<RecipeStencil>(RecipeStencil.GraphName);
            GraphAssetCreationHelpers.CreateInProjectWindow<RecipeAsset>(template, path,
                graphAsset => GraphViewEditorWindow.ShowGraphInExistingOrNewWindow<RecipeWindow>(graphAsset));
        }
    }
}
