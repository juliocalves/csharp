using System;
using System.Collections.Generic;
using dioSeries.interfaces;

namespace dioSeries
{
    public class serieRepository : IRepository<series>
    {
        private List<series> ListSerie = new List<series>();
        public void Delet(int id)
        {
            ListSerie[id].Delete();
        }

        public void Insert(series entidade)
        {
            ListSerie.Add(entidade);
        }

        public List<series> ListSeries()
        {
            return ListSerie;
        }

        public int NextId()
        {
            return ListSerie.Count;
        }

        public series ReturnForId(int id)
        {
            return ListSerie[id];
        }
        

        public void Update(int id, series entidade)
        {
            ListSerie[id] = entidade;
        }
    }
}