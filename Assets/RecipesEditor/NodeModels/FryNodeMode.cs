using System;
using Unity.GraphToolsFoundation.Editor;

namespace RecipesEditor.NodeModels {
    [Serializable]
    [LibraryItem(typeof(RecipeStencil), SearchContext.Graph, "Cooking/Fry")]
    sealed class FryNodeMode : NodeModel {
        protected override void OnDefineNode() {
            AddInputPort("Cookware", PortType.Data, RecipeStencil.Cookware, options: PortModelOptions.NoEmbeddedConstant);
            AddInputPort("Ingredient", PortType.Data, RecipeStencil.Ingredient, options: PortModelOptions.NoEmbeddedConstant);
            AddOutputPort("Result", PortType.Data, RecipeStencil.Ingredient, options: PortModelOptions.NoEmbeddedConstant);
        }
    }
}
