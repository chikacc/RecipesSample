using Unity.GraphToolsFoundation.Editor;

namespace RecipesEditor {
    sealed class RecipeBlackboardModel : BlackboardGraphModel {
        public override string GetBlackboardTitle() {
            if (GraphModel?.GetFriendlyScriptName() is not { } scriptName) return "Recipe";
            return scriptName;
        }

        public override string GetBlackboardSubTitle() {
            return "The Pantry";
        }
    }
}
