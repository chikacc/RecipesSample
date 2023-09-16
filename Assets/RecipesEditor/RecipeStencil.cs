using System.Collections.Generic;
using System.Linq;
using Unity.GraphToolsFoundation;
using Unity.GraphToolsFoundation.Editor;
using UnityEditor;

namespace RecipesEditor {
    sealed class RecipeStencil : Stencil {
        public const string GraphName = "Recipe";
        static readonly string[] Sections = { "Cookware", "Ingredients" };

        public RecipeStencil(GraphModel graphModel) : base(graphModel) { }

        public static TypeHandle Cookware { get; } = TypeHandleHelpers.GenerateCustomTypeHandle("Cookware");
        public static TypeHandle Ingredient { get; } = TypeHandleHelpers.GenerateCustomTypeHandle("Ingredient");

        public override BlackboardGraphModel CreateBlackboardGraphModel(GraphModel graphModel) {
            return new RecipeBlackboardModel { GraphModel = graphModel };
        }

        public override IEnumerable<string> SectionNames => GraphModel != null ? Sections : Enumerable.Empty<string>();

        public override void PopulateBlackboardCreateMenu(string sectionName, List<MenuItem> menuItems, RootView view,
            GroupModel selectedGroup = null) {
            var existingNames = GraphModel.VariableDeclarations.Select(x => x.Title).ToArray();
            var group = selectedGroup ?? GraphModel.GetSectionModel(sectionName);
            if (sectionName == Sections[0]) {
                var name = ObjectNames.GetUniqueName(existingNames, Cookware.Identification);
                menuItems.Add(new MenuItem {
                    name = "Add",
                    action = () =>
                        view.Dispatch(new CreateGraphVariableDeclarationCommand(name, true, Cookware, group))
                });
            } else if (sectionName == Sections[1]) {
                var name = ObjectNames.GetUniqueName(existingNames, Ingredient.Identification);
                menuItems.Add(new MenuItem {
                    name = "Add",
                    action = () =>
                        view.Dispatch(new CreateGraphVariableDeclarationCommand(name, true, Ingredient, group))
                });
            }
        }

        public override bool CanPasteNode(AbstractNodeModel originalModel, GraphModel graph) {
            return true;
        }

        public override bool CanPasteVariable(VariableDeclarationModel originalModel, GraphModel graph) {
            return true;
        }
    }
}
