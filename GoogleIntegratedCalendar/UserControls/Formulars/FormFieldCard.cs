using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DatabaseCommunicator.Model;
using DatabaseCommunicator.Enums;
using EZKO.UserControls.FlatControls;
using EZKO.Forms.AdministrationForms;

namespace EZKO.UserControls.Formulars
{
    public partial class FormFieldCard : UserControl
    {
        public MouseEventHandler CardMouseUp;
        public MouseEventHandler CardMouseMove;
        public EventHandler RemoveButtonClick;

        #region Public properties
        public string CardName { get; set; }
        public int CenterY { get { return Location.Y + Height / 2; } }
        public int PaddingBottom { get; set; }
        public int OriginalY { get; private set; }
        public int CardWidth
        {
            set
            {
                flowPanel.MinimumSize = new Size(value, 0);
                topPanel.Width = value;
                foreach (Control item in flowPanel.Controls)
                    item.Width = flowPanel.MinimumSize.Width - 7;
            }
        }

        public bool Up { get; private set; }
        private FormFieldCard aboveCard;
        public FormFieldCard AboveCard
        {
            get { return aboveCard; }
            set{ aboveCard = value; }
        }
        private FormFieldCard belowCard;
        public FormFieldCard BelowCard
        {
            get { return belowCard; }
            set
            {
                if (value != null)
                    value.AboveCard = this;
                belowCard = value;
            }
        }
        public Field Field { get; set; }
        public string Question
        {
            get
            {
                string result = questionTextBox.Text.Trim();
                if (string.IsNullOrEmpty(result) || result == defaultText)
                    result = null;

                return result;
            }
            set
            {
                if (value == null)
                {
                    questionTextBox.Font = italicFont;
                    questionTextBox.Text = defaultText;
                }
                else if (value == "")
                {
                    questionTextBox.Text = value;
                    questionTextBox.Font = new Font(italicFont, FontStyle.Regular);
                }
                else
                {
                    questionTextBox.Font = new Font(italicFont, FontStyle.Regular);
                    questionTextBox.Text = value;
                }
            }
        }
        public bool IsRemoved { get; set; }
        public Panel EditorMainPanel { get; set; }
        public FormEditorControl MainControl { get; set; }
        #endregion

        private bool move = false;
        private bool isPreview;
        private string defaultText = "Otázka do formulára";
        private Font italicFont;
        private Point? newLocation;

        #region Private properties
       private string fieldName { set { fieldNameLabel.Text = value; } }
        #endregion

        public FormFieldCard()
        {
            InitializeComponent();

            IsRemoved = false;
            italicFont = questionTextBox.Font;
            PaddingBottom = 3;
            OriginalY = Location.Y;
        }

        public FormFieldCard(bool isPreview) : this()
        {
            this.isPreview = isPreview;

            questionTextBox.Enabled = !isPreview;
            removeButton.Enabled = !isPreview;
            upButton.Enabled = !isPreview;
            downButton.Enabled = !isPreview;
            fieldName = "";
        }

        #region Public methods

        public void SetField(Field field)
        {
            Field = field;
            InitializeField();
        }
        public void MoveUp(bool assignNewLocation)
        {
            if (aboveCard != null)
            {
                FormFieldCard oldAboveCard = aboveCard;

                if (aboveCard.AboveCard != null)
                    aboveCard.AboveCard.BelowCard = this;
                else
                    AboveCard = null;

                FormFieldCard oldBelowCard = BelowCard;
                BelowCard = oldAboveCard;

                belowCard.BelowCard = oldBelowCard;

                newLocation = belowCard.Location;
                OriginalY = newLocation.Value.Y;
                if (assignNewLocation)
                    Location = newLocation.Value;
                belowCard.Location = new Point(Location.X, newLocation.Value.Y + Height + PaddingBottom);
            }
        }

        public void MoveDown(bool assignNewLocation)
        {
            if (belowCard != null)
            {
                FormFieldCard oldBelowCard = belowCard;
                BelowCard = belowCard.BelowCard;

                if (aboveCard != null)
                    aboveCard.BelowCard = oldBelowCard;
                else
                    oldBelowCard.AboveCard = null;

                AboveCard = oldBelowCard;
                oldBelowCard.BelowCard = this;

                aboveCard.Location = new Point(Location.X, !assignNewLocation ? OriginalY : Location.Y);
                newLocation = new Point(Location.X, aboveCard.Location.Y + aboveCard.Height + aboveCard.PaddingBottom);
                OriginalY = newLocation.Value.Y;
                if (assignNewLocation)
                    Location = newLocation.Value;
            }
        }

        public void AssignNewLocation()
        {
            if (newLocation.HasValue)
            {
                Location = newLocation.Value;
                newLocation = null;
            }
        }

        public void RemoveCard(bool removePermanently = false)
        {
            if(removePermanently)
            {
                MainControl.RemoveCommands(this);

                if (aboveCard != null)
                    aboveCard.BelowCard = belowCard;
                else if (belowCard != null)
                    belowCard.AboveCard = null;

                Dispose();
            }
            else
            {
                MainControl.Commands.Add(new Classes.CardCommand(this, Enums.CardCommandEnum.Remove));
                IsRemoved = true;
            }

            MainControl.UpdateBackButtonVisibility();
        }

        public void ChangeTopPanelVisibility(bool isVisible)
        {
            topPanel.Visible = isVisible;
        }
        #endregion

