using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace ModalWPF.Controls
{
    public partial class Modal : UserControl
    {
        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            this.Visibility = Visibility.Hidden;

            var parentGrid = new FrameworkElementFactory(typeof(Grid));
            var child1 = new FrameworkElementFactory(typeof(Grid));
            child1.SetValue(Grid.BackgroundProperty, Brushes.Black);
            child1.SetValue(Grid.OpacityProperty, 0.5);
            parentGrid.AppendChild(child1);

            var row1 = new FrameworkElementFactory(typeof(RowDefinition));
            row1.SetValue(RowDefinition.HeightProperty, new GridLength(1, GridUnitType.Star));
            var row2 = new FrameworkElementFactory(typeof(RowDefinition));
            row2.SetValue(RowDefinition.HeightProperty, new GridLength(2, GridUnitType.Star));
            var row3 = new FrameworkElementFactory(typeof(RowDefinition));
            row3.SetValue(RowDefinition.HeightProperty, new GridLength(1, GridUnitType.Star));

            var col1 = new FrameworkElementFactory(typeof(ColumnDefinition));
            col1.SetValue(ColumnDefinition.WidthProperty, new GridLength(1, GridUnitType.Star));
            var col2 = new FrameworkElementFactory(typeof(ColumnDefinition));
            col2.SetValue(ColumnDefinition.WidthProperty, new GridLength(3, GridUnitType.Star));
            var col3 = new FrameworkElementFactory(typeof(ColumnDefinition));
            col3.SetValue(ColumnDefinition.WidthProperty, new GridLength(1, GridUnitType.Star));

            var child2 = new FrameworkElementFactory(typeof(Grid));
            child2.AppendChild(row1);
            child2.AppendChild(row2);
            child2.AppendChild(row3);

            child2.AppendChild(col1);
            child2.AppendChild(col2);
            child2.AppendChild(col3);

            var grandChild = new FrameworkElementFactory(typeof(Grid));
            //Grid.SetRow(grandChild, 1);
            //Grid.SetColumn(grandChild, 1);
            grandChild.SetValue(Grid.RowProperty, 1);
            grandChild.SetValue(Grid.ColumnProperty, 1);
            grandChild.SetValue(Grid.BackgroundProperty, Brushes.White);
            grandChild.SetValue(Grid.EffectProperty, new DropShadowEffect() { ShadowDepth = 0, Opacity = 0.2 });
            var contentPresenter = new FrameworkElementFactory(typeof(ContentPresenter));
            Binding binding = new Binding("Content");
            //binding.Source = Content;
            binding.RelativeSource = RelativeSource.TemplatedParent;
            //BindingOperations.SetBinding(contentPresenter, ContentPresenter.ContentProperty, binding);
            contentPresenter.SetBinding(ContentPresenter.ContentProperty, binding);
            grandChild.AppendChild(contentPresenter);

            child2.AppendChild(grandChild);
            parentGrid.AppendChild(child2);
            DataTemplate template = new DataTemplate() { VisualTree = parentGrid };
            this.ContentTemplate = template;
        }

        public void Show()
        {
            Visibility = Visibility.Visible;
        }

        public void Hide()
        {
            Visibility = Visibility.Collapsed;
        }
    }
}