using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.Data;
using LiquidacionSueldos.Datos;

namespace LiquidacionSueldos.Negocio
{
    public class Agentes
    {
        private Gestor ocdGestor = new Gestor();

        private DataTable Fila;

        private DataTable Tabla = new DataTable();

        private int _ageId;

        private string _ageCuil;

        private string _ageTipoDocumento;

        private string _ageApellidoyNombre;

        private DateTime _ageFechaNacimiento;

        private int _ageSexo;

        private int _ageEstadoCivil;

        private string _ageNumeroObraSocial;

        private int _ageCantidadAdherente;

        private int _ageCantidadAdherenteNacional;

        private int _ageActivo;

        private int _usuIdCreacion;

        private int _usuIdUltimaModificacion;

        private DateTime _ageFechaHoraCreacion;

        private DateTime _ageFechaHoraUltimaModificacion;

        public int ageActivo
        {
            get
            {
                return this._ageActivo;
            }
            set
            {
                this._ageActivo = value;
            }
        }

        public string ageApellidoyNombre
        {
            get
            {
                return this._ageApellidoyNombre;
            }
            set
            {
                this._ageApellidoyNombre = value;
            }
        }

        public int ageCantidadAdherente
        {
            get
            {
                return this._ageCantidadAdherente;
            }
            set
            {
                this._ageCantidadAdherente = value;
            }
        }

        public int ageCantidadAdherenteNacional
        {
            get
            {
                return this._ageCantidadAdherenteNacional;
            }
            set
            {
                this._ageCantidadAdherenteNacional = value;
            }
        }

        public string ageCuil
        {
            get
            {
                return this._ageCuil;
            }
            set
            {
                this._ageCuil = value;
            }
        }

        public int ageEstadoCivil
        {
            get
            {
                return this._ageEstadoCivil;
            }
            set
            {
                this._ageEstadoCivil = value;
            }
        }

        public DateTime ageFechaHoraCreacion
        {
            get
            {
                return this._ageFechaHoraCreacion;
            }
            set
            {
                this._ageFechaHoraCreacion = value;
            }
        }

        public DateTime ageFechaHoraUltimaModificacion
        {
            get
            {
                return this._ageFechaHoraUltimaModificacion;
            }
            set
            {
                this._ageFechaHoraUltimaModificacion = value;
            }
        }

        public DateTime ageFechaNacimiento
        {
            get
            {
                return this._ageFechaNacimiento;
            }
            set
            {
                this._ageFechaNacimiento = value;
            }
        }

        public int ageId
        {
            get
            {
                return this._ageId;
            }
            set
            {
                this._ageId = value;
            }
        }

        public string ageNumeroObraSocial
        {
            get
            {
                return this._ageNumeroObraSocial;
            }
            set
            {
                this._ageNumeroObraSocial = value;
            }
        }

        public int ageSexo
        {
            get
            {
                return this._ageSexo;
            }
            set
            {
                this._ageSexo = value;
            }
        }

        public string ageTipoDocumento
        {
            get
            {
                return this._ageTipoDocumento;
            }
            set
            {
                this._ageTipoDocumento = value;
            }
        }

        public int usuIdCreacion
        {
            get
            {
                return this._usuIdCreacion;
            }
            set
            {
                this._usuIdCreacion = value;
            }
        }

        public int usuIdUltimaModificacion
        {
            get
            {
                return this._usuIdUltimaModificacion;
            }
            set
            {
                this._usuIdUltimaModificacion = value;
            }
        }

        public Agentes()
        {
        }

        public int Insertar()
        {
            int num;
            try
            {
                Gestor gestor = this.ocdGestor;
                object[,] objArray = new object[14, 2];
                objArray[0, 0] = "@ageCuil";
                objArray[0, 1] = this.ageCuil;
                objArray[1, 0] = "@ageTipoDocumento";
                objArray[1, 1] = this.ageTipoDocumento;
                objArray[2, 0] = "@ageApellidoyNombre";
                objArray[2, 1] = this.ageApellidoyNombre;
                objArray[3, 0] = "@ageFechaNacimiento";
                objArray[3, 1] = this.ageFechaNacimiento;
                objArray[4, 0] = "@ageSexo";
                objArray[4, 1] = this.ageSexo;
                objArray[5, 0] = "@ageEstadoCivil";
                objArray[5, 1] = this.ageEstadoCivil;
                objArray[6, 0] = "@ageNumeroObraSocial";
                objArray[6, 1] = this.ageNumeroObraSocial;
                objArray[7, 0] = "@ageCantidadAdherente";
                objArray[7, 1] = this.ageCantidadAdherente;
                objArray[8, 0] = "@ageCantidadAdherenteNacional";
                objArray[8, 1] = this.ageCantidadAdherenteNacional;
                objArray[9, 0] = "@ageActivo";
                objArray[9, 1] = this.ageActivo;
                objArray[10, 0] = "@usuIdCreacion";
                objArray[10, 1] = this.usuIdCreacion;
                objArray[11, 0] = "@usuIdUltimaModificacion";
                objArray[11, 1] = this.usuIdUltimaModificacion;
                objArray[12, 0] = "@ageFechaHoraCreacion";
                objArray[12, 1] = this.ageFechaHoraCreacion;
                objArray[13, 0] = "@ageFechaHoraUltimaModificacion";
                objArray[13, 1] = this.ageFechaHoraUltimaModificacion;
                num = gestor.EjecutarNonQueryRetornaId("[Agente.Insertar]", objArray);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return num;
        }
    }
}