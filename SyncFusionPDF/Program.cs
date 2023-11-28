// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using static System.Net.Mime.MediaTypeNames;

public class Program
{
    static void Main(string[] args)
    {
        Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Your License");
        Console.WriteLine("Hello, World!");
        
        PdfDocument pdfDocument = new PdfDocument();
        //Add a page to the document
        PdfPage currentPage = pdfDocument.Pages.Add();
        SizeF clientSize = currentPage.GetClientSize();
        FileStream imageStream = new FileStream("Resources/image15.png", FileMode.Open, FileAccess.Read);
        FileStream imageStream2 = new FileStream("Resources/DigDrilProg.png", FileMode.Open, FileAccess.Read);
        PdfImage icon = new PdfBitmap(imageStream);
        SizeF iconSize = new SizeF(114, 24);
        PointF iconLocation = new PointF(14, 13);
        PdfImage icon2 = new PdfBitmap(imageStream2);
        SizeF iconSize2 = new SizeF(95, 20);
        PointF iconLocation2 = new PointF(clientSize.Width - 100, 13);
        PdfGraphics graphics = currentPage.Graphics;
        graphics.DrawImage(icon, iconLocation, iconSize);
        graphics.DrawImage(icon2, iconLocation2, iconSize2);
        PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 12, PdfFontStyle.Bold);

