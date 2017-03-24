Imports MySql.Data
Imports MySql.Data.MySqlClient
Imports iTextSharp
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO
Public Class Form2
    Private Sub PacientesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PacientesToolStripMenuItem.Click
        Form3.Show()
    End Sub
    Private Sub VisitaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VisitaToolStripMenuItem.Click
        Form4.Show()
    End Sub
    Private Sub AyudaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AyudaToolStripMenuItem.Click
        Form5.Show()
    End Sub
    Private Sub Form2_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim opc As DialogResult = MsgBox("¿Desea salir de esta aplicación?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Salir")

        If opc = Windows.Forms.DialogResult.Yes Then
            End
        Else
            e.Cancel = True
        End If
    End Sub
    Private Sub ReporteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReporteToolStripMenuItem.Click
        MsgBox("En breve se generara tu reporte del dia")
        Dim oConexion As New MySqlConnection
        Dim oAdaptador As MySqlDataAdapter
        Dim oDataSet As New DataSet
        Dim sSql As String
        Dim max As Integer
        Dim min As Integer
        Try
            oConexion.ConnectionString = "Server=192.168.15.208;database=regist;user id=tishca;password=jshtmlcss;"
            sSql = "SELECT MIN(regist_visitas_id) as idmin,MAX(regist_visitas_id) as idmax FROM regist.regist_visitas WHERE regist_visitas_fecha='" & Date.Now.ToString("dd/MM/yyyy") & "';"
            oConexion.Open()
            oAdaptador = New MySqlDataAdapter(sSql, oConexion)
            oDataSet.Clear()
            oAdaptador.Fill(oDataSet, "regist_visitas")
            Dim dr As DataRowView = BindingContext(oDataSet, "regist_visitas").Current
            max = dr("idmax")
            min = dr("idmin")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        oConexion.Close()
        System.IO.Directory.CreateDirectory("c:\Reportes")
        Dim pdfDoc As New Document()
        Dim pdfwrite As PdfWriter = PdfWriter.GetInstance(pdfDoc, New FileStream("c:\Reportes\reporte" & Date.Now.ToString("ddMMyyy") & ".pdf", FileMode.Create))
        pdfDoc.Open()
        Dim table As New PdfPTable(5)
        Dim cell As New PdfPCell(New Phrase("Registros del" & Date.Now.ToString("dd/MM/yyyy")))
        cell.Colspan = 5
        cell.HorizontalAlignment = 1
        table.AddCell(cell)
        table.AddCell("Fecha")
        table.AddCell("Paciente")
        table.AddCell("Visitantes")
        table.AddCell("Relacion")
        table.AddCell("Actividades")
        oConexion.ConnectionString = "Server=192.168.15.208;database=regist;user id=tishca;password=jshtmlcss;"
        oConexion.Open()
        For i As Integer = min To (max) Step 1
            Try
                sSql = "SELECT regist_visitas_fecha,regist_pacientes_nombre,regist_visitas_visitantes,regist_visitas_relacion,regist_visitas_actividades FROM regist.regist_visitas,regist_pacientes WHERE regist_pacientes_id=regist_pacientes_regist_pacientes_id AND regist_visitas_fecha='" & Date.Now.ToString("dd/MM/yyyy") & "' AND regist_visitas_id='" & i & "';"
                oAdaptador = New MySqlDataAdapter(sSql, oConexion)
                oDataSet.Clear()
                oAdaptador.Fill(oDataSet, "regist_visitas")
                Dim dr As DataRowView = BindingContext(oDataSet, "regist_visitas").Current
                table.AddCell(dr("regist_visitas_fecha"))
                table.AddCell(dr("regist_pacientes_nombre"))
                table.AddCell(dr("regist_visitas_visitantes"))
                table.AddCell(dr("regist_visitas_relacion"))
                table.AddCell(dr("regist_visitas_actividades"))
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
        Next
        oConexion.Close()
        pdfDoc.Add(table)
        pdfDoc.Close()
        MsgBox("Tu reporte esta en la siguiente ruta" & vbCr & "c:\Reportes\reporte" & Date.Now.ToString("ddMMyyy") & ".pdf")
    End Sub
End Class