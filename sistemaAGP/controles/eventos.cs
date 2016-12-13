using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CENTIDAD;

namespace sistemaAGP
{
	#region Argumentos
	#region Argumentos para los eventos de los objetos wucPersonaBase y wucPersonaNew
	/// <summary>
	/// Argumentos del evento que maneja el cambio de persona en los objetos wucPersonaBase y wucPersonaNew
	/// </summary>
	public class CambioPersonaEventArgs : EventArgs
	{
		private readonly Persona _persona;
		/// <summary>
		/// Retorna los datos de la persona seleccionada
		/// </summary>
		public Persona Persona
		{
			get { return _persona; }
		}

		public CambioPersonaEventArgs(Persona persona)
		{
			this._persona = persona;
		}
	}

	/// <summary>
	/// Argumentos del evento que maneja cuando se guardan los datos de una persona en los objetos wucPersonaBase y wucPersonaNew
	/// </summary>
	public class GuardarPersonaEventArgs : EventArgs
	{
		private readonly Persona _persona;
		/// <summary>
		/// Retorna los datos de la persona guardada
		/// </summary>
		public Persona Persona
		{
			get { return _persona; }
		}

		private readonly string _mensajeError;
		/// <summary>
		/// Retorna el mensaje de error producido al guardar
		/// </summary>
		public string MensajeError
		{
			get { return _mensajeError; }
		}

		public GuardarPersonaEventArgs(Persona persona)
		{
			this._persona = persona;
			this._mensajeError = null;
		}

		public GuardarPersonaEventArgs(string mensajeError)
		{
			this._persona = null;
			this._mensajeError = mensajeError;
		}

		public GuardarPersonaEventArgs(Persona persona, string mensajeError)
		{
			this._persona = persona;
			this._mensajeError = mensajeError;
		}
	}
	#endregion

	#region Argumentos para los eventos del objeto wucPersonaNew
	/// <summary>
	/// Argumentos del evento que maneja el cambio del check del compra para
	/// </summary>
	public class CambioCompraParaEventArgs : EventArgs
	{
		private readonly bool _activar;

		public bool Activar
		{
			get { return _activar; }
		}

		public CambioCompraParaEventArgs(bool activar)
		{
			this._activar = activar;
		}
	}
	#endregion
	#endregion

	#region Delegados
	#region Delegados para los eventos de los objetos wucPersonaBase y wucPersonaNew
	/// <summary>
	/// Delegado del evento que maneja el cambio de persona
	/// </summary>
	/// <param name="sender">Objeto que provocó el evento</param>
	/// <param name="e">Argumentos del evento</param>
	public delegate void CambioPersonaEventHandler(object sender, CambioPersonaEventArgs e);

	/// <summary>
	/// Delegado del evento que maneja cuando se guardan los datos de una persona
	/// </summary>
	/// <param name="sender">Objeto que provocó el evento</param>
	/// <param name="e">Argumentos del evento</param>
	public delegate void GuardarPersonaEventHandler(object sender, GuardarPersonaEventArgs e);

	/// <summary>
	/// Delegado del evento que maneja cuando se limpian los datos de una persona
	/// </summary>
	/// <param name="sender">Objeto que provocó el evento</param>
	/// <param name="e">Argumentos del evento</param>
	public delegate void LimpiarPersonaEventHandler(object sender, EventArgs e);
	#endregion

	#region Delegados para los eventos del objeto wucPersonaNew
	/// <summary>
	/// Delegado del evento que maneja el cambio de estado en el check del compra para
	/// </summary>
	/// <param name="sender">Objeto que provocó el evento</param>
	/// <param name="e">Argumentos del evento</param>
	public delegate void CambioCompraParaEventHandler(object sender, CambioCompraParaEventArgs e);
	#endregion

	#region Delegados para los eventos del objeto wucRepresentamtes
	public delegate void CambioRepresentantesEventHandler(object sender, EventArgs e);
	#endregion

	#region Delegados para los eventos del objeto wucDirecciones
	/// <summary>
	/// Delegado del evento que maneja el cambio de prioridad en una dirección
	/// </summary>
	/// <param name="sender">Objeto que provocó el evento</param>
	/// <param name="e">Argumentos del evento</param>
	public delegate void CambioDireccionEventHandler(object sender, EventArgs e);

	/// <summary>
	/// Delegado del evento que maneja cuando se guarda una dirección
	/// </summary>
	/// <param name="sender">Objeto que provocó el evento</param>
	/// <param name="e">Argumentos del evento</param>
	public delegate void GuardarDireccionEventHandler(object sender, EventArgs e);
	#endregion

	#region Delegados para los eventos del objeto wucTelefonos
	/// <summary>
	/// Delegado del evento que maneja el cambio de prioridad en un teléfono
	/// </summary>
	/// <param name="sender">Objeto que provocó el evento</param>
	/// <param name="e">Argumentos del evento</param>
	public delegate void CambioTelefonoEventHandler(object sender, EventArgs e);

	/// <summary>
	/// Delegado del evento que maneja cuando se guarda un teléfono
	/// </summary>
	/// <param name="sender">Objeto que provocó el evento</param>
	/// <param name="e">Argumentos del evento</param>
	public delegate void GuardarTelefonoEventHandler(object sender, EventArgs e);
	#endregion

	#region Delegados para los eventos del objeto wucCorreos
	/// <summary>
	/// Delegado del evento que maneja el cambio de prioridad en un correo
	/// </summary>
	/// <param name="sender">Objeto que provocó el evento</param>
	/// <param name="e">Argumentos del evento</param>
	public delegate void CambioCorreoEventHandler(object sender, EventArgs e);

	/// <summary>
	/// Delegado del evento que maneja cuando se guarda un correo
	/// </summary>
	/// <param name="sender">Objeto que provocó el evento</param>
	/// <param name="e">Argumentos del evento</param>
	public delegate void GuardarCorreoEventHandler(object sender, EventArgs e);
	#endregion
	#endregion
}