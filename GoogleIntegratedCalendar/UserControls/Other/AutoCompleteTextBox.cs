﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

//Little bit updated https://stackoverflow.com/questions/1437002/winforms-c-sharp-autocomplete-in-the-middle-of-a-textbox

namespace EZKO.UserControls.Other
{
    public class AutoCompleteTextBox : TextBox
    {
        private ListBox _listBox;
        private bool _isAdded;
        private Object[] _values;
        private String _formerValue = String.Empty;

        public AutoCompleteTextBox()
        {
            InitializeComponent();
            ResetListBox();
        }

        private void InitializeComponent()
        {
            _listBox = new ListBox();
            this.KeyDown += this_KeyDown;
            this.KeyUp += this_KeyUp;
            this.LostFocus += this_LostFocus;
            this.GotFocus += this_GotFocus;

            _listBox.MouseDoubleClick += _listBox_MouseDoubleClick;
            _listBox.LostFocus += _listBox_LostFocus;
        }

        private void ShowListBox()
        {
            if (!_isAdded)
            {
                Form parentForm = this.FindForm(); // new line added
                parentForm.Controls.Add(_listBox); // adds it to the form
                Point positionOnForm = parentForm.PointToClient(this.Parent.PointToScreen(this.Location)); // absolute position in the form
                _listBox.Left = positionOnForm.X;
                _listBox.Top = positionOnForm.Y + Height;
                _isAdded = true;
            }
            _listBox.Visible = true;
            _listBox.BringToFront();
        }



        private void ResetListBox()
        {
            _listBox.Visible = false;
        }

        private void this_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateListBox();
        }

        private void this_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                case Keys.Tab:
                    {
                        if (_listBox.Visible)
                        {
                            Text = _listBox.SelectedItem.ToString();
                            Tag = _listBox.SelectedItem;
                            ResetListBox();
                            _formerValue = Text;
                            this.Select(this.Text.Length, 0);
                            e.Handled = true;

                            this.OnTextChanged(new EventArgs());
                        }
                        break;
                    }
                case Keys.Down:
                    {
                        if ((_listBox.Visible) && (_listBox.SelectedIndex < _listBox.Items.Count - 1))
                            _listBox.SelectedIndex++;
                        e.Handled = true;
                        break;
                    }
                case Keys.Up:
                    {
                        if ((_listBox.Visible) && (_listBox.SelectedIndex > 0))
                            _listBox.SelectedIndex--;
                        e.Handled = true;
                        break;
                    }
            }
        }

        private void this_LostFocus(object sender, EventArgs e)
        {
            //if(_listBox != null)
            //{
            //    _listBox.Visible = _listBox.Focused;

            //    if (_values == null)
            //        return;
            //    if (!_listBox.Focused && _values.FirstOrDefault(x => x.ToString().Trim() == Text.Trim()) == null)
            //    {
            //        Text = string.Empty;
            //        Tag = null;

            //        OnTextChanged(new EventArgs());
            //    }
            //}

            if (_listBox != null)
            {
                _listBox.Visible = _listBox.Focused;

                if (_values == null)
                    return;

                if (!_listBox.Focused && _values.FirstOrDefault(x => x.ToString().Trim() == Text.Trim()) == null)
                {
                    //Text = string.Empty;
                    Tag = null;

                    OnTextChanged(new EventArgs());
                }
            }
        }

        private void this_GotFocus(object sender, EventArgs e)
        {
            UpdateListBox();
            if (_listBox != null && (!Text.Equals(_formerValue)))
            {
                _listBox.Visible = true;
            }
        }

        private void _listBox_LostFocus(object sender, EventArgs e)
        {
            if (_listBox != null)
                _listBox.Visible = false;
        }

        private void _listBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (_listBox.Visible)
            {
                Text = _listBox.SelectedItem.ToString();
                Tag = _listBox.SelectedItem;
                ResetListBox();
                this.Select(this.Text.Length, 0);
                UpdateListBox();
                _listBox.Visible = false;

                this.OnTextChanged(new EventArgs());
            }
        }

        protected override bool IsInputKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Tab:
                    if (_listBox.Visible)
                        return true;
                    else
                        return false;
                default:
                    return base.IsInputKey(keyData);
            }
        }

        private void UpdateListBox()
        {
            if (Text == _formerValue)
                return;

            _formerValue = this.Text;
            string word = this.Text;

            if (_values != null && word.Length > 0)
            {
                object[] matches = Array.FindAll(_values,
                                                 x => (x.ToString().ToLower().Contains(word.ToLower())));
                if (matches.Length > 0)
                {
                    ShowListBox();
                    _listBox.BeginUpdate();
                    _listBox.Items.Clear();
                    Array.ForEach(matches, x => _listBox.Items.Add(x));
                    _listBox.SelectedIndex = 0;
                    _listBox.Height = 0;
                    _listBox.Width = 0;
                    Focus();
                    using (Graphics graphics = _listBox.CreateGraphics())
                    {
                        for (int i = 0; i < _listBox.Items.Count; i++)
                        {
                            if (i < 20)
                                _listBox.Height += _listBox.GetItemHeight(i);
                            // it item width is larger than the current one
                            // set it to the new max item width
                            // GetItemRectangle does not work for me
                            // we add a little extra space by using '_'
                            //int itemWidth = (int)graphics.MeasureString(((string)_listBox.Items[i]) + "_", _listBox.Font).Width;
                            //_listBox.Width = (_listBox.Width < itemWidth) ? itemWidth : this.Width;
                            _listBox.Width = Width;
                        }
                    }
                    _listBox.EndUpdate();
                }
                else
                {
                    ResetListBox();
                }
            }
            else
            {
                ResetListBox();
            }
        }

        public Object[] Values
        {
            get
            {
                return _values;
            }
            set
            {
                _values = value;
            }
        }

        public List<String> SelectedValues
        {
            get
            {
                String[] result = Text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                return new List<String>(result);
            }
        }
    }
}
