using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace test4
{
    /// <summary>
    /// MyDocumentViewer.xaml 的互動邏輯
    /// </summary>
    public partial class MyDocumentViewer : Window
    {
        Color fontColor = Colors.Black;
        public MyDocumentViewer()
        {
            InitializeComponent();
            fontClolorPicker.SelectedColor = fontColor;
            foreach (FontFamily fontFamily in Fonts.SystemFontFamilies)
            {
                fontFamilyComoboBox.Items.Add(fontFamily.Source);
            }
            fontFamilyComoboBox.SelectedIndex = 3;
            fontSizeComoboBox.ItemsSource = new List<Double>() { 8, 9, 10, 11, 12, 14, 16, 18, 20, 24, 32, 40, 50, 60, 70, 80, 100};
            fontSizeComoboBox.SelectedIndex = 3;

        }

        private void New_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MyDocumentViewer myDocumentViewer = new MyDocumentViewer();
            myDocumentViewer.Show();
        }

        private void Open_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("ApplicationCommands.Open");
        }
        private void Save_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("ApplicationCommands.Save");
        }

        private void rtbEditor_SelectionChanged(object sender, RoutedEventArgs e)
        {
            object property = rtbEditor.Selection.GetPropertyValue(Inline.FontWeightProperty);
            boldButton.IsChecked = (property != DependencyProperty.UnsetValue) && (property.Equals(FontWeights.Bold));

            property = rtbEditor.Selection.GetPropertyValue(TextElement.FontWeightProperty);
            italicButton.IsChecked= (property != DependencyProperty.UnsetValue) && (property.Equals(FontStyles.Italic));

            property = rtbEditor.Selection.GetPropertyValue(Inline.TextDecorationsProperty);
            underlineButton.IsChecked =(property != DependencyProperty.UnsetValue) && (property.Equals(TextDecorations.Underline));
        }

        private void fontSizeComoboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (fontSizeComoboBox.SelectedItem != null)
            {
                rtbEditor.Selection.ApplyPropertyValue(TextElement.FontSizeProperty, fontSizeComoboBox.SelectedItem);
            }
        }

        private void fontFamilyComoboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (fontFamilyComoboBox.SelectedItem != null)
            {
                rtbEditor.Selection.ApplyPropertyValue(TextElement.FontFamilyProperty, fontFamilyComoboBox.SelectedItem);
            }
        }

        private void fontClolorPicker_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            fontColor = (Color)e.NewValue;
            SolidColorBrush fontBrush = new SolidColorBrush(fontColor);
            rtbEditor.Selection.ApplyPropertyValue(TextElement.ForegroundProperty, fontBrush);
        }
    }
}
