using System.Collections.Generic;
using RecipesEditor.GraphViews;
using Unity.GraphToolsFoundation.Editor;
using UnityEditor;
using UnityEngine;

namespace RecipesEditor {
    sealed class RecipeWindow : GraphViewEditorWindow {
        [MenuItem("Window/Recipe Editor")]
        public static void ShowWindow() {
            FindOrCreateGraphWindow<RecipeWindow>();
        }

        [InitializeOnLoadMethod]
        static void OnLoadMethod() {
            ShortcutHelper.RegisterDefaultShortcuts<RecipeWindow>(RecipeStencil.GraphName);
        }

        protected override void OnEnable() {
            base.OnEnable();
            titleContent = new GUIContent("Recipe Editor");
        }

        protected override BlankPage CreateBlankPage() {
            var onboardingProviders = new List<OnboardingProvider> { new RecipeOnboardingProvider() };
            return new BlankPage(GraphTool, onboardingProviders);
        }

        protected override GraphView CreateGraphView() {
            return RecipeView.Create(this, GraphTool, "Recipe Graph");
        }

        protected override bool CanHandleAssetType(GraphAsset asset) {
            return asset is RecipeAsset;
        }
    }
}
