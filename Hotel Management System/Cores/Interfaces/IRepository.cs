namespace Hotel_Management_System.Cores.Interfaces
{
    public interface IRepository <T>
    {
        List<T> GetAll();
        T GetById(int id);
        void Add(T Dto);
        void Update(int id, T Dto);
        void Dalete(int id);
    }
}
