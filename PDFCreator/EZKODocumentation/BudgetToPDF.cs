using System;
using System.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using DatabaseCommunicator.Model;
using ExceptionHandler;

namespace PDFCreator.EZKODocumentation
{
    public class BudgetToPDF : PDFCreator
    {
        private Budget budget;

        public BudgetToPDF(string path, Budget budget) : base(path)
        {
            this.budget = budget;
        }

        public bool CreatePdf()
        {
            bool result = true;

            try
            {
                if (budget == null)
                    result = false;
                else
                {
                    PdfDocument.Open();

                    Chapter chapter = AddChapter(new Paragraph(GetTitleText(budget.Name)) { SpacingAfter = 10f, Alignment = HAlingmentLeft }, 0, 0);

                    iTextSharp.text.Section infoSection = AddSection(chapter, 0f,
                        new Paragraph(GetBoldText("Základné informácie")) {SpacingAfter = 0f, SpacingBefore = 0f }, 0);
                    AddInfoTable(infoSection);

                    iTextSharp.text.Section itemsSection = AddSection(chapter, 0f,
                        new Paragraph(GetBoldText("Položky")) { SpacingBefore = 0f, SpacingAfter = 0f}, 0);
                    AddItemsTable(itemsSection);

                    PdfDocument.Add(chapter);

                    PdfDocument.Close();
                }
            }
            catch (Exception ex)
            {
                BasicMessagesHandler.LogException(ex);
                result = false;
                if(PdfDocument.IsOpen())
                    PdfDocument.Close();
            }

            return result;
        }

        /// <summary>
        /// Creates table with basic information about patient whome the budget belongs to
        /// </summary>
        private void AddInfoTable(iTextSharp.text.Section section)
        {
            try
            {
                PdfPTable table = new PdfPTable(2) { HorizontalAlignment = HAlingmentLeft, SpacingBefore = 10f };

                PdfPCell cell = GetCell(System.Drawing.Color.White, GetBoldText("ID"));
                table.AddCell(cell);
                cell = GetCell(System.Drawing.Color.White, budget.ID.ToString());
                table.AddCell(cell);

                cell = GetCell(System.Drawing.Color.White, GetBoldText("Pacient"));
                table.AddCell(cell);
                cell = GetCell(System.Drawing.Color.White, budget.Patient.ToString());
                table.AddCell(cell);

                cell = GetCell(System.Drawing.Color.White, GetBoldText("Cena spolu"));
                table.AddCell(cell);
                cell = GetCell(System.Drawing.Color.White, budget.BudgetItems.Sum(x => (x.Count * x.UnitPrice)).ToString("0.00 €"));
                table.AddCell(cell);

                table.SpacingAfter = 10f;

                section.Add(table);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Creates table with information about budget items
        /// </summary>
        private void AddItemsTable(iTextSharp.text.Section section)
        {
            try
            {
                PdfPTable table = new PdfPTable(new[] { 60f, 20f, 20f})
                { HorizontalAlignment = HAlingmentLeft, SpacingBefore = 10f,WidthPercentage = 100f };

                PdfPCell cell = new PdfPCell();

                bool firstRow = false;

                foreach(BudgetItem item in budget.BudgetItems)
                {
                    cell = GetCell(System.Drawing.Color.White, item.Name);
                    if(firstRow)
                    {
                        cell.UseVariableBorders = true;
                        cell.BorderColorTop = BaseColor.BLACK;
                    }
                    table.AddCell(cell);

                    cell = GetCell(System.Drawing.Color.White, item.Count.ToString("0 ks"));
                    if (firstRow)
                    {
                        cell.UseVariableBorders = true;
                        cell.BorderColorTop = BaseColor.BLACK;
                    }
                    table.AddCell(cell);

                    cell = GetCell(System.Drawing.Color.White, item.UnitPrice.ToString("0.00 €"));
                    if (firstRow)
                    {
                        cell.UseVariableBorders = true;
                        cell.BorderColorTop = BaseColor.BLACK;
                    }
                    table.AddCell(cell);

                    firstRow = false;
                }

                table.SpacingAfter = 10f;

                section.Add(table);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
