Imports System.Data.SqlClient


Public Class Form1

        Private Sub btnLoadData_Click(sender As Object, e As EventArgs) Handles btnLoadData.Click
        ' Definir la cadena de conexión (ajústala según tu configuración)
        Dim connectionString As String = "Server=PONCE\MSSQLSERVER1;Database=CorreosMx;Integrated Security=True"

        ' Definir la consulta SQL para obtener todos los datos de Asentamiento y las tablas relacionadas
        Dim query As String = "SELECT a.id, a.Nombre AS Asentamiento, a.CodigoPostal, " &
                                  "ta.Nombre AS TipoAsentamiento, z.Nombre AS Zona, m.Nombre AS Municipio, e.Nombre AS Estado, " &
                                  "uCrea.Nombre AS UsuarioCrea, a.FechaCrea, uModifica.Nombre AS UsuarioModifica, a.FechaModifica, a.Estatus " &
                                  "FROM Asentamiento AS a " &
                                  "LEFT JOIN TipoAsentamiento AS ta ON a.IdTipoAsentamiento = ta.id " &
                                  "LEFT JOIN Zona AS z ON a.IdZona = z.id " &
                                  "LEFT JOIN Municipio AS m ON a.IdMunicipio = m.id " &
                                  "LEFT JOIN Estado AS e ON m.IdEstado = e.id " &
                                  "LEFT JOIN Usuario AS uCrea ON a.IdUsuarioCrea = uCrea.id " &
                                  "LEFT JOIN Usuario AS uModifica ON a.IdUsuarioModifica = uModifica.id"

            ' Crear una conexión y un adaptador de datos
            Using connection As New SqlConnection(connectionString)
                Dim adapter As New SqlDataAdapter(query, connection)

                ' Llenar un DataTable con los datos obtenidos
                Dim table As New DataTable()
                adapter.Fill(table)

                ' Asignar el DataTable al DataGridView
                DataGridView1.DataSource = table
            End Using
        End Sub

    End Class

