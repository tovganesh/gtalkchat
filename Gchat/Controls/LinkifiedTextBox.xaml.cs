﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using Gchat.Utilities;

namespace Gchat.Controls {
    public partial class LinkifiedTextBox : UserControl {
        public static DependencyProperty TextProperty = 
            DependencyProperty.Register("Text", typeof(string), typeof(LinkifiedTextBox), 
            new PropertyMetadata("", ChangedText));

        public string Text {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); } 
        }

        private static void ChangedText(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            ((LinkifiedTextBox)d).ChangedText(e);
        }

        private void ChangedText(DependencyPropertyChangedEventArgs e) {
            if (e.OldValue != e.NewValue) {
                Paragraph richtext = GoogleTalkHelper.Linkify((string) e.NewValue);
                RichText.Blocks.Add(richtext);
            }
        }

        public LinkifiedTextBox() {
            InitializeComponent();
        }
    }
}
