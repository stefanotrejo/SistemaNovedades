Namespace LiquidacionSueldos
    Namespace Negocio
        Partial Public Class Usuario
        
			Private ocdGestor As New LiquidacionSueldos.Datos.Gestor
            Private Fila As DataTable
            Private Tabla As New DataTable

			Private _usuId As Integer
            Public Property usuId() As Integer
                Get
					Return _usuId
                End Get
                Set(ByVal value As Integer)
                    _usuId = value
                End Set
            End Property

			Private _usuApellido As String
            Public Property usuApellido() As String
                Get
					Return _usuApellido
                End Get
                Set(ByVal value As String)
                    _usuApellido = value
                End Set
            End Property

			Private _usuNombre As String
            Public Property usuNombre() As String
                Get
					Return _usuNombre
                End Get
                Set(ByVal value As String)
                    _usuNombre = value
                End Set
            End Property

			Private _usuNombreIngreso As String
            Public Property usuNombreIngreso() As String
                Get
					Return _usuNombreIngreso
                End Get
                Set(ByVal value As String)
                    _usuNombreIngreso = value
                End Set
            End Property

			Private _usuClave As String
            Public Property usuClave() As String
                Get
					Return _usuClave
                End Get
                Set(ByVal value As String)
                    _usuClave = value
                End Set
            End Property

			Private _usuClaveProvisoria As String
            Public Property usuClaveProvisoria() As String
                Get
					Return _usuClaveProvisoria
                End Get
                Set(ByVal value As String)
                    _usuClaveProvisoria = value
                End Set
            End Property

			Private _usuCambiarClave As Boolean
            Public Property usuCambiarClave() As Boolean
                Get
					Return _usuCambiarClave
                End Get
                Set(ByVal value As Boolean)
                    _usuCambiarClave = value
                End Set
            End Property

			Private _usuEmail As String
            Public Property usuEmail() As String
                Get
					Return _usuEmail
                End Get
                Set(ByVal value As String)
                    _usuEmail = value
                End Set
            End Property

			Private _usuFechaHoraCreacion As Date
            Public Property usuFechaHoraCreacion() As Date
                Get
					Return _usuFechaHoraCreacion
                End Get
                Set(ByVal value As Date)
                    _usuFechaHoraCreacion = value
                End Set
            End Property

			Private _usuFechaHoraUltimaModificacion As Date
            Public Property usuFechaHoraUltimaModificacion() As Date
                Get
					Return _usuFechaHoraUltimaModificacion
                End Get
                Set(ByVal value As Date)
                    _usuFechaHoraUltimaModificacion = value
                End Set
            End Property

			Private _usuActivo As Boolean
            Public Property usuActivo() As Boolean
                Get
					Return _usuActivo
                End Get
                Set(ByVal value As Boolean)
                    _usuActivo = value
                End Set
            End Property

			Private _perId As Integer
            Public Property perId() As Integer
                Get
					Return _perId
                End Get
                Set(ByVal value As Integer)
                    _perId = value
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
                    Me.usuId = 0
				Catch ex As Exception
                    Throw ex
                End Try
            End Sub            

			Public Sub New(ByVal usuId As Integer)
				Try
                    Fila = New DataTable
                    Fila = ocdGestor.EjecutarReader("[Usuario.ObtenerUno]", New Object(,) {{"@usuId", usuId}})

					If Fila.Rows.Count > 0 Then
						If Fila(0)("usuId").ToString().Trim().Length > 0 Then
                            Me.usuId = Convert.ToInt32(Fila(0)("usuId"))
                        Else
                            Me.usuId = 0
                        End If
                        
						If Fila(0)("usuApellido").ToString().Trim().Length > 0 Then
                            Me.usuApellido = Convert.ToString(Fila(0)("usuApellido"))
                        Else
                            Me.usuApellido = ""
                        End If
                        
						If Fila(0)("usuNombre").ToString().Trim().Length > 0 Then
                            Me.usuNombre = Convert.ToString(Fila(0)("usuNombre"))
                        Else
                            Me.usuNombre = ""
                        End If
                        
						If Fila(0)("usuNombreIngreso").ToString().Trim().Length > 0 Then
                            Me.usuNombreIngreso = Convert.ToString(Fila(0)("usuNombreIngreso"))
                        Else
                            Me.usuNombreIngreso = ""
                        End If
                        
						If Fila(0)("usuClave").ToString().Trim().Length > 0 Then
                            Me.usuClave = Convert.ToString(Fila(0)("usuClave"))
                        Else
                            Me.usuClave = ""
                        End If
                        
						If Fila(0)("usuClaveProvisoria").ToString().Trim().Length > 0 Then
                            Me.usuClaveProvisoria = Convert.ToString(Fila(0)("usuClaveProvisoria"))
                        Else
                            Me.usuClaveProvisoria = ""
                        End If
                        
						If Fila(0)("usuEmail").ToString().Trim().Length > 0 Then
                            Me.usuEmail = Convert.ToString(Fila(0)("usuEmail"))
                        Else
                            Me.usuEmail = ""
                        End If
                        
						If Fila(0)("usuFechaHoraCreacion").ToString().Trim().Length > 0 Then
                            Me.usuFechaHoraCreacion = Convert.ToDateTime(Fila(0)("usuFechaHoraCreacion"))
                        Else
                            Me.usuFechaHoraCreacion = Date.Now
                        End If
                        
						If Fila(0)("usuFechaHoraUltimaModificacion").ToString().Trim().Length > 0 Then
                            Me.usuFechaHoraUltimaModificacion = Convert.ToDateTime(Fila(0)("usuFechaHoraUltimaModificacion"))
                        Else
                            Me.usuFechaHoraUltimaModificacion = Date.Now
                        End If
                        
						If Fila(0)("usuCambiarClave").ToString().Trim().Length > 0 Then
                            Me.usuCambiarClave = IIf(Convert.ToInt32(Fila(0)("usuCambiarClave")) = 1, True, False)
                        Else
							Me.usuCambiarClave = False
                        End If
                        
						If Fila(0)("usuActivo").ToString().Trim().Length > 0 Then
                            Me.usuActivo = IIf(Convert.ToInt32(Fila(0)("usuActivo")) = 1, True, False)
                        Else
							Me.usuActivo = False
                        End If
                        
						If Fila(0)("perId").ToString().Trim().Length > 0 Then
                            Me.perId = Convert.ToInt32(Fila(0)("perId"))
                        Else
							Me.perId = 0
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

			Public Sub New(ByVal usuId As Integer, ByVal usuApellido As String, ByVal usuNombre As String, ByVal usuNombreIngreso As String, ByVal usuClave As String, ByVal usuClaveProvisoria As String, ByVal usuCambiarClave As Boolean, ByVal usuEmail As String, ByVal usuFechaHoraCreacion As Date, ByVal usuFechaHoraUltimaModificacion As Date, ByVal usuActivo As Boolean, ByVal IperId As Integer, ByVal IusuIdCreacion As Integer, ByVal IusuIdUltimaModificacion As Integer)
				Try
					me.usuId = usuId
					me.usuApellido = usuApellido
					me.usuNombre = usuNombre
					me.usuNombreIngreso = usuNombreIngreso
					me.usuClave = usuClave
					me.usuClaveProvisoria = usuClaveProvisoria
					me.usuCambiarClave = usuCambiarClave
					me.usuEmail = usuEmail
					me.usuFechaHoraCreacion = usuFechaHoraCreacion
					me.usuFechaHoraUltimaModificacion = usuFechaHoraUltimaModificacion
					me.usuActivo = usuActivo
					me.perId = perId
					me.usuIdCreacion = usuIdCreacion
					me.usuIdUltimaModificacion = usuIdUltimaModificacion
				Catch ex As Exception
                    Throw ex
                End Try
            End Sub

			
			Public Function ObtenerAutenticar(ByVal usuNombreIngreso as String, ByVal usuClave as String) As DataTable
				ocdGestor = New Datos.Gestor
				Tabla = New DataTable

			    Try
					Tabla = ocdGestor.EjecutarReader("[Usuario.ObtenerAutenticar]", New Object(,) {{"@usuNombreIngreso", usuNombreIngreso}, {"@usuClave", usuClave}})
				Catch ex As Exception
					Throw ex
				End Try
				
				Return Tabla
			End Function
			
			Public Function ObtenerBuscador(ByVal ValorABuscar as String) As DataTable
				ocdGestor = New Datos.Gestor
				Tabla = New DataTable

			    Try
					Tabla = ocdGestor.EjecutarReader("[Usuario.ObtenerBuscador]", New Object(,) {{"@ValorABuscar", ValorABuscar}})
				Catch ex As Exception
					Throw ex
				End Try
				
				Return Tabla
			End Function
			
			Public Function ObtenerBuscadorCustomAlumnoDocente(ByVal ValorABuscar as String) As DataTable
				ocdGestor = New Datos.Gestor
				Tabla = New DataTable

			    Try
					Tabla = ocdGestor.EjecutarReader("[Usuario.ObtenerBuscadorCustomAlumnoDocente]", New Object(,) {{"@ValorABuscar", ValorABuscar}})
				Catch ex As Exception
					Throw ex
				End Try
				
				Return Tabla
			End Function
			
			Public Function ObtenerGrupo(ByVal usuId as Integer) As DataTable
				ocdGestor = New Datos.Gestor
				Tabla = New DataTable

			    Try
					Tabla = ocdGestor.EjecutarReader("[Usuario.ObtenerGrupo]", New Object(,) {{"@usuId", usuId}})
				Catch ex As Exception
					Throw ex
				End Try
				
				Return Tabla
			End Function
			
			Public Function ObtenerLista(ByVal PrimerItem as String) As DataTable
				ocdGestor = New Datos.Gestor
				Tabla = New DataTable

			    Try
					Tabla = ocdGestor.EjecutarReader("[Usuario.ObtenerLista]", New Object(,) {{"@PrimerItem", PrimerItem}})
				Catch ex As Exception
					Throw ex
				End Try
				
				Return Tabla
			End Function
			
			Public Function ObtenerListaCustom(ByVal PrimerItem as String) As DataTable
				ocdGestor = New Datos.Gestor
				Tabla = New DataTable

			    Try
					Tabla = ocdGestor.EjecutarReader("[Usuario.ObtenerListaCustom]", New Object(,) {{"@PrimerItem", PrimerItem}})
				Catch ex As Exception
					Throw ex
				End Try
				
				Return Tabla
			End Function
			
			Public Function ObtenerTodo() As DataTable
				ocdGestor = New Datos.Gestor
				Tabla = New DataTable

			    Try
					Tabla = ocdGestor.EjecutarReader("[Usuario.ObtenerTodo]", New Object(,) {})
				Catch ex As Exception
					Throw ex
				End Try
				
				Return Tabla
			End Function
			
			Public Function ObtenerTodoBuscarxNombre(ByVal Nombre as String) As DataTable
				ocdGestor = New Datos.Gestor
				Tabla = New DataTable

			    Try
					Tabla = ocdGestor.EjecutarReader("[Usuario.ObtenerTodoBuscarxNombre]", New Object(,) {{"@Nombre", Nombre}})
				Catch ex As Exception
					Throw ex
				End Try
				
				Return Tabla
			End Function

            Public Function ObtenerTodoCustom(ByVal Nombre As String, ByVal Apellido As String, ByVal Usuario As String, ByVal perId As Integer) As DataTable
                ocdGestor = New Datos.Gestor
                Tabla = New DataTable

                Try
                    Tabla = ocdGestor.EjecutarReader("[Usuario.ObtenerTodoCustom]", New Object(,) {{"@Nombre", Nombre}, {"@Apellido", Apellido}, {"@Usuario", Usuario}, {"@perId", perId}})
                Catch ex As Exception
                    Throw ex
                End Try

                Return Tabla
            End Function

            Public Function ObtenerUno(ByVal usuId as Integer) As DataTable
				ocdGestor = New Datos.Gestor
				Tabla = New DataTable

			    Try
					Tabla = ocdGestor.EjecutarReader("[Usuario.ObtenerUno]", New Object(,) {{"@usuId", usuId}})
				Catch ex As Exception
					Throw ex
				End Try
				
				Return Tabla
			End Function
			
			Public Function ObtenerUnoUsuarioEmail(ByVal Usuario as String, ByVal Email as String) As DataTable
				ocdGestor = New Datos.Gestor
				Tabla = New DataTable

			    Try
					Tabla = ocdGestor.EjecutarReader("[Usuario.ObtenerUnoUsuarioEmail]", New Object(,) {{"@Usuario", Usuario}, {"@Email", Email}})
				Catch ex As Exception
					Throw ex
				End Try
				
				Return Tabla
			End Function
			
			Public Function ObtenerValidarRepetido(ByVal usuId as Integer, ByVal usuNombre as String) As DataTable
				ocdGestor = New Datos.Gestor
				Tabla = New DataTable

			    Try
					Tabla = ocdGestor.EjecutarReader("[Usuario.ObtenerValidarRepetido]", New Object(,) {{"@usuId", usuId}, {"@usuNombre", usuNombre}})
				Catch ex As Exception
					Throw ex
				End Try
				
				Return Tabla
			End Function
			
			Public Function ObtenerValidarSiExisteEmail(ByVal Usuario as String, ByVal Email as String) As DataTable
				ocdGestor = New Datos.Gestor
				Tabla = New DataTable

			    Try
					Tabla = ocdGestor.EjecutarReader("[Usuario.ObtenerValidarSiExisteEmail]", New Object(,) {{"@Usuario", Usuario}, {"@Email", Email}})
				Catch ex As Exception
					Throw ex
				End Try
				
				Return Tabla
			End Function
			
			Public Sub ActivarInactivar(ByVal usuId as Integer)
				Try
                    ocdGestor.EjecutarNonQuery("[Usuario.ActivarInactivar]", New Object(,) {{"@usuId", usuId}})
                Catch ex As Exception
                    Throw ex
                End Try
			End Sub
			
			Public Sub Actualizar(ByVal usuId as Integer, ByVal usuApellido as String, ByVal usuNombre as String, ByVal usuNombreIngreso as String, ByVal usuClave as String, ByVal usuClaveProvisoria as String, ByVal usuCambiarClave as Boolean, ByVal usuEmail as String, ByVal perId as Integer, ByVal usuIdCreacion as Integer, ByVal usuIdUltimaModificacion as Integer, ByVal usuFechaHoraCreacion as Date, ByVal usuFechaHoraUltimaModificacion as Date, ByVal usuActivo as Boolean)
				Try
                    ocdGestor.EjecutarNonQuery("[Usuario.Actualizar]", New Object(,) {{"@usuId", usuId}, {"@usuApellido", usuApellido}, {"@usuNombre", usuNombre}, {"@usuNombreIngreso", usuNombreIngreso}, {"@usuClave", usuClave}, {"@usuClaveProvisoria", usuClaveProvisoria}, {"@usuCambiarClave", usuCambiarClave}, {"@usuEmail", usuEmail}, {"@perId", perId}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@usuFechaHoraCreacion", usuFechaHoraCreacion}, {"@usuFechaHoraUltimaModificacion", usuFechaHoraUltimaModificacion}, {"@usuActivo", usuActivo}})
                Catch ex As Exception
                    Throw ex
                End Try
			End Sub
			
			Public Sub BlanquearClave(ByVal usuId as Integer)
				Try
                    ocdGestor.EjecutarNonQuery("[Usuario.BlanquearClave]", New Object(,) {{"@usuId", usuId}})
                Catch ex As Exception
                    Throw ex
                End Try
			End Sub
			
			Public Sub BlanquearClaveUsuarioEmail(ByVal Usuario as String, ByVal Email as String)
				Try
                    ocdGestor.EjecutarNonQuery("[Usuario.BlanquearClaveUsuarioEmail]", New Object(,) {{"@Usuario", Usuario}, {"@Email", Email}})
                Catch ex As Exception
                    Throw ex
                End Try
			End Sub
			
			Public Sub CambiarClave(ByVal usuId as Integer, ByVal usuClave as String)
				Try
                    ocdGestor.EjecutarNonQuery("[Usuario.CambiarClave]", New Object(,) {{"@usuId", usuId}, {"@usuClave", usuClave}})
                Catch ex As Exception
                    Throw ex
                End Try
			End Sub
			
			Public Sub Copiar(ByVal usuApellido as String, ByVal usuNombre as String, ByVal usuNombreIngreso as String, ByVal usuClave as String, ByVal usuClaveProvisoria as String, ByVal usuCambiarClave as Boolean, ByVal usuEmail as String, ByVal perId as Integer, ByVal usuIdCreacion as Integer, ByVal usuIdUltimaModificacion as Integer, ByVal usuFechaHoraCreacion as Date, ByVal usuFechaHoraUltimaModificacion as Date, ByVal usuActivo as Boolean)
				Try
                    ocdGestor.EjecutarNonQuery("[Usuario.Copiar]", New Object(,) {{"@usuApellido", usuApellido}, {"@usuNombre", usuNombre}, {"@usuNombreIngreso", usuNombreIngreso}, {"@usuClave", usuClave}, {"@usuClaveProvisoria", usuClaveProvisoria}, {"@usuCambiarClave", usuCambiarClave}, {"@usuEmail", usuEmail}, {"@perId", perId}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@usuFechaHoraCreacion", usuFechaHoraCreacion}, {"@usuFechaHoraUltimaModificacion", usuFechaHoraUltimaModificacion}, {"@usuActivo", usuActivo}})
                Catch ex As Exception
                    Throw ex
                End Try
			End Sub
			
			Public Sub Eliminar(ByVal usuId as Integer)
				Try
                    ocdGestor.EjecutarNonQuery("[Usuario.Eliminar]", New Object(,) {{"@usuId", usuId}})
                Catch ex As Exception
                    Throw ex
                End Try
			End Sub
			
			Public Sub Insertar(ByVal usuApellido as String, ByVal usuNombre as String, ByVal usuNombreIngreso as String, ByVal usuClave as String, ByVal usuClaveProvisoria as String, ByVal usuCambiarClave as Boolean, ByVal usuEmail as String, ByVal perId as Integer, ByVal usuIdCreacion as Integer, ByVal usuIdUltimaModificacion as Integer, ByVal usuFechaHoraCreacion as Date, ByVal usuFechaHoraUltimaModificacion as Date, ByVal usuActivo as Boolean)
				Try
                    ocdGestor.EjecutarNonQuery("[Usuario.Insertar]", New Object(,) {{"@usuApellido", usuApellido}, {"@usuNombre", usuNombre}, {"@usuNombreIngreso", usuNombreIngreso}, {"@usuClave", usuClave}, {"@usuClaveProvisoria", usuClaveProvisoria}, {"@usuCambiarClave", usuCambiarClave}, {"@usuEmail", usuEmail}, {"@perId", perId}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@usuFechaHoraCreacion", usuFechaHoraCreacion}, {"@usuFechaHoraUltimaModificacion", usuFechaHoraUltimaModificacion}, {"@usuActivo", usuActivo}})
                Catch ex As Exception
                    Throw ex
                End Try
			End Sub
			
			Public Sub Actualizar()
                Try
                    If Me.usuId <> 0 Then
                        ocdGestor.EjecutarNonQuery("[Usuario.Actualizar]", New Object(,) {{"@usuId", usuId}, {"@usuApellido", usuApellido}, {"@usuNombre", usuNombre}, {"@usuNombreIngreso", usuNombreIngreso}, {"@usuClave", usuClave}, {"@usuClaveProvisoria", usuClaveProvisoria}, {"@usuCambiarClave", usuCambiarClave}, {"@usuEmail", usuEmail}, {"@perId", perId}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@usuFechaHoraCreacion", usuFechaHoraCreacion}, {"@usuFechaHoraUltimaModificacion", usuFechaHoraUltimaModificacion}, {"@usuActivo", usuActivo}})
                    End If
                Catch ex As Exception
                    Throw ex
                End Try
            End Sub

			Public Sub Copiar()
                Try
                    If Me.usuId <> 0 Then
                        ocdGestor.EjecutarNonQuery("[Usuario.Copiar]", New Object(,) {{"@usuApellido", usuApellido}, {"@usuNombre", usuNombre}, {"@usuNombreIngreso", usuNombreIngreso}, {"@usuClave", usuClave}, {"@usuClaveProvisoria", usuClaveProvisoria}, {"@usuCambiarClave", usuCambiarClave}, {"@usuEmail", usuEmail}, {"@perId", perId}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@usuFechaHoraCreacion", usuFechaHoraCreacion}, {"@usuFechaHoraUltimaModificacion", usuFechaHoraUltimaModificacion}, {"@usuActivo", usuActivo}})
                    End If
                Catch ex As Exception
                    Throw ex
                End Try
            End Sub

			Public Sub Eliminar()
                Try
                    If Me.usuId <> 0 Then
                        ocdGestor.EjecutarNonQuery("[Usuario.Eliminar]", New Object(,) {{"@usuId", usuId}})
                    End If
                Catch ex As Exception
                    Throw ex
                End Try
            End Sub

			Public Function Insertar() as Integer
                Dim IdMax As Integer
                Try
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[Usuario.Insertar]", New Object(,) {{"@usuApellido", usuApellido}, {"@usuNombre", usuNombre}, {"@usuNombreIngreso", usuNombreIngreso}, {"@usuClave", usuClave}, {"@usuClaveProvisoria", usuClaveProvisoria}, {"@usuCambiarClave", usuCambiarClave}, {"@usuEmail", usuEmail}, {"@perId", perId}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@usuFechaHoraCreacion", usuFechaHoraCreacion}, {"@usuFechaHoraUltimaModificacion", usuFechaHoraUltimaModificacion}, {"@usuActivo", usuActivo}})
                Catch ex As Exception
                    Throw ex
                End Try
                Return IdMax
            End Function

		End Class
    End Namespace
End Namespace