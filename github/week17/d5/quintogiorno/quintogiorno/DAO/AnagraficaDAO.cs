
using quintogiorno.Models;

namespace quintogiorno.DAO
{
    public class AnagraficaDAO
    {
        private readonly VerbaliContext _context;

        public AnagraficaDAO(VerbaliContext context)
        {
            _context = context;
        }

        public List<Anagrafica> GetAll()
        {
            return _context.Anagraficas.ToList();
        }

        public Anagrafica GetById(int id)
        {
            return _context.Anagraficas.Find(id);
        }

        public void Add(Anagrafica anagrafica)
        {
            _context.Anagraficas.Add(anagrafica);
            _context.SaveChanges();
        }

        public void Update(Anagrafica anagrafica)
        {
            _context.Anagraficas.Update(anagrafica);
            _context.SaveChanges();
        }


        public void Delete(int id)
        {
            var anagrafica = _context.Anagraficas.Find(id);
            if (anagrafica != null)
            {
                _context.Anagraficas.Remove(anagrafica);
                _context.SaveChanges();
            }
        }
        public bool Exists(int id)
        {
            return _context.Anagraficas.Any(a => a.IDAnagrafica == id);
        }
    }
}
