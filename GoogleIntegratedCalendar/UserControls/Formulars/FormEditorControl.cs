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
using ExceptionHandler;

namespace EZKO.UserControls.Formulars
{
    public partial class FormEditorControl : UserControl
    {
        private int startX = 0;
        private int startY = 0;
        private int diffX = 30;
        private bool showTools = true;

        #region Public properties
        public List<FieldForm> FormFields
        {
            get
            {
                List<FieldForm> result = new List<FieldForm>();
                try
                {
                    FormFieldCard actualCard = FindFirstCard();
                    int questionIndex = 1;

                    while (actualCard != null)
                    {
                        string questionValue = actualCard.Question;
                        if (questionValue == null)
                        {
                            BasicMessagesHandler.ShowInformationMessage("Musíte zadať otázku do formulára");
                            actualCard.Focus();
                            mainPanel.ScrollControlIntoView(actualCard);
                            result = null;
                            break;
                        }
                        else if (actualCard.Field == null)
                        {
                            BasicMessagesHandler.ShowInformationMessage("Vyskytla sa chyba pri vytváraní položiek formulára.\nChybná položka je zvýraznená modrou farbou");
                            actualCard.Focus();
                            mainPanel.ScrollControlIntoView(actualCard);
                            result = null;
                            break;
                        }

                        Question question = new Question() { Value = questionValue, Index = questionIndex++ };
                        FieldForm newFieldForm = new FieldForm()
                        {
                            Field = actualCard.Field,
                            Question = question,
                        };

                        result.Add(newFieldForm);
                        actualCard = actualCard.BelowCard;
                    }
                }
                catch (Exception ex)
                {
                    BasicMessagesHandler.ShowErrorMessage("Počas načítavania polí do formulára sa vyskytla chyba", ex);
                    result = null;
                }
               
                return result;
            }
        }
        #endregion

        public FormEditorControl()
        {
            InitializeComponent();

            RedrawFormular();
        }

        #region Public methods
        /// <summary>
        /// Loads EZKO formular into mainPanel of the FormEditorControl
        /// </summary>
        /// <param name="formular">Formular which has to be loaded</param>
        public void LoadFormular(DatabaseCommunicator.Model.Form formular)
        {
            if (formular == null) return;
            mainPanel.Controls.Clear();

            formNameLabel.Text = formular.Name;

            FormFieldCard lastAddedCard = null;
            foreach (var item in formular.FieldForms.Where(x => !x.Field.IsDeleted).OrderBy(x => x.Question.Index))
            {
                FormFieldCard card = new FormFieldCard()
                {
                    Question = item.Question.Value,
                    CardWidth = mainPanel.Width - diffX,
                    EditorMainPanel = mainPanel,
                };
                card.CardMouseMove += card_MouseMove;
                card.CardMouseMove += card_MouseMove;
                card.CardMouseUp += card_MouseUp;
                card.RemoveButtonClick += card_RemoveButtonClick;
                card.SetField(item.Field);

                if (lastAddedCard != null)
                    lastAddedCard.BelowCard = card;

                lastAddedCard = card;
                mainPanel.Controls.Add(card);
            }

            RedrawFormular();
        }

        /// <summary>
        /// Add or update in FormEditorControl
        /// </summary>
        /// <param name="field">Field to add</param>
        /// <param name="updateField">Specifies if the field has to be updated in the editor if was founded</param>
        /// /// <param name="addField">Specifies if the field has to be added into editor if was not founded</param>
        /// <returns></returns>
        public bool AddOrUpdateField(Field field, bool updateField, bool addField)
        {
            bool containsField = false;

            foreach (var item in mainPanel.Controls)
            {
                if (item is FormFieldCard cardItem && cardItem.Field.ID == field.ID)
                {
                    if(updateField)
                        cardItem.SetField(field);

                    cardItem.Focus();
                    containsField = true;
                    mainPanel.ScrollControlIntoView(cardItem);
                    break;
                }
            }

            if(!containsField && addField)
            {
                FormFieldCard lastCard = FindLastCard();
                FormFieldCard card = new FormFieldCard() { CardWidth = mainPanel.Width - diffX, EditorMainPanel = mainPanel };
                card.CardMouseMove += card_MouseMove;
                card.CardMouseMove += card_MouseMove;
                card.CardMouseUp += card_MouseUp;
                card.RemoveButtonClick += card_RemoveButtonClick;
                card.ChangeTopPanelVisibility(showTools);
                card.SetField(field);

                if (lastCard != null)
                    lastCard.BelowCard = card;

                mainPanel.Controls.Add(card);
                RedrawFormular();

                mainPanel.ScrollControlIntoView(card);
            }

            return containsField;
        }

