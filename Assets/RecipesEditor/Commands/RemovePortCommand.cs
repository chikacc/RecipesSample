using System.Collections.Generic;
using RecipesEditor.NodeModels;
using Unity.CommandStateObserver;
using Unity.GraphToolsFoundation.Editor;

namespace RecipesEditor.Commands {
    sealed class RemovePortCommand : ModelCommand<MixNodeModel> {
        const string UndoStringSingular = "Remove Ingredient";

        public RemovePortCommand(IReadOnlyList<MixNodeModel> nodes)
            : base(UndoStringSingular, UndoStringSingular, nodes) { }

        public static void DefaultHandler(UndoStateComponent undoState, GraphModelStateComponent graphModelState,
            RemovePortCommand command) {
            if (command.Models.Count < 1) return;
            using (var undoStateUpdater = undoState.UpdateScope) {
                undoStateUpdater.SaveState(graphModelState);
            }

            using var graphUpdater = graphModelState.UpdateScope;
            using var changeScope = graphModelState.GraphModel.ChangeDescriptionScope;
            foreach (var nodeModel in command.Models) nodeModel.RemoveIngredientPort();
            graphUpdater.MarkUpdated(changeScope.ChangeDescription);
        }
    }
}
