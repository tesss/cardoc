﻿using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace CARDOC.Views
{
    public class CustomComboBox : ComboBox
    {
        public CustomComboBox()
        {
            DrawMode = DrawMode.OwnerDrawFixed;
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            this.Select(0, 0);
            timer.Enabled = false;
        }

        const int CB_SETCUEBANNER = 0x1703;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern int SendMessage(IntPtr hWnd, int msg, int wParam, string lParam);
        string hint;
        private Timer timer = new System.Windows.Forms.Timer();
        public string Hint
        {
            get { return hint; }
            set { hint = value; UpdateHint(); }
        }
        private void UpdateHint()
        {
            if (!this.IsHandleCreated)
                return;
            if (DropDownStyle == ComboBoxStyle.DropDownList)
                this.Invalidate();
            else
                SendMessage(Handle, CB_SETCUEBANNER, 0, Hint);
        }
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            if (!string.IsNullOrEmpty(Hint))
                UpdateHint();
        }
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            string text = Hint;
            base.OnDrawItem(e);
            if (e.Index > -1)
                text = this.GetItemText(this.Items[e.Index]);
            e.DrawBackground();
            TextRenderer.DrawText(e.Graphics, text, Font,
                e.Bounds, e.ForeColor, TextFormatFlags.TextBoxControl);
        }

        protected override void OnSelectedItemChanged(EventArgs e)
        {
            base.OnSelectedItemChanged(e);
            timer.Enabled = true;
        }
    }
}
