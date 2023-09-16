using RecipesEditor.Commands;
using RecipesEditor.NodeModels;
using Unity.GraphToolsFoundation;
using Unity.GraphToolsFoundation.Editor;
using UnityEditor;
using UnityEngine.UIElements;

namespace RecipesEditor.GraphElements {
    sealed class BakeNodePart : BaseModelViewPart {
        public const string UssClassName = "ge-bake-node-part";
        public const string TemperatureLabelName = "temperature";
        public const string MinutesLabelName = "minutes";

        VisualElement _root;
        EditableLabel _temperature;
        EditableLabel _minutes;

        BakeNodePart(string name, Model model, ChildView ownerElement, string parentClassName) : base(name,
            model, ownerElement, parentClassName) { }

        public override VisualElement Root => _root;

        public static BakeNodePart Create(string name, Model model, ChildView ownerElement,
            string parentClassName) {
            if (model is not NodeModel) return null;
            return new BakeNodePart(name, model, ownerElement, parentClassName);
        }

        protected override void BuildPartUI(VisualElement container) {
            if (m_Model is not BakeNodeModel) return;
            var root = new VisualElement { name = "temperature-and-time-container" };
            root.AddToClassList(UssClassName);
            root.AddToClassList(m_ParentClassName.WithUssElement(PartName));
            _root = root;
            container.Add(root);

            var temperatureLabel = new EditableLabel { name = TemperatureLabelName };
            _temperature = temperatureLabel;
            temperatureLabel.RegisterCallback<ChangeEvent<string>>(OnChangeTemperature);
            root.Add(temperatureLabel);

            var minutesLabel = new EditableLabel { name = MinutesLabelName };
            _minutes = minutesLabel;
            minutesLabel.RegisterCallback<ChangeEvent<string>>(OnChangeMinutes);
            root.Add(minutesLabel);
        }

        protected override void PostBuildPartUI() {
            base.PostBuildPartUI();
            var stylesheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/RecipesEditor/GraphElements/StyleSheets/BakeNodePart.uss");
            if (stylesheet == null) return;
            _root.styleSheets.Add(stylesheet);
        }

        protected override void UpdatePartFromModel() {
            if (m_Model is not BakeNodeModel nodeModel) return;
            _temperature.SetValueWithoutNotify($"{nodeModel.Temperature} °C");
            _minutes.SetValueWithoutNotify($"{nodeModel.Minutes} min.");
        }

        void OnChangeTemperature(ChangeEvent<string> evt) {
            if (m_Model is not BakeNodeModel nodeModel) return;
            if (int.TryParse(evt.newValue, out var temperature))
                m_OwnerElement.RootView.Dispatch(new SetTemperatureCommand(temperature, nodeModel));
        }

        void OnChangeMinutes(ChangeEvent<string> evt) {
            if (m_Model is not BakeNodeModel nodeModel) return;
            if (int.TryParse(evt.newValue, out var minutes))
                m_OwnerElement.RootView.Dispatch(new SetMinutesCommand(minutes, nodeModel));
        }
    }
}
