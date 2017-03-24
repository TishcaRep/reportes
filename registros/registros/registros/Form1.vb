Imports MySql.Data
Imports MySql.Data.MySqlClient
Imports MySql.Data.Types
Public Class Form1
    Sub cerrar()
        Dim opc As DialogResult = MsgBox("¿Desea salir de esta aplicación?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Salir")
        If opc = Windows.Forms.DialogResult.Yes Then
            Close()
        End If
    End Sub
    Sub vaciarfocalizar()
        TextBox1.Text = ""
        MaskedTextBox1.Text = ""
        TextBox1.Focus()
    End Sub
    Function verificadata()
        Dim oConexion As New MySqlConnection
        Dim oAdaptador As MySqlDataAdapter
        Dim oDataSet As New DataSet
        Dim sSql As String
        Dim sw As Boolean = False
        Try
            oConexion.ConnectionString = "Server=192.168.15.208;database=regist;user id=tishca;password=jshtmlcss;"
            sSql = "SELECT * FROM regist_enfermera WHERE regist_enfermera_usuario = '" & TextBox1.Text & "' AND regist_enfermera_password = '" & MaskedTextBox1.Text & "'"
            oConexion.Open()
            oAdaptador = New MySqlDataAdapter(sSql, oConexion)
            oDataSet.Clear()
            oAdaptador.Fill(oDataSet, "regist_enfermera")
            If (oDataSet.Tables("regist_enfermera").Rows.Count() <> 0) Then
                MessageBox.Show("Bienvenido", "Sistema")
                Dim dr As DataRowView = BindingContext(oDataSet, "regist_enfermera").Current
                sw = True
            Else
                MessageBox.Show("Usuario y/o contraseña son incorrectos", "Sistema")
                vaciarfocalizar()
                sw = False
            End If
        Catch ex As Exception

        End Try

        oConexion.Close()
        Return (sw)
    End Function
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        cerrar()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If (verificadata()) Then
            Form2.Show()
            Me.Hide()
        End If
    End Sub
End Class
