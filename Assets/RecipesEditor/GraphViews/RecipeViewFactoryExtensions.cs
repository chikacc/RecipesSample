using RecipesEditor.GraphElements;
using RecipesEditor.NodeModels;
using Unity.GraphToolsFoundation.Editor;

namespace RecipesEditor.GraphViews {
    [GraphElementsExtensionMethodsCache(typeof(RecipeView))]
    static class RecipeViewFactoryExtensions {
        public static ModelView CreateNode(this ElementBuilder elementBuilder, BakeNodeModel model) {
            var ui = new BakeNode();
            ui.SetupBuildAndUpdate(model, elementBuilder.View, elementBuilder.Context);
            return ui;
        }

        public static ModelView CreateNode(this ElementBuilder elementBuilder, MixNodeModel model) {
            var ui = new MixNode();
            ui.SetupBuildAndUpdate(model, elementBuilder.View, elementBuilder.Context);
            return ui;
        }
    }
}
