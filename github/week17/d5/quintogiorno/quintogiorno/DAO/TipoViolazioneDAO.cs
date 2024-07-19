using quintogiorno.Models;
using System.Collections.Generic;
using System.Linq;

namespace quintogiorno.DAO
{
   

    public class TipoViolazioneDAO
    {
        private readonly VerbaliContext _context;

        public TipoViolazioneDAO(VerbaliContext context)
        {
            _context = context;
        }

        public List<TipoViolazione> GetAll()
        {
            return _context.TipoViolaziones.ToList();
        }

        public TipoViolazione GetById(int id)
        {
            return _context.TipoViolaziones.Find(id);
        }


        public void Add(TipoViolazione tipoViolazione)
        {
            _context.TipoViolaziones.Add(tipoViolazione);
            _context.SaveChanges();
        }

        public void Update(TipoViolazione tipoViolazione)
        {
            _context.TipoViolaziones.Update(tipoViolazione);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var tipoViolazione = _context.TipoViolaziones.Find(id);
            if (tipoViolazione != null)
            {
                _context.TipoViolaziones.Remove(tipoViolazione);
                _context.SaveChanges();
            }
        }
    }

}
