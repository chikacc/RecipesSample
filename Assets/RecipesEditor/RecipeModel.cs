using Unity.GraphToolsFoundation.Editor;

namespace RecipesEditor {
    sealed class RecipeModel : GraphModel {
        protected override bool IsCompatiblePort(PortModel startPortModel, PortModel compatiblePortModel) {
            return startPortModel.DataTypeHandle == compatiblePortModel.DataTypeHandle;
        }
    }
}
