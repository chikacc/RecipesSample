using System;
using Unity.GraphToolsFoundation.Editor;
using UnityEngine;

namespace RecipesEditor.NodeModels {
    [Serializable]
    [LibraryItem(typeof(RecipeStencil), SearchContext.Graph, "Preparation/Mix")]
    sealed class MixNodeModel : NodeModel {
        [HideInInspector]
        public int IngredientCount = 2;

        protected override void OnDefineNode() {
            AddInputPort("Cookware", PortType.Data, RecipeStencil.Cookware,
                options: PortModelOptions.NoEmbeddedConstant);
            for (var i = 0; i < IngredientCount; i++)
                AddInputPort("Ingredient " + (i + 1), PortType.Data, RecipeStencil.Ingredient,
                    options: PortModelOptions.NoEmbeddedConstant);
            AddOutputPort("Result", PortType.Data, RecipeStencil.Ingredient,
                options: PortModelOptions.NoEmbeddedConstant);
        }

        public void AddIngredientPort() {
            IngredientCount++;
            DefineNode();
        }

        public void RemoveIngredientPort() {
            IngredientCount--;
            if (IngredientCount < 2) IngredientCount = 2;
            DefineNode();
        }
    }
}
