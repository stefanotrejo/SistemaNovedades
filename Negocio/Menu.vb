Namespace LiquidacionSueldos
    Namespace Negocio
        Partial Public Class Menu
        
			Private ocdGestor As New LiquidacionSueldos.Datos.Gestor
            Private Fila As DataTable
            Private Tabla As New DataTable

			Private _menId As Integer
            Public Property menId() As Integer
                Get
					Return _menId
                End Get
                Set(ByVal value As Integer)
                    _menId = value
                End Set
            End Property

			Private _menNombre As String
            Public Property menNombre() As String
                Get
					Return _menNombre
                End Get
                Set(ByVal value As String)
                    _menNombre = value
                End Set
            End Property

			Private _menOrden As Integer
            Public Property menOrden() As Integer
                Get
					Return _menOrden
                End Get
                Set(ByVal value As Integer)
                    _menOrden = value
                End Set
            End Property

			Private _menUrl As String
            Public Property menUrl() As String
                Get
					Return _menUrl
                End Get
                Set(ByVal value As String)
                    _menUrl = value
                End Set
            End Property

			Private _menIcono As String
            Public Property menIcono() As String
                Get
					Return _menIcono
                End Get
                Set(ByVal value As String)
                    _menIcono = value
                End Set
            End Property

			Private _menEsMenu As Boolean
            Public Property menEsMenu() As Boolean
                Get
					Return _menEsMenu
                End Get
                Set(ByVal value As Boolean)
                    _menEsMenu = value
                End Set
            End Property

			Private _menActivo As Boolean
            Public Property menActivo() As Boolean
                Get
					Return _menActivo
                End Get
                Set(ByVal value As Boolean)
                    _menActivo = value
                End Set
            End Property

			Private _menFechaHoraCreacion As Date
            Public Property menFechaHoraCreacion() As Date
                Get
					Return _menFechaHoraCreacion
                End Get
                Set(ByVal value As Date)
                    _menFechaHoraCreacion = value
                End Set
            End Property

			Private _menFechaHoraUltimaModificacion As Date
            Public Property menFechaHoraUltimaModificacion() As Date
                Get
					Return _menFechaHoraUltimaModificacion
                End Get
                Set(ByVal value As Date)
                    _menFechaHoraUltimaModificacion = value
                End Set
            End Property

			Private _menIdPadre As Integer
            Public Property menIdPadre() As Integer
                Get
					Return _menIdPadre
                End Get
                Set(ByVal value As Integer)
                    _menIdPadre = value
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
                    Me.menId = 0
				Catch ex As Exception
                    Throw ex
                End Try
            End Sub            

			Public Sub New(ByVal menId As Integer)
				Try
                    Fila = New DataTable
                    Fila = ocdGestor.EjecutarReader("[Menu.ObtenerUno]", New Object(,) {{"@menId", menId}})

					If Fila.Rows.Count > 0 Then
						If Fila(0)("menId").ToString().Trim().Length > 0 Then
                            Me.menId = Convert.ToInt32(Fila(0)("menId"))
                        Else
                            Me.menId = 0
                        End If
                        
						If Fila(0)("menNombre").ToString().Trim().Length > 0 Then
                            Me.menNombre = Convert.ToString(Fila(0)("menNombre"))
                        Else
                            Me.menNombre = ""
                        End If
                        
						If Fila(0)("menOrden").ToString().Trim().Length > 0 Then
                            Me.menOrden = Convert.ToInt32(Fila(0)("menOrden"))
                        Else
                            Me.menOrden = 0
                        End If
                        
						If Fila(0)("menUrl").ToString().Trim().Length > 0 Then
                            Me.menUrl = Convert.ToString(Fila(0)("menUrl"))
                        Else
                            Me.menUrl = ""
                        End If
                        
						If Fila(0)("menIcono").ToString().Trim().Length > 0 Then
                            Me.menIcono = Convert.ToString(Fila(0)("menIcono"))
                        Else
                            Me.menIcono = ""
                        End If
                        
						If Fila(0)("menFechaHoraCreacion").ToString().Trim().Length > 0 Then
                            Me.menFechaHoraCreacion = Convert.ToDateTime(Fila(0)("menFechaHoraCreacion"))
                        Else
                            Me.menFechaHoraCreacion = Date.Now
                        End If
                        
						If Fila(0)("menFechaHoraUltimaModificacion").ToString().Trim().Length > 0 Then
                            Me.menFechaHoraUltimaModificacion = Convert.ToDateTime(Fila(0)("menFechaHoraUltimaModificacion"))
                        Else
                            Me.menFechaHoraUltimaModificacion = Date.Now
                        End If
                        
						If Fila(0)("menEsMenu").ToString().Trim().Length > 0 Then
                            Me.menEsMenu = IIf(Convert.ToInt32(Fila(0)("menEsMenu")) = 1, True, False)
                        Else
							Me.menEsMenu = False
                        End If
                        
						If Fila(0)("menActivo").ToString().Trim().Length > 0 Then
                            Me.menActivo = IIf(Convert.ToInt32(Fila(0)("menActivo")) = 1, True, False)
                        Else
							Me.menActivo = False
                        End If
                        
						If Fila(0)("menIdPadre").ToString().Trim().Length > 0 Then
                            Me.menIdPadre = Convert.ToInt32(Fila(0)("menIdPadre"))
                        Else
							Me.menIdPadre = 0
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

			Public Sub New(ByVal menId As Integer, ByVal menNombre As String, ByVal menOrden As Integer, ByVal menUrl As String, ByVal menIcono As String, ByVal menEsMenu As Boolean, ByVal menActivo As Boolean, ByVal menFechaHoraCreacion As Date, ByVal menFechaHoraUltimaModificacion As Date, ByVal ImenIdPadre As Integer, ByVal IusuIdCreacion As Integer, ByVal IusuIdUltimaModificacion As Integer)
				Try
					me.menId = menId
					me.menNombre = menNombre
					me.menOrden = menOrden
					me.menUrl = menUrl
					me.menIcono = menIcono
					me.menEsMenu = menEsMenu
					me.menActivo = menActivo
					me.menFechaHoraCreacion = menFechaHoraCreacion
					me.menFechaHoraUltimaModificacion = menFechaHoraUltimaModificacion
					me.menIdPadre = menIdPadre
					me.usuIdCreacion = usuIdCreacion
					me.usuIdUltimaModificacion = usuIdUltimaModificacion
				Catch ex As Exception
                    Throw ex
                End Try
            End Sub

			
			Public Function ObtenerBuscador(ByVal ValorABuscar as String) As DataTable
				ocdGestor = New Datos.Gestor
				Tabla = New DataTable

			    Try
					Tabla = ocdGestor.EjecutarReader("[Menu.ObtenerBuscador]", New Object(,) {{"@ValorABuscar", ValorABuscar}})
				Catch ex As Exception
					Throw ex
				End Try
				
				Return Tabla
			End Function
			
			Public Function ObtenerLista(ByVal PrimerItem as String) As DataTable
				ocdGestor = New Datos.Gestor
				Tabla = New DataTable

			    Try
					Tabla = ocdGestor.EjecutarReader("[Menu.ObtenerLista]", New Object(,) {{"@PrimerItem", PrimerItem}})
				Catch ex As Exception
					Throw ex
				End Try
				
				Return Tabla
			End Function
			
			Public Function ObtenerListaAsociarACustom(ByVal perId as Integer) As DataTable
				ocdGestor = New Datos.Gestor
				Tabla = New DataTable

			    Try
					Tabla = ocdGestor.EjecutarReader("[Menu.ObtenerListaAsociarACustom]", New Object(,) {{"@perId", perId}})
				Catch ex As Exception
					Throw ex
				End Try
				
				Return Tabla
			End Function
			
			Public Function ObtenerListaRaiz(ByVal PrimerItem as String) As DataTable
				ocdGestor = New Datos.Gestor
				Tabla = New DataTable

			    Try
					Tabla = ocdGestor.EjecutarReader("[Menu.ObtenerListaRaiz]", New Object(,) {{"@PrimerItem", PrimerItem}})
				Catch ex As Exception
					Throw ex
				End Try
				
				Return Tabla
			End Function
			
			Public Function ObtenerMenuSecundario(ByVal menIdPadre as Integer) As DataTable
				ocdGestor = New Datos.Gestor
				Tabla = New DataTable

			    Try
					Tabla = ocdGestor.EjecutarReader("[Menu.ObtenerMenuSecundario]", New Object(,) {{"@menIdPadre", menIdPadre}})
				Catch ex As Exception
					Throw ex
				End Try
				
				Return Tabla
			End Function
			
			Public Function ObtenerTodo() As DataTable
				ocdGestor = New Datos.Gestor
				Tabla = New DataTable

			    Try
					Tabla = ocdGestor.EjecutarReader("[Menu.ObtenerTodo]", New Object(,) {})
				Catch ex As Exception
					Throw ex
				End Try
				
				Return Tabla
			End Function
			
			Public Function ObtenerTodoBuscarxNombre(ByVal Nombre as String) As DataTable
				ocdGestor = New Datos.Gestor
				Tabla = New DataTable

			    Try
					Tabla = ocdGestor.EjecutarReader("[Menu.ObtenerTodoBuscarxNombre]", New Object(,) {{"@Nombre", Nombre}})
				Catch ex As Exception
					Throw ex
				End Try
				
				Return Tabla
			End Function
			
			Public Function ObtenerUno(ByVal menId as Integer) As DataTable
				ocdGestor = New Datos.Gestor
				Tabla = New DataTable

			    Try
					Tabla = ocdGestor.EjecutarReader("[Menu.ObtenerUno]", New Object(,) {{"@menId", menId}})
				Catch ex As Exception
					Throw ex
				End Try
				
				Return Tabla
			End Function
			
			Public Function ObtenerValidarRepetido(ByVal menId as Integer, ByVal menNombre as String) As DataTable
				ocdGestor = New Datos.Gestor
				Tabla = New DataTable

			    Try
					Tabla = ocdGestor.EjecutarReader("[Menu.ObtenerValidarRepetido]", New Object(,) {{"@menId", menId}, {"@menNombre", menNombre}})
				Catch ex As Exception
					Throw ex
				End Try
				
				Return Tabla
			End Function
			
			Public Sub ActivarInactivar(ByVal menId as Integer)
				Try
                    ocdGestor.EjecutarNonQuery("[Menu.ActivarInactivar]", New Object(,) {{"@menId", menId}})
                Catch ex As Exception
                    Throw ex
                End Try
			End Sub
			
			Public Sub Actualizar(ByVal menId as Integer, ByVal menNombre as String, ByVal menIdPadre as Integer, ByVal menOrden as Integer, ByVal menUrl as String, ByVal menIcono as String, ByVal menEsMenu as Boolean, ByVal menActivo as Boolean, ByVal usuIdCreacion as Integer, ByVal usuIdUltimaModificacion as Integer, ByVal menFechaHoraCreacion as Date, ByVal menFechaHoraUltimaModificacion as Date)
				Try
                    ocdGestor.EjecutarNonQuery("[Menu.Actualizar]", New Object(,) {{"@menId", menId}, {"@menNombre", menNombre}, {"@menIdPadre", menIdPadre}, {"@menOrden", menOrden}, {"@menUrl", menUrl}, {"@menIcono", menIcono}, {"@menEsMenu", menEsMenu}, {"@menActivo", menActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@menFechaHoraCreacion", menFechaHoraCreacion}, {"@menFechaHoraUltimaModificacion", menFechaHoraUltimaModificacion}})
                Catch ex As Exception
                    Throw ex
                End Try
			End Sub
			
			Public Sub Copiar(ByVal menNombre as String, ByVal menIdPadre as Integer, ByVal menOrden as Integer, ByVal menUrl as String, ByVal menIcono as String, ByVal menEsMenu as Boolean, ByVal menActivo as Boolean, ByVal usuIdCreacion as Integer, ByVal usuIdUltimaModificacion as Integer, ByVal menFechaHoraCreacion as Date, ByVal menFechaHoraUltimaModificacion as Date)
				Try
                    ocdGestor.EjecutarNonQuery("[Menu.Copiar]", New Object(,) {{"@menNombre", menNombre}, {"@menIdPadre", menIdPadre}, {"@menOrden", menOrden}, {"@menUrl", menUrl}, {"@menIcono", menIcono}, {"@menEsMenu", menEsMenu}, {"@menActivo", menActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@menFechaHoraCreacion", menFechaHoraCreacion}, {"@menFechaHoraUltimaModificacion", menFechaHoraUltimaModificacion}})
                Catch ex As Exception
                    Throw ex
                End Try
			End Sub
			
			Public Sub Eliminar(ByVal menId as Integer)
				Try
                    ocdGestor.EjecutarNonQuery("[Menu.Eliminar]", New Object(,) {{"@menId", menId}})
                Catch ex As Exception
                    Throw ex
                End Try
			End Sub
			
			Public Sub EliminarCustom(ByVal menId as Integer)
				Try
                    ocdGestor.EjecutarNonQuery("[Menu.EliminarCustom]", New Object(,) {{"@menId", menId}})
                Catch ex As Exception
                    Throw ex
                End Try
			End Sub
			
			Public Sub Insertar(ByVal menNombre as String, ByVal menIdPadre as Integer, ByVal menOrden as Integer, ByVal menUrl as String, ByVal menIcono as String, ByVal menEsMenu as Boolean, ByVal menActivo as Boolean, ByVal usuIdCreacion as Integer, ByVal usuIdUltimaModificacion as Integer, ByVal menFechaHoraCreacion as Date, ByVal menFechaHoraUltimaModificacion as Date)
				Try
                    ocdGestor.EjecutarNonQuery("[Menu.Insertar]", New Object(,) {{"@menNombre", menNombre}, {"@menIdPadre", menIdPadre}, {"@menOrden", menOrden}, {"@menUrl", menUrl}, {"@menIcono", menIcono}, {"@menEsMenu", menEsMenu}, {"@menActivo", menActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@menFechaHoraCreacion", menFechaHoraCreacion}, {"@menFechaHoraUltimaModificacion", menFechaHoraUltimaModificacion}})
                Catch ex As Exception
                    Throw ex
                End Try
			End Sub
			
			Public Sub Actualizar()
                Try
                    If Me.menId <> 0 Then
                        ocdGestor.EjecutarNonQuery("[Menu.Actualizar]", New Object(,) {{"@menId", menId}, {"@menNombre", menNombre}, {"@menIdPadre", menIdPadre}, {"@menOrden", menOrden}, {"@menUrl", menUrl}, {"@menIcono", menIcono}, {"@menEsMenu", menEsMenu}, {"@menActivo", menActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@menFechaHoraCreacion", menFechaHoraCreacion}, {"@menFechaHoraUltimaModificacion", menFechaHoraUltimaModificacion}})
                    End If
                Catch ex As Exception
                    Throw ex
                End Try
            End Sub

			Public Sub Copiar()
                Try
                    If Me.menId <> 0 Then
                        ocdGestor.EjecutarNonQuery("[Menu.Copiar]", New Object(,) {{"@menNombre", menNombre}, {"@menIdPadre", menIdPadre}, {"@menOrden", menOrden}, {"@menUrl", menUrl}, {"@menIcono", menIcono}, {"@menEsMenu", menEsMenu}, {"@menActivo", menActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@menFechaHoraCreacion", menFechaHoraCreacion}, {"@menFechaHoraUltimaModificacion", menFechaHoraUltimaModificacion}})
                    End If
                Catch ex As Exception
                    Throw ex
                End Try
            End Sub

			Public Sub Eliminar()
                Try
                    If Me.menId <> 0 Then
                        ocdGestor.EjecutarNonQuery("[Menu.Eliminar]", New Object(,) {{"@menId", menId}})
                    End If
                Catch ex As Exception
                    Throw ex
                End Try
            End Sub

			Public Function Insertar() as Integer
                Dim IdMax As Integer
                Try
                    IdMax = ocdGestor.EjecutarNonQueryRetornaId("[Menu.Insertar]", New Object(,) {{"@menNombre", menNombre}, {"@menIdPadre", menIdPadre}, {"@menOrden", menOrden}, {"@menUrl", menUrl}, {"@menIcono", menIcono}, {"@menEsMenu", menEsMenu}, {"@menActivo", menActivo}, {"@usuIdCreacion", usuIdCreacion}, {"@usuIdUltimaModificacion", usuIdUltimaModificacion}, {"@menFechaHoraCreacion", menFechaHoraCreacion}, {"@menFechaHoraUltimaModificacion", menFechaHoraUltimaModificacion}})
                Catch ex As Exception
                    Throw ex
                End Try
                Return IdMax
            End Function

		End Class
    End Namespace
End Namespace