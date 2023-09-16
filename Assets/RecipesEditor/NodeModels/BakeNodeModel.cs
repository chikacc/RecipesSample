using System;
using Unity.GraphToolsFoundation.Editor;

namespace RecipesEditor.NodeModels {
    [Serializable]
    [LibraryItem(typeof(RecipeStencil), SearchContext.Graph, "Cooking/Bake")]
    sealed class BakeNodeModel : NodeModel {
        public int Temperature = 180;
        public int Minutes = 60;

        protected override void OnDefineNode() {
            AddInputPort("Cookware", PortType.Data, RecipeStencil.Cookware, options: PortModelOptions.NoEmbeddedConstant);
            AddInputPort("Ingredient", PortType.Data, RecipeStencil.Ingredient, options: PortModelOptions.NoEmbeddedConstant);
            AddOutputPort("Result", PortType.Data, RecipeStencil.Ingredient, options: PortModelOptions.NoEmbeddedConstant);
        }
    }
}
