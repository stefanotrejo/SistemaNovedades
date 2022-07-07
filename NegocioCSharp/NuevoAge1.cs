using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic;
using System.Collections;
using System.Data;
using System.Diagnostics;
using LiquidacionSueldos.Datos;

namespace LiquidacionSueldos.Negocio
{
    public partial class NuevoAge1
    {
        private Datos.Gestor ocdGestor = new Datos.Gestor();
        private DataTable Fila;
        private DataTable Tabla = new DataTable();

        #region Propiedades
        public string PlantaTipo { get; set; }
        public string NroCOntrol { get; set; }
        public string LugarPago { get; set; }
        public string Escuela { get; set; }
        public string Escalafon { get; set; }
        public string Agru { get; set; }
        public string tramo { get; set; }
        public string Apertura { get; set; }
        public string Categoria { get; set; }
        public string HsCat { get; set; }
        public string Juris { get; set; }
        public string Prog { get; set; }
        public string SubP { get; set; }
        public string Actividad { get; set; }
        public string Nombre { get; set; }
        public string Cuil { get; set; }
        public string TipoDOc { get; set; }
        public string FechaNac { get; set; }
        public string Sexo { get; set; }
        public string EstadoCivil { get; set; }
        public string FechaIngreso { get; set; }
        public string Anios { get; set; }
        public string Meses { get; set; }
        public string DiasMultaAntig { get; set; }
        public string AniosAntig { get; set; }
        public string Ad_Prof_Perm_cgo { get; set; }
        public string NumeroCarnet { get; set; }
        public string AporteIOSEP { get; set; }
        public string AporteOsocNac { get; set; }
        public string Jubilado { get; set; }
        public string AportePrevisional { get; set; }
        public string SituRev { get; set; }
        public string Interinato { get; set; }
        public string SituRevDoc { get; set; }
        public string Nopres_RiesgoVida { get; set; }
        public string FechaBaja { get; set; }
        public string MesAnioLiq { get; set; }
        public string DiasTrabajados { get; set; }
        public string ImponibleANSES { get; set; }
        public string Imponible { get; set; }
        public string HaberS_aporte { get; set; }
        public string HaberC_aporte { get; set; }
        public string TotalHaberes { get; set; }
        public string TotalDescuentos { get; set; }
        public string Liquido { get; set; }
        public string CantItemsOcupados { get; set; }
        public string codBonifDescto2 { get; set; }
        public string importe { get; set; }
        public int NuevoAgeId { get; set; }
        public string Cargo { get; set; }
        public DateTime FechaLiquidacion { get; set; }
        public string SalarioFamiliar { get; set; }
        public string TotalSinCargosAlHaber { get; set; }
        public string RemuneracionOit { get; set; }
        public string AsistenciaPerfecta { get; set; }
        public string Bloqueo { get; set; }
        public string RiesgoDeVida { get; set; }
        public string JubRetActivo { get; set; }
        public string DiasNoTrabajados { get; set; }
        public decimal Fonid { get; set; }
        public int Activo { get; set; }
        public string Legajo { get; set; }

        #endregion

        // METODOS //

        // INICIO - Importacion de Agentes

        public int Insertar()
        {
            int IdMax = 0;
            try
            {
                IdMax = ocdGestor.EjecutarNonQueryRetornaId("[NuevoAge.Insertar]", new object[,] {
                        {
                            "@PlantaTipo",
                             PlantaTipo
                        },
                        {
                            "@NroCOntrol",
                            NroCOntrol
                        },
                        {
                            "@LugarPago",
                            LugarPago
                        },
                        {
                            "@Escuela",
                            Escuela
                        },
                        {
                            "@Escalafon",
                            Escalafon
                        },
                        {
                            "@Agru",
                            Agru
                        },
                        {
                            "@tramo",
                            tramo
                        },
                        {
                            "@Apertura",
                            Apertura
                        },
                    {
                            "@Categoria",
                            Categoria
                        },
                    {
                            "@HsCat",
                            HsCat
                        },
                    {
                            "@Juris",
                            Juris
                        },
                     {
                            "@Prog",
                            Prog
                        },
                      {
                            "@SubP",
                            SubP
                        },
                       {
                            "@Actividad",
                            Actividad
                        },
                        {
                            "@Nombre",
                            Nombre
                        },
                         {
                            "@Cuil",
                            Cuil
                        },
                          {
                            "@TipoDOc",
                            TipoDOc
                        },
                          {
                            "@FechaNac",
                            FechaNac
                        },
                          {
                            "@Sexo",
                            Sexo
                        },
                          {
                            "@EstadoCivil",
                            EstadoCivil
                        },
                          {
                            "@FechaIngreso",
                            FechaIngreso
                        },
                          {
                            "@Anios",
                            Anios
                        },
                           {
                            "@Meses",
                            Meses
                        },
                            {
                            "@DiasMultaAntig",
                            DiasMultaAntig
                        },
                             {
                            "@AniosAntig",
                            AniosAntig
                    },
                              {
                            "@AdProfPermcgo",
                            Ad_Prof_Perm_cgo
                        },
                               {
                            "@NumeroCarnet",
                            NumeroCarnet
                        },
                                {
                            "@AporteIOSEP",
                           AporteIOSEP
                        },
                                 {
                            "@AporteOsocNac",
                            AporteOsocNac
                        },
                                  {
                            "@Jubilado",
                            Jubilado
                        },
                                   {
                            "@AportePrevisional",
                            AportePrevisional
                        },
 {
                            "@SituRev",
                            SituRev
                        },
  {
                            "@Interinato",
                            Interinato
                        },
   {
                            "@SituRevDoc",
                            SituRevDoc
                        },
    {
                            "@NopresRiesgoVida",
                            Nopres_RiesgoVida
                        },
                        {
                            "@FechaBaja",
                            FechaBaja
                        },
                         {
                            "@MesAnioLiq",
                            MesAnioLiq
                        },
                          {
                            "@DiasTrabajados",
                            DiasTrabajados
                        },
                           {
                            "@ImponibleANSES",
                            ImponibleANSES
                        },
                            {
                            "@Imponible",
                            Imponible
                        },
                             {
                            "@HaberSaporte",
                            HaberS_aporte
                        },
                              {
                            "@HaberCaporte",
                            ImponibleANSES
                        },
                               {
                            "@TotalHaberes",
                            TotalHaberes
                        },
                                {
                            "@TotalDescuentos",
                            TotalDescuentos
                        },
                                 {
                            "@Liquido",
                            Liquido
                        },
                                  {
                            "@CantItemsOcupados",
                            CantItemsOcupados
                        },
                                   {
                            "@FechaLiquidacion",
                            FechaLiquidacion
                        },
                                    {
                            "@Activo",
                            Activo
                        },
                                    {
                            "@Legajo",
                            Legajo
                        },
                                    {
                            "@Bloqueo",
                            Bloqueo
                        }
                    });
            }

            catch (Exception ex)
            {
                throw ex;
            }
            return IdMax;
        }

