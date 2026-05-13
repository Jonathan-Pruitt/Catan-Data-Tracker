using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CatanCompanion.pages.views.partials
{
    /// <summary>
    /// Interaction logic for InputAndList.xaml
    /// </summary>
    public partial class InputAndList : UserControl
    {
        public InputAndList()
        {
            InitializeComponent();
        }

        // ROUTED EVENT ARGS CLASS DEFINED AT BOTTOM OF THIS FILE
        public static readonly RoutedEvent ListSubmittedEvent =
            EventManager.RegisterRoutedEvent("ListSubmitted", RoutingStrategy.Bubble, typeof(EventHandler<ListSubmittedEventArgs>), typeof(InputAndList));

        public event EventHandler<ListSubmittedEventArgs> ListSubmitted
        {
            add => AddHandler(ListSubmittedEvent, value);
            remove => RemoveHandler(ListSubmittedEvent, value);
        }

        private List<string> _items = new List<string>();
        
        public static readonly DependencyProperty UCKeyProperty =
            DependencyProperty.Register("UCKey", typeof(string), typeof(InputAndList), new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty RequestProperty =
            DependencyProperty.Register("Request", typeof(string), typeof(InputAndList), new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty InfoProperty =
            DependencyProperty.Register("Info", typeof(string), typeof(InputAndList), new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty BoxMinWidthProperty =
            DependencyProperty.Register("BoxMinWidth", typeof(double), typeof(InputAndList), new PropertyMetadata(25.0));

        public string UCKey
        {
            get => (string)GetValue(UCKeyProperty);
            set => SetValue(UCKeyProperty, value);
        }

        public string Request
        {
            get => (string)GetValue(RequestProperty);
            set => SetValue(RequestProperty, value);
        }

        public string Info
        {
            get => (string)GetValue(InfoProperty);
            set => SetValue(InfoProperty, value);
        }

        public double BoxMinWidth
        {
            get => (double)GetValue(BoxMinWidthProperty);
            set => SetValue(BoxMinWidthProperty, value);
        }

        private void AddItem()
        {
            _items.Add(txtbxInputs.Text);
            UpdateListView();
            txtbxInputs.Text = "";

            RaiseEvent(new ListSubmittedEventArgs(ListSubmittedEvent, this.UCKey, new List<string>(_items)));
        }

        private void RemoveItem(object sender, RoutedEventArgs e)
        {
            if (sender is DisplayBox boxToDelete)
            {
                _items.RemoveAt(boxToDelete.Id);
            }
            UpdateListView();
            RaiseEvent(new ListSubmittedEventArgs(ListSubmittedEvent, this.UCKey, new List<string>(_items)));
        }

        private void UpdateListView()
        {
            stkpnlList.Children.Clear();
            DisplayBox[] boxes = new DisplayBox[_items.Count];

            int index = 0;
            foreach (string item in _items)
            {
                boxes[index] = new DisplayBox(index);
                boxes[index].DisplayValue = item;
                boxes[index].MinWidth = BoxMinWidth;
                boxes[index].DeleteRequest += RemoveItem;
                stkpnlList.Children.Add(boxes[index]);
                index++;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddItem();
        }

        private void txtbxInputs_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter)
            {
                return;
            }
            AddItem();
        }

    }// END CLASS

    // EVENT HANDLING TO RAISE COLLECTED DATA TO PARENT ELEMENTS/CLASSES
    public class ListSubmittedEventArgs : RoutedEventArgs
    {
        public string Key { get; }
        public List<string> Items { get; }

        public ListSubmittedEventArgs(RoutedEvent routedEvent, string key, List<string> items)
            : base(routedEvent)
        {
            Key = key;
            Items = items;
        }
    }
}
