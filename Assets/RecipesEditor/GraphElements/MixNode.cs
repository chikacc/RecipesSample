using RecipesEditor.Commands;
using RecipesEditor.NodeModels;
using Unity.GraphToolsFoundation.Editor;
using UnityEngine.UIElements;

namespace RecipesEditor.GraphElements {
    sealed class MixNode : CollapsibleInOutNode {
        protected override void BuildContextualMenu(ContextualMenuPopulateEvent evt) {
            base.BuildContextualMenu(evt);
            if (Model is not MixNodeModel mixNodeModel) return;
            if (evt.menu.MenuItems().Count > 0) evt.menu.AppendSeparator();
            evt.menu.AppendAction("Add Ingredient",
                _ => RootView.Dispatch(new AddPortCommand(new[] { mixNodeModel })));
            evt.menu.AppendAction("Remove Ingredient",
                _ => RootView.Dispatch(new RemovePortCommand(new[] { mixNodeModel })));
        }
    }
}
