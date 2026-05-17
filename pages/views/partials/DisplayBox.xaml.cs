using System;
using System.Collections.Generic;
using System.Reflection;
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

namespace CatanCompanion
{
    /// <summary>
    /// Interaction logic for DisplayBox.xaml
    /// </summary>
    public partial class DisplayBox : UserControl
    {
        public DisplayBox(int id)
        {
            InitializeComponent();
            Id = id;
        }

        public static readonly RoutedEvent DeleteRequestEvent =
            EventManager.RegisterRoutedEvent("DeleteRequest", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(DisplayBox));

        public event RoutedEventHandler DeleteRequest
        {
            add { AddHandler(DeleteRequestEvent, value); }
            remove { RemoveHandler(DeleteRequestEvent, value); }
        }

        public static readonly DependencyProperty ContentProperty =
            DependencyProperty.Register("Content", typeof(string), typeof(DisplayBox), new PropertyMetadata(string.Empty));
        
        public static readonly DependencyProperty MinWidthProperty =
            DependencyProperty.Register("MinWidth", typeof(double), typeof(DisplayBox), new PropertyMetadata(25.0));

        public int Id 
        { 
            get;
            private set;
        }

        public string Content
        {
            get => (string)GetValue(ContentProperty);
            set => SetValue(ContentProperty, value);
        }

        public double MinWidth
        {
            get => (double)GetValue(MinWidthProperty);
            set => SetValue(MinWidthProperty, value);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(DeleteRequestEvent));
        }
    }
}
