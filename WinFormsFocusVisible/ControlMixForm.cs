using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsFocusVisible
{
    public partial class ControlMixForm : Form
    {
        private Pen focusPen;

        public ControlMixForm()
        {
            InitializeComponent();

            CreateKeyboardFocusVisualsPens();
        }

        private void CreateKeyboardFocusVisualsPens()
        {
            // The pen is two pixels thick.
            this.focusPen = new Pen(SystemColors.ControlText, 2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Called in response to a custom control gettting WM_UPDATEUISTATE.
        public bool ShouldProcessUpdateUIState(ref Message m)
        {
            bool shouldProcessUpdateUIState = true;

            // Is the focus indicator amonsgt the affected UI state elements?
            int affectedStates = ((int)m.WParam >> 0x10);
            if ((int)(affectedStates & NativeMethods.UISF_HIDEFOCUS) == NativeMethods.UISF_HIDEFOCUS)
            {
                // Remove the focus indicator from thet set of affected UI elements.
                int remainingStates = (affectedStates & ~NativeMethods.UISF_HIDEFOCUS);

                // Are any other UI states still affected?
                if (remainingStates != 0)
                {
                    // Remove the focus indicator from the set of affected states,
                    // and continue to process the messages for those UI states.
                    m.WParam = (IntPtr)((int)remainingStates << 0x10) + ((int)m.WParam & 0xFF);
                }
                else
                {
                    // The only UI state changing was to be the focus indicator,
                    // and we are intentionally suppressing that.
                    shouldProcessUpdateUIState = false;
                }
            }

            return shouldProcessUpdateUIState;
        }

        public void DrawCustomFocusFeedback(
            Control control, 
            PaintEventArgs e,
            Rectangle offsetRect)
        {
            if (control.Focused)
            {
                e.Graphics.DrawRectangle(this.focusPen, offsetRect);
            }
        }
    }

    public class ButtonWithFocusFeedback : Button
    {
        private ControlMixForm owningForm;

        private ControlMixForm GetOwningForm()
        {
            if (this.owningForm == null)
            {
                this.owningForm = this.FindForm() as ControlMixForm;
            }

            return this.owningForm;
        }

        protected override void WndProc(ref Message m)
        {
            if ((m.Msg != NativeMethods.WM_UPDATEUISTATE) ||
                GetOwningForm().ShouldProcessUpdateUIState(ref m))
            {
                base.WndProc(ref m);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            GetOwningForm().DrawCustomFocusFeedback(this, e,
                new Rectangle(1, 1, this.Width - 2, this.Height - 2));
        }
    }

    public class CheckBoxWithFocusFeedback : CheckBox
    {
        private ControlMixForm owningForm;

        private ControlMixForm GetOwningForm()
        {
            if (this.owningForm == null)
            {
                this.owningForm = this.FindForm() as ControlMixForm;
            }

            return this.owningForm;
        }

        protected override void WndProc(ref Message m)
        {
            if ((m.Msg != NativeMethods.WM_UPDATEUISTATE) ||
                GetOwningForm().ShouldProcessUpdateUIState(ref m))
            {
                base.WndProc(ref m);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            GetOwningForm().DrawCustomFocusFeedback(this, e,
                new Rectangle(1, 1, this.Width - 2, this.Height - 4));
        }
    }

    public class RadioButtonithFocusFeedback : RadioButton
    {
        private ControlMixForm owningForm;

        private ControlMixForm GetOwningForm()
        {
            if (this.owningForm == null)
            {
                this.owningForm = this.FindForm() as ControlMixForm;
            }

            return this.owningForm;
        }


        protected override void WndProc(ref Message m)
        {
            if ((m.Msg != NativeMethods.WM_UPDATEUISTATE) ||
                GetOwningForm().ShouldProcessUpdateUIState(ref m))
            {
                base.WndProc(ref m);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            GetOwningForm().DrawCustomFocusFeedback(this, e,
                new Rectangle(1, 1, this.Width - 2, this.Height - 2));
        }
    }

    public class LinkLabelWithFocusFeedback : LinkLabel
    {
        private ControlMixForm owningForm;

        private ControlMixForm GetOwningForm()
        {
            if (this.owningForm == null)
            {
                this.owningForm = this.FindForm() as ControlMixForm;
            }

            return this.owningForm;
        }


        protected override void WndProc(ref Message m)
        {
            if ((m.Msg != NativeMethods.WM_UPDATEUISTATE) ||
                GetOwningForm().ShouldProcessUpdateUIState(ref m))
            {
                base.WndProc(ref m);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            GetOwningForm().DrawCustomFocusFeedback(this, e,
                new Rectangle(1, 1, this.Width - 2, this.Height - 2));
        }
    }

    internal static class NativeMethods
    {
        public const int WM_UPDATEUISTATE = 0x0128;
        public const int UISF_HIDEFOCUS = 0x01;
    }
}

