Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class Form4
    Private Sub Form4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
            ComboBox1.DataSource = oDataSet.Tables("regist_pacientes")
            ComboBox1.DisplayMember = "regist_pacientes_nombre"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        oConexion.Close()
    End Sub
    Function selectid()
        Dim oConexion As New MySqlConnection
        Dim oAdaptador As MySqlDataAdapter
        Dim oDataSet As New DataSet
        Dim sSql As String
        Dim dr As DataRowView
        Try
            oConexion.ConnectionString = "Server=192.168.15.208;database=regist;user id=tishca;password=jshtmlcss;"
            sSql = "SELECT regist_pacientes_id FROM regist_pacientes WHERE regist_pacientes_nombre='" & ComboBox1.SelectedItem("regist_pacientes_nombre") & "'"
            oConexion.Open()
            oAdaptador = New MySqlDataAdapter(sSql, oConexion)
            oDataSet.Clear()
            oAdaptador.Fill(oDataSet, "regist_pacientes")
            dr = BindingContext(oDataSet, "regist_pacientes").Current
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        oConexion.Close()
        Return dr("regist_pacientes_id")
    End Function
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim oConexion As New MySqlConnection
        Dim oAdaptador As MySqlDataAdapter
        Dim oDataSet As New DataSet
        Dim sSql As String
        Try
            oConexion.ConnectionString = "Server=192.168.15.208;database=regist;user id=tishca;password=jshtmlcss;"
            sSql = "INSERT INTO regist_visitas (regist_visitas_fecha,regist_pacientes_regist_pacientes_id,regist_visitas_visitantes,regist_visitas_relacion,regist_visitas_actividades) VALUES ('" & Date.Now.ToString("dd/MM/yyyy") & "','" & selectid() & "','" & NumericUpDown1.Value & "','" & TextBox1.Text & "','" & TextBox2.Text & "')"
            oConexion.Open()
            oAdaptador = New MySqlDataAdapter(sSql, oConexion)
            oDataSet.Clear()
            oAdaptador.Fill(oDataSet, "regist_pacientes")
            MsgBox("Datos Guardados Correcta Mente.", MsgBoxStyle.Information)
            Me.Hide()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        oConexion.Close()
    End Sub
End Class