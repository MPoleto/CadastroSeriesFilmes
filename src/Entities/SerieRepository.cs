using System.Collections.Generic;

namespace Cadastro_Series.src
{
    public class SerieRepository : IRepository<Serie>
    {
        private List<Serie> series = new List<Serie>();

        public void Delete(int id)
        {
            series[id].DeletedSerie();
        }

        public Serie ReturnById(int id)
        {
            return series[id];
        }

        public void Insert(Serie production)
        {
            series.Add(production);
        }

        public int NextId()
        {
            return series.Count;
        }

        public void Update(int id, Serie production)
        {
            series[id] = production;
        }

        public List<Serie> catalog()
        {
            return series;
        }
    }
}