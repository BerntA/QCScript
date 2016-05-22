//=========       Copyright © Bernt Andreas Eide!       ============//
//
// Purpose: Global/Shared events goes here.
//
//==================================================================//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QScript.Core
{
    public class FormClosingArgs : EventArgs
    {
        public Form winForm { get; set; }
        public FormClosingArgs(Form pForm)
        {
            winForm = pForm;
        }
    }

    public static class SharedEvents
    {
        public delegate void DefaultEvent();
        public delegate void FormCloseEvent(FormClosingArgs args);

        public static event DefaultEvent OnCreatedProject;
        public static event DefaultEvent OnOpenedProject;
        public static event DefaultEvent OnClosedProject;
        public static event DefaultEvent OnSavedProject;

        public static event DefaultEvent OnCompileStart;
        public static event DefaultEvent OnCompileStop;
        public static event DefaultEvent OnCompileComplete;
        public static event FormCloseEvent OnFormClosed;

        public static void CreatedNewProject()
        {
            if (OnCreatedProject == null)
                return;

            OnCreatedProject();
        }

        public static void OpenedProject()
        {
            if (OnOpenedProject == null)
                return;

            OnOpenedProject();
        }

        public static void ClosedProject()
        {
            if (OnClosedProject == null)
                return;

            OnClosedProject();
        }

        public static void SavedProject()
        {
            if (OnSavedProject == null)
                return;

            OnSavedProject();
        }

        public static void StartCompile()
        {
            if (OnCompileStart == null)
                return;

            OnCompileStart();
        }

        public static void StopCompile()
        {
            if (OnCompileStop == null)
                return;

            OnCompileStop();
        }

        public static void CompileFinished()
        {
            if (OnCompileComplete == null)
                return;

            OnCompileComplete();
        }

        public static void CloseForm(Form pForm)
        {
            if (OnFormClosed == null)
                return;

            OnFormClosed(new FormClosingArgs(pForm));
        }
    }
}
