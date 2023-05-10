using CheeseBurger.Model.Entities;

namespace CheeseBurger.Repository
{
    public interface IImportOrderRepository
    {
        List<ImportOrder> GetAllImport();
    }
}
