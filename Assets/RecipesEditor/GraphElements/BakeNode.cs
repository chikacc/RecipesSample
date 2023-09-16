using Unity.GraphToolsFoundation.Editor;

namespace RecipesEditor.GraphElements {
    sealed class BakeNode : CollapsibleInOutNode {
        public static readonly string ParamContainerPartName = "param-container";

        protected override void BuildPartList() {
            base.BuildPartList();
            PartList.InsertPartAfter(titleIconContainerPartName,
                BakeNodePart.Create(ParamContainerPartName, Model, this, ussClassName));
        }
    }
}
