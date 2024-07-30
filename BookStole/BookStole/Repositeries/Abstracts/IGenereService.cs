using BookStole.Models.Domain;

namespace BookStole.Repositeries.Abstracts
{
    public interface IGenereService
    {

        bool Add(Genre model);
        bool Update(Genre model);
        bool Delete(int id);
        Genre FindById(int id);
        IEnumerable<Genre> GetAll();
    }
}