        public void UpdateFieldForm(FieldForm fieldForm)
        {
            bool wasUpdated = false;
            foreach (var item in mainPanel.Controls)
            {
                if (item is FormFieldCard card)
                {
                    if(card.Field.ID == fieldForm.Field.ID)
                    {
                        card.SetField(fieldForm.Field);
                        card.Question = fieldForm.Question.Value;
                        wasUpdated = true;
                        RedrawFormular();
                        card.Focus();
                        mainPanel.ScrollControlIntoView(card);
                        break;
                    }
                }
            }

            if (!wasUpdated)
                AddField(fieldForm);
        }

        public void RemoveField(int fieldId)
        {
            foreach (var item in mainPanel.Controls)
            {
                if (item is FormFieldCard card)
                {
                    if (card.Field.ID == fieldId)
                    {
                        card.RemoveCard();
                        RedrawFormular();
                        break;
                    }
                }
            }
        }

        public void ChangeFormularName(string newName)
        {
            formNameLabel.Text = newName;
        }
        #endregion

        #region Private methods
        private void RedrawFormular()
        {
            mainPanel.AutoScroll = false;
            FormFieldCard actualCard = FindFirstCard();

            if (actualCard != null)
            {
                actualCard.Location = new Point(startX, startY);

                while (actualCard.BelowCard != null)
                {
                    actualCard.BelowCard.Location = new Point(startX, actualCard.Location.Y + actualCard.Height + actualCard.PaddingBottom);
                    actualCard = actualCard.BelowCard;
                }
            }
            mainPanel.AutoScroll = true;
        }

        private void AddField(FieldForm fieldForm)
        {
            FormFieldCard lastCard = FindLastCard();
            FormFieldCard card = new FormFieldCard()
            {
                Question = fieldForm.Question.Value,
                CardWidth = mainPanel.Width - diffX,
                EditorMainPanel = mainPanel,
            };
            card.CardMouseMove += card_MouseMove;
            card.CardMouseUp += card_MouseUp;
            card.RemoveButtonClick += card_RemoveButtonClick;
            card.ChangeTopPanelVisibility(showTools);
            card.SetField(fieldForm.Field);

            if (lastCard != null)
                lastCard.BelowCard = card;

            mainPanel.Controls.Add(card);
            RedrawFormular();
            card.Focus();
            mainPanel.ScrollControlIntoView(card);
        }

        private FormFieldCard FindFirstCard()
        {
            FormFieldCard result = null;
            foreach (var item in mainPanel.Controls)
            {
                if (item is FormFieldCard card && card.AboveCard == null)
                {
                    result = card;
                    break;
                }
            }

            return result;
        }

        private FormFieldCard FindLastCard()
        {
            FormFieldCard result = null;
            foreach (var item in mainPanel.Controls)
            {
                if (item is FormFieldCard card && card.BelowCard == null)
                {
                    result = card;
                    break;
                }
            }

            return result;
        }

        private void ChangeCardToolsVisibility(bool showTools)
        {
            foreach (FormFieldCard item in mainPanel.Controls)
                item.ChangeTopPanelVisibility(showTools);

            RedrawFormular();
        }
        #endregion

        #region UI events
        private void card_MouseUp(object sender, MouseEventArgs e)
        {
            FormFieldCard card = ((sender as Control)?.Parent?.Parent as FormFieldCard);
            if (card != null)
                card.AssignNewLocation();
        }

        private void card_MouseMove(object sender, MouseEventArgs e)
        {
            FormFieldCard card = ((sender as Control)?.Parent?.Parent as FormFieldCard);

            if (card != null)
            {
                if (card.Up && card.AboveCard != null)
                {
                    FormFieldCard aboveCard = card.AboveCard;
                    if (card.Location.Y < aboveCard.CenterY)
                        card.MoveUp(false);
                }
                else if (!card.Up && card.BelowCard != null)
                {
                    FormFieldCard belowCard = card.BelowCard;
                    if ((card.Location.Y + card.Height) > belowCard.CenterY)
                        card.MoveDown(false);
                }
            }
        }

        private void card_RemoveButtonClick(object sender, EventArgs e)
        {
            RedrawFormular();
        }

        private void mainPanel_Resize(object sender, EventArgs e)
        {
            foreach (FormFieldCard item in mainPanel.Controls)
                item.CardWidth = mainPanel.Width - diffX;

            mainPanel.PerformLayout();
        }

        private void showToolsButton_Click(object sender, EventArgs e)
        {
            showTools = !showTools;
            if(showTools)
            {
                showToolsButton.BackgroundImage = Properties.Resources.hide_black_16;
                ChangeCardToolsVisibility(showTools);
            }
            else
            {
                showToolsButton.BackgroundImage = Properties.Resources.show_black_16;
                ChangeCardToolsVisibility(showTools);
            }
        }
        #endregion
    }
}
