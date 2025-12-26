using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace UseCases.FarmsUseCases
{
    public interface IRecordTransactionUseCase
    {
        void Execute(SupplyTransaction transaction);
    }

    public class RecordTransactionUseCase : IRecordTransactionUseCase
    {
        private readonly ISupplyRepository _supplyRepo;
        private readonly ISupplyTransactionRepository _transRepo;

        public RecordTransactionUseCase(ISupplyRepository supplyRepo, ISupplyTransactionRepository transRepo)
        {
            _supplyRepo = supplyRepo;
            _transRepo = transRepo;
        }

        public void Execute(SupplyTransaction transaction)
        {
            // 1. Lưu lại lịch sử phiếu nhập/xuất
            _transRepo.AddTransaction(transaction);

            // 2. Tự động tính toán lại kho
            var supply = _supplyRepo.GetSupplyById(transaction.SupplyId);
            if (supply != null)
            {
                if (transaction.ActionType == TransactionType.Import)
                    supply.Quantity += transaction.Quantity; // Cộng kho
                else
                    supply.Quantity -= transaction.Quantity; // Trừ kho

                _supplyRepo.UpdateSupply(supply); // Lưu số lượng mới vào DB
            }
        }
    }
}