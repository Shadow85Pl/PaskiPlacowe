using System;
using System.Windows;
using System.Windows.Interactivity;
using Microsoft.Win32;
using Prism.Interactivity.InteractionRequest;
using AutoMapper;

namespace PaskiPlacowe.InteractionRequest
{
    

    public class OpenFileDialogAction : TriggerAction<FrameworkElement>
    {

        protected override void Invoke(object parameter)
        {
            InteractionRequestedEventArgs EventArgs = (InteractionRequestedEventArgs)parameter;
            OpenFileDialog op = Mapper.Map<OpenFileDialog>((OpenFileDialogConfirmation)EventArgs.Context);
            ((OpenFileDialogConfirmation)EventArgs.Context).Confirmed = op.ShowDialog() ?? false;

            if (((OpenFileDialogConfirmation)EventArgs.Context).Confirmed)
            {
                ((OpenFileDialogConfirmation)EventArgs.Context).FileName = op.FileName;
                EventArgs.Callback?.Invoke();
            }
        }
    }
}
