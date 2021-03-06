﻿
namespace B2WTI.PCFTI.APRESENTACAO.SERVICES.Map
{
    using B2WTI.PCFTI.APLICACAO.Operacao;
    using B2WTI.PCFTI.DOMINIO.Model.Sistema;
    using DOMINIO.Model.Global;
    using INFRAESTRUTURA.TRANSVERSAL.DTO.Modulo.Sistema.ViewModel;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class UsuarioMap
    {

        public static List<Usuario> DeViewParaDomin(this List<UsuarioView> source)
        {
            List<Usuario> usuarios = new List<Usuario>();

            Parallel.ForEach<UsuarioView>(source, usuario =>
            {
                usuarios.Add(new Usuario()
                {
                    UsuarioId = usuario.UsuarioId,
                    Nome = usuario.Nome,
                    LoginWindows = usuario.LoginWindows,
                    Email = usuario.Email,
                    Ativo = usuario.Ativo
                });
            });
            return usuarios;
        }

        public static Usuario DeViewParaDomin(this UsuarioView source)
        {
            Usuario usuario = new Usuario()
            {
                UsuarioId = source.UsuarioId,
                Nome = source.Nome,
                LoginWindows = source.LoginWindows,
                Email = source.Email,
                Ativo = source.Ativo
            };
            return usuario;
        }

        public static List<UsuarioView> DeDominParaView(this List<Usuario> source)
        {
            List<UsuarioView> usuarios = new List<UsuarioView>();

            Parallel.ForEach<Usuario>(source, usuario =>
            {
                usuarios.Add(new UsuarioView()
                {
                    UsuarioId = usuario.UsuarioId,
                    Nome = usuario.Nome,
                    LoginWindows = usuario.LoginWindows,
                    Email = usuario.Email,
                    Ativo = usuario.Ativo
                });
            });

            return usuarios;
        }

        public static UsuarioView DeDominParaView(this Usuario source)
        {
            UsuarioView usuario = null; 
            List<UsuarioRegraView> lstUsuarioRegra = null;
            if (source != null)
            {
                usuario = new UsuarioView()
                {
                    UsuarioId = source.UsuarioId,
                    Nome = source.Nome,
                    LoginWindows = source.LoginWindows,
                    Email = source.Email,
                    Ativo = source.Ativo
                };

                if (source.UsuarioRegras != null)
                    if (source.UsuarioRegras.Count() > 0)
                        lstUsuarioRegra = source.UsuarioRegras.ToList<UsuarioRegra>().DeDominParaView();

                if (lstUsuarioRegra != null)
                    if (lstUsuarioRegra.Count() > 0)
                    {
                        List<RegraView> regras = new List<RegraView>();
                        Parallel.ForEach<UsuarioRegraView>(lstUsuarioRegra, item => regras.Add(item.Regra));
                        usuario.Regras = regras;
                    }
            }
            return usuario;
        }

        //public static List<RegraView> DeDominParaView(this List<UsuarioRegra> source)
        //{
        //    List<RegraView> usuarioregras = null;

        //    return usuarioregras;
        //}

    }
}
