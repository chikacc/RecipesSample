using System.Collections.Generic;
using RecipesEditor.NodeModels;
using Unity.CommandStateObserver;
using Unity.GraphToolsFoundation.Editor;

namespace RecipesEditor.Commands {
    sealed class AddPortCommand : ModelCommand<MixNodeModel> {
        const string UndoStringSingular = "Add Ingredient";

        public AddPortCommand(IReadOnlyList<MixNodeModel> nodes) :
            base(UndoStringSingular, UndoStringSingular, nodes) { }

        public static void DefaultHandler(UndoStateComponent undoState, GraphModelStateComponent graphModelState,
            AddPortCommand command) {
            if (command.Models.Count < 1) return;
            using (var undoStateUpdater = undoState.UpdateScope) {
                undoStateUpdater.SaveState(graphModelState);
            }

            using var graphUpdater = graphModelState.UpdateScope;
            using var changeScope = graphModelState.GraphModel.ChangeDescriptionScope;
            foreach (var nodeModel in command.Models) nodeModel.AddIngredientPort();
            graphUpdater.MarkUpdated(changeScope.ChangeDescription);
        }
    }
}
