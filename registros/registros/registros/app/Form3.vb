Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class Form3
    Sub llendata()
        Dim oConexion As New MySqlConnection
        Dim oAdaptador As MySqlDataAdapter
        Dim oDataSet As New DataSet
        Dim sSql As String
        Try
            oConexion.ConnectionString = "Server=192.168.15.208;database=regist;user id=tishca;password=jshtmlcss;"
            sSql = "SELECT * FROM regist_pacientes"
            oConexion.Open()
            oAdaptador = New MySqlDataAdapter(sSql, oConexion)
            oDataSet.Clear()
            oAdaptador.Fill(oDataSet, "regist_pacientes")
            DataGridView1.DataSource = oDataSet.Tables("regist_pacientes")
            ComboBox1.DataSource = oDataSet.Tables("regist_pacientes")
            ComboBox1.DisplayMember = "regist_pacientes_id"
            Dim dr As DataRowView = BindingContext(oDataSet, "regist_pacientes").Current
            TextBox2.Text = dr("regist_pacientes_nombre")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

        oConexion.Close()
    End Sub
    Sub llendatos()
        Dim oConexion As New MySqlConnection
        Dim oAdaptador As MySqlDataAdapter
        Dim oDataSet As New DataSet
        Dim sSql As String
        Try
            oConexion.ConnectionString = "Server=192.168.15.208;database=regist;user id=tishca;password=jshtmlcss;"
            sSql = "SELECT * FROM regist_pacientes WHERE regist_pacientes_id ='" & ComboBox1.SelectedItem("regist_pacientes_id") & "'"
            oConexion.Open()
            oAdaptador = New MySqlDataAdapter(sSql, oConexion)
            oDataSet.Clear()
            oAdaptador.Fill(oDataSet, "regist_pacientes")
            Dim dr As DataRowView = BindingContext(oDataSet, "regist_pacientes").Current
            TextBox2.Text = dr("regist_pacientes_nombre")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

        oConexion.Close()
    End Sub
    Sub vaciafocaliza()
        TextBox1.Text = ""
        DateTimePicker1.Value = Date.Now
        TextBox1.Focus()
    End Sub
    Sub llendata2()
        Dim oConexion As New MySqlConnection
        Dim oAdaptador As MySqlDataAdapter
        Dim oDataSet As New DataSet
        Dim sSql As String
        Try
            oConexion.ConnectionString = "Server=192.168.15.208;database=regist;user id=tishca;password=jshtmlcss;"
            sSql = "SELECT * FROM regist_pacientes"
            oConexion.Open()
            oAdaptador = New MySqlDataAdapter(sSql, oConexion)
            oDataSet.Clear()
            oAdaptador.Fill(oDataSet, "regist_pacientes")
            DataGridView2.DataSource = oDataSet.Tables("regist_pacientes")
            ComboBox2.DataSource = oDataSet.Tables("regist_pacientes")
            ComboBox2.DisplayMember = "regist_pacientes_id"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        oConexion.Close()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim oConexion As New MySqlConnection
        Dim oAdaptador As MySqlDataAdapter
        Dim oDataSet As New DataSet
        Dim sSql As String
        Dim sw As Boolean = False
        Try
            oConexion.ConnectionString = "Server=192.168.15.208;database=regist;user id=tishca;password=jshtmlcss;"
            sSql = "INSERT INTO regist_pacientes (regist_pacientes_nombre,regist_pacientes_fecha_nacimiento,regist_pacientes_fecha_entrada) VALUES ('" & TextBox1.Text & "','" & DateTimePicker1.Value.ToString("dd/MM/yy") & "','" & DateTime.Now.ToString("dd/MM/yyyy") & "')"
            oConexion.Open()
            oAdaptador = New MySqlDataAdapter(sSql, oConexion)
            oDataSet.Clear()
            oAdaptador.Fill(oDataSet, "regist_pacientes")
            MsgBox("Guardado correcta mente", MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        vaciafocaliza()
        oConexion.Close()
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        vaciafocaliza()
    End Sub
    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        llendata()
        llendata2()
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        llendatos()
    End Sub
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        llendata()
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim oConexion As New MySqlConnection
        Dim oAdaptador As MySqlDataAdapter
        Dim oDataSet As New DataSet
        Dim sSql As String
        Try
            oConexion.ConnectionString = "Server=192.168.15.208;database=regist;user id=tishca;password=jshtmlcss;"
            sSql = "UPDATE regist_pacientes set regist_pacientes_nombre='" & TextBox2.Text & "', regist_pacientes_fecha_nacimiento='" & DateTimePicker2.Value.ToString("dd/MM/yyyy") & "' , regist_pacientes_password='" & TextBox3.Text & "' WHERE regist_pacientes_id ='" & ComboBox1.SelectedItem("regist_pacientes_id") & "'"
            oConexion.Open()
            oAdaptador = New MySqlDataAdapter(sSql, oConexion)
            oDataSet.Clear()
            oAdaptador.Fill(oDataSet, "regist_pacientes")
            MsgBox("Gatos Guardados Correcta mente.", MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        oConexion.Close()
        llendata()
    End Sub
    Private Sub RadioButton5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton5.CheckedChanged
        ComboBox1.Enabled = True
        TextBox4.Enabled = False
    End Sub
    Private Sub RadioButton7_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton7.CheckedChanged
        ComboBox1.Enabled = False
        TextBox4.Enabled = True
    End Sub
    Private Sub TextBox4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox4.TextChanged
        Dim oConexion As New MySqlConnection
        Dim oAdaptador As MySqlDataAdapter
        Dim oDataSet As New DataSet
        Dim sSql As String
        Try
            oConexion.ConnectionString = "Server=192.168.15.208;database=regist;user id=tishca;password=jshtmlcss;"
            sSql = "SELECT * FROM regist_pacientes WHERE regist_pacientes_nombre LIKE '%" & TextBox4.Text & "%'"
            oConexion.Open()
            oAdaptador = New MySqlDataAdapter(sSql, oConexion)
            oDataSet.Clear()
            oAdaptador.Fill(oDataSet, "regist_pacientes")
            DataGridView2.DataSource = oDataSet.Tables("regist_pacientes")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        oConexion.Close()
    End Sub
End Class