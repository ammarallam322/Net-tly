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

        public RecietServicecs(IRepositoryGeneric<Client> clientRepo , IRepositoryGeneric<Offer> offerData, IRepositoryGeneric<package> packageData)
        {
            this.clientRepo = clientRepo;
            this.offerData = offerData;
            this.packageData = packageData;
        }
        public ReceitViewModel GetRecietData(int clientId)
        {
            var clientData= clientRepo.GetById(clientId);
            string OfferName = clientData.Offer.Name;
            string Offerstr = OfferName.Replace("%", "");  
            int OfferValue = int.Parse(Offerstr);  
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
                PackageName = packageData.GetById(clientData.Package_Id).Name,
                Package_Price = packageData.GetById(clientData.Package_Id).Price,
                Start_Date =DateOnly.FromDateTime( clientData.Subscription),
                End_Date = DateOnly.FromDateTime(clientData.Subscription).AddMonths(offerData.GetById(clientData.Offer_Id).offerduration),
                Paid_Count = offerData.GetById(clientData.Offer_Id).offerduration,



                Total_Price = clientData.package.Price - (clientData.package.Price * OfferValue / 100)


            };
            return data;
        }

        public void Paid(ReceitViewModel receitView)
        {
            var client = clientRepo.GetById(receitView.Client_Id);
            if (client.Receipt.Paid_Count <= 0)
            {
                client.Receipt.Total_Price = client.package.Price;

            }
            client.Receipt = new Receipt
            {

                Paid_Count = --receitView.Paid_Count,

            };
           
            
            clientRepo.Update(client);

        }   
    }
}
