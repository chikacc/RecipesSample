using System;
using Unity.GraphToolsFoundation.Editor;

namespace RecipesEditor {
    sealed class RecipeAsset : GraphAsset {
        protected override Type GraphModelType => typeof(RecipeModel);
    }
}
