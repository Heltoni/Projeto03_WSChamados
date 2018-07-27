using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto03_WSChamados.Models
{
    public class ChamadosRepository
    {
        public IEnumerable<Chamado> BuscarChamados()
        {
            using (var ctx = new ChamadosContext())
            {
                return ctx.Chamados.ToList<Chamado>();
            }
        }

        public IEnumerable<Chamado> BuscarChamados(int? id)
        {
            using (var ctx = new ChamadosContext())
            {
                return ctx.Chamados.ToList<Chamado>();
            }
        }

        public bool GravarChamado(Chamado chamado)
        {
            using (var ctx = new ChamadosContext())
            {
                try
                {
                    ctx.Chamados.Add(chamado);
                    ctx.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public bool ResponderChamado(Chamado chamado)
        {
            using (var ctx = new ChamadosContext())
            {
                ctx.Entry<Chamado>(chamado).State = System.Data.Entity.EntityState.Modified;

            }
        }
    }
}