        public void InsertarCodBonificacionImporte(int id, string cod, string importe)
        {
            try
            {

                ocdGestor.EjecutarNonQuery("[NuevoAge.InsertarImporteCodBonificacion]", new object[,] {
                    {
                            "@NuegoAgeId",
                             id
                        },
                        {
                            "@codBonifDescto2",
                            cod
                        },
                        {
                            "@importe",
                            importe
                        }
                    });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CalcularHaberes(int ageId)
        {
            try
            {
                ocdGestor.EjecutarNonQuery("[Agentes.CalcularHaberes]", new object[,] { {
                        "@id",
                        ageId
                    } });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ActualizarAsistenciaPerfecta(int ageId, int AsistenciaPerfecta)
        {
            try
            {
                ocdGestor.EjecutarNonQuery("[Agentes.AsistenciaPerfecta]", new object[,] { {
                        "@Id",
                        ageId
                    }, {
                        "@AsistenciaPerfecta",
                        AsistenciaPerfecta
                    } });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InsertarAgenteRevision(int ageId)
        {
            try
            {
                ocdGestor.EjecutarNonQuery("[Agentes.InsertarAgenteRevision]", new object[,] { {
                        "@id",
                        ageId
                    } });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ActualizarRiesgoDeVida(int ageId, int RiesgoDeVida)
        {
            try
            {
                ocdGestor.EjecutarNonQuery("[Agentes.RiesgoDeVida]", new object[,] { {
                        "@Id",
                        ageId
                    }, {
                        "@RiesgoDeVida",
                        RiesgoDeVida
                    } });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ActualizarJubRetActivo(int ageId, int JubRetActivo)
        {
            try
            {
                ocdGestor.EjecutarNonQuery("[Agentes.JubRetActivo]", new object[,] { {
                        "@Id",
                        ageId
                    }, {
                        "@JubRetActivo",
                        JubRetActivo
                    } });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ObtenerAgentesCasoUno(String MesAnioLiquidacion)
        {
            try
            {
                Tabla = new DataTable();
                Tabla = ocdGestor.EjecutarReader("[Agentes.ObtenerAgentesCasoUno]", new object[,] {
                       {
                            "@MesAnioLiquidacion",
                            MesAnioLiquidacion
                        }
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Tabla;
        }

        public NuevoAge1 ObtenerAgenteCasoUno(int NroControl, string MesAnioLiquidacion)
        {
            try
            {
                NuevoAge1 oAgente = new NuevoAge1();
                Fila = new DataTable();
                Fila = ocdGestor.EjecutarReader("[Agentes.ObtenerAgenteCasoUno]", new object[,] {
                    {
                        "@mesaniol",
                        MesAnioLiquidacion
                    },
                     {
                            "@NroControl",
                            NroControl
                        }
                });
                if (Fila.Rows.Count > 0)
                {
                    if (Fila.Rows[0]["HaberSinAporte"].ToString().Trim().Length > 0)
                    {
                        oAgente.TotalSinCargosAlHaber = Convert.ToString(Fila.Rows[0]["HaberSinAporte"]);
                    }
                    if (Fila.Rows[0]["Id"].ToString().Trim().Length > 0)
                    {
                        oAgente.NuevoAgeId = Convert.ToInt32(Fila.Rows[0]["Id"]);
                    }
                }
                return oAgente;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ObtenerAgentesCasoDos(String MesAnioLiquidacion)
        {
            try
            {
                Tabla = new DataTable();
                Tabla = ocdGestor.EjecutarReader("[Agentes.ObtenerAgentesCasoDos]", new object[,] {
                       {
                            "@MesAnioLiquidacion",
                            MesAnioLiquidacion
                        }
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Tabla;
        }

        public NuevoAge1 ObtenerAgenteCasoDos(string NroControl, string MesAnioLiquidacion)
        {
            try
            {
                NuevoAge1 oAgente = new NuevoAge1();
                Fila = new DataTable();
                Fila = ocdGestor.EjecutarReader("[Agentes.ObtenerAgenteCasoDos]", new object[,] {
                    {
                        "@MesAnioLiq",
                        MesAnioLiquidacion
                    },
                     {
                            "@NroControl",
                            NroControl
                        }
                });
                if (Fila.Rows.Count > 0)
                {
                    if (Fila.Rows[0]["DiasNoTrabajados"].ToString().Trim().Length > 0)
                    {
                        oAgente.DiasNoTrabajados = Convert.ToString(Fila.Rows[0]["DiasNoTrabajados"]);
                    }
                    if (Fila.Rows[0]["Id"].ToString().Trim().Length > 0)
                    {
                        oAgente.NuevoAgeId = Convert.ToInt32(Fila.Rows[0]["Id"]);
                    }
                }
                return oAgente;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ActualizarFonid(int ageId, decimal Fonid)
        {
            try
            {
                ocdGestor.EjecutarNonQuery("[Agentes.ActualizarFonid]", new object[,] { {
                        "@Id",
                        ageId
                    }, {
                        "@Fonid",
                        Fonid
                    } });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ActualizarDiasNoTrabajados(int ageId, string DiasNoTrabajados)
        {
            try
            {
                ocdGestor.EjecutarNonQuery("[Agentes.ActualizarDiasNoTrabajados]", new object[,] { {
                        "@Id",
                        ageId
                    }, {
                        "@DiasNoTrabajados",
                        DiasNoTrabajados
                    } });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ActivarDesactivarRegistro(int ageId, int activardesactivar)
        {
            try
            {
                ocdGestor.EjecutarNonQuery("[Agentes.ActivarDesactivarRegistro]", new object[,] { {
                        "@Id",
                        ageId
                    },
                { "@activo",
                        activardesactivar
                    }
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ActivarCargarNovedades(string mesanio)
        {
            try
            {
                Gestor gestor = this.ocdGestor;
                object[,] objArray = new object[1, 2];
                objArray[0, 0] = "@mesanio";
                objArray[0, 1] = mesanio;
                gestor.EjecutarNonQuery("[Agentes.ActivarCargarNovedades]", objArray);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        // FIN - Importacion de Agentes

        /*------------------------------------------------------------------------------------*/

        // INICIO - CONSULTA DE AGENTES 

        public DataTable ObtenerAgentePorDniConFiltro(string Cuil, DateTime periodo, DateTime periodo2)
        {
            try
            {
                Tabla = new DataTable();
                Tabla = ocdGestor.EjecutarReader("[Agentes.ObtenerAgentePorDniConFiltro]", new object[,] {
                     {
                            "@dni",
                            Cuil
                        },
                     {
                            "@periodo",
                            periodo
                        },
                      {
                            "@periodo2",
                            periodo2
                        }
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Tabla;
        }

        public DataTable ObtenerCargosPorCuilyLiquidacionConFiltro(string Cuil, DateTime periodo, DateTime periodo2, int ageId)
        {
            //TRAE EL RESTO DE CARGOS EXCEPTUANDO AL QUE TIENE EL ID ACTUAL
            try
            {
                Tabla = new DataTable();
                Tabla = ocdGestor.EjecutarReader("[Agentes.ObtenerCargosPorCuilyLiquidacionConFiltro]", new object[,] {
                     {
                            "@dni",
                            Cuil
                        },
                     {
                            "@periodo",
                            periodo
                        },
                      {
                            "@periodo2",
                            periodo2
                        },
                    {
                        "@ageId",
                        ageId
                    }
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Tabla;
        }

        public DataTable ObtenerAgentesPorNombreConFiltro(string nombre, DateTime periodo, DateTime periodo2)
        {
            try
            {
                Tabla = new DataTable();
                Tabla = ocdGestor.EjecutarReader("[Agentes.ObtenerAgentesPorNombreConFiltro]", new object[,] {
                     {
                            "@nombre",
                            nombre
                        },
                      {
                            "@periodo",
                            periodo
                        },
                       {
                            "@periodo2",
                            periodo2
                        }
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Tabla;
        }

        public DataTable ObtenerAgentesPorNroControlConFiltro(string nrocontrol, DateTime periodo, DateTime periodo2)
        {
            try
            {
                Tabla = new DataTable();
                Tabla = ocdGestor.EjecutarReader("[Agentes.ObtenerAgentePorNroControlConFiltro]", new object[,] {
                     {
                            "@nrocontrol",
                            nrocontrol
                        },
                      {
                            "@periodo",
                            periodo
                        },
                       {
                            "@periodo2",
                            periodo2
                        }
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Tabla;
        }

        // FIN - CONSULTA DE AGENTES 

        public NuevoAge1 ObtenerAgentePorId(int id)
        {
            try
            {
                NuevoAge1 oAgente = new NuevoAge1();
                Fila = new DataTable();
                Fila = ocdGestor.EjecutarReader("[Agentes.ObtenerAgentePorId]", new object[,] {
                     {
                            "@id",
                            id
                        }
                    //,{
                    //        "@periodo",
                    //        periodo
                    //    }

                });
                if (Fila.Rows.Count > 0)
                {
                    if (Fila.Rows[0]["Cuil"].ToString().Trim().Length > 0)
                    {
                        oAgente.Cuil = Convert.ToString(Fila.Rows[0]["Cuil"]);
                    }
                    else
                    {
                        oAgente.Cuil = "";
                    }
                    if (Fila.Rows[0]["Nombre"].ToString().Trim().Length > 0)
                    {
                        oAgente.Nombre = Convert.ToString(Fila.Rows[0]["Nombre"]);
                    }
                    else
                    {
                        oAgente.Nombre = "";
                    }
                    if (Fila.Rows[0]["Lugar de Pago"].ToString().Trim().Length > 0)
                    {
                        oAgente.LugarPago = Convert.ToString(Fila.Rows[0]["Lugar de Pago"]);
                    }
                    else
                    {
                        oAgente.LugarPago = "";
                    }
                    if (Fila.Rows[0]["Escuela"].ToString().Trim().Length > 0)
                    {
                        oAgente.Escuela = Convert.ToString(Fila.Rows[0]["Escuela"]);
                    }
                    else
                    {
                        oAgente.Escuela = "";
                    }
                    if (Fila.Rows[0]["Planta"].ToString().Trim().Length > 0)
                    {
                        oAgente.PlantaTipo = Convert.ToString(Fila.Rows[0]["Planta"]);
                    }

                    if (Fila.Rows[0]["Cargo"].ToString().Trim().Length > 0)
                    {
                        oAgente.Cargo = Convert.ToString(Fila.Rows[0]["Cargo"]);
                    }
                    if (Fila.Rows[0]["Horas Catedra"].ToString().Trim().Length > 0)
                    {
                        oAgente.HsCat = Convert.ToString(Fila.Rows[0]["Horas Catedra"]);
                    }
                    if (Fila.Rows[0]["Fecha de Ingreso"].ToString().Trim().Length > 0)
                    {
                        oAgente.FechaIngreso = Convert.ToString(Fila.Rows[0]["Fecha de Ingreso"]);
                    }
                    if (Fila.Rows[0]["Antiguedad"].ToString().Trim().Length > 0)
                    {
                        oAgente.AniosAntig = Convert.ToString(Fila.Rows[0]["Antiguedad"]);
                    }
                    if (Fila.Rows[0]["Periodo"].ToString().Trim().Length > 0)
                    {
                        oAgente.MesAnioLiq = Convert.ToString(Fila.Rows[0]["Periodo"]);
                    }
                    if (Fila.Rows[0]["Dias trabajados"].ToString().Trim().Length > 0)
                    {
                        oAgente.DiasTrabajados = Convert.ToString(Fila.Rows[0]["Dias trabajados"]);
                    }
                    if (Fila.Rows[0]["Dias no trabajados"].ToString().Trim().Length > 0)
                    {
                        oAgente.DiasNoTrabajados = Convert.ToString(Fila.Rows[0]["Dias no trabajados"]);
                    }
                    if (Fila.Rows[0]["Situacion de Revista"].ToString().Trim().Length > 0)
                    {
                        oAgente.SituRev = Convert.ToString(Fila.Rows[0]["Situacion de Revista"]);
                    }
                    if (Fila.Rows[0]["Total Haberes"].ToString().Trim().Length > 0)
                    {
                        oAgente.TotalHaberes = Convert.ToString(Fila.Rows[0]["Total Haberes"]);
                    }
                    if (Fila.Rows[0]["Salario Familiar"].ToString().Trim().Length > 0)
                    {
                        oAgente.HaberC_aporte = Convert.ToString(Fila.Rows[0]["Salario Familiar"]);
                    }
                    else
                    {
                        oAgente.HaberC_aporte = "0";
                    }
                    if (Fila.Rows[0]["Total Descuentos"].ToString().Trim().Length > 0)
                    {
                        oAgente.TotalDescuentos = Convert.ToString(Fila.Rows[0]["Total Descuentos"]);
                    }
                    if (Fila.Rows[0]["Liquido"].ToString().Trim().Length > 0)
                    {
                        oAgente.Liquido = Convert.ToString(Fila.Rows[0]["Liquido"]);
                    }
                    if (Fila.Rows[0]["Agru"].ToString().Trim().Length > 0)
                    {
                        oAgente.Agru = Convert.ToString(Fila.Rows[0]["Agru"]);
                    }
                    if (Fila.Rows[0]["Tramo"].ToString().Trim().Length > 0)
                    {
                        oAgente.tramo = Convert.ToString(Fila.Rows[0]["Tramo"]);
                    }
                    if (Fila.Rows[0]["Apertura"].ToString().Trim().Length > 0)
                    {
                        oAgente.Apertura = Convert.ToString(Fila.Rows[0]["Apertura"]);
                    }
                    if (Fila.Rows[0]["Anios"].ToString().Trim().Length > 0)
                    {
                        oAgente.Anios = Convert.ToString(Fila.Rows[0]["Anios"]);
                    }
                    if (Fila.Rows[0]["Meses"].ToString().Trim().Length > 0)
                    {
                        oAgente.Meses = Convert.ToString(Fila.Rows[0]["Meses"]);
                    }
                    if (Fila.Rows[0]["Total sin cargos al Haber"].ToString().Trim().Length > 0)
                    {
                        oAgente.TotalSinCargosAlHaber = Convert.ToString(Fila.Rows[0]["Total sin cargos al Haber"]);
                    }
                    if (Fila.Rows[0]["Remuneracion OIT"].ToString().Trim().Length > 0)
                    {
                        oAgente.RemuneracionOit = Convert.ToString(Fila.Rows[0]["Remuneracion OIT"]);
                    }
                    if (Fila.Rows[0]["Fecha nacimiento"].ToString().Trim().Length > 0)
                    {
                        oAgente.FechaNac = Convert.ToString(Fila.Rows[0]["Fecha nacimiento"]);
                    }
                    if (Fila.Rows[0]["Jurisdiccion"].ToString().Trim().Length > 0)
                    {
                        oAgente.Juris = Convert.ToString(Fila.Rows[0]["Jurisdiccion"]);
                    }
                    if (Fila.Rows[0]["Control"].ToString().Trim().Length > 0)
                    {
                        oAgente.NroCOntrol = Convert.ToString(Fila.Rows[0]["Control"]);
                    }
                    if (Fila.Rows[0]["Asistencia Perfecta"].ToString().Trim().Length > 0)
                    {
                        oAgente.AsistenciaPerfecta = Convert.ToString(Fila.Rows[0]["Asistencia Perfecta"]);
                    }
                    if (Fila.Rows[0]["Riesgo de vida"].ToString().Trim().Length > 0)
                    {
                        oAgente.RiesgoDeVida = Convert.ToString(Fila.Rows[0]["Riesgo de vida"]);
                    }
                    if (Fila.Rows[0]["JubRetActivo"].ToString().Trim().Length > 0)
                    {
                        oAgente.JubRetActivo = Convert.ToString(Fila.Rows[0]["JubRetActivo"]);
                    }
                    if (Fila.Rows[0]["Fonid"].ToString().Trim().Length > 0)
                    {
                        oAgente.Fonid = Convert.ToDecimal(Fila.Rows[0]["Fonid"]);
                    }


                }
                return oAgente;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // INICIO - CONSULTA DE NOVEDADES 

        public DataTable ObtenerAgentesPorNombrePorMesAnioLiq(string nombre, string mesanioliq, int jurId)
        {
            try
            {
                Tabla = new DataTable();
                Tabla = ocdGestor.EjecutarReader("[Agentes.ObtenerAgentesPorNombrePorMesAnioLiq]", new object[,] {
                     {
                            "@nombre",
                            nombre
                        },
                      {
                            "@mesanioliq",
                            mesanioliq
                        },
                      {
                            "@jurId",
                            jurId
                        }
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Tabla;
        }

        public DataTable ObtenerAgentesPorDniPorMesAnioLiq(string dni, string mesAnioLiq, int jurId)
        {
            try
            {
                Tabla = new DataTable();
                Tabla = ocdGestor.EjecutarReader("[Agentes.ObtenerAgentePorDniPorMesAnioLiq]", new object[,] {
                     {
                            "@dni",
                            dni
                        },
                     {
                            "@mesanioliq",
                            mesAnioLiq
                        },
                      {
                            "@jurId",
                            jurId
                        }
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Tabla;
        }

        #region  Vialidad
        public DataTable ObtenerxDnixMesAnioLiqVialidad(string dni, string mesAnioLiq)
        {
            try
            {
                Tabla = new DataTable();
                Tabla = ocdGestor.EjecutarReader("[Agentes.ConsultaVialidadDni]", new object[,] {
                     {
                            "@dni",
                            dni
                        },
                     {
                            "@mesanioliq",
                            mesAnioLiq
                        }
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Tabla;
        }

        public DataTable ObtenerxControlxMesAnioLiqVialidad(string numeroControl, string mesAnioLiq)
        {
            try
            {
                Tabla = new DataTable();
                Tabla = ocdGestor.EjecutarReader("[Agentes.ConsultaVialidadNumeroControl]", new object[,] {
                     {
                            "@numeroControl",
                            numeroControl
                        },
                     {
                            "@mesanioliq",
                            mesAnioLiq
                        }
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Tabla;
        }

        public DataTable ObtenerxNombrexMesAnioLiqVialidad(string nombre, string mesAnioLiq)
        {
            try
            {
                Tabla = new DataTable();
                Tabla = ocdGestor.EjecutarReader("[Agentes.ConsultaVialidadNombre]", new object[,] {
                     {
                            "@nombre",
                            nombre
                        },
                     {
                            "@mesanioliq",
                            mesAnioLiq
                        }
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Tabla;
        }
        #endregion

        #region  Tribunal de Cuentas
        public DataTable ObtenerxDnixMesAnioLiqTribunalCuentas(string dni, string mesAnioLiq)
        {
            try
            {
                Tabla = new DataTable();
                Tabla = ocdGestor.EjecutarReader("[Agentes.ConsultaTribunalCuentasDni]", new object[,] {
                     {
                            "@dni",
                            dni
                        },
                     {
                            "@mesanioliq",
                            mesAnioLiq
                        }
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Tabla;
        }

        public DataTable ObtenerxControlxMesAnioLiqTribunalCuentas(string numeroControl, string mesAnioLiq)
        {
            try
            {
                Tabla = new DataTable();
                Tabla = ocdGestor.EjecutarReader("[Agentes.ConsultaTribunalCuentasNumeroControl]", new object[,] {
                     {
                            "@numeroControl",
                            numeroControl
                        },
                     {
                            "@mesanioliq",
                            mesAnioLiq
                        }
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Tabla;
        }

        public DataTable ObtenerxNombrexMesAnioLiqTribunalCuentas(string nombre, string mesAnioLiq)
        {
            try
            {
                Tabla = new DataTable();
                Tabla = ocdGestor.EjecutarReader("[Agentes.ConsultaTribunalCuentasNombre]", new object[,] {
                     {
                            "@nombre",
                            nombre
                        },
                     {
                            "@mesanioliq",
                            mesAnioLiq
                        }
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Tabla;
        }
        #endregion

        #region  Riego
        public DataTable ObtenerxDnixMesAnioLiqRiego(string dni, string mesAnioLiq)
        {
            try
            {
                Tabla = new DataTable();
                Tabla = ocdGestor.EjecutarReader("[Agentes.ConsultaRiegoDni]", new object[,] {
                     {
                            "@dni",
                            dni
                        },
                     {
                            "@mesanioliq",
                            mesAnioLiq
                        }
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Tabla;
        }

        public DataTable ObtenerxControlxMesAnioLiqRiego(string numeroControl, string mesAnioLiq)
        {
            try
            {
                Tabla = new DataTable();
                Tabla = ocdGestor.EjecutarReader("[Agentes.ConsultaRiegoNumeroControl]", new object[,] {
                     {
                            "@numeroControl",
                            numeroControl
                        },
                     {
                            "@mesanioliq",
                            mesAnioLiq
                        }
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Tabla;
        }

        public DataTable ObtenerxNombrexMesAnioLiqRiego(string nombre, string mesAnioLiq)
        {
            try
            {
                Tabla = new DataTable();
                Tabla = ocdGestor.EjecutarReader("[Agentes.ConsultaRiegoNombre]", new object[,] {
                     {
                            "@nombre",
                            nombre
                        },
                     {
                            "@mesanioliq",
                            mesAnioLiq
                        }
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Tabla;
        }
        #endregion

        #region  Policia
        public DataTable ObtenerxDnixMesAnioLiqPolicia(string dni, string mesAnioLiq)
        {
            try
            {
                Tabla = new DataTable();
                Tabla = ocdGestor.EjecutarReader("[Agentes.ConsultaPoliciaDni]", new object[,] {
                     {
                            "@dni",
                            dni
                        },
                     {
                            "@mesanioliq",
                            mesAnioLiq
                        }
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Tabla;
        }

        public DataTable ObtenerxControlxMesAnioLiqPolicia(string numeroControl, string mesAnioLiq)
        {
            try
            {
                Tabla = new DataTable();
                Tabla = ocdGestor.EjecutarReader("[Agentes.ConsultaPoliciaNumeroControl]", new object[,] {
                     {
                            "@numeroControl",
                            numeroControl
                        },
                     {
                            "@mesanioliq",
                            mesAnioLiq
                        }
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Tabla;
        }

        public DataTable ObtenerxNombrexMesAnioLiqPolicia(string nombre, string mesAnioLiq)
        {
            try
            {
                Tabla = new DataTable();
                Tabla = ocdGestor.EjecutarReader("[Agentes.ConsultaPoliciaNombre]", new object[,] {
                     {
                            "@nombre",
                            nombre
                        },
                     {
                            "@mesanioliq",
                            mesAnioLiq
                        }
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Tabla;
        }
        #endregion

        #region  Municipalidades
        public DataTable ObtenerxDnixMesAnioLiqMunicipalidades(string dni, string mesAnioLiq)
        {
            try
            {
                Tabla = new DataTable();
                Tabla = ocdGestor.EjecutarReader("[Agentes.ConsultaMunicipalidadesDni]", new object[,] {
                     {
                            "@dni",
                            dni
                        },
                     {
                            "@mesanioliq",
                            mesAnioLiq
                        }
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Tabla;
        }

        public DataTable ObtenerxControlxMesAnioLiqMunicipalidades(string numeroControl, string mesAnioLiq)
        {
            try
            {
                Tabla = new DataTable();
                Tabla = ocdGestor.EjecutarReader("[Agentes.ConsultaMunicipalidadesNumeroControl]", new object[,] {
                     {
                            "@numeroControl",
                            numeroControl
                        },
                     {
                            "@mesanioliq",
                            mesAnioLiq
                        }
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Tabla;
        }

        public DataTable ObtenerxNombrexMesAnioLiqMunicipalidades(string nombre, string mesAnioLiq)
        {
            try
            {
                Tabla = new DataTable();
                Tabla = ocdGestor.EjecutarReader("[Agentes.ConsultaMunicipalidadesNombre]", new object[,] {
                     {
                            "@nombre",
                            nombre
                        },
                     {
                            "@mesanioliq",
                            mesAnioLiq
                        }
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Tabla;
        }
        #endregion

        #region  Legislativo
        public DataTable ObtenerxDnixMesAnioLiqLegislativo(string dni, string mesAnioLiq)
        {
            try
            {
                Tabla = new DataTable();
                Tabla = ocdGestor.EjecutarReader("[Agentes.ConsultaLegislativoDni]", new object[,] {
                     {
                            "@dni",
                            dni
                        },
                     {
                            "@mesanioliq",
                            mesAnioLiq
                        }
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Tabla;
        }

        public DataTable ObtenerxControlxMesAnioLiqLegislativo(string numeroControl, string mesAnioLiq)
        {
            try
            {
                Tabla = new DataTable();
                Tabla = ocdGestor.EjecutarReader("[Agentes.ConsultaLegislativoNumeroControl]", new object[,] {
                     {
                            "@numeroControl",
                            numeroControl
                        },
                     {
                            "@mesanioliq",
                            mesAnioLiq
                        }
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Tabla;
        }

        public DataTable ObtenerxNombrexMesAnioLiqLegislativo(string nombre, string mesAnioLiq)
        {
            try
            {
                Tabla = new DataTable();
                Tabla = ocdGestor.EjecutarReader("[Agentes.ConsultaLegislativoNombre]", new object[,] {
                     {
                            "@nombre",
                            nombre
                        },
                     {
                            "@mesanioliq",
                            mesAnioLiq
                        }
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Tabla;
        }
        #endregion

        #region  Ipvu
        public DataTable ObtenerxDnixMesAnioLiqIpvu(string dni, string mesAnioLiq)
        {
            try
            {
                Tabla = new DataTable();
                Tabla = ocdGestor.EjecutarReader("[Agentes.ConsultaIpvuDni]", new object[,] {
                     {
                            "@dni",
                            dni
                        },
                     {
                            "@mesanioliq",
                            mesAnioLiq
                        }
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Tabla;
        }

        public DataTable ObtenerxControlxMesAnioLiqIpvu(string numeroControl, string mesAnioLiq)
        {
            try
            {
                Tabla = new DataTable();
                Tabla = ocdGestor.EjecutarReader("[Agentes.ConsultaIpvuNumeroControl]", new object[,] {
                     {
                            "@numeroControl",
                            numeroControl
                        },
                     {
                            "@mesanioliq",
                            mesAnioLiq
                        }
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Tabla;
        }

        public DataTable ObtenerxNombrexMesAnioLiqIpvu(string nombre, string mesAnioLiq)
        {
            try
            {
                Tabla = new DataTable();
                Tabla = ocdGestor.EjecutarReader("[Agentes.ConsultaIpvuNombre]", new object[,] {
                     {
                            "@nombre",
                            nombre
                        },
                     {
                            "@mesanioliq",
                            mesAnioLiq
                        }
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Tabla;
        }
        #endregion

        #region  Iosep
        public DataTable ObtenerxDnixMesAnioLiqIosep(string dni, string mesAnioLiq)
        {
            try
            {
                Tabla = new DataTable();
                Tabla = ocdGestor.EjecutarReader("[Agentes.ConsultaIosepDni]", new object[,] {
                     {
                            "@dni",
                            dni
                        },
                     {
                            "@mesanioliq",
                            mesAnioLiq
                        }
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Tabla;
        }

        public DataTable ObtenerxControlxMesAnioLiqIosep(string numeroControl, string mesAnioLiq)
        {
            try
            {
                Tabla = new DataTable();
                Tabla = ocdGestor.EjecutarReader("[Agentes.ConsultaIosepNumeroControl]", new object[,] {
                     {
                            "@numeroControl",
                            numeroControl
                        },
                     {
                            "@mesanioliq",
                            mesAnioLiq
                        }
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Tabla;
        }

        public DataTable ObtenerxNombrexMesAnioLiqIosep(string nombre, string mesAnioLiq)
        {
            try
            {
                Tabla = new DataTable();
                Tabla = ocdGestor.EjecutarReader("[Agentes.ConsultaIosepNombre]", new object[,] {
                     {
                            "@nombre",
                            nombre
                        },
                     {
                            "@mesanioliq",
                            mesAnioLiq
                        }
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Tabla;
        }
        #endregion

        #region  Recursos Hidricos
        public DataTable ObtenerxDnixMesAnioLiqRecursosHidricos(string dni, string mesAnioLiq)
        {
            try
            {
                Tabla = new DataTable();
                Tabla = ocdGestor.EjecutarReader("[Agentes.ConsultaRecursosHidricosDni]", new object[,] {
                     {
                            "@dni",
                            dni
                        },
                     {
                            "@mesanioliq",
                            mesAnioLiq
                        }
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Tabla;
        }

        public DataTable ObtenerxControlxMesAnioLiqRecursosHidricos(string numeroControl, string mesAnioLiq)
        {
            try
            {
                Tabla = new DataTable();
                Tabla = ocdGestor.EjecutarReader("[Agentes.ConsultaRecursosHidricosNumeroControl]", new object[,] {
                     {
                            "@numeroControl",
                            numeroControl
                        },
                     {
                            "@mesanioliq",
                            mesAnioLiq
                        }
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Tabla;
        }

        public DataTable ObtenerxNombrexMesAnioLiqRecursosHidricos(string nombre, string mesAnioLiq)
        {
            try
            {
                Tabla = new DataTable();
                Tabla = ocdGestor.EjecutarReader("[Agentes.ConsultaRecursosHidricosNombre]", new object[,] {
                     {
                            "@nombre",
                            nombre
                        },
                     {
                            "@mesanioliq",
                            mesAnioLiq
                        }
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Tabla;
        }
        #endregion

        #region  Consejo de Educacion
        public DataTable ObtenerxDnixMesAnioLiqConsejoEducacion(string dni, string mesAnioLiq)
        {
            try
            {
                Tabla = new DataTable();
                Tabla = ocdGestor.EjecutarReader("[Agentes.ConsultaConsejoEducacionDni]", new object[,] {
                     {
                            "@dni",
                            dni
                        },
                     {
                            "@mesanioliq",
                            mesAnioLiq
                        }
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Tabla;
        }

        public DataTable ObtenerxControlxMesAnioLiqConsejoEducacion(string numeroControl, string mesAnioLiq)
        {
            try
            {
                Tabla = new DataTable();
                Tabla = ocdGestor.EjecutarReader("[Agentes.ConsultaConsejoEducacionNumeroControl]", new object[,] {
                     {
                            "@numeroControl",
                            numeroControl
                        },
                     {
                            "@mesanioliq",
                            mesAnioLiq
                        }
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Tabla;
        }

        public DataTable ObtenerxNombrexMesAnioLiqConsejoEducacion(string nombre, string mesAnioLiq)
        {
            try
            {
                Tabla = new DataTable();
                Tabla = ocdGestor.EjecutarReader("[Agentes.ConsultaConsejoEducacionNombre]", new object[,] {
                     {
                            "@nombre",
                            nombre
                        },
                     {
                            "@mesanioliq",
                            mesAnioLiq
                        }
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Tabla;
        }
        #endregion

        #region  Aviacion Civil
        public DataTable ObtenerxDnixMesAnioLiqAviacionCivil(string dni, string mesAnioLiq)
        {
            try
            {
                Tabla = new DataTable();
                Tabla = ocdGestor.EjecutarReader("[Agentes.ConsultaAviacionCivilDni]", new object[,] {
                     {
                            "@dni",
                            dni
                        },
                     {
                            "@mesanioliq",
                            mesAnioLiq
                        }
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Tabla;
        }

        public DataTable ObtenerxControlxMesAnioLiqAviacionCivil(string numeroControl, string mesAnioLiq)
        {
            try
            {
                Tabla = new DataTable();
                Tabla = ocdGestor.EjecutarReader("[Agentes.ConsultaAviacionCivilNumeroControl]", new object[,] {
                     {
                            "@numeroControl",
                            numeroControl
                        },
                     {
                            "@mesanioliq",
                            mesAnioLiq
                        }
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Tabla;
        }

        public DataTable ObtenerxNombrexMesAnioLiqAviacionCivil(string nombre, string mesAnioLiq)
        {
            try
            {
                Tabla = new DataTable();
                Tabla = ocdGestor.EjecutarReader("[Agentes.ConsultaAviacionCivilNombre]", new object[,] {
                     {
                            "@nombre",
                            nombre
                        },
                     {
                            "@mesanioliq",
                            mesAnioLiq
                        }
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Tabla;
        }
        #endregion

        public DataTable ObtenerAgentesPorNroControlPorMesAnioLiq(string nrocontrol, string mesanioliq, int jurId)
        {
            try
            {
                Tabla = new DataTable();
                Tabla = ocdGestor.EjecutarReader("[Agentes.ObtenerAgentePorNroControlPorMesAnioLiq]", new object[,] {
                     {
                            "@nrocontrol",
                            nrocontrol
                        },
                      {
                            "@mesanioliq",
                            mesanioliq
                        },
                      {
                            "@jurId",
                            jurId
                        }
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Tabla;
        }

        public DataTable ObtenerConceptosPorAgente(int ageId)
        {
            try
            {
                NuevoAge1 oAgente = new NuevoAge1();
                Fila = new DataTable();
                Fila = ocdGestor.EjecutarReader("[Agentes.ConceptosPorAgente]", new object[,] {
                    {
                        "@ageId",
                        ageId
                    }
                });
                return Fila;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ImportarArchivoPersonal(string control, string dni, string mesanio)
        {
            try
            {

                ocdGestor.EjecutarNonQuery("[Agentes.ImportarArchivoPersonal]", new object[,] {
                    {
                            "@numeroControl",
                             control
                        },
                        {
                            "@dni",
                            dni
                        },
                        {
                            "@mesanio",
                            mesanio
                        }
                    });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // FIN - CONSULTA DE NOVEDADES

        #region Metodos viejos sin usar

        //public DataTable ObtenerAgenteXNroControl(string nrocontrol, DateTime periodo, DateTime periodo2)
        //{
        //    try
        //    {
        //        Tabla = new DataTable();
        //        Tabla = ocdGestor.EjecutarReader("[Agentes.ObtenerAgentePorNroControl]", new object[,] {
        //             {
        //                    "@nrocontrol",
        //                    nrocontrol
        //                },
        //              {
        //                    "@periodo",
        //                    periodo
        //                },
        //               {
        //                    "@periodo2",
        //                    periodo2
        //                }
        //        });
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return Tabla;
        //}



        //public DataTable ObtenerAgentePorDni(string Cuil, DateTime periodo, DateTime periodo2)
        //{
        //    try
        //    {
        //        Tabla = new DataTable();
        //        Tabla = ocdGestor.EjecutarReader("[Agentes.ObtenerAgentePorDni]", new object[,] {
        //             {
        //                    "@dni",
        //                    Cuil
        //                },
        //             {
        //                    "@periodo",
        //                    periodo
        //                },
        //              {
        //                    "@periodo2",
        //                    periodo2
        //                }
        //        });
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return Tabla;
        //}

        //public DataTable ObtenerAgentesPorNombre(string nombre, DateTime periodo, DateTime periodo2)
        //{
        //    try
        //    {
        //        Tabla = new DataTable();
        //        Tabla = ocdGestor.EjecutarReader("[Agentes.ObtenerAgentesPorNombre]", new object[,] {
        //             {
        //                    "@nombre",
        //                    nombre
        //                },
        //              {
        //                    "@periodo",
        //                    periodo
        //                },
        //               {
        //                    "@periodo2",
        //                    periodo2
        //                }
        //        });
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return Tabla;
        //}

        //public DataTable ObtenerCargosPorCuilyLiquidacion(string Cuil, DateTime periodo, DateTime periodo2, int ageId)
        //{
        //    try
        //    {
        //        Tabla = new DataTable();
        //        Tabla = ocdGestor.EjecutarReader("[Agentes.ObtenerCargosPorCuilyLiquidacion]", new object[,] {
        //             {
        //                    "@dni",
        //                    Cuil
        //                },
        //             {
        //                    "@periodo",
        //                    periodo
        //                },
        //              {
        //                    "@periodo2",
        //                    periodo2
        //                },
        //            {
        //                "@ageId",
        //                ageId
        //            }                   
        //        });
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return Tabla;
        //}

        #endregion
    }
}
