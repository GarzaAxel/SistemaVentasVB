﻿Imports BOSistemaVentasVB
Imports System.Data.SqlClient

Public Class Ventas
    Dim venta As New BOVentas
    Dim etiqueta As Boolean = True
    Private Sub Ventas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MostrarVentas()
    End Sub
    Public Sub Limpiar()
        txtIdVenta.Clear()
        txtFecha.Clear()
        txtIVA.Clear()
        txtSubtotal.Clear()
        txtEstatus.Clear()
        txtIdCliente.Clear()
        txtIdCrear.Clear()
        txtIdModificar.Clear()
    End Sub
    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim conexion As String = "Server=DESKTOP-R538THL;Database=SistemaVentas; Integrated Security=True;"
        Dim conn As SqlConnection = New SqlConnection(conexion)
        conn.Open()
        Dim cmd As New SqlCommand("select * from Ventas where Id_Venta = @Id_Venta", conn)
        cmd.CommandType = CommandType.Text
        cmd.Parameters.Add(New SqlParameter("@Id_Venta", txtIdVenta.Text))
        Using sda As New SqlDataAdapter()
            sda.SelectCommand = cmd
            Using dt As New DataTable()
                sda.Fill(dt)
                If dt.Rows.Count Then
                    txtFecha.Text = dt.Rows(0)(1).ToString
                    txtIVA.Text = dt.Rows(0)(2).ToString
                    txtSubtotal.Text = dt.Rows(0)(3).ToString
                    If dt.Rows(0)(4) = True Then
                        txtEstatus.Text = 1
                    Else
                        txtEstatus.Text = 0
                    End If
                    txtIdCliente.Text = dt.Rows(0)(5).ToString
                    txtIdCrear.Text = dt.Rows(0)(6).ToString
                    txtIdModificar.Text = dt.Rows(0)(7).ToString
                End If
            End Using
        End Using
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        Limpiar()
    End Sub

    Private Sub btnAñadir_Click(sender As Object, e As EventArgs) Handles btnAñadir.Click
        Dim valido As Boolean = True

        If (String.IsNullOrEmpty(txtIdVenta.Text)) Then
            valido = False
        End If
        If (String.IsNullOrEmpty(txtFecha.Text)) Then
            valido = False
        End If
        If (String.IsNullOrEmpty(txtIVA.Text)) Then
            valido = False
        End If
        If (String.IsNullOrEmpty(txtSubtotal.Text)) Then
            valido = False
        End If
        If (String.IsNullOrEmpty(txtEstatus.Text)) Then
            valido = False
        End If
        If (String.IsNullOrEmpty(txtIdCliente.Text)) Then
            valido = False
        End If
        If (String.IsNullOrEmpty(txtIdCrear.Text)) Then
            valido = False
        End If
        If (String.IsNullOrEmpty(txtIdModificar.Text)) Then
            valido = False
        End If
        If valido Then
            etiqueta = venta.RegistrarVenta(txtIdVenta.Text, txtFecha.Text, txtIVA.Text, txtSubtotal.Text, txtEstatus.Text, txtIdCliente.Text, txtIdCrear.Text, txtIdModificar.Text)
            MsgBox("La informacion se ha registrado con Exito")
            Limpiar()
            MostrarVentas()
        Else
            MsgBox("No se ha podido registrar la informacion.")
        End If
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Dim valido As Boolean = True

        If (String.IsNullOrEmpty(txtIdVenta.Text)) Then
            valido = False
        End If
        If (String.IsNullOrEmpty(txtFecha.Text)) Then
            valido = False
        End If
        If (String.IsNullOrEmpty(txtIVA.Text)) Then
            valido = False
        End If
        If (String.IsNullOrEmpty(txtSubtotal.Text)) Then
            valido = False
        End If
        If (String.IsNullOrEmpty(txtEstatus.Text)) Then
            valido = False
        End If
        If (String.IsNullOrEmpty(txtIdCliente.Text)) Then
            valido = False
        End If
        If (String.IsNullOrEmpty(txtIdCrear.Text)) Then
            valido = False
        End If
        If (String.IsNullOrEmpty(txtIdModificar.Text)) Then
            valido = False
        End If
        If valido Then
            etiqueta = venta.ModificarVenta(txtIdVenta.Text, txtFecha.Text, txtIVA.Text, txtSubtotal.Text, txtEstatus.Text, txtIdCliente.Text, txtIdCrear.Text, txtIdModificar.Text)
            MsgBox("La informacion se ha registrado con Exito")
            Limpiar()
            MostrarVentas()
        Else
            MsgBox("No se ha podido registrar la informacion.")
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim valido As Boolean = True

        If (String.IsNullOrEmpty(txtIdVenta.Text)) Then
            valido = False
        End If
        If valido Then
            etiqueta = venta.EliminarVenta(txtIdVenta.Text)
            MsgBox("La informacion se ha registrado con Exito")
            Limpiar()
            MostrarVentas()
        Else
            MsgBox("No se ha podido registrar la informacion.")
        End If
    End Sub
    Public Sub MostrarVentas()
        Dim cnn As SqlConnection = New SqlConnection("Server=DESKTOP-R538THL;Database=SistemaVentas; Integrated Security=True;")
        Dim cmd = New SqlCommand("SELECT * FROM Ventas", cnn)
        Dim da = New SqlDataAdapter(cmd)
        Dim dt = New DataTable()
        Try
            cnn.Open()
            da.Fill(dt)
        Catch ex As Exception
            MessageBox.Show("Error al abrir la conexión: " & ex.Message)
        Finally
            If cnn.State = ConnectionState.Open Then
                cnn.Close()
            End If
        End Try

        ' Mostrar los datos en el DataGridView
        dgvVentas.DataSource = dt
    End Sub

    Private Sub DetalleComprasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DetalleComprasToolStripMenuItem.Click
        DetalleVenta.ShowDialog()
    End Sub
End Class