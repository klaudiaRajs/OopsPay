using Contracts;
using Products.Repos;

namespace Products;

public class GetProductInformationFactory(GetProductDetailsRepo getProductDetailsRepo, ReturnResponseToTransactionRepo returnResponseToTransactionRepo)
{
    public bool Get(GetProductDetails request)
    {
        var productDetails = getProductDetailsRepo.Get(request);
        if( productDetails.Count == 0)
        {
            //TODO log 
            //TODO zwieksz ilosc bledów 
            return false;
        }
        
        var wasSavingSuccessful = returnResponseToTransactionRepo.Return(request, productDetails);
        if (!wasSavingSuccessful)
        {
            //TODO dodaj log 
            //TODO zwieksz ilosc bledów 
            return false;
        }

        return true;
    }
}