        #region Private methods
        private void InitializeField()
        {
            if (Field == null) return;

            if (Field.FieldType != null)
            {
                fieldName = Field.Name;

                flowPanel.Controls.Clear();
                int width = flowPanel.MinimumSize.Width - 7;
                Control newControl = null;

                switch (Field.FieldType.ID)
                {
                    case (int)FieldTypeEnum.Text:
                        newControl = new TextBox() { Width = width };
                        //newControl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                        //newControl.Enabled = !isPreview;
                        flowPanel.Controls.Add(newControl);
                        break;

                    case (int)FieldTypeEnum.LongText:
                        newControl = new FlatRichTextBox() { Width = width, Height = 100 };
                        //newControl.Anchor = AnchorStyles.Left | AnchorStyles.Right;
                        //newControl.Enabled = !isPreview;
                        flowPanel.Controls.Add(newControl);
                        break;

                    case (int)FieldTypeEnum.RadioBox:
                        ICollection<FieldValue> values = Field.FieldValues;
                        if (values != null)
                        {
                            foreach (var value in values)
                            {
                                newControl = new RadioButton() { Width = width, Checked = false, Text = value.Value };
                                //newControl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                                //newControl.Enabled = !isPreview;
                                flowPanel.Controls.Add(newControl);
                            }
                        }
                        break;

                    case (int)FieldTypeEnum.SelectBox:
                        values = Field.FieldValues;
                        if (values != null)
                        {
                            ComboBox comboBox = new ComboBox() { Width = width, DropDownStyle = ComboBoxStyle.DropDownList };
                            //comboBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                            //comboBox.Enabled = !isPreview;
                            foreach (var value in values)
                            {
                                comboBox.Items.Add(value);
                            }
                            flowPanel.Controls.Add(comboBox);

                            if (comboBox.Items.Count > 0)
                                comboBox.SelectedIndex = 0;
                        }
                        break;

                    case (int)FieldTypeEnum.CheckBox:
                        values = Field.FieldValues;
                        if (values != null)
                        {
                            foreach (var value in values)
                            {
                                newControl = new CheckBox() { Width = width, Checked = false, Text = value.Value };
                                //newControl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                                //newControl.Enabled = !isPreview;
                                flowPanel.Controls.Add(newControl);
                            }
                        }
                        break;
                }
            }
        }
        #endregion

        #region UI events
        private void questionTextBox_Enter(object sender, EventArgs e)
        {
            if (questionTextBox.Text == defaultText || questionTextBox.Text.Length == 0)
                Question = "";
        }

        private void questionTextBox_Leave(object sender, EventArgs e)
        {
            if (questionTextBox.Text.Length > 0)
                Question = questionTextBox.Text;
            else
                Question = null;
        }

        private void topPanel_MouseEnter(object sender, EventArgs e)
        {
            if(!isPreview)
                Cursor = Cursors.NoMoveVert;
        }

        private void topPanel_MouseLeave(object sender, EventArgs e)
        {
            if (!isPreview)
                Cursor = Cursors.Default;
        }

        private void topPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (!isPreview)
            {
                //EditorMainPanel.AutoScroll = false;
                Focus();
                Cursor = Cursors.Hand;
                OriginalY = Location.Y;
                move = true;
                BringToFront();
            }
        }

        private void topPanel_MouseUp(object sender, MouseEventArgs e)
        {
            //EditorMainPanel.AutoScroll = true;
            Cursor = Cursors.Default;
            move = false;
            Location = new Point(Location.X, OriginalY);

            CardMouseUp?.Invoke(sender, e);
            EditorMainPanel.ScrollControlIntoView(this);
        }

        private void topPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                int diffY = e.Y;
                if (Location.Y + diffY >= 0)
                {
                    Location = new Point(Location.X, Location.Y + diffY);
                    Up = Location.Y < OriginalY;

                    CardMouseMove?.Invoke(sender, e);
                }
            }
        }

        private void upButton_Click(object sender, EventArgs e)
        {
            EditorMainPanel.AutoScroll = false;
            MoveUp(true);
            EditorMainPanel.AutoScroll = true;
            EditorMainPanel.ScrollControlIntoView(this);

            MainControl.Commands.Add(new Classes.CardCommand(this, Enums.CardCommandEnum.MoveUp));
            MainControl.UpdateBackButtonVisibility();
        }

        private void downButton_Click(object sender, EventArgs e)
        {
            EditorMainPanel.AutoScroll = false;
            MoveDown(true);
            EditorMainPanel.AutoScroll = true;
            EditorMainPanel.ScrollControlIntoView(this);

            MainControl.Commands.Add(new Classes.CardCommand(this, Enums.CardCommandEnum.MoveDown));
            MainControl.UpdateBackButtonVisibility();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            RemoveCard();
            RemoveButtonClick?.Invoke(sender, e);
        }

        private void editFieldButton_Click(object sender, EventArgs e)
        {
            if (Field == null)
                return;

           MainControl.UpdateField(Field);
        }

        private void FormFieldCard_SizeChanged(object sender, EventArgs e)
        {
            //MinimumSize = new Size(Width, 70);
            flowPanel.MinimumSize = new Size(questionTextBox.Width, 0);
        }
        private void FormFieldCard_Enter(object sender, EventArgs e)
        {
            mainFlowPanel.BackColor = Color.FromName("Highlight");
        }    

        private void FormFieldCard_Leave(object sender, EventArgs e)
        {
            mainFlowPanel.BackColor = Color.FromName("Info");
        }
        #endregion

        public override string ToString()
        {
            return CardName;
        }
    }
}
