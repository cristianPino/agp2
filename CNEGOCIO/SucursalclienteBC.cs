using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;

namespace CNEGOCIO
{
    public class SucursalclienteBC
    {

        public List<Usuario> GetUsuariosEnSucursal(Int16 id_sucursal)
        {
            return new SucursalclienteDAC().GetUsuariosEnSucursal(id_sucursal);
        }
        public bool getEncargadoSucursal(Int16 id_sucursal, string cuenta_usuario)
        {
            return new SucursalclienteDAC().getEncargadoSucursal(id_sucursal, cuenta_usuario);
        }

        //nuevo para traer id y nombre de sucursal 
        public List<SucursalCliente> GetSucursalbyclienteCombobox(Int16 idCliente)
        {
            return new SucursalclienteDAC().GetSucursalbyclienteCombobox(idCliente);
        }


        public List<SucursalCliente> GetSucursalbyclienteShort(Int16 id_cliente)
        {
            return new SucursalclienteDAC().GetSucursalbyclienteShort(id_cliente);
        }

        public SucursalCliente GetSucursalShort(Int16 id_sucursal)
        {
            return new SucursalclienteDAC().GetSucursalShort(id_sucursal);
        }

        public string add_sucursal(Int16 id_comuna, Int16 id_cliente, Int16 id_modulo, string nombre, int ind_principal)
        {
            string add = new SucursalclienteDAC().add_Sucursalcliente(id_comuna, id_cliente, id_modulo, nombre, ind_principal);
            return add;
        }

        public List<SucursalCliente> getSucursalbymodulo(Int16 id_modulo)
        {
            List<SucursalCliente> lsucursal = new SucursalclienteDAC().getSucursalbymodulo(id_modulo);
            return lsucursal;
        }

        public List<SucursalCliente> getSucursalbycliente(Int16 id_cliente)
        {
            List<SucursalCliente> lsucursal = new SucursalclienteDAC().GetSucursalbyclienteShort(id_cliente);
            return lsucursal;
        }

        public List<SucursalCliente> getUsuarioSucursal(Int16 id_modulo, string usuario)
        {
            List<SucursalCliente> lsucursal = new SucursalclienteDAC().getUsuariosucursal(id_modulo, usuario);
            return lsucursal;
        }

        public List<SucursalCliente> getSucursalByClienteAndUsuario(Int16 id_cliente, string usuario)
        {
            List<SucursalCliente> lsucursal = new SucursalclienteDAC().getSucursalByClienteAndUsuario(id_cliente, usuario);
            return lsucursal;
        }

        public List<SucursalCliente> getSucursalByClienteAndUsuarioconces(Int16 id_cliente, string usuario, string conces)
        {
            List<SucursalCliente> lsucursal = new SucursalclienteDAC().getSucursalByClienteAndUsuarioconc(id_cliente, usuario, conces);
            return lsucursal;
        }
        public List<SucursalCliente> GetSucursalByClienteAndUsuarioShort(Int16 id_cliente, string usuario)
        {
            return new SucursalclienteDAC().GetSucursalByClienteAndUsuarioShort(id_cliente, usuario);
        }



        public SucursalCliente getSucursalParidadAG(string codigo)
        {
            return new SucursalclienteDAC().getSucursalParidadAG(codigo);
        }

        public SucursalCliente getsucursalnav(Int32 id_sucursal)
        {
            return new SucursalclienteDAC().getsucursalnav(id_sucursal);
        }

        public SucursalCliente getSucursalParidad(string codigo, Int32 id_cliente)
        {
            return new SucursalclienteDAC().getSucursalParidad(codigo, id_cliente);
        }

        public SucursalCliente getSucursal(Int16 id_sucursal)
        {
            return new SucursalclienteDAC().getSucursal(id_sucursal);
        }
    }
}