        var text = new PdfTextElement("DRILLING PROGRAMME", font, new PdfSolidBrush(Color.FromArgb( 255, 84, 103, 120)));
        //var result = text.Draw(currentPage, new PointF(14, iconLocation.Y + 10));
        text.StringFormat = new PdfStringFormat(PdfTextAlignment.Center);
        var result = text.Draw(currentPage, new PointF(clientSize.Width / 2, iconLocation.Y + 100));
        font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);
        text = new PdfTextElement("25/7-A-2 B  &  25/7-A-2 B", font, new PdfSolidBrush(Color.FromArgb(255, 21, 118, 198)));
        text.StringFormat = new PdfStringFormat(PdfTextAlignment.Center);
        result = text.Draw(currentPage, new PointF(clientSize.Width / 2, result.Bounds.Bottom + 12));

        //Multi-line text to draw
        string str = "Lorem ipsum dolor sit amet consectetur. Aliquam pretium ipsum cursus vulputate amet pharetra a. Non eget diam sagittis nisl egestas at ut fermentum. Et amet lorem aenean in nam venenatis. Vitae at nibh commodo sit nullam elit. Et amet lorem aenean in nam venenatis. Vitae at nibh commodo sit nullam elit.Et amet lorem Lorem ipsum dolor sit amet consectetur. Aliquam pretium ipsum cursus vulputate amet pharetra a. Non eget diam sagittis nisl egestas at ut fermentum. Et amet lorem aenean in nam venenatis. Vitae at nibh commodo sit nullam elit. Et amet lorem aenean in nam venenatis. Vitae at nibh commodo sit nullam elit.Et amet lorem ";

        //Create a text element
        PdfTextElement element = new PdfTextElement(str);
        element.Brush = new PdfSolidBrush(Color.Black);
        element.Font = new PdfStandardFont(PdfFontFamily.Helvetica, 12);
        //Set the properties to paginate the text
        PdfLayoutFormat layoutFormat = new PdfLayoutFormat();
        layoutFormat.Break = PdfLayoutBreakType.FitPage;
        //Set bounds to draw multiline text
        RectangleF bounds = new RectangleF(new PointF(14, result.Bounds.Bottom + 32), currentPage.Graphics.ClientSize);
        //Draw the text element with the properties and formats set
        element.Draw(currentPage, bounds, layoutFormat);
        font = new PdfStandardFont(PdfFontFamily.Helvetica, 10);
        text = new PdfTextElement("Partners", font, new PdfSolidBrush(Color.FromArgb(255, 71, 87, 103)));
        text.StringFormat = new PdfStringFormat(PdfTextAlignment.Left);
        result = text.Draw(currentPage, new PointF(14, clientSize.Height - 30));
        font = new PdfStandardFont(PdfFontFamily.Helvetica, 12);
        text = new PdfTextElement("Var Energi", font);
        text.StringFormat = new PdfStringFormat(PdfTextAlignment.Left);
        result = text.Draw(currentPage, new PointF(result.Bounds.Right+83, clientSize.Height - 30));
        text = new PdfTextElement("Var Energi", font);
        text.StringFormat = new PdfStringFormat(PdfTextAlignment.Left);
        result = text.Draw(currentPage, new PointF(result.Bounds.Right + 40, clientSize.Height - 30));
        text = new PdfTextElement("Var Energi", font);
        text.StringFormat = new PdfStringFormat(PdfTextAlignment.Left);
        result = text.Draw(currentPage, new PointF(result.Bounds.Right + 40, clientSize.Height - 30));
        text = new PdfTextElement("Var Energi", font);
        text.StringFormat = new PdfStringFormat(PdfTextAlignment.Left);
        result = text.Draw(currentPage, new PointF(result.Bounds.Right + 40, clientSize.Height - 30));




        //PdfPage secondPage = pdfDocument.Pages.Add();
        PdfGrid grid = new PdfGrid();
        font = new PdfStandardFont(PdfFontFamily.Helvetica, 10, PdfFontStyle.Regular);
        grid.Style.Font = font;
        grid.Columns.Add(4);
        grid.Columns[1].Width = 70;

        grid.Headers.Add(1);
        PdfStringFormat stringFormat = new PdfStringFormat(PdfTextAlignment.Right, PdfVerticalAlignment.Middle);
        PdfGridRow header = grid.Headers[0];

        header.Cells[0].Value = "Item & description";
        header.Cells[0].StringFormat.LineAlignment = PdfVerticalAlignment.Middle;
        header.Cells[1].Value = "Hrs/Qty";
        header.Cells[1].StringFormat = stringFormat;

        PdfGridRow row = grid.Rows.Add();
        row.Cells[0].Value = "API Development";
        row.Cells[0].StringFormat.LineAlignment = PdfVerticalAlignment.Middle;

        row.Cells[1].Value = $"{25}";
        row.Cells[1].StringFormat = stringFormat;

        decimal sum = 0;

        row = grid.Rows.Add();
        row.Cells[0].Value = "Desktop Software Development";
        row.Cells[0].StringFormat.LineAlignment = PdfVerticalAlignment.Middle;
        row.Cells[1].Value = $"{25}";
        row.Cells[1].StringFormat = stringFormat;
        row = grid.Rows.Add();
        row.Cells[0].Value = "Site admin development";
        row.Cells[0].StringFormat.LineAlignment = PdfVerticalAlignment.Middle;
        row.Cells[1].Value = $"{33}";
        row.Cells[1].StringFormat = stringFormat;

        grid.ApplyBuiltinStyle(PdfGridBuiltinStyle.GridTable4Accent5);
        PdfGridStyle gridStyle = new PdfGridStyle();
        gridStyle.CellPadding = new PdfPaddings(5, 5, 5, 5);
        grid.Style = gridStyle;

        PdfGridLayoutFormat gridLayoutFormat = new PdfGridLayoutFormat();
        layoutFormat.Layout = PdfLayoutType.Paginate;
        result = grid.Draw(currentPage, 14, result.Bounds.Bottom + 30, clientSize.Width - 35, gridLayoutFormat);

        /*secondPage.Graphics.DrawRectangle(new PdfSolidBrush(Color.FromArgb(255, 239, 242, 255)),
            new RectangleF(result.Bounds.Right - 100, result.Bounds.Bottom + 20, 100, 20));*/

        /*PdfTextElement gridElement = new PdfTextElement("Total", font);
        gridElement.Draw(secondPage, new RectangleF(result.Bounds.Right - 100, result.Bounds.Bottom + 22, result.Bounds.Width, result.Bounds.Height));

        var totalPrice = $"$ {Math.Round(sum, 2)}";
        gridElement = new PdfTextElement(totalPrice, font);
        gridElement.StringFormat = new PdfStringFormat(PdfTextAlignment.Right);
        gridElement.Draw(secondPage, new RectangleF(15, result.Bounds.Bottom + 22, result.Bounds.Width, result.Bounds.Height));*/

        MemoryStream stream = new MemoryStream();
        pdfDocument.Save(stream);
        pdfDocument.Close(true);
        stream.Position = 0;
        File.WriteAllBytes("Output.pdf", stream.ToArray());
    }
}

