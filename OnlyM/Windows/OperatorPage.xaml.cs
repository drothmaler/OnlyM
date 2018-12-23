﻿namespace OnlyM.Windows
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using CommonServiceLocator;
    using GalaSoft.MvvmLight.Messaging;
    using OnlyM.PubSubMessages;
    using Services.DragAndDrop;

    /// <summary>
    /// Interaction logic for OperatorPage.xaml
    /// </summary>
    public partial class OperatorPage : UserControl
    {
        public OperatorPage()
        {
            InitializeComponent();

            var dragAndDropService = ServiceLocator.Current.GetInstance<IDragAndDropService>();
            dragAndDropService.Init(this);
        }

        private void MirrorCheckBoxChecked(object sender, RoutedEventArgs e)
        {
            HandleMirrorCheckBoxChanged(sender, true);
        }

        private void MirrorCheckBoxUnchecked(object sender, RoutedEventArgs e)
        {
            HandleMirrorCheckBoxChanged(sender, false);
        }

        private void HandleMirrorCheckBoxChanged(object sender, bool isChecked)
        {
            if (sender is CheckBox cb)
            {
                var mediaItemGuid = (Guid)cb.Tag;
                Messenger.Default.Send(new MirrorWindowMessage { MediaItemId = mediaItemGuid, UseMirror = isChecked });
            }
        }
    }
}
