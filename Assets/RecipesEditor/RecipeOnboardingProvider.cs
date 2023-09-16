using Unity.CommandStateObserver;
using Unity.GraphToolsFoundation.Editor;
using UnityEngine.UIElements;

namespace RecipesEditor {
    sealed class RecipeOnboardingProvider : OnboardingProvider {
        public override VisualElement CreateOnboardingElements(ICommandTarget commandTarget) {
            var template = new GraphTemplate<RecipeStencil>(RecipeStencil.GraphName);
            return AddNewGraphButton<RecipeAsset>(commandTarget, template);
        }
    }
}
