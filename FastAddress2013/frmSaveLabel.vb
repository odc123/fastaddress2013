Public Class frmSaveLabel

    Friend Shared OldLabel As Object

    Private Sub frmSaveLabel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnSave.Text = String.Format("Update current label ({0}) with current settings.", OldLabel.ToString)
        btnDelete.Text = String.Format("Delete this label ({0}) from saved label settings", OldLabel.ToString)
        txtNew.Text = String.Empty
        If OldLabel.ToString.Trim = "- Default -" Then
            btnDelete.Enabled = False
        Else
            btnDelete.Enabled = True
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim LabelSaved As Boolean = False
        ' Set converter to convert entered dimensions to inches and x100
        Dim converter As Single
        If frmLabels.rbCent.Checked Then ' Centimeter selected
            converter = 100 / InToCm
        Else                    ' Inches selected
            converter = 100
        End If
        ' Update currently selected label definition
        Dim dvLabel As New DataView(dsLabels.Tables("Dimensions"))
        dvLabel.RowFilter = String.Format("Description = '{0}'", OldLabel)
        Dim drvLabel As DataRowView = dvLabel(0)
        ' Leave name as is - drvLabel("Description")
        drvLabel("Rows") = CType(frmLabels.txtDown.Text, Integer)
        drvLabel("Cols") = CType(frmLabels.txtAcross.Text, Integer)
        drvLabel("TM") = CInt(CType(frmLabels.txtTM.Text, Single) * converter)
        drvLabel("LM") = CInt(CType(frmLabels.txtLM.Text, Single) * converter)
        drvLabel("H") = CInt(CType(frmLabels.txtHeight.Text, Single) * converter)
        drvLabel("W") = CInt(CType(frmLabels.txtWidth.Text, Single) * converter)
        drvLabel("V") = CInt(CType(frmLabels.txtVertical.Text, Single) * converter)
        drvLabel("G") = CInt(CType(frmLabels.txtGutter.Text, Single) * converter)
        drvLabel("Pad") = CInt(CType(frmLabels.txtPad.Text, Single) * converter)
        ' Leave selected as is - dsLabels.Tables("Settings").Rows(0).Item(0) = lstLayoutNames.SelectedIndex
        dsLabels.AcceptChanges()
        dsLabels.WriteXml(LabelDataLocation, XmlWriteMode.WriteSchema)
        LabelSaved = True
        Me.Close()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim dvLabel As New DataView(dsLabels.Tables("Dimensions"))
        dvLabel.RowFilter = String.Format("Description = '{0}'", OldLabel)
        dvLabel.Delete(0)
        dsLabels.Tables("Settings").Rows(0).Item(0) = 0 ' Reset selected to Default
        dsLabels.AcceptChanges()
        dsLabels.WriteXml(LabelDataLocation, XmlWriteMode.WriteSchema)
        Me.Close()
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        ' Set converter to convert entered dimensions to inches and x100
        Dim converter As Single
        If frmLabels.rbCent.Checked Then ' Centimeter selected
            converter = 100 / InToCm
        Else                    ' Inches selected
            converter = 100
        End If
        ' Add New label definition
        Dim rLabel As DataRow = dsLabels.Tables("Dimensions").NewRow
        rLabel("Description") = txtNew.Text
        rLabel("Rows") = CType(frmLabels.txtDown.Text, Integer)
        rLabel("Cols") = CType(frmLabels.txtAcross.Text, Integer)
        rLabel("TM") = CInt(CType(frmLabels.txtTM.Text, Single) * Converter)
        rLabel("LM") = CInt(CType(frmLabels.txtLM.Text, Single) * Converter)
        rLabel("H") = CInt(CType(frmLabels.txtHeight.Text, Single) * Converter)
        rLabel("W") = CInt(CType(frmLabels.txtWidth.Text, Single) * Converter)
        rLabel("V") = CInt(CType(frmLabels.txtVertical.Text, Single) * Converter)
        rLabel("G") = CInt(CType(frmLabels.txtGutter.Text, Single) * Converter)
        rLabel("Pad") = CInt(CType(frmLabels.txtPad.Text, Single) * converter)
        dsLabels.Tables("Dimensions").Rows.Add(rLabel)
        ' Mark new label as selected
        Dim LabelsSaved As Integer = dsLabels.Tables("Dimensions").Rows.Count
        dsLabels.Tables("Settings").Rows(0).Item(0) = LabelsSaved - 1
        dsLabels.AcceptChanges()
        dsLabels.WriteXml(LabelDataLocation, XmlWriteMode.WriteSchema)
        frmLabels.RefreshLabelSettingsList
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class