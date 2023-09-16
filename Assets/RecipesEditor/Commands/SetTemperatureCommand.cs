using System.Collections.Generic;
using RecipesEditor.NodeModels;
using Unity.CommandStateObserver;
using Unity.GraphToolsFoundation.Editor;

namespace RecipesEditor.Commands {
    sealed class SetTemperatureCommand : ModelCommand<BakeNodeModel, int> {
        const string UndoStringSingular = "Set Bake Node Temperature";
        const string UndoStringPlural = "Set Bake Nodes Temperature";

        public SetTemperatureCommand(int value, params BakeNodeModel[] models) : this(value,
            (IReadOnlyList<BakeNodeModel>)models) { }

        public SetTemperatureCommand(int value, IReadOnlyList<BakeNodeModel> models) : base(UndoStringSingular,
            UndoStringPlural, value, models) { }

        public static void DefaultHandler(UndoStateComponent undoState, GraphModelStateComponent graphModelState,
            SetTemperatureCommand command) {
            if (command.Models is { Count: < 1 }) return;
            using (var undoStateUpdater = undoState.UpdateScope) {
                undoStateUpdater.SaveState(graphModelState);
            }

            using var graphUpdater = graphModelState.UpdateScope;
            using var changeScope = graphModelState.GraphModel.ChangeDescriptionScope;
            foreach (var model in command.Models) model.Temperature = command.Value;
            graphUpdater.MarkUpdated(changeScope.ChangeDescription);
        }
    }
}
