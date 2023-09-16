using RecipesEditor.Commands;
using Unity.GraphToolsFoundation.Editor;

namespace RecipesEditor.GraphViews {
    sealed class RecipeView : GraphView {
        RecipeView(GraphViewEditorWindow window, BaseGraphTool graphTool, string graphViewName,
            GraphViewDisplayMode displayMode = GraphViewDisplayMode.Interactive) : base(window, graphTool,
            graphViewName, displayMode) {
            this.RegisterCommandHandler<SetTemperatureCommand>(SetTemperatureCommand.DefaultHandler);
            this.RegisterCommandHandler<SetMinutesCommand>(SetMinutesCommand.DefaultHandler);
            this.RegisterCommandHandler<AddPortCommand>(AddPortCommand.DefaultHandler);
            this.RegisterCommandHandler<RemovePortCommand>(RemovePortCommand.DefaultHandler);
        }

        public new static RecipeView Create(GraphViewEditorWindow window, BaseGraphTool graphTool, string graphViewName,
            GraphViewDisplayMode displayMode = GraphViewDisplayMode.Interactive) {
            var graphView = new RecipeView(window, graphTool, graphViewName, displayMode);
            graphView.Initialize();
            return graphView;
        }
    }
}
