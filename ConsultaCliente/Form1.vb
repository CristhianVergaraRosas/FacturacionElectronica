Imports ConsultaCliente.ServiceReference1
Imports System.IO

Public Class Form1

    

    Private Sub btnEjecutar_Click_1(sender As Object, e As EventArgs) Handles btnEjecutar.Click
        Dim cliente As New ConsultaServicioClient()

        Try
            Dim sql As String = txtQuery.Text.Trim()
            If String.IsNullOrEmpty(sql) Then
                MessageBox.Show("Ingresa una query.        ")
                Exit Sub
            End If

            Dim columnas As List(Of String) = cliente.ObtenerColumnas(sql)
            Dim datos As List(Of List(Of Object)) = cliente.EjecutarQuery(sql)

            dgvResultados.Columns.Clear()
            dgvResultados.Rows.Clear()

            If datos.Count = 0 Then
                MessageBox.Show("No hay resultados")
                Exit Sub
            End If

            ' Crear columnas dinámicas
            For Each columna As String In columnas
                dgvResultados.Columns.Add(columna, columna)
            Next

            ' Agregar filas
            For Each fila As List(Of Object) In datos
                dgvResultados.Rows.Add(fila.ToArray())
            Next

            dgvResultados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            If cliente.State <> ServiceModel.CommunicationState.Faulted Then
                cliente.Close()
            End If
        End Try
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        If dgvResultados.Rows.Count = 0 Then
            MessageBox.Show("No hay datos para exportar.")
            Exit Sub
        End If

        Dim sfd As New SaveFileDialog()
        sfd.Filter = "CSV|*.csv"
        sfd.FileName = "Exportacion.csv"

        If sfd.ShowDialog() = DialogResult.OK Then
            Try
                Using sw As New StreamWriter(sfd.FileName, False, System.Text.Encoding.UTF8)
                    ' Escribir encabezados
                    Dim encabezados As String = String.Join(",", dgvResultados.Columns.Cast(Of DataGridViewColumn).Select(Function(c) c.HeaderText))
                    sw.WriteLine(encabezados)

                    ' Escribir filas
                    For Each row As DataGridViewRow In dgvResultados.Rows
                        If Not row.IsNewRow Then
                            Dim fila As String = String.Join(",", row.Cells.Cast(Of DataGridViewCell).Select(Function(c) EscapeCSV(c.Value)))
                            sw.WriteLine(fila)
                        End If
                    Next
                End Using

                MessageBox.Show("Exportación a CSV completada.")
            Catch ex As Exception
                MessageBox.Show("Error al exportar a CSV: " & ex.Message)
            End Try
        End If
    End Sub

    ' Función para manejar comas y comillas en los valores
    Private Function EscapeCSV(value As Object) As String
        If value Is Nothing Then Return ""
        Dim s As String = value.ToString()
        If s.Contains(",") Or s.Contains("""") Or s.Contains(vbNewLine) Then
            s = s.Replace(",", "")
            's = """{s}"""
        End If
        Return s
    End Function



End Class
