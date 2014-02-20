Public Class clsLabelPrint
    ' Inherits all the functionality of a PrintDocument
    Inherits Printing.PrintDocument
    ' Private variables to hold ID, default font and text
    Private MyMemID As Long
    Private fntPrintFont As Font
    Private strText As String
    Private dtDataToPrint As DataTable
    Private LAlgmnt As StringAlignment
    Private intPrintAreaHeight, intPrintAreaWidth As Integer
    Private intMarginLeft, intMarginTop As Integer
    Private LabelCounter As Integer
    Private skipLabels As Integer = 0

    Public Property Text() As String
        Get
            Return strText
        End Get
        Set(ByVal Value As String)
            strText = Value
        End Set
    End Property

    Friend Property CurrentLabel As LabelData

    Public Property Font() As Font
        ' Allows the user to override the default font
        Get
            Return fntPrintFont
        End Get
        Set(ByVal Value As Font)
            fntPrintFont = Value
        End Set
    End Property

    Public Property Skip As Integer
    ' Number of labels to skip
        Get
            Return skipLabels
        End Get
        Set(ByVal value As Integer)
            skipLabels = value
        End Set
    End Property

    Public WriteOnly Property DataToPrint() As DataTable
        Set(ByVal Value As DataTable)
            dtDataToPrint = Value
        End Set
    End Property

    Public Property algLabel() As StringAlignment
        Get
            Return LAlgmnt
        End Get
        Set(ByVal Value As StringAlignment)
            LAlgmnt = Value
        End Set
    End Property

    Protected Overrides Sub OnBeginPrint(ByVal ev As Printing.PrintEventArgs)
        ' Run base code
        MyBase.OnBeginPrint(ev)
        ' Sets the default font
        If fntPrintFont Is Nothing Then
            fntPrintFont = New Font("Arial", 12)
        End If
    End Sub

    Protected Overrides Sub OnPrintPage(ByVal ev As Printing.PrintPageEventArgs)
        ' Run base code
        MyBase.OnPrintPage(ev)
        ' == Is label selected?
        If CurrentLabel.Name = "" Then
            MessageBox.Show("No label type selected." & ControlChars.CrLf & "Please set a label and try again.", "No Label", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        ' == Set printing area boundaries and margin coordinates
        With MyBase.DefaultPageSettings
            If .Landscape Then
                .Landscape = False
            End If
            intMarginLeft = CurrentLabel.LM
            intMarginTop = CurrentLabel.TM
            If intMarginTop < 0 Then
                .Margins.Top = 0
            Else
                .Margins.Top = intMarginTop
            End If
            .Margins.Bottom = .Margins.Top
            If intMarginLeft < 0 Then
                .Margins.Left = 0
            Else
                .Margins.Left = intMarginLeft
            End If
            .Margins.Right = .Margins.Left
            intPrintAreaHeight = .PaperSize.Height - _
                    .Margins.Top - .Margins.Bottom
            intPrintAreaWidth = .PaperSize.Width - _
                    .Margins.Left - .Margins.Right
        End With
        If dtDataToPrint Is Nothing Then
            ' If there is no data print test page
            'Dim LArea As New Rectangle(intMarginLeft, _
            '    intMarginTop, CurrentLabel.W, CurrentLabel.H)
            Dim P As New Pen(Color.Black)
            For row As Integer = 1 To CurrentLabel.NoDown
                For col As Integer = 1 To CurrentLabel.NoAcross
                    Dim LeftEdge As Integer = (CurrentLabel.LM + (CurrentLabel.W + CurrentLabel.G) * (col - 1))
                    Dim TopEdge As Integer = (CurrentLabel.TM + (CurrentLabel.H + CurrentLabel.V) * (row - 1))
                    Dim LArea = New Rectangle(LeftEdge, TopEdge, CurrentLabel.W, CurrentLabel.H)
                    ev.Graphics.DrawRectangle(P, LArea)
                Next
            Next
        Else
            ' If there is data then  fill labels and print
            ' How many Labels
            Dim drow As DataRow
            ''Dim LArea As New Rectangle(intMarginLeft, _
            ''    intMarginTop, CurrentLabel.W, CurrentLabel.H)
            ' Initialise StringFormat class, for text layout
            ' StringFormatFlags.LineLimit ensures only whole lines are laid out,
            ' continuing until all text is laid out or until no more lines of 
            ' text will be visible 
            Dim objSF As New StringFormat(StringFormatFlags.LineLimit)
            objSF.Alignment = LAlgmnt
            ' use stringbuilder to build up the contents of one label
            Dim sb As New System.Text.StringBuilder
            Dim FirstRow As Integer = 1
            Dim FirstCol As Integer = 1
            ev.HasMorePages = True ' Gets turned off when we run out of labels
            For row As Integer = 1 To CurrentLabel.NoDown
                For col As Integer = 1 To CurrentLabel.NoAcross
                    If skipLabels > 0 Then
                        'do nothing move on
                        skipLabels -= 1
                    Else
                        Dim oneLine As String
                        Dim Lfont As Font = fntPrintFont
                        Dim P As Integer = CurrentLabel.Pad * 2 ' amount to take of label height and width to get printable area
                        Dim Lsize As New SizeF(CurrentLabel.W - P, CurrentLabel.H - P) ' Size of printable area inside label
                        Dim LineCount As Integer = 0
                        LabelCounter += 1
                        If LabelCounter > dtDataToPrint.Rows.Count Then
                            'flag that there are no more pages and exit this one
                            ev.HasMorePages = False
                            LabelCounter = 0 'reset for next print job
                            Exit Sub
                        End If
                        drow = dtDataToPrint.Rows(LabelCounter - 1)
                        ' Build Address Text
                        sb.Remove(0, sb.Length)
                        '' First and Last Name
                        'sb.Append(drow("FirstName").ToString & " " & drow("Surname").ToString) ' First and Last Name
                        If drow("Title").ToString & "" > "" Then ' Title
                            sb.Append(drow("Title").ToString & " " & drow("SurName"))
                        ElseIf drow("FirstName") & "" > "" Then
                            sb.Append(drow("FirstName").ToString & " " & drow("SurName"))
                        Else 
                            sb.Append(drow("SurName"))
                        End If
                        Lfont = FitFont(ev, objSF, Lfont, sb.ToString, Lsize)
                        LineCount += 1
                        If drow("Addressline1").ToString & "" > "" And drow("Addressline2").ToString & "" > "" Then
                            oneLine = drow("Addressline1").ToString & ", " & drow("Addressline2").ToString 'House + Street
                        ElseIf drow("Addressline1").ToString & "" > "" Then
                            oneLine = drow("Addressline1").ToString & ""       ' House
                        ElseIf drow("Addressline2").ToString & "" > "" Then
                            oneLine = drow("Addressline2").ToString & ""       ' Street
                        Else
                            oneLine = String.Empty
                        End If
                        If Len(oneLine) > 0 Then
                            sb.Append(ControlChars.CrLf & oneLine)
                            Lfont = FitFont(ev, objSF, Lfont, oneLine, Lsize)
                            LineCount += 1
                        End If
                        oneLine = drow("PostTown").ToString & "" 'Town
                        If Len(oneLine) > 0 Then
                            sb.Append(ControlChars.CrLf & oneLine)
                            Lfont = FitFont(ev, objSF, Lfont, oneLine, Lsize)
                            LineCount += 1
                        End If
                        'County and Postcode
                        If drow("County").ToString & "" > "" And drow("Postcode").ToString & "" > "" Then
                            oneLine = drow("County").ToString & ", " & drow("Postcode").ToString
                        ElseIf drow("County").ToString & "" > "" Then
                            oneLine = drow("County").ToString
                        ElseIf drow("Postcode").ToString & "" > "" Then
                            oneLine = drow("Postcode").ToString
                        Else
                            oneLine = String.Empty
                        End If
                        If Len(oneLine) > 0 Then
                            sb.Append(ControlChars.CrLf & oneLine)
                            Lfont = FitFont(ev, objSF, Lfont, oneLine, Lsize)
                            LineCount += 1
                        End If
                        ' Country
                        oneLine = drow("Country").ToString & "" 'Town
                        If Len(oneLine) > 0 Then
                            sb.Append(ControlChars.CrLf & oneLine)
                            Lfont = FitFont(ev, objSF, Lfont, oneLine, Lsize)
                            LineCount += 1
                        End If
                        ' All lines now fit horizontally - ensure whole label fits vertically
                        Lfont = FitFontWholeLabel(ev, objSF, sb.ToString, Lsize, Lfont)
                        Dim LeftEdge As Integer = (CurrentLabel.LM + (CurrentLabel.W + CurrentLabel.G) * (col - 1))
                        Dim TopEdge As Integer = (CurrentLabel.TM + (CurrentLabel.H + CurrentLabel.V) * (row - 1))
                        ' draws rectangle round label (useful when debugging)
                        'LArea = New Rectangle(LeftEdge, TopEdge, CurrentLabel.W, CurrentLabel.H)
                        'ev.Graphics.DrawRectangle(New Pen(Color.Gray), LArea)
                        Dim TextHeight As Integer = CInt(Lfont.Height * LineCount)
                        TopEdge = TopEdge + CInt((CurrentLabel.H - TextHeight) / 2)
                        Dim pad As Integer = CurrentLabel.Pad
                        Dim FLArea As New RectangleF(LeftEdge + pad, TopEdge + pad, CurrentLabel.W - (2 * CurrentLabel.Pad), CurrentLabel.H - (2 * CurrentLabel.Pad))
                        ev.Graphics.DrawString(sb.ToString, Lfont, Brushes.Black, FLArea, objSF)
                        '' Member ID in top right corner
                        'If _includeID then
                        '    Dim IDArea As New RectangleF(LeftEdge + CurrentLabel.W-40, TopEdge , 40,12)
                        '    Dim F As New Font("Arial",8)
                        '    ev.Graphics.Drawstring(drow("ID"),F,Brushes.Black,IDArea,objSF)
                        'End If
                    End If
                Next col
            Next row
        End If
    End Sub

    Private Function PrintALine(ByVal ev As Printing.PrintPageEventArgs, _
                    ByVal Top As Integer, ByVal Heading As String, _
                    ByVal Info As String) As Integer
        Dim objSF As New StringFormat(StringFormatFlags.LineLimit)
        objSF.Alignment = StringAlignment.Near
        Dim TitleWidth As Integer = 150
        Dim TitleFont As New Font("Arial", _
                11, FontStyle.Bold, GraphicsUnit.Point)
        Dim BodyFont As New Font("Arial", _
                11, FontStyle.Regular, GraphicsUnit.Point)
        Dim TitleArea As New RectangleF(intMarginLeft, _
            Top, TitleWidth, intPrintAreaHeight)
        Dim TitleSize As New SizeF(TitleWidth, intPrintAreaHeight)
        Dim BodyArea As New RectangleF(intMarginLeft + TitleWidth, Top, _
            intPrintAreaWidth - TitleWidth, intPrintAreaHeight)
        Dim BodySize As New SizeF(intPrintAreaWidth - TitleWidth, intPrintAreaHeight)
        ' Print the title
        Dim TitleLinesFilled, BodyLinesFilled, intCharsFitted As Int32
        ' Arguments are Text, Font, LayoutArea, StringFormat, CharsFitted, LinesFilled
        Dim txt As String = Info
        ev.Graphics.MeasureString(Heading, TitleFont, _
                    TitleSize, objSF, intCharsFitted, TitleLinesFilled)
        ' Print the text to the page
        ' Arguments are String, Font, Brush, Rectangle, StringFormat
        ev.Graphics.DrawString(Heading, TitleFont, _
            Brushes.Black, TitleArea, objSF)
        ' Repeat for Body
        ' Arguments are Text, Font, LayoutArea, StringFormat, CharsFitted, LinesFilled
        ev.Graphics.MeasureString(Info, BodyFont, _
                    BodySize, objSF, intCharsFitted, BodyLinesFilled)
        ' Print the text to the page
        ' Arguments are String, Font, Brush, Rectangle, StringFormat
        ev.Graphics.DrawString(Info, BodyFont, _
            Brushes.Black, BodyArea, objSF)
        If BodyLinesFilled > TitleLinesFilled Then
            Top = Top + (BodyLinesFilled * TitleFont.Height) + 5
        Else
            Top = Top + (TitleLinesFilled * TitleFont.Height) + 5
        End If
        Return Top
    End Function

    ''Public Function PrintOneLine(ByVal ev As Printing.PrintPageEventArgs, _
    ''                ByVal Top As Integer, ByVal Lwidth As Integer, ByVal Ltext As String, _
    ''                ByVal Lfont As Font, ByVal Lalign As StringAlignment, _
    ''                ByVal Rtext As String, ByVal Rfont As Font, _
    ''                ByVal Ralign As StringAlignment) As Integer
    ''    Dim objSF As New StringFormat(StringFormatFlags.LineLimit)
    ''    Dim LArea As New RectangleF(intMarginLeft, _
    ''        Top, Lwidth, intPrintAreaHeight - Top)
    ''    Dim LSize As New SizeF(Lwidth, intPrintAreaHeight - Top)
    ''    ' Print the label
    ''    Dim LLinesFilled, CharsFitted As Int32
    ''    objSF.Alignment = StringAlignment.Near
    ''    ' Arguments are Text, Font, LayoutArea, StringFormat, CharsFitted, LinesFilled
    ''    Dim i As Integer = 0
    ''    Do 'Ensure the line fits, reducing font size if necessary
    ''        Lfont = New Font(Lfont.Name, Lfont.Size + i)
    ''        ev.Graphics.MeasureString(Ltext, Lfont, _
    ''                    LSize, objSF, CharsFitted, LLinesFilled)
    ''    Loop While LLinesFilled > 1
    ''    ' Print the text to the page
    ''    ' Arguments are String, Font, Brush, Rectangle, StringFormat
    ''    ev.Graphics.DrawString(Ltext, Lfont, _
    ''        Brushes.Black, LArea, objSF)
    ''    Top = Top + (LLinesFilled * Lfont.Height) + 5
    ''End Function

    Private Function FitFont(ByRef ev As Printing.PrintPageEventArgs, _
        ByRef objSF As StringFormat, _
        ByVal fntToFit As Font, ByRef strLine As String, _
        ByVal Frame As SizeF) As Font
        ' Takes in font a line of text and a rectangle to fit it in
        ' Reduces the font size (if necessary) to make the line fit
        Dim LLinesFilled, CharsFitted As Int32
        Dim fntTemp As Font
        Dim i As Integer
        Do 'Ensure the line fits, reducing font size if necessary
            fntTemp = New Font(fntToFit.Name, fntToFit.Size - i, fntToFit.Style)
            i += 1
            ' Arguments are Text, Font, LayoutArea, StringFormat, CharsFitted, LinesFilled
            ev.Graphics.MeasureString(strLine, fntTemp, _
                Frame, objSF, CharsFitted, LLinesFilled)
        Loop While LLinesFilled > 1
        Return fntTemp
    End Function

    Private Function FitFontWholeLabel(ByRef ev As Printing.PrintPageEventArgs, ByRef objSF As StringFormat, ByVal theAddress As String, ByVal Lsize As SizeF, ByVal printFont As Font) As Font
        ' Takes in font a line of text and a rectangle to fit it in
        ' Reduces the font size (if necessary) to make the line fit
        Dim LLinesFilled, CharsFitted As Int32
        Dim fntTemp As Font
        Dim i As Integer
        Do 'Ensure the line fits, reducing font size if necessary
            fntTemp = New Font(printFont.Name, printFont.Size - i, printFont.Style)
            i += 1
            ' Arguments are Text, Font, LayoutArea, StringFormat, CharsFitted, LinesFilled
            ev.Graphics.MeasureString(theAddress, fntTemp, _
                Lsize, objSF, CharsFitted, LLinesFilled)
        Loop While CharsFitted < theAddress.Length
        Return fntTemp
    End Function
End Class
