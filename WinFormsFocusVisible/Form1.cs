using Microsoft.Win32;
using System;
using System.Drawing;
using System.Windows.Forms;

// This demo app shows different approaches to rendering keyboard focus visuals
// in a WinForms app. By default, standard controls would be used in the app, 
// which would mean that such custom rendering actions are not required.

// Seriously - by default use standard controls. WinForms provides a great deal
// of support for accessibility by default when using standard controls. 

namespace WinFormsFocusVisible
{
    public partial class FormFocusVisible : Form
    {
        public FormFocusVisible()
        {
            InitializeComponent();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonShowMoreControls_Click(object sender, EventArgs e)
        {
            var controlsForm = new ControlMixForm();
            controlsForm.ShowDialog(this);
        }
    }

    // This button demonstrates the use of DrawFocusRectangle() 
    // to render keyboard focus visuals.
    public class MyButton : Button
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            // For this demo, simply fill the button bounds with a color.
            e.Graphics.FillRectangle(Brushes.LightGreen, 
                0, 0, this.Width, this.Height);

            // Given that this method is written to deliberately prevent
            // the keyboard focus visuals to be shown on the button by 
            // default, take action now to force the keyboard focus visuals 
            // to be rendered if the control has focus.
            if (this.Focused)
            {
                // Render the feedback a little in from the egde of the button.
                Rectangle rectFocus = this.ClientRectangle;
                rectFocus.Inflate(-2, -2);

                // Without this call, the focus visuals will not appear.
                ControlPaint.DrawFocusRectangle(e.Graphics, rectFocus);
            }
        }
    }

    // This class demonstrates fully custom rendering of keyboard focus visuals.
    // Note: The DrawFocusRectangle() called above will work on UserControl here,
    // just as it does with the Button. But this UserControl intentionally doesn't 
    // use DrawFocusRectangle(), in order to demo another approach, in case for 
    // some reason your control doesn't have access to DrawFocusRectangle().

    public class MyUserControl : UserControl
    {
        private Pen focusPenForeground;
        private Pen focusPenBackground;
        private bool myCustomControlHasFocus;

        public MyUserControl()
        {
            // Create pens for the focus visuals which will be guaranteed to
            // have strong contrast against the background of the control,
            // regardless of the active theme.
            CreateKeyboardFocusVisualsPens();

            // Set up an event handler to be notified when the active theme 
            // changes. For example, when the customer selects a high contrast theme.
            SystemEvents.UserPreferenceChanged += SystemEvents_UserPreferenceChanged;

            // We'll keep track of whether the control has focus.
            this.GotFocus += MyUserControl_GotFocus;
            this.LostFocus += MyUserControl_LostFocus;
        }

        private void SystemEvents_UserPreferenceChanged(object sender, UserPreferenceChangedEventArgs e)
        {
            CreateKeyboardFocusVisualsPens();
        }

        private void CreateKeyboardFocusVisualsPens()
        {
            // The keyboard focus visuals must always have contrast against 
            // its surroundings. This can be achieved by having adjacent 
            // inner and outer rects, using a foreground and a background
            // color from the active theme. Alternatively, as shown here,
            // the two contrasting color could be used in a dashed pattern.

            this.focusPenForeground = new Pen(SystemColors.ControlText, 2);
            this.focusPenForeground.DashPattern = new float[] { 1, 1 };

            this.focusPenBackground = new Pen(SystemColors.Control);
        }

        private void MyUserControl_GotFocus(object sender, EventArgs e)
        {
            this.myCustomControlHasFocus = true;

            this.Refresh();
        }

        private void MyUserControl_LostFocus(object sender, EventArgs e)
        {
            this.myCustomControlHasFocus = false;

            this.Refresh();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // For this demo, simply fill the control bounds with a color.
            e.Graphics.FillRectangle(Brushes.LightGreen,
                0, 0, this.Width, this.Height);

            // For this example, say for some reason DrawFocusRectangle()
            // is not available, and custom keyboard focus visuals are
            // required.
            if (this.myCustomControlHasFocus)
            {
                // Render the feedback a little in from the edge of the button.
                // Note that attempting to draw outside the button will require 
                // more work that rendering to only e.Graphics.
                Rectangle rectFocus = new Rectangle(
                    0, 0, this.Width - 1, this.Height - 1);
                rectFocus.Inflate(-1, -1);

                // Draw the focus visuals on the control.
                e.Graphics.DrawRectangle(this.focusPenBackground, rectFocus);
                e.Graphics.DrawRectangle(this.focusPenForeground, rectFocus);
            }
        }
    }
}
