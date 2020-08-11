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

        public void DrawCustomFocusFeedback(Control control, PaintEventArgs e)
        {
            if (control.Focused)
            {
                // This is hard coded to look ok on Buttons.
                Rectangle rectFocus = new Rectangle(
                    3, 3, control.Width - 6, control.Height - 6);

                e.Graphics.DrawRectangle(this.focusPen, rectFocus);
            }
        }
    }

    public class ButtonWithFocusFeedback : Button
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            (this.FindForm() as ControlMixForm).DrawCustomFocusFeedback(this, e);
        }
    }

    public class CheckBoxWithFocusFeedback : CheckBox
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            (this.FindForm() as ControlMixForm).DrawCustomFocusFeedback(this, e);
        }
    }

    public class RadioButtonithFocusFeedback : RadioButton
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            (this.FindForm() as ControlMixForm).DrawCustomFocusFeedback(this, e);
        }
    }

    public class LinkLabelWithFocusFeedback : LinkLabel
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            (this.FindForm() as ControlMixForm).DrawCustomFocusFeedback(this, e);
        }
    }
}
