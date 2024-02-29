using MyProjectTemp.App.Interfaces;

namespace MyProjectTemp.Infra.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(
            IArchDesignRepository archDesignRepository
       
        // Add more for new tables
        )
        {
            ArchDesign = archDesignRepository;
        
        // Add more for new tables
        }

        public IArchDesignRepository ArchDesign { get; }
    

        // Implement any additional IUnitOfWork methods here.
    }
}