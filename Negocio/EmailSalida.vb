Namespace LiquidacionSueldos
    Namespace Negocio
        Partial Public Class EmailSalida

            Private ocdGestor As New LiquidacionSueldos.Datos.Gestor
            Private Fila As DataTable
            Private Tabla As New DataTable

			Private _esaId As Integer
            Public Property esaId() As Integer
                Get
					Return _esaId
                End Get
                Set(ByVal value As Integer)
                    _esaId = value
                End Set
            End Property

			Private _esaFecha As Date
            Public Property esaFecha() As Date
                Get
					Return _esaFecha
                End Get
                Set(ByVal value As Date)
                    _esaFecha = value
                End Set
            End Property

			Private _esaPara As String
            Public Property esaPara() As String
                Get
					Return _esaPara
                End Get
                Set(ByVal value As String)
                    _esaPara = value
                End Set
            End Property

			Private _esaTipo As String
            Public Property esaTipo() As String
                Get
					Return _esaTipo
                End Get
                Set(ByVal value As String)
                    _esaTipo = value
                End Set
            End Property

			Private _esaTitulo As String
            Public Property esaTitulo() As String
                Get
					Return _esaTitulo
                End Get
                Set(ByVal value As String)
                    _esaTitulo = value
                End Set
            End Property

			Private _esaCuerpo As String
            Public Property esaCuerpo() As String
                Get
					Return _esaCuerpo
                End Get
                Set(ByVal value As String)
                    _esaCuerpo = value
                End Set
            End Property

			Private _esaDescripcion As String
            Public Property esaDescripcion() As String
                Get
					Return _esaDescripcion
                End Get
                Set(ByVal value As String)
                    _esaDescripcion = value
                End Set
            End Property

			Private _esaActivo As Boolean
            Public Property esaActivo() As Boolean
                Get
					Return _esaActivo
                End Get
                Set(ByVal value As Boolean)
                    _esaActivo = value
                End Set
            End Property

			Private _esaFechaHoraCreacion As Date
            Public Property esaFechaHoraCreacion() As Date
                Get
					Return _esaFechaHoraCreacion
                End Get
                Set(ByVal value As Date)
                    _esaFechaHoraCreacion = value
                End Set
            End Property

			Private _esaFechaHoraUltimaModificacion As Date
            Public Property esaFechaHoraUltimaModificacion() As Date
                Get
					Return _esaFechaHoraUltimaModificacion
                End Get
                Set(ByVal value As Date)
                    _esaFechaHoraUltimaModificacion = value
                End Set
            End Property

			Private _cuoId As Integer
            Public Property cuoId() As Integer
                Get
					Return _cuoId
                End Get
                Set(ByVal value As Integer)
                    _cuoId = value
                End Set
            End Property

			Private _usuIdCreacion As Integer
            Public Property usuIdCreacion() As Integer
                Get
					Return _usuIdCreacion
                End Get
                Set(ByVal value As Integer)
                    _usuIdCreacion = value
                End Set
            End Property

			Private _usuIdUltimaModificacion As Integer
            Public Property usuIdUltimaModificacion() As Integer
                Get
					Return _usuIdUltimaModificacion
                End Get
                Set(ByVal value As Integer)
                    _usuIdUltimaModificacion = value
                End Set
            End Property

			Public Sub New()
                Try                
                    Me.esaId = 0
				Catch ex As Exception
                    Throw ex
                End Try
            End Sub            

			Public Sub New(ByVal esaId As Integer)
				Try
                    Fila = New DataTable
                    Fila = ocdGestor.EjecutarReader("[EmailSalida.ObtenerUno]", New Object(,) {{"@esaId", esaId}})

					If Fila.Rows.Count > 0 Then
						If Fila(0)("esaId").ToString().Trim().Length > 0 Then
                            Me.esaId = Convert.ToInt32(Fila(0)("esaId"))
                        Else
                            Me.esaId = 0
                        End If
                        
						If Fila(0)("esaFecha").ToString().Trim().Length > 0 Then
                            Me.esaFecha = Convert.ToDateTime(Fila(0)("esaFecha"))
                        Else
                            Me.esaFecha = Date.Now
                        End If
                        
						If Fila(0)("esaPara").ToString().Trim().Length > 0 Then
                            Me.esaPara = Convert.ToString(Fila(0)("esaPara"))
                        Else
                            Me.esaPara = ""
                        End If
                        
						If Fila(0)("esaTipo").ToString().Trim().Length > 0 Then
                            Me.esaTipo = Convert.ToString(Fila(0)("esaTipo"))
                        Else
                            Me.esaTipo = ""
                        End If
                        
						If Fila(0)("esaTitulo").ToString().Trim().Length > 0 Then
                            Me.esaTitulo = Convert.ToString(Fila(0)("esaTitulo"))
                        Else
                            Me.esaTitulo = ""
                        End If
                        
						If Fila(0)("esaCuerpo").ToString().Trim().Length > 0 Then
                            Me.esaCuerpo = Convert.ToString(Fila(0)("esaCuerpo"))
                        Else
                            Me.esaCuerpo = ""
                        End If
                        
						If Fila(0)("esaDescripcion").ToString().Trim().Length > 0 Then
                            Me.esaDescripcion = Convert.ToString(Fila(0)("esaDescripcion"))
                        Else
                            Me.esaDescripcion = ""
                        End If
                        
						If Fila(0)("esaFechaHoraCreacion").ToString().Trim().Length > 0 Then
                            Me.esaFechaHoraCreacion = Convert.ToDateTime(Fila(0)("esaFechaHoraCreacion"))
                        Else
                            Me.esaFechaHoraCreacion = Date.Now
                        End If
                        
						If Fila(0)("esaFechaHoraUltimaModificacion").ToString().Trim().Length > 0 Then
                            Me.esaFechaHoraUltimaModificacion = Convert.ToDateTime(Fila(0)("esaFechaHoraUltimaModificacion"))
                        Else
                            Me.esaFechaHoraUltimaModificacion = Date.Now
                        End If
                        
						If Fila(0)("esaActivo").ToString().Trim().Length > 0 Then
                            Me.esaActivo = IIf(Convert.ToInt32(Fila(0)("esaActivo")) = 1, True, False)
                        Else
							Me.esaActivo = False
                        End If
                        
						If Fila(0)("cuoId").ToString().Trim().Length > 0 Then
                            Me.cuoId = Convert.ToInt32(Fila(0)("cuoId"))
                        Else
							Me.cuoId = 0
                        End If
                        
						If Fila(0)("usuIdCreacion").ToString().Trim().Length > 0 Then
                            Me.usuIdCreacion = Convert.ToInt32(Fila(0)("usuIdCreacion"))
                        Else
							Me.usuIdCreacion = 0
                        End If
                        
						If Fila(0)("usuIdUltimaModificacion").ToString().Trim().Length > 0 Then
                            Me.usuIdUltimaModificacion = Convert.ToInt32(Fila(0)("usuIdUltimaModificacion"))
                        Else
							Me.usuIdUltimaModificacion = 0
                        End If
                        
					End If
				Catch ex As Exception
                    Throw ex
                End Try
            End Sub

			Public Sub New(ByVal esaId As Integer, ByVal esaFecha As Date, ByVal esaPara As String, ByVal esaTipo As String, ByVal esaTitulo As String, ByVal esaCuerpo As String, ByVal esaDescripcion As String, ByVal esaActivo As Boolean, ByVal esaFechaHoraCreacion As Date, ByVal esaFechaHoraUltimaModificacion As Date, ByVal IcuoId As Integer, ByVal IusuIdCreacion As Integer, ByVal IusuIdUltimaModificacion As Integer)
				Try
					me.esaId = esaId
					me.esaFecha = esaFecha
					me.esaPara = esaPara
					me.esaTipo = esaTipo
					me.esaTitulo = esaTitulo
					me.esaCuerpo = esaCuerpo
					me.esaDescripcion = esaDescripcion
					me.esaActivo = esaActivo
					me.esaFechaHoraCreacion = esaFechaHoraCreacion
					me.esaFechaHoraUltimaModificacion = esaFechaHoraUltimaModificacion
					me.cuoId = cuoId
					me.usuIdCreacion = usuIdCreacion
					me.usuIdUltimaModificacion = usuIdUltimaModificacion
				Catch ex As Exception
                    Throw ex
                End Try
            End Sub

			
			Public Function ObtenerParametros() As DataTable
				ocdGestor = New Datos.Gestor
				Tabla = New DataTable

			    Try
					Tabla = ocdGestor.EjecutarReader("[EmailSalida.ObtenerParametros]", New Object(,) {})
				Catch ex As Exception
					Throw ex
				End Try
				
				Return Tabla
			End Function
			
			Public Function ObtenerTodo() As DataTable
				ocdGestor = New Datos.Gestor
				Tabla = New DataTable

			    Try
					Tabla = ocdGestor.EjecutarReader("[EmailSalida.ObtenerTodo]", New Object(,) {})
				Catch ex As Exception
					Throw ex
				End Try
				
				Return Tabla
			End Function
			
			Public Function ObtenerTodoCustom() As DataTable
				ocdGestor = New Datos.Gestor
				Tabla = New DataTable

			    Try
					Tabla = ocdGestor.EjecutarReader("[EmailSalida.ObtenerTodoCustom]", New Object(,) {})
				Catch ex As Exception
					Throw ex
				End Try
				
				Return Tabla
			End Function
			
			Public Function ObtenerUno(ByVal esaId as Integer) As DataTable
				ocdGestor = New Datos.Gestor
				Tabla = New DataTable

			    Try
					Tabla = ocdGestor.EjecutarReader("[EmailSalida.ObtenerUno]", New Object(,) {{"@esaId", esaId}})
				Catch ex As Exception
					Throw ex
				End Try
				
				Return Tabla
			End Function
			
			Public Function ObtenerValidarParametro() As DataTable
				ocdGestor = New Datos.Gestor
				Tabla = New DataTable

			    Try
					Tabla = ocdGestor.EjecutarReader("[EmailSalida.ObtenerValidarParametro]", New Object(,) {})
				Catch ex As Exception
					Throw ex
				End Try
				
				Return Tabla
			End Function
			
			Public Sub Actualizar(ByVal esaId as Integer, ByVal esaFecha as Date, ByVal esaPara as String, ByVal esaTipo as String, ByVal esaTitulo as String, ByVal esaCuerpo as String, ByVal esaDescripcion as String, ByVal cuoId as Integer, ByVal esaActivo as Boolean, ByVal usuIdCreacion as Integer, ByVal usuIdUltimaModificacion as Integer, ByVal esaFechaHoraCreacion as Date, ByVal esaFechaHoraUltimaModificacion as Date)
				Try
                    ocdGestor.EjecutarNonQuery("[EmailSalida.Actualizar]", New Object(,) {{"@esaId", esaId}, {"@esaFecha", esaFecha}, {"@esaPara", esaPara}, {"@esaTipo", esaTipo}, {"@esaTitulo", esaTitulo}, {"@esaCuerpo", esaCuerpo}, {"@esaDescripcion", esaDescripcion}, {"@cuoId", cuoId}, {"@esaActivo", esaActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@esaFechaHoraCreacion", esaFechaHoraCreacion}, {"@esaFechaHoraUltimaModificacion", esaFechaHoraUltimaModificacion}})
                Catch ex As Exception
                    Throw ex
                End Try
			End Sub
			
			Public Sub Eliminar(ByVal esaId as Integer)
				Try
                    ocdGestor.EjecutarNonQuery("[EmailSalida.Eliminar]", New Object(,) {{"@esaId", esaId}})
                Catch ex As Exception
                    Throw ex
                End Try
			End Sub
			
			Public Sub Generar(ByVal QueEnviar as String, ByVal Mes as Integer, ByVal Año as Integer, ByVal usuId as Integer)
				Try
                    ocdGestor.EjecutarNonQuery("[EmailSalida.Generar]", New Object(,) {{"@QueEnviar", QueEnviar}, {"@Mes", Mes}, {"@Año", Año}, {"@usuId", usuId}})
                Catch ex As Exception
                    Throw ex
                End Try
			End Sub
			
			Public Sub Insertar(ByVal esaFecha as Date, ByVal esaPara as String, ByVal esaTipo as String, ByVal esaTitulo as String, ByVal esaCuerpo as String, ByVal esaDescripcion as String, ByVal cuoId as Integer, ByVal esaActivo as Boolean, ByVal usuIdCreacion as Integer, ByVal usuIdUltimaModificacion as Integer, ByVal esaFechaHoraCreacion as Date, ByVal esaFechaHoraUltimaModificacion as Date)
				Try
                    ocdGestor.EjecutarNonQuery("[EmailSalida.Insertar]", New Object(,) {{"@esaFecha", esaFecha}, {"@esaPara", esaPara}, {"@esaTipo", esaTipo}, {"@esaTitulo", esaTitulo}, {"@esaCuerpo", esaCuerpo}, {"@esaDescripcion", esaDescripcion}, {"@cuoId", cuoId}, {"@esaActivo", esaActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@esaFechaHoraCreacion", esaFechaHoraCreacion}, {"@esaFechaHoraUltimaModificacion", esaFechaHoraUltimaModificacion}})
                Catch ex As Exception
                    Throw ex
                End Try
			End Sub
			
			Public Sub RegistrarEnvio(ByVal esaId as Integer)
				Try
                    ocdGestor.EjecutarNonQuery("[EmailSalida.RegistrarEnvio]", New Object(,) {{"@esaId", esaId}})
                Catch ex As Exception
                    Throw ex
                End Try
			End Sub
			
			Public Sub Actualizar()
                Try
                    If Me.esaId <> 0 Then
                        ocdGestor.EjecutarNonQuery("[EmailSalida.Actualizar]", New Object(,) {{"@esaId", esaId}, {"@esaFecha", esaFecha}, {"@esaPara", esaPara}, {"@esaTipo", esaTipo}, {"@esaTitulo", esaTitulo}, {"@esaCuerpo", esaCuerpo}, {"@esaDescripcion", esaDescripcion}, {"@cuoId", cuoId}, {"@esaActivo", esaActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@esaFechaHoraCreacion", esaFechaHoraCreacion}, {"@esaFechaHoraUltimaModificacion", esaFechaHoraUltimaModificacion}})
                    End If
                Catch ex As Exception
                    Throw ex
                End Try
            End Sub

			Public Sub Eliminar()
                Try
                    If Me.esaId <> 0 Then
                        ocdGestor.EjecutarNonQuery("[EmailSalida.Eliminar]", New Object(,) {{"@esaId", esaId}})
                    End If
                Catch ex As Exception
                    Throw ex
                End Try
            End Sub

			Public Function Insertar() as Integer
                Dim IdMax As Integer
                Try
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[EmailSalida.Insertar]", New Object(,) {{"@esaFecha", esaFecha}, {"@esaPara", esaPara}, {"@esaTipo", esaTipo}, {"@esaTitulo", esaTitulo}, {"@esaCuerpo", esaCuerpo}, {"@esaDescripcion", esaDescripcion}, {"@cuoId", cuoId}, {"@esaActivo", esaActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@esaFechaHoraCreacion", esaFechaHoraCreacion}, {"@esaFechaHoraUltimaModificacion", esaFechaHoraUltimaModificacion}})
                Catch ex As Exception
                    Throw ex
                End Try
                Return IdMax
            End Function

		End Class
    End Namespace
End Namespace