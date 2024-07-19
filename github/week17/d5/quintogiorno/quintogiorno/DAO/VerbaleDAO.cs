using quintogiorno.Models;
using System.Collections.Generic;
using System.Linq;

namespace quintogiorno.DAO
{
    

    public class VerbaleDAO
    {
        private readonly VerbaliContext _context;

        public VerbaleDAO(VerbaliContext context)
        {
            _context = context;
        }

        public List<Verbale> GetAll()
        {
            return _context.Verbales.ToList();
        }

        public Verbale GetById(int id)
        {
            return _context.Verbales.Find(id);
        }

        public void Add(Verbale verbale)
        {
            _context.Verbales.Add(verbale);
            _context.SaveChanges();
        }

        public void Update(Verbale verbale)
        {
            _context.Verbales.Update(verbale);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var verbale = _context.Verbales.Find(id);
            if (verbale != null)
            {
                _context.Verbales.Remove(verbale);
                _context.SaveChanges();
            }
        }
    }

}
