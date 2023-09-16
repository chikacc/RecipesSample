using System.Collections.Generic;
using RecipesEditor.NodeModels;
using Unity.CommandStateObserver;
using Unity.GraphToolsFoundation.Editor;

namespace RecipesEditor.Commands {
    sealed class SetMinutesCommand : ModelCommand<BakeNodeModel, int> {
        const string UndoStringSingular = "Set Bake Node Minutes";
        const string UndoStringPlural = "Set Bake Nodes Minutes";

        public SetMinutesCommand(int value, params BakeNodeModel[] models) : this(value,
            (IReadOnlyList<BakeNodeModel>)models) { }

        public SetMinutesCommand(int value, IReadOnlyList<BakeNodeModel> models) : base(UndoStringSingular,
            UndoStringPlural, value, models) { }

        public static void DefaultHandler(UndoStateComponent undoState, GraphModelStateComponent graphModelState,
            SetMinutesCommand command) {
            if (command.Models.Count < 1) return;
            using (var undoStateUpdater = undoState.UpdateScope) {
                undoStateUpdater.SaveState(graphModelState);
            }

            using var graphUpdater = graphModelState.UpdateScope;
            using var changeScope = graphModelState.GraphModel.ChangeDescriptionScope;
            foreach (var model in command.Models) model.Minutes = command.Value;
            graphUpdater.MarkUpdated(changeScope.ChangeDescription);
        }
    }
}
