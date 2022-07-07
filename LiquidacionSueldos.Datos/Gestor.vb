Imports System.Data
Imports System.Data.OleDb
Imports System.Text
Imports System.Security.Cryptography
Imports System.Xml

Namespace LiquidacionSueldos
    Namespace Datos
        Public Class Gestor
            Private _ConexionCadena As String
            Private _TiempoEjecucionSQL As Integer

            Public Sub New()
                Me._ConexionCadena = GetParValue()
                Me._TiempoEjecucionSQL = 300
            End Sub

            Public Sub New(ByVal ConexionCadena As String, ByVal TiempoEjecucionSQL As Integer)
                Me._ConexionCadena = ConexionCadena
                Me._TiempoEjecucionSQL = TiempoEjecucionSQL
            End Sub

            Public ReadOnly Property ConexionCadena()
                Get
                    Return Me._ConexionCadena
                End Get
            End Property

            Private Function GetParValue() As String
                Return System.Configuration.ConfigurationSettings.AppSettings("ConexionCadena").ToString()
            End Function

            ''' <summary>
            ''' Devuelve un Datatable a partir de un OleDbDataReader.    
            ''' </summary>
            ''' <returns></returns>
            Public Function DataReaderToDataTable(ByVal rdrReader As OleDbDataReader, ByVal Sql As String) As DataTable
                'Data Table
                Dim dataTable As New DataTable()

                Try
                    'Table Schema
                    Dim schemaTable As New DataTable()
                    schemaTable = rdrReader.GetSchemaTable()

                    'Now to create the Schema on the DataTable
                    For i As Integer = 0 To schemaTable.Rows.Count - 1
                        'Current Row
                        Dim dataRow As DataRow = schemaTable.Rows(i)
                        'Current Column Name
                        Dim columnName As String = dataRow("ColumnName").ToString()

                        'Si la columna no tiene nombre debe mostrar un mensaje de error
                        If columnName.Trim().Length = 0 Then
                            columnName = "SinNombre" & i.ToString()
                        End If

                        'Current Column
                        Dim column As New DataColumn(columnName, DirectCast(dataRow("DataType"), Type))

                        'Add Column to the DataTable
                        If Not dataTable.Columns.Contains(column.ColumnName) Then
                            dataTable.Columns.Add(column)
                        End If
                    Next

                    'Now to fill the table with the reader
                    While rdrReader.Read()
                        'New Row
                        Dim dataRow As DataRow = dataTable.NewRow()
                        'Loop the fields
                        For i As Integer = 0 To rdrReader.FieldCount - 1
                            'Insert the current value of the DataReader to the DataRow
                            dataRow(rdrReader.GetName(i)) = rdrReader.GetValue(i)
                        Next

                        'Insert the Row into the DataTable
                        dataTable.Rows.Add(dataRow)
                    End While

                    'Close the reader
                    rdrReader.Close()
                Catch oError As Exception
                    Throw oError
                End Try

                Return dataTable

            End Function

            ''' <summary>
            ''' Ejecuta SP desde la presentación.
            ''' </summary>
            ''' <param name="strNombreSP">Nombre del SP</param>
            ''' <param name="arr">Array de Parametros de la forma {{"nombreParametro", valorParametro},{...,...},{...,...}}</param>
            ''' <returns>Retorna un DataTable con los resultados.</returns>
            Public Function EjecutarReader(ByVal strNombreSP As String, ByVal arr As Object(,)) As DataTable
                Dim oDT As New DataTable()

                Dim ConexionCadena As String = GetParValue()

                Using oCnx As New OleDbConnection(ConexionCadena)
                    Using Comando As New OleDbCommand(strNombreSP, oCnx)
                        oCnx.Open()

                        Try
                            Comando.Parameters.Clear()
                            Dim oPar As OleDbParameter

                            '#Region "Parametros"
                            For i As Integer = 0 To arr.Length \ 2 - 1
                                oPar = New OleDbParameter(arr(i, 0).ToString(), arr(i, 1))
                                Comando.Parameters.Add(oPar)

                                oPar = Nothing
                            Next
                            '#End Region

                            Comando.CommandType = CommandType.StoredProcedure
                            Comando.CommandTimeout = _TiempoEjecucionSQL
                            Dim [oR] As OleDbDataReader = Comando.ExecuteReader()
                            oDT = DataReaderToDataTable([oR], strNombreSP)

                            [oR] = Nothing
                        Catch oError As Exception
                            Throw oError
                        Finally
                            oCnx.Close()
                        End Try
                    End Using
                End Using

                Return oDT
            End Function

            Public Function EjecutarReader(ByVal strNombreSP As String) As DataTable
                Dim ConexionCadena As String = GetParValue()
                Dim oDT As New DataTable()

                Using oCnx As New OleDbConnection(ConexionCadena)
                    Using Comando As New OleDbCommand(strNombreSP, oCnx)
                        oCnx.Open()

                        Try
                            Comando.Parameters.Clear()

                            Comando.CommandType = CommandType.StoredProcedure
                            Comando.CommandTimeout = _TiempoEjecucionSQL
                            Dim [oR] As OleDbDataReader = Comando.ExecuteReader()
                            oDT = DataReaderToDataTable([oR], strNombreSP)

                            [oR] = Nothing
                        Catch oError As Exception
                            Throw oError
                        Finally
                            oCnx.Close()
                        End Try
                    End Using
                End Using

                Return oDT
            End Function

            Public Function EjecutarReaderSql(ByVal SQL As String) As DataTable
                Dim oDT As New DataTable()
                Dim ConexionCadena As String = GetParValue()
                Using oCnx As New OleDbConnection(ConexionCadena)
                    Using Comando As New OleDbCommand(SQL, oCnx)
                        oCnx.Open()

                        Try
                            Comando.Parameters.Clear()
                            Comando.CommandType = CommandType.Text
                            Comando.CommandTimeout = _TiempoEjecucionSQL
                            Dim [oR] As OleDbDataReader = Comando.ExecuteReader()
                            oDT = DataReaderToDataTable([oR], SQL)
                            [oR] = Nothing
                        Catch oError As Exception
                            Throw oError
                        Finally
                            oCnx.Close()
                        End Try
                    End Using
                End Using

                Return oDT
            End Function

            ''' <summary>
            ''' Ejecuta SQL desde la presentación.
            ''' </summary>
            ''' <returns>Retorna un DataTable con los resultados.</returns>
            Public Function EjecutarReaderSPSinParametro(ByVal SQL As String) As DataTable
                Dim oDT As New DataTable()

                Dim ConexionCadena As String = GetParValue()
                Using oCnx As New OleDbConnection(ConexionCadena)
                    Using Comando As New OleDbCommand(SQL, oCnx)
                        oCnx.Open()

                        Try
                            Comando.Parameters.Clear()
                            Comando.CommandType = CommandType.Text
                            Comando.CommandTimeout = _TiempoEjecucionSQL
                            Dim [oR] As OleDbDataReader = Comando.ExecuteReader()
                            oDT = DataReaderToDataTable([oR], SQL)
                            [oR] = Nothing
                        Catch oError As Exception
                            Throw oError
                        Finally
                            oCnx.Close()
                        End Try
                    End Using
                End Using

                Return oDT
            End Function

            ''' <summary>
            ''' Ejecuta SP desde la presentación.
            ''' </summary>    
            ''' <param name="strNombreSP">Nombre del SP</param>
            ''' <param name="arr">Array de Parametros de la forma {{"nombreParametro", valorParametro},{...,...},{...,...}}</param>
            ''' <returns>Retorna un entero.</returns>
            Public Function EjecutarScalar(ByVal strNombreSP As String, ByVal arr As Object(,)) As Integer
                Dim iResul As Integer = 0

                Dim ConexionCadena As String = GetParValue()

                Using oCnx As New OleDbConnection(ConexionCadena)
                    Using Comando As New OleDbCommand(strNombreSP, oCnx)
                        oCnx.Open()

                        Try
                            Comando.Parameters.Clear()
                            Dim oPar As OleDbParameter

                            '#Region "Parametros"
                            For i As Integer = 0 To arr.Length \ 2 - 1
                                oPar = New OleDbParameter(arr(i, 0).ToString(), arr(i, 1))
                                Comando.Parameters.Add(oPar)

                                oPar = Nothing
                            Next
                            '#End Region

                            Comando.CommandType = CommandType.StoredProcedure
                            Comando.CommandTimeout = _TiempoEjecucionSQL
                            iResul = Integer.Parse(Comando.ExecuteScalar().ToString())
                        Catch oError As Exception
                            Throw oError
                        Finally
                            Comando.Dispose()

                            oCnx.Close()
                            oCnx.Dispose()
                        End Try
                    End Using
                End Using

                Return iResul

            End Function

            Public Function EjecutarScalar(ByVal Sql As String) As Integer
                Dim iResul As Integer = 0

                Dim ConexionCadena As String = GetParValue()

                Using oCnx As New OleDbConnection(ConexionCadena)
                    Using Comando As New OleDbCommand(Sql, oCnx)
                        oCnx.Open()

                        Try
                            Comando.CommandType = CommandType.Text
                            Comando.CommandTimeout = _TiempoEjecucionSQL
                            iResul = Integer.Parse(Comando.ExecuteScalar().ToString())
                        Catch oError As Exception
                            Throw oError
                        Finally
                            Comando.Dispose()

                            oCnx.Close()
                            oCnx.Dispose()
                        End Try
                    End Using
                End Using

                Return iResul

            End Function

            ''' <summary>
            ''' Ejecuta SP desde la presentación.
            ''' </summary>    
            ''' <param name="strNombreSP">Nombre del SP</param>
            ''' <param name="arr">Array de Parametros de la forma {{"nombreParametro", valorParametro},{...,...},{...,...}}</param>    
            Public Function EjecutarNonQueryRetornaValor(ByVal strNombreSP As String, ByVal arr As Object(,)) As Integer
                Dim ConexionCadena As String = GetParValue()
                Dim IdRetorno As Integer = 0

                Using oCnx As New OleDbConnection(ConexionCadena)
                    Using Comando As New OleDbCommand(strNombreSP, oCnx)
                        oCnx.Open()

                        Try
                            Comando.Parameters.Clear()
                            Dim oPar As OleDbParameter

                            '#Region "Parametros"
                            For i As Integer = 0 To arr.Length \ 2 - 1
                                oPar = New OleDbParameter(arr(i, 0).ToString(), arr(i, 1))
                                Comando.Parameters.Add(oPar)

                                oPar = Nothing
                            Next
                            '#End Region

                            Comando.CommandType = CommandType.StoredProcedure
                            Comando.CommandTimeout = _TiempoEjecucionSQL
                            IdRetorno = Convert.ToInt32(Comando.ExecuteScalar())
                        Catch oError As Exception
                            Throw oError
                        Finally
                            Comando.Dispose()

                            oCnx.Close()
                            oCnx.Dispose()
                        End Try
                    End Using
                End Using

                Return IdRetorno

            End Function

            Public Sub EjecutarNonQuery(ByVal strNombreSP As String, ByVal arr As Object(,))
                Dim ConexionCadena As String = GetParValue()

                Using oCnx As New OleDbConnection(ConexionCadena)
                    Using Comando As New OleDbCommand(strNombreSP, oCnx)
                        oCnx.Open()

                        Try
                            Comando.Parameters.Clear()
                            Dim oPar As OleDbParameter

                            '#Region "Parametros"
                            For i As Integer = 0 To arr.Length \ 2 - 1

                                If arr(i, 1).ToString().Length >= 10 Then
                                    If arr(i, 1).ToString().Substring(0, 10) = "01/01/0001" Then
                                        arr(i, 1) = Date.Now
                                    End If
                                End If

                                oPar = New OleDbParameter(arr(i, 0).ToString(), arr(i, 1))
                                Comando.Parameters.Add(oPar)

                                oPar = Nothing
                            Next
                            '#End Region

                            Comando.CommandType = CommandType.StoredProcedure
                            Comando.CommandTimeout = _TiempoEjecucionSQL
                            Comando.ExecuteNonQuery().ToString()
                        Catch oError As Exception
                            Throw oError
                        Finally
                            Comando.Dispose()
                            oCnx.Close()
                            oCnx.Dispose()
                        End Try
                    End Using
                End Using
            End Sub

            Public Sub EjecutarNonQuerySinParametros(ByVal strNombreSP As String)
                Dim ConexionCadena As String = GetParValue()

                Using oCnx As New OleDbConnection(ConexionCadena)
                    Using Comando As New OleDbCommand(strNombreSP, oCnx)
                        oCnx.Open()

                        Try
                            Comando.Parameters.Clear()
                            Comando.CommandType = CommandType.StoredProcedure
                            Comando.CommandTimeout = _TiempoEjecucionSQL
                            Comando.ExecuteNonQuery().ToString()
                        Catch oError As Exception
                            Throw oError
                        Finally
                            Comando.Dispose()

                            oCnx.Close()
                            oCnx.Dispose()
                        End Try
                    End Using
                End Using
            End Sub

            Public Sub EjecutarNonQuery(ByVal SQL As String)
                SQL = SQL.Replace("''", "' '")

                Dim ConexionCadena As String = GetParValue()

                Using oCnx As New OleDbConnection(ConexionCadena)
                    Using Comando As New OleDbCommand(SQL, oCnx)
                        oCnx.Open()

                        Try
                            Comando.Parameters.Clear()
                            Comando.CommandType = CommandType.Text
                            Comando.CommandTimeout = _TiempoEjecucionSQL
                            Comando.ExecuteNonQuery().ToString()
                        Catch oError As Exception
                            Throw oError
                        Finally
                            Comando.Dispose()

                            oCnx.Close()
                            oCnx.Dispose()
                        End Try
                    End Using
                End Using
            End Sub

            Public Sub EjecutarNonQuerySinModificarComillas(ByVal SQL As String)
                Dim ConexionCadena As String = GetParValue()

                Using oCnx As New OleDbConnection(ConexionCadena)
                    Using Comando As New OleDbCommand(SQL, oCnx)
                        oCnx.Open()

                        Try
                            Comando.Parameters.Clear()
                            Comando.CommandType = CommandType.Text
                            Comando.CommandTimeout = _TiempoEjecucionSQL
                            Comando.ExecuteNonQuery().ToString()
                        Catch oError As Exception
                            Throw oError
                        Finally
                            Comando.Dispose()

                            oCnx.Close()
                            oCnx.Dispose()
                        End Try
                    End Using
                End Using
            End Sub

            Public Sub EjecutarNonQuery_Transaccion(ByVal SQL As String)
                SQL = SQL.Replace("''", "' '")

                Dim ConexionCadena As String = GetParValue()

                Using oCnx As New OleDbConnection(ConexionCadena)
                    Using Comando As New OleDbCommand(SQL, oCnx)
                        oCnx.Open()

                        'Abro la transaccion
                        Dim Transaccion As OleDbTransaction = oCnx.BeginTransaction()
                        Comando.Transaction = Transaccion

                        Try
                            Comando.Parameters.Clear()
                            Comando.CommandType = CommandType.Text
                            Comando.CommandTimeout = _TiempoEjecucionSQL
                            Comando.ExecuteNonQuery().ToString()

                            'Confirma la transaccion

                            Transaccion.Commit()
                        Catch oError As OleDbException
                            'Vuelve atras la transaccion
                            Transaccion.Rollback()

                            Throw oError
                        Finally
                            Comando.Dispose()

                            oCnx.Close()
                            oCnx.Dispose()
                        End Try
                    End Using
                End Using
            End Sub

            Public Function EjecutarNonQueryRetornaId(ByVal SQL As String) As Integer
                SQL = SQL.Replace("''", "' '")

                Dim ConexionCadena As String = GetParValue()
                Dim Id As Integer = 0

                Using oCnx As New OleDbConnection(ConexionCadena)
                    Using Comando As New OleDbCommand(SQL, oCnx)
                        oCnx.Open()

                        Try
                            Comando.Parameters.Clear()
                            Comando.CommandType = CommandType.Text
                            Comando.CommandTimeout = _TiempoEjecucionSQL
                            Comando.ExecuteNonQuery()

                            Comando.CommandText = "select isnull(@@IDENTITY,0)"
                            Id = Convert.ToInt32(Comando.ExecuteScalar())
                        Catch oError As Exception
                            Throw oError
                        Finally
                            Comando.Dispose()

                            oCnx.Close()
                            oCnx.Dispose()
                        End Try
                    End Using
                End Using

                Return Id
            End Function

            Public Function EjecutarNonQueryRetornaId(ByVal strNombreSP As String, ByVal arr As Object(,)) As Integer
                Dim Id As Integer = 0
                Dim ConexionCadena As String = GetParValue()

                Using oCnx As New OleDbConnection(ConexionCadena)
                    Using Comando As New OleDbCommand(strNombreSP, oCnx)
                        oCnx.Open()

                        Try
                            Comando.Parameters.Clear()
                            Dim oPar As OleDbParameter

                            '#Region "Parametros"
                            For i As Integer = 0 To arr.Length \ 2 - 1

                                If arr(i, 1).ToString().Length >= 10 Then
                                    If arr(i, 1).ToString().Substring(0, 10) = "01/01/0001" Then
                                        arr(i, 1) = Date.Now
                                    End If
                                End If

                                oPar = New OleDbParameter(arr(i, 0).ToString(), arr(i, 1))
                                Comando.Parameters.Add(oPar)
                                oPar = Nothing
                            Next
                            '#End Region

                            Comando.CommandType = CommandType.StoredProcedure
                            Comando.CommandTimeout = _TiempoEjecucionSQL
                            Id = Convert.ToInt32(Comando.ExecuteScalar())
                        Catch oError As Exception
                            Throw oError
                        Finally
                            Comando.Dispose()

                            oCnx.Close()
                            oCnx.Dispose()
                        End Try
                    End Using
                End Using

                Return Id
            End Function

            Public Function EjecutarNonQueryRetornaId_Transaccion(ByVal SQL As String) As Integer
                SQL = SQL.Replace("''", "' '")

                Dim ConexionCadena As String = GetParValue()
                Dim Id As Integer = 0

                Using oCnx As New OleDbConnection(ConexionCadena)
                    Using Comando As New OleDbCommand(SQL, oCnx)
                        oCnx.Open()

                        'Abro la transaccion
                        Dim Transaccion As OleDbTransaction = oCnx.BeginTransaction()
                        Comando.Transaction = Transaccion

                        Try
                            Comando.Parameters.Clear()
                            Comando.CommandType = CommandType.Text
                            Comando.CommandTimeout = _TiempoEjecucionSQL
                            Comando.ExecuteNonQuery()

                            Comando.CommandText = "select isnull(@@IDENTITY,0)"
                            Id = Convert.ToInt32(Comando.ExecuteScalar())

                            'Confirma la transaccion
                            Transaccion.Commit()
                        Catch oError As Exception
                            'Vuelve atras la transaccion
                            Transaccion.Rollback()

                            Throw oError
                        Finally
                            Comando.Dispose()

                            oCnx.Close()
                            oCnx.Dispose()
                        End Try
                    End Using
                End Using

                Return Id
            End Function

            ''' <summary>
            ''' Ejecuta SP desde la presentación.
            ''' </summary>
            ''' <param name="strNombreSP">Nombre del SP</param>
            ''' <param name="arr">Array de Parametros de la forma {{"nombreParametro", valorParametro},{...,...},{...,...}}</param>
            ''' <returns>Retorna un DataTable con los resultados.</returns>
            Public Function DevolverDS(ByVal strNombreSP As String, ByVal arr As Object(,)) As DataSet
                Dim oDS As New DataSet()

                Dim ConexionCadena As String = GetParValue()

                Using oCnx As New OleDbConnection(ConexionCadena)
                    Using Comando As New OleDbCommand(strNombreSP, oCnx)
                        oCnx.Open()

                        Try
                            Comando.Parameters.Clear()
                            Dim oPar As OleDbParameter
                            Dim Adaptador As New OleDbDataAdapter()

                            '#Region "Parametros"
                            For i As Integer = 0 To arr.Length \ 2 - 1
                                oPar = New OleDbParameter(arr(i, 0).ToString(), arr(i, 1))
                                Comando.Parameters.Add(oPar)

                                oPar = Nothing
                            Next
                            '#End Region

                            Comando.CommandType = CommandType.StoredProcedure
                            Comando.CommandTimeout = _TiempoEjecucionSQL
                            Adaptador.SelectCommand = Comando

                            'Conexion.Open();
                            Adaptador.Fill(oDS, "Catalogo")

                            Adaptador.Dispose()
                        Catch oError As Exception
                            Throw oError
                        Finally
                            Comando.Dispose()

                            oCnx.Close()
                            oCnx.Dispose()
                        End Try
                    End Using
                End Using

                Return oDS

            End Function

            Public Function DevolverDS(ByVal Sql As String) As DataSet
                Dim oDS As New DataSet()

                Dim ConexionCadena As String = GetParValue()

                Using oCnx As New OleDbConnection(ConexionCadena)
                    Using Comando As New OleDbCommand(Sql, oCnx)
                        oCnx.Open()

                        Try
                            Comando.Parameters.Clear()
                            Dim Adaptador As New OleDbDataAdapter()
                            Comando.CommandType = CommandType.Text
                            Comando.CommandTimeout = _TiempoEjecucionSQL
                            Adaptador.SelectCommand = Comando

                            'Conexion.Open();
                            Adaptador.Fill(oDS, "Catalogo")

                            Adaptador.Dispose()
                        Catch oError As Exception
                            Throw oError
                        Finally
                            Comando.Dispose()

                            oCnx.Close()
                            oCnx.Dispose()
                        End Try
                    End Using
                End Using

                Return oDS

            End Function

            Public Function Obtener(ByVal Sql As String) As DataTable
                Dim oDT As New DataTable()

                Dim ConexionCadena As String = GetParValue()
                Using oCnx As New OleDbConnection(ConexionCadena)
                    Using Comando As New OleDbCommand(Sql, oCnx)
                        oCnx.Open()

                        Try
                            Comando.Parameters.Clear()
                            Comando.CommandType = CommandType.Text
                            Comando.CommandTimeout = _TiempoEjecucionSQL
                            Dim [oR] As OleDbDataReader = Comando.ExecuteReader()
                            oDT = DataReaderToDataTable([oR], Sql)

                            [oR] = Nothing
                        Catch oError As Exception
                            Throw oError
                        Finally
                            oCnx.Close()
                        End Try
                    End Using
                End Using

                Return oDT
            End Function

            Public Function Obtener(ByVal Tabla As DataTable) As String
                Dim Cadena As New StringBuilder()

                Try
                    Cadena.Append("")
                    For Each Fila As DataRow In Tabla.Rows
                        Cadena.Append(Convert.ToString(Fila(0)) & vbCr)
                    Next

                Catch oError As Exception
                    Throw oError
                End Try

                Return Cadena.ToString() & vbCr

            End Function

            Public Sub GenerarDbfMultasSuspensiones(ByVal Tabla As DataTable, ByVal rutaDestino As String, ByVal etapaLiquidacion As String)

                Dim directorioArchivo = rutaDestino
                'Dim path As String = rutaDestino
                Dim nombreArchivo As String = "PEMULPC.dbf"
                Dim formatoArchivo As String = ".dbf"
                Dim nombreArchivoConEtapa As String = "PEMULPC." + etapaLiquidacion

                ' Si no existe el directorio, lo creo
                If Not My.Computer.FileSystem.DirectoryExists(directorioArchivo) Then
                    My.Computer.FileSystem.CreateDirectory(directorioArchivo)
                End If

                'Dim myConnection As New System.Data.OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + directorioArchivo + ";Extended Properties=dBase III")
                Dim myConnection As New System.Data.OleDb.OleDbConnection(“Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + directorioArchivo + ";Extended Properties=dBase III")

                myConnection.Open()
                ''Si existe el archivo, lo borro
                If IO.File.Exists(directorioArchivo + "\" & nombreArchivoConEtapa) Then
                    'Dim myCommand As New System.Data.OleDb.OleDbCommand("drop table " & nombreArchivoConEtapa, myConnection)
                    'Dim comando1 As New OleDb.OleDbCommand()
                    'comando1.Connection = myConnection
                    'myCommand.ExecuteNonQuery()
                    My.Computer.FileSystem.DeleteFile(directorioArchivo + "\" + nombreArchivoConEtapa)
                End If

                'CREO LA TABLA DBF CON SU ESTRUCTURA
                Dim sql As String
                sql = "CREATE TABLE " + NombreArchivo + "(" +
                        "PLANTA Char(1), " +
                        "LUGAR char(5)," +
                        "HOJA char(2)," +
                        "CONTROL1 char(8)," +
                        "DIAS1 char(3)," +
                        "FECHA1 date," +
                        "MULTA1 char(1)," +
                        "CONTROL2 char(8)," +
                        "DIAS2 char(3)," +
                        "FECHA2 date," +
                        "MULTA2 char(1)," +
                        "CONTROL3 char(8)," +
                        "DIAS3 char(3)," +
                        "FECHA3 date," +
                        "MULTA3 char(1)," +
                        "CONTROL4 char(8)," +
                        "DIAS4 char(3)," +
                        "FECHA4 date," +
                        "MULTA4 char(1)," +
                        "TOTAL char(10)," +
                        "MARCA char(36)," +
                        "QUIEN char(4)," +
                        "CUANDO char(6)," +
                        "COMO char(1))"

                Dim myCommand1 As New System.Data.OleDb.OleDbCommand(sql, myConnection)
                Dim comando2 As New OleDb.OleDbCommand()
                comando2.Connection = myConnection
                myCommand1.ExecuteNonQuery()

                ' INSERTO LOS REGISTROS UNO A UNO EN LA TABLA
                Dim dt As Data.DataTable
                Dim dr As Data.DataRow
                Dim comando As New OleDb.OleDbCommand()

                dt = Tabla
                comando.CommandType = CommandType.Text
                comando.Connection = myConnection
                comando.CommandText = "INSERT INTO " & NombreArchivo & "
                    (PLANTA, LUGAR, HOJA, CONTROL1, DIAS1, FECHA1, MULTA1, CONTROL2, DIAS2, FECHA2, MULTA2, CONTROL3, DIAS3, FECHA3, MULTA3, CONTROL4, DIAS4, FECHA4, MULTA4, TOTAL, MARCA, QUIEN, CUANDO, COMO) 
                    VALUES (@PLANTA, @LUGAR, @HOJA, @CONTROL1, @DIAS1, @FECHA1, @MULTA1, @CONTROL2, @DIAS2, @FECHA2, @MULTA2, @CONTROL3, @DIAS3, @FECHA3, @MULTA3, @CONTROL4, @DIAS4, @FECHA4, @MULTA4, @TOTAL, @MARCA, @QUIEN, @CUANDO, @COMO)"

                For Each dr In dt.Rows

                    If (String.IsNullOrEmpty(dr.Item("PLANTA").ToString().Trim())) Then
                        comando.Parameters.Add("@PLANTA", SqlDbType.VarChar).Value = ""
                    Else
                        comando.Parameters.Add("@PLANTA", SqlDbType.VarChar).Value = dr.Item("PLANTA").ToString()
                    End If


                    If (String.IsNullOrEmpty(dr.Item("LUGAR").ToString().Trim())) Then

                        comando.Parameters.Add("@LUGAR", SqlDbType.VarChar).Value = ""
                    Else
                        comando.Parameters.Add("@LUGAR", SqlDbType.VarChar).Value = dr.Item("LUGAR").ToString()
                    End If


                    If (String.IsNullOrEmpty(dr.Item("HOJA").ToString().Trim())) Then

                        comando.Parameters.Add("@HOJA", SqlDbType.VarChar).Value = ""
                    Else
                        comando.Parameters.Add("@HOJA", SqlDbType.VarChar).Value = dr.Item("HOJA").ToString()
                    End If

                    If (String.IsNullOrEmpty(dr.Item("CONTROL1").ToString().Trim())) Then

                        comando.Parameters.Add("@CONTROL1", SqlDbType.VarChar).Value = ""
                    Else
                        comando.Parameters.Add("@CONTROL1", SqlDbType.VarChar).Value = dr.Item("CONTROL1").ToString()
                    End If

                    If (String.IsNullOrEmpty(dr.Item("DIAS1").ToString().Trim())) Then
                        comando.Parameters.Add("@CONTROL1", SqlDbType.VarChar).Value = ""
                    Else
                        If (Convert.ToInt32(dr.Item("DIAS1").ToString().Trim()) > 30) Then
                            comando.Parameters.Add("@DIAS1", SqlDbType.VarChar).Value = "030"
                        Else
                            comando.Parameters.Add("@DIAS1", SqlDbType.VarChar).Value = dr.Item("DIAS1").ToString()
                        End If
                    End If

                    comando.Parameters.Add("@FECHA1", SqlDbType.Date).Value = dr.Item("FECHA1")

                    If (String.IsNullOrEmpty(dr.Item("MULTA1").ToString().Trim())) Then

                        comando.Parameters.Add("@MULTA1", SqlDbType.VarChar).Value = ""
                    Else
                        comando.Parameters.Add("@MULTA1", SqlDbType.VarChar).Value = dr.Item("MULTA1").ToString()
                    End If


                    If (String.IsNullOrEmpty(dr.Item("CONTROL2").ToString().Trim())) Then

                        comando.Parameters.Add("@CONTROL2", SqlDbType.VarChar).Value = ""
                    Else
                        comando.Parameters.Add("@CONTROL2", SqlDbType.VarChar).Value = dr.Item("CONTROL2").ToString()
                    End If

                    If (String.IsNullOrEmpty(dr.Item("DIAS2").ToString().Trim())) Then

                        comando.Parameters.Add("@DIAS2", SqlDbType.VarChar).Value = ""
                    Else
                        comando.Parameters.Add("@DIAS2", SqlDbType.VarChar).Value = dr.Item("DIAS2").ToString()
                    End If

                    If (String.IsNullOrEmpty(dr.Item("FECHA2").ToString().Trim())) Then

                        comando.Parameters.Add("@FECHA2", SqlDbType.Date).Value = DBNull.Value
                    Else
                        comando.Parameters.Add("@FECHA2", SqlDbType.VarChar).Value = dr.Item("FECHA2").ToString()
                    End If

                    If (String.IsNullOrEmpty(dr.Item("MULTA2").ToString().Trim())) Then

                        comando.Parameters.Add("@MULTA2", SqlDbType.VarChar).Value = ""
                    Else
                        comando.Parameters.Add("@MULTA2", SqlDbType.VarChar).Value = dr.Item("MULTA2").ToString()
                    End If

                    If (String.IsNullOrEmpty(dr.Item("CONTROL3").ToString().Trim())) Then

                        comando.Parameters.Add("@CONTROL3", SqlDbType.VarChar).Value = ""
                    Else
                        comando.Parameters.Add("@CONTROL3", SqlDbType.VarChar).Value = dr.Item("CONTROL3").ToString()
                    End If

                    If (String.IsNullOrEmpty(dr.Item("DIAS3").ToString().Trim())) Then

                        comando.Parameters.Add("@DIAS3", SqlDbType.VarChar).Value = ""
                    Else
                        comando.Parameters.Add("@DIAS3", SqlDbType.VarChar).Value = dr.Item("DIAS3").ToString()
                    End If
                    '
                    If (String.IsNullOrEmpty(dr.Item("FECHA3").ToString().Trim())) Then

                        comando.Parameters.Add("@FECHA3", SqlDbType.Date).Value = DBNull.Value
                    Else
                        comando.Parameters.Add("@FECHA3", SqlDbType.VarChar).Value = dr.Item("FECHA3").ToString()
                    End If

                    If (String.IsNullOrEmpty(dr.Item("MULTA3").ToString().Trim())) Then

                        comando.Parameters.Add("@MULTA3", SqlDbType.VarChar).Value = ""
                    Else
                        comando.Parameters.Add("@MULTA3", SqlDbType.VarChar).Value = dr.Item("MULTA3").ToString()
                    End If

                    If (String.IsNullOrEmpty(dr.Item("CONTROL4").ToString().Trim())) Then

                        comando.Parameters.Add("@CONTROL4", SqlDbType.VarChar).Value = ""
                    Else
                        comando.Parameters.Add("@CONTROL4", SqlDbType.VarChar).Value = dr.Item("CONTROL4").ToString()
                    End If

                    If (String.IsNullOrEmpty(dr.Item("DIAS4").ToString().Trim())) Then

                        comando.Parameters.Add("@DIAS4", SqlDbType.VarChar).Value = ""
                    Else
                        comando.Parameters.Add("@DIAS4", SqlDbType.VarChar).Value = dr.Item("DIAS4").ToString()
                    End If


                    If (String.IsNullOrEmpty(dr.Item("FECHA4").ToString().Trim())) Then

                        comando.Parameters.Add("@FECHA4", SqlDbType.Date).Value = DBNull.Value
                    Else
                        comando.Parameters.Add("@FECHA4", SqlDbType.VarChar).Value = dr.Item("FECHA4").ToString()
                    End If


                    If (String.IsNullOrEmpty(dr.Item("MULTA4").ToString().Trim())) Then

                        comando.Parameters.Add("@MULTA4", SqlDbType.VarChar).Value = ""
                    Else
                        comando.Parameters.Add("@MULTA4", SqlDbType.VarChar).Value = dr.Item("MULTA4").ToString()
                    End If

                    If (String.IsNullOrEmpty(dr.Item("TOTAL").ToString().Trim())) Then

                        comando.Parameters.Add("@TOTAL", SqlDbType.VarChar).Value = ""
                    Else
                        comando.Parameters.Add("@TOTAL", SqlDbType.VarChar).Value = dr.Item("TOTAL").ToString()
                    End If

                    If (String.IsNullOrEmpty(dr.Item("MARCA").ToString().Trim())) Then

                        comando.Parameters.Add("@MARCA", SqlDbType.VarChar).Value = ""
                    Else
                        comando.Parameters.Add("@MARCA", SqlDbType.VarChar).Value = dr.Item("MARCA").ToString()
                    End If

                    If (String.IsNullOrEmpty(dr.Item("QUIEN").ToString().Trim())) Then

                        comando.Parameters.Add("@QUIEN", SqlDbType.VarChar).Value = ""
                    Else
                        comando.Parameters.Add("@QUIEN", SqlDbType.VarChar).Value = dr.Item("QUIEN").ToString()
                    End If

                    If (String.IsNullOrEmpty(dr.Item("CUANDO").ToString().Trim())) Then

                        comando.Parameters.Add("@CUANDO", SqlDbType.VarChar).Value = ""
                    Else
                        comando.Parameters.Add("@CUANDO", SqlDbType.VarChar).Value = dr.Item("CUANDO").ToString()
                    End If

                    If (String.IsNullOrEmpty(dr.Item("COMO").ToString().Trim())) Then

                        comando.Parameters.Add("@COMO", SqlDbType.VarChar).Value = ""
                    Else
                        comando.Parameters.Add("@COMO", SqlDbType.VarChar).Value = dr.Item("COMO").ToString()
                    End If

                    comando.ExecuteNonQuery()
                    comando.Parameters.Clear()
                Next dr
                My.Computer.FileSystem.RenameFile((directorioArchivo + "\" & nombreArchivo), nombreArchivoConEtapa)
                myConnection.Close()
            End Sub

            Public Sub GenerarDbfBajas(ByVal Tabla As DataTable, ByVal rutaDestino As String, ByVal etapaLiquidacion As String)

                Dim directorioArchivo = rutaDestino
                Dim NombreArchivo As String = "PEPERSPC.dbf"
                Dim formatoArchivo As String = ".dbf"
                Dim nombreArchivoConEtapa As String = "PEPERSPC." + etapaLiquidacion

                ' Si no existe el directorio, lo creo
                If Not My.Computer.FileSystem.DirectoryExists(directorioArchivo) Then
                    My.Computer.FileSystem.CreateDirectory(directorioArchivo)
                End If

                'Dim myConnection As New System.Data.OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + directorioArchivo + ";Extended Properties=dBase III")
                Dim myConnection As New System.Data.OleDb.OleDbConnection(“Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + directorioArchivo + ";Extended Properties=dBase III")

                myConnection.Open()
                ''Si existe el archivo, lo borro
                If IO.File.Exists(directorioArchivo + "\" & nombreArchivoConEtapa) Then
                    'Dim myCommand As New System.Data.OleDb.OleDbCommand("drop table " & nombreArchivoConEtapa, myConnection)
                    'Dim comando1 As New OleDb.OleDbCommand()
                    'comando1.Connection = myConnection
                    'myCommand.ExecuteNonQuery()
                    My.Computer.FileSystem.DeleteFile(directorioArchivo + "\" + nombreArchivoConEtapa)
                End If

                'CREO LA TABLA DBF CON SU ESTRUCTURA
                Dim sql As String
                sql = "CREATE TABLE " + NombreArchivo + "(" +
                        "PLANTA Char(1), " +
                        "HOJA char(5)," +
                        "NOVEDAD char(1)," +
                        "PROGRAMA char(4)," +
                        "SUBPROG char(4)," +
                        "ESCUELA char(5)," +
                        "LUGAR char(5)," +
                        "CUIL char(11)," +
                        "SEXO char(1)," +
                        "NUMIOSEP char(7)," +
                        "ACTIVIDAD char(3)," +
                        "CONTROL char(8)," +
                        "LEGAJO char(7)," +
                        "CARGO char(6)," +
                        "NOMBRE char(25)," +
                        "FECHANAC char(6)," +
                        "DOCUMENTO char(9)," +
                        "ANTREC char(3)," +
                        "FECHAING char(6)," +
                        "ESTADO char(1)," +
                        "IOSEP char(1)," +
                        "CAJAJUB char(1)," +
                        "BONIFIC char(27)," +
                        "OTROAPOR char(1)," +
                        "OSPLAD char(1)," +
                        "CAJACOMP char(1)," +
                        "HORAS char(2)," +
                        "JORNAL1 char(2)," +
                        "JORNAL2 char(3)," +
                        "MARCA char(50)," +
                        "QUIEN char(4)," +
                        "CUANDO char(6)," +
                        "COMO char(1))"

                Dim myCommand1 As New System.Data.OleDb.OleDbCommand(sql, myConnection)
                Dim comando2 As New OleDb.OleDbCommand()
                comando2.Connection = myConnection
                myCommand1.ExecuteNonQuery()

                ' INSERTO LOS REGISTROS UNO A UNO EN LA TABLA
                Dim dt As Data.DataTable
                Dim dr As Data.DataRow
                Dim comando As New OleDb.OleDbCommand()

                dt = Tabla
                comando.CommandType = CommandType.Text
                comando.Connection = myConnection
                comando.CommandText = "INSERT INTO " & NombreArchivo & "
                    (PLANTA, HOJA, NOVEDAD, PROGRAMA, SUBPROG, ESCUELA, LUGAR, CUIL, SEXO, NUMIOSEP, ACTIVIDAD, CONTROL, LEGAJO, CARGO, NOMBRE, FECHANAC, DOCUMENTO, ANTREC, FECHAING, ESTADO, IOSEP, CAJAJUB, BONIFIC, OTROAPOR, OSPLAD, CAJACOMP, HORAS, JORNAL1, JORNAL2, MARCA, QUIEN, CUANDO, COMO) 
                    VALUES (@PLANTA, @HOJA, @NOVEDAD, @PROGRAMA, @SUBPROG, @ESCUELA, @LUGAR, @CUIL, @SEXO, @NUMIOSEP, @ACTIVIDAD, @CONTROL, @LEGAJO, @CARGO, @NOMBRE, @FECHANAC, @DOCUMENTO, @ANTREC, @FECHAING, @ESTADO, @IOSEP, @CAJAJUB, @BONIFIC, @OTROAPOR, @OSPLAD, @CAJACOMP, @HORAS, @JORNAL1, @JORNAL2, @MARCA, @QUIEN, @CUANDO, @COMO)"

                For Each dr In dt.Rows

                    If (String.IsNullOrEmpty(dr.Item("PLANTA").ToString().Trim())) Then
                        comando.Parameters.Add("@PLANTA", SqlDbType.VarChar).Value = ""
                    Else
                        comando.Parameters.Add("@PLANTA", SqlDbType.VarChar).Value = dr.Item("PLANTA").ToString()
                    End If

                    If (String.IsNullOrEmpty(dr.Item("HOJA").ToString().Trim())) Then
                        comando.Parameters.Add("@HOJA", SqlDbType.VarChar).Value = ""
                    Else
                        comando.Parameters.Add("@HOJA", SqlDbType.VarChar).Value = dr.Item("HOJA").ToString()
                    End If

                    If (String.IsNullOrEmpty(dr.Item("NOVEDAD").ToString().Trim())) Then
                        comando.Parameters.Add("@NOVEDAD", SqlDbType.VarChar).Value = ""
                    Else
                        comando.Parameters.Add("@NOVEDAD", SqlDbType.VarChar).Value = dr.Item("NOVEDAD").ToString()
                    End If

                    If (String.IsNullOrEmpty(dr.Item("PROGRAMA").ToString().Trim())) Then
                        comando.Parameters.Add("@PROGRAMA", SqlDbType.VarChar).Value = ""
                    Else
                        comando.Parameters.Add("@PROGRAMA", SqlDbType.VarChar).Value = dr.Item("PROGRAMA").ToString()
                    End If

                    If (String.IsNullOrEmpty(dr.Item("SUBPROG").ToString().Trim())) Then
                        comando.Parameters.Add("@SUBPROG", SqlDbType.VarChar).Value = ""
                    Else
                        comando.Parameters.Add("@SUBPROG", SqlDbType.VarChar).Value = dr.Item("SUBPROG").ToString()
                    End If

                    If (String.IsNullOrEmpty(dr.Item("ESCUELA").ToString().Trim())) Then
                        comando.Parameters.Add("@ESCUELA", SqlDbType.VarChar).Value = ""
                    Else
                        comando.Parameters.Add("@ESCUELA", SqlDbType.VarChar).Value = dr.Item("ESCUELA").ToString()
                    End If

                    If (String.IsNullOrEmpty(dr.Item("LUGAR").ToString().Trim())) Then
                        comando.Parameters.Add("@LUGAR", SqlDbType.VarChar).Value = ""
                    Else
                        comando.Parameters.Add("@LUGAR", SqlDbType.VarChar).Value = dr.Item("LUGAR").ToString()
                    End If

                    If (String.IsNullOrEmpty(dr.Item("CUIL").ToString().Trim())) Then
                        comando.Parameters.Add("@CUIL", SqlDbType.VarChar).Value = ""
                    Else
                        comando.Parameters.Add("@CUIL", SqlDbType.VarChar).Value = dr.Item("CUIL").ToString()
                    End If

                    If (String.IsNullOrEmpty(dr.Item("SEXO").ToString().Trim())) Then
                        comando.Parameters.Add("@SEXO", SqlDbType.VarChar).Value = ""
                    Else
                        comando.Parameters.Add("@SEXO", SqlDbType.VarChar).Value = dr.Item("SEXO").ToString()
                    End If

                    If (String.IsNullOrEmpty(dr.Item("NUMIOSEP").ToString().Trim())) Then
                        comando.Parameters.Add("@NUMIOSEP", SqlDbType.VarChar).Value = ""
                    Else
                        comando.Parameters.Add("@NUMIOSEP", SqlDbType.VarChar).Value = dr.Item("NUMIOSEP").ToString()
                    End If

                    If (String.IsNullOrEmpty(dr.Item("ACTIVIDAD").ToString().Trim())) Then

                        comando.Parameters.Add("@ACTIVIDAD", SqlDbType.VarChar).Value = ""
                    Else
                        comando.Parameters.Add("@ACTIVIDAD", SqlDbType.VarChar).Value = dr.Item("ACTIVIDAD").ToString()
                    End If

                    If (String.IsNullOrEmpty(dr.Item("CONTROL").ToString().Trim())) Then
                        comando.Parameters.Add("@CONTROL", SqlDbType.VarChar).Value = ""
                    Else
                        comando.Parameters.Add("@CONTROL", SqlDbType.VarChar).Value = dr.Item("CONTROL").ToString()
                    End If

                    If (String.IsNullOrEmpty(dr.Item("LEGAJO").ToString().Trim())) Then
                        comando.Parameters.Add("@LEGAJO", SqlDbType.VarChar).Value = ""
                    Else
                        comando.Parameters.Add("@LEGAJO", SqlDbType.VarChar).Value = dr.Item("LEGAJO").ToString()
                    End If

                    If (String.IsNullOrEmpty(dr.Item("CARGO").ToString().Trim())) Then
                        comando.Parameters.Add("@CARGO", SqlDbType.VarChar).Value = ""
                    Else
                        comando.Parameters.Add("@CARGO", SqlDbType.VarChar).Value = dr.Item("CARGO").ToString()
                    End If

                    If (String.IsNullOrEmpty(dr.Item("NOMBRE").ToString().Trim())) Then
                        comando.Parameters.Add("@NOMBRE", SqlDbType.VarChar).Value = ""
                    Else
                        comando.Parameters.Add("@NOMBRE", SqlDbType.VarChar).Value = dr.Item("NOMBRE").ToString()
                    End If

                    If (String.IsNullOrEmpty(dr.Item("FECHANAC").ToString().Trim())) Then
                        comando.Parameters.Add("@FECHANAC", SqlDbType.VarChar).Value = ""
                    Else
                        comando.Parameters.Add("@FECHANAC", SqlDbType.VarChar).Value = dr.Item("FECHANAC").ToString()
                    End If

                    If (String.IsNullOrEmpty(dr.Item("DOCUMENTO").ToString().Trim())) Then
                        comando.Parameters.Add("@DOCUMENTO", SqlDbType.VarChar).Value = ""
                    Else
                        comando.Parameters.Add("@DOCUMENTO", SqlDbType.VarChar).Value = dr.Item("DOCUMENTO").ToString()
                    End If

                    If (String.IsNullOrEmpty(dr.Item("ANTREC").ToString().Trim())) Then
                        comando.Parameters.Add("@ANTREC", SqlDbType.VarChar).Value = ""
                    Else
                        comando.Parameters.Add("@ANTREC", SqlDbType.VarChar).Value = dr.Item("ANTREC").ToString()
                    End If

                    If (String.IsNullOrEmpty(dr.Item("FECHAING").ToString().Trim())) Then
                        comando.Parameters.Add("@FECHAING", SqlDbType.VarChar).Value = ""
                    Else
                        comando.Parameters.Add("@FECHAING", SqlDbType.VarChar).Value = dr.Item("FECHAING").ToString()
                    End If

                    If (String.IsNullOrEmpty(dr.Item("ESTADO").ToString().Trim())) Then
                        comando.Parameters.Add("@ESTADO", SqlDbType.VarChar).Value = ""
                    Else
                        comando.Parameters.Add("@ESTADO", SqlDbType.VarChar).Value = dr.Item("ESTADO").ToString()
                    End If

                    If (String.IsNullOrEmpty(dr.Item("IOSEP").ToString().Trim())) Then
                        comando.Parameters.Add("@IOSEP", SqlDbType.VarChar).Value = ""
                    Else
                        comando.Parameters.Add("@IOSEP", SqlDbType.VarChar).Value = dr.Item("IOSEP").ToString()
                    End If

                    If (String.IsNullOrEmpty(dr.Item("CAJAJUB").ToString().Trim())) Then
                        comando.Parameters.Add("@CAJAJUB", SqlDbType.VarChar).Value = ""
                    Else
                        comando.Parameters.Add("@CAJAJUB", SqlDbType.VarChar).Value = dr.Item("CAJAJUB").ToString()
                    End If

                    If (String.IsNullOrEmpty(dr.Item("BONIFIC").ToString().Trim())) Then
                        comando.Parameters.Add("@BONIFIC", SqlDbType.VarChar).Value = ""
                    Else
                        comando.Parameters.Add("@BONIFIC", SqlDbType.VarChar).Value = dr.Item("BONIFIC").ToString()
                    End If

                    If (String.IsNullOrEmpty(dr.Item("OTROAPOR").ToString().Trim())) Then
                        comando.Parameters.Add("@OTROAPOR", SqlDbType.VarChar).Value = ""
                    Else
                        comando.Parameters.Add("@OTROAPOR", SqlDbType.VarChar).Value = dr.Item("OTROAPOR").ToString()
                    End If

                    If (String.IsNullOrEmpty(dr.Item("OSPLAD").ToString().Trim())) Then
                        comando.Parameters.Add("@OSPLAD", SqlDbType.VarChar).Value = ""
                    Else
                        comando.Parameters.Add("@OSPLAD", SqlDbType.VarChar).Value = dr.Item("OSPLAD").ToString()
                    End If

                    If (String.IsNullOrEmpty(dr.Item("CAJACOMP").ToString().Trim())) Then
                        comando.Parameters.Add("@CAJACOMP", SqlDbType.VarChar).Value = ""
                    Else
                        comando.Parameters.Add("@CAJACOMP", SqlDbType.VarChar).Value = dr.Item("CAJACOMP").ToString()
                    End If

                    If (String.IsNullOrEmpty(dr.Item("HORAS").ToString().Trim())) Then
                        comando.Parameters.Add("@HORAS", SqlDbType.VarChar).Value = ""
                    Else
                        comando.Parameters.Add("@HORAS", SqlDbType.VarChar).Value = dr.Item("HORAS").ToString()
                    End If

                    If (String.IsNullOrEmpty(dr.Item("JORNAL1").ToString().Trim())) Then
                        comando.Parameters.Add("@JORNAL1", SqlDbType.VarChar).Value = ""
                    Else
                        comando.Parameters.Add("@JORNAL1", SqlDbType.VarChar).Value = dr.Item("JORNAL1").ToString()
                    End If

                    If (String.IsNullOrEmpty(dr.Item("JORNAL2").ToString().Trim())) Then
                        comando.Parameters.Add("@JORNAL2", SqlDbType.VarChar).Value = ""
                    Else
                        comando.Parameters.Add("@JORNAL2", SqlDbType.VarChar).Value = dr.Item("JORNAL2").ToString()
                    End If

                    If (String.IsNullOrEmpty(dr.Item("MARCA").ToString().Trim())) Then
                        comando.Parameters.Add("@MARCA", SqlDbType.VarChar).Value = ""
                    Else
                        comando.Parameters.Add("@MARCA", SqlDbType.VarChar).Value = dr.Item("MARCA").ToString()
                    End If

                    If (String.IsNullOrEmpty(dr.Item("QUIEN").ToString().Trim())) Then
                        comando.Parameters.Add("@QUIEN", SqlDbType.VarChar).Value = ""
                    Else
                        comando.Parameters.Add("@QUIEN", SqlDbType.VarChar).Value = dr.Item("QUIEN").ToString()
                    End If

                    If (String.IsNullOrEmpty(dr.Item("CUANDO").ToString().Trim())) Then
                        comando.Parameters.Add("@CUANDO", SqlDbType.VarChar).Value = ""
                    Else
                        comando.Parameters.Add("@CUANDO", SqlDbType.VarChar).Value = dr.Item("CUANDO").ToString()
                    End If

                    If (String.IsNullOrEmpty(dr.Item("COMO").ToString().Trim())) Then
                        comando.Parameters.Add("@COMO", SqlDbType.VarChar).Value = ""
                    Else
                        comando.Parameters.Add("@COMO", SqlDbType.VarChar).Value = dr.Item("COMO").ToString()
                    End If

                    comando.ExecuteNonQuery()
                    comando.Parameters.Clear()
                Next dr
                My.Computer.FileSystem.RenameFile((directorioArchivo + "\" & NombreArchivo), nombreArchivoConEtapa)
                myConnection.Close()
            End Sub

        End Class

        Public Class Utiles
            Private Shared Function Desencriptar(Cadena As String) As String
                Dim textDecrypt As String = String.Empty
                Try
                    'RijndaelManaged
                    Dim key As String = "Rdy/obTlKObAUKni/+R+EQ7O0H/vMP66Srsnrr7U9gY="
                    Dim algorithm As SymmetricAlgorithm = New RijndaelManaged()

                    algorithm.Key = Convert.FromBase64String(key)
                    algorithm.Mode = CipherMode.ECB

                    Dim decryptor As ICryptoTransform = algorithm.CreateDecryptor()

                    Dim data As Byte() = Convert.FromBase64String(Cadena)

                    Dim dataDecrypted As Byte() = decryptor.TransformFinalBlock(data, 0, data.Length)

                    textDecrypt = Encoding.Unicode.GetString(dataDecrypted)
                Catch oError As Exception
                    Throw oError
                End Try

                Return textDecrypt
            End Function

            Public Shared Function GetHash(ByVal Texto As String) As String
                Dim encoder As UnicodeEncoding = Nothing
                Dim sSHA512 As SHA512Managed = Nothing

                Try
                    encoder = New UnicodeEncoding()
                    sSHA512 = New SHA512Managed()
                Catch oError As Exception
                    Throw oError
                End Try

                Return Convert.ToBase64String(sSHA512.ComputeHash(encoder.GetBytes(Texto)))
            End Function
        End Class
    End Namespace
End Namespace
