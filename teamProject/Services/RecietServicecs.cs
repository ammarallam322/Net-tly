using teamProject.Models;
using teamProject.Repository;
using teamProject.Repository.ImodelRepository;
using teamProject.viewModel;

namespace teamProject.Services
{
    public class RecietServicecs : IRecietServicecs
    {
        private readonly IRepositoryGeneric<Client> clientRepo;
        private readonly IRepositoryGeneric<Offer> offerData;
        private readonly IRepositoryGeneric<package> packageData;
        private readonly IRepositoryGeneric<Receipt> receitRepo;

        public RecietServicecs(IRepositoryGeneric<Client> clientRepo , IRepositoryGeneric<Offer> offerData, IRepositoryGeneric<package> packageData , IRepositoryGeneric<Receipt> receitRepo)
        {
            this.clientRepo = clientRepo;
            this.offerData = offerData;
            this.packageData = packageData;
            this.receitRepo = receitRepo;
        }
        public ReceitViewModel GetRecietData(int clientId)
        {
            var clientData = clientRepo.GetById(clientId);

            // الحصول على قيمة العرض
            string OfferName = clientData.Offer.Name;
            string Offerstr = OfferName.Replace("%", "");
            int OfferValue = int.Parse(Offerstr);

            // تحقق مما إذا كانت الفاتورة موجودة بالفعل واستخدام القيم المخزنة
            int currentPaidCount = clientData.Receipt?.Paid_Count ?? clientData.Offer.offerduration;
            double currentTotalPrice = clientData.Receipt?.Total_Price ?? clientData.package.Price - (clientData.package.Price * OfferValue / 100);

            var data = new ReceitViewModel
            {
                Name = clientData.Name,
                Address = clientData.Address,
                Email = clientData.Email,
                Phone = clientData.Phone,
                Mobile = clientData.Mobile,
                SSN = clientData.SSN,
                Client_Id = clientData.Id,
                ServiceProviderName = clientData.ServiceProvider.Name,
                OfferName = offerData.GetById(clientData.Offer_Id).Name,
                offerStatus = (clientData.Offer.offerStatus).ToString(),
                PackageName = packageData.GetById(clientData.Package_Id).Name,
                Package_Price = packageData.GetById(clientData.Package_Id).Price,
                Start_Date = DateOnly.FromDateTime(clientData.Subscription),
                End_Date = DateOnly.FromDateTime(clientData.Subscription).AddMonths(offerData.GetById(clientData.Offer_Id).offerduration),
                Paid_Count = currentPaidCount,  // استخدام Paid_Count المخزن إذا كان موجوداً
                Total_Price = currentTotalPrice
            };

            // إذا لم تكن هناك فاتورة، أنشئ واحدة جديدة
            if (clientData.Receipt == null)
            {
                clientData.Receipt = new Receipt
                {
                    Client_Id = clientData.Id,
                    Total_Price = currentTotalPrice,
                    Paid_Count = currentPaidCount,  // تعيين Paid_Count
                    Start_Date = data.Start_Date,
                    End_Date = data.End_Date
                };

                clientRepo.Update(clientData);
                receitRepo.Save();
            }

            return data;
        }

        public void Paid(int clientId)
        {
            var client = clientRepo.GetById(clientId);
            if (client.Receipt.Paid_Count <= 0)
            {
                client.Receipt.Total_Price = client.package.Price;
                client.Offer.offerStatus = OfferStatus.Expired;
            } 
            else
            {
                client.Receipt.Paid_Count--;
            }
            clientRepo.Update(client);
            clientRepo.Save();

         
        }   
    }